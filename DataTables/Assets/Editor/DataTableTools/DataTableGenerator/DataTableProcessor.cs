//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;


namespace DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private const string CommentLineSeparator = "#";
        private static readonly char[] DataSplitSeparators = new char[] { '\t' };
        private static readonly char[] DataTrimSeparators = new char[] { '\"' };

        private readonly string[] m_NameRow;
        private readonly string[] m_TypeRow;
        private readonly string[] m_CommentRow;
        private readonly int m_IdColumn;

        private readonly DataProcessor[] m_DataProcessor;
        private readonly string[][] m_RawValues;

        private string m_CodeTemplate;
        private DataTableCodeGenerator m_CodeGenerator;


        private string[][] ReadFromJson(string dataTableFileName,Encoding encoding)
        {
            string json = File.ReadAllText(dataTableFileName, encoding);
            var lines = JsonConvert.DeserializeObject<string[][]>(json);
            if (lines == null)
            {
                throw new GameFrameworkException(Utility.Text.Format("Table name '{0}' is invalid.",
                    dataTableFileName));
            }

            return lines;
        }
        private string[][] ReadFromTxt(string dataTableFileName,Encoding encoding)
        {
            string[] lines = File.ReadAllLines(dataTableFileName, encoding);
            int rawColumnCount = 0;
            List<string[]> rawValues = new List<string[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] rawValue = lines[i].Split(DataSplitSeparators);
                for (int j = 0; j < rawValue.Length; j++)
                {
                    rawValue[j] = rawValue[j].Trim(DataTrimSeparators);
                }
            
                if (i == 0)
                {
                    rawColumnCount = rawValue.Length;
                }
                else if (rawValue.Length != rawColumnCount)
                {
                    throw new GameFrameworkException(Utility.Text.Format("Data table file '{0}', raw Column is '{2}', but line '{1}' column is '{3}'.", dataTableFileName, i, rawColumnCount, rawValue.Length));
                }
            
                rawValues.Add(rawValue);
            }
            var linesTmp = rawValues.ToArray();
            return linesTmp;
        }


        public DataTableProcessor(string dataTableFileName, Encoding encoding,bool isReadFromJson, int nameRow, int typeRow, int? defaultValueRow, int? commentRow, int contentStartRow, int idColumn)
        {
            if (string.IsNullOrEmpty(dataTableFileName))
            {
                throw new GameFrameworkException("Data table file name is invalid.");
            }

            if (!dataTableFileName.EndsWith(".txt", StringComparison.Ordinal))
            {
                throw new GameFrameworkException(Utility.Text.Format("Data table file '{0}' is not a txt.", dataTableFileName));
            }

            if (!File.Exists(dataTableFileName))
            {
                throw new GameFrameworkException(Utility.Text.Format("Data table file '{0}' is not exist.", dataTableFileName));
            }


            m_RawValues = isReadFromJson ? ReadFromJson(dataTableFileName, encoding) : ReadFromTxt(dataTableFileName, encoding);

            int rawRowCount = m_RawValues.Length;
            int rawColumnCount = m_RawValues[0].Length;
            

            if (nameRow < 0)
            {
                throw new GameFrameworkException(Utility.Text.Format("Name row '{0}' is invalid.", nameRow));
            }

            if (typeRow < 0)
            {
                throw new GameFrameworkException(Utility.Text.Format("Type row '{0}' is invalid.", typeRow));
            }

            if (contentStartRow < 0)
            {
                throw new GameFrameworkException(Utility.Text.Format("Content start row '{0}' is invalid.", contentStartRow));
            }

            if (idColumn < 0)
            {
                throw new GameFrameworkException(Utility.Text.Format("Id column '{0}' is invalid.", idColumn));
            }

            if (nameRow >= rawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Name row '{0}' >= raw row count '{1}' is not allow.", nameRow, rawRowCount));
            }

            if (typeRow >= rawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Type row '{0}' >= raw row count '{1}' is not allow.", typeRow, rawRowCount));
            }

            if (defaultValueRow.HasValue && defaultValueRow.Value >= rawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Default value row '{0}' >= raw row count '{1}' is not allow.", defaultValueRow.Value, rawRowCount));
            }

            if (commentRow.HasValue && commentRow.Value >= rawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Comment row '{0}' >= raw row count '{1}' is not allow.", commentRow.Value, rawRowCount));
            }

            if (contentStartRow > rawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Content start row '{0}' > raw row count '{1}' is not allow.", contentStartRow, rawRowCount));
            }

            if (idColumn >= rawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Id column '{0}' >= raw column count '{1}' is not allow.", idColumn, rawColumnCount));
            }

            m_NameRow = m_RawValues[nameRow];
            m_TypeRow = m_RawValues[typeRow];
            m_CommentRow = commentRow.HasValue ? m_RawValues[commentRow.Value] : null;
            m_IdColumn = idColumn;

            m_DataProcessor = new DataProcessor[rawColumnCount];
            for (int i = 0; i < rawColumnCount; i++)
            {
                if (i == IdColumn)
                {
                    m_DataProcessor[i] = DataProcessorUtility.GetDataProcessor("id");
                }
                else
                {
                    m_DataProcessor[i] = DataProcessorUtility.GetDataProcessor(m_TypeRow[i]);
                }
            }

            Dictionary<string, int> strings = new Dictionary<string, int>(StringComparer.Ordinal);
            for (int i = contentStartRow; i < rawRowCount; i++)
            {
                if (IsCommentRow(i))
                {
                    continue;
                }

                for (int j = 0; j < rawColumnCount; j++)
                {
                    if (m_DataProcessor[j].LanguageKeyword != "string")
                    {
                        continue;
                    }

                    string str = m_RawValues[i][j];
                    if (strings.ContainsKey(str))
                    {
                        strings[str]++;
                    }
                    else
                    {
                        strings[str] = 1;
                    }
                }
            }

            m_CodeTemplate = null;
            m_CodeGenerator = null;
        }

        public int RawRowCount
        {
            get
            {
                return m_RawValues.Length;
            }
        }

        public int RawColumnCount
        {
            get
            {
                return m_RawValues.Length > 0 ? m_RawValues[0].Length : 0;
            }
        }

        public int IdColumn
        {
            get
            {
                return m_IdColumn;
            }
        }

        public bool IsIdColumn(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_DataProcessor[rawColumn].IsId;
        }

        public bool IsCommentRow(int rawRow)
        {
            if (rawRow < 0 || rawRow >= RawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw row '{0}' is out of range.", rawRow));
            }

            return GetValue(rawRow, 0).StartsWith(CommentLineSeparator, StringComparison.Ordinal);
        }

        public bool IsCommentColumn(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return string.IsNullOrEmpty(GetName(rawColumn)) || m_DataProcessor[rawColumn].IsComment;
        }

        public string GetName(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            if (IsIdColumn(rawColumn))
            {
                return "Id";
            }

            return m_NameRow[rawColumn];
        }

        public bool IsSystem(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_DataProcessor[rawColumn].IsSystem;
        }

        public System.Type GetType(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_DataProcessor[rawColumn].Type;
        }

        public string GetLanguageKeyword(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_DataProcessor[rawColumn].LanguageKeyword;
        }

        public string GetComment(int rawColumn)
        {
            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_CommentRow != null ? m_CommentRow[rawColumn] : null;
        }

        public string GetValue(int rawRow, int rawColumn)
        {
            if (rawRow < 0 || rawRow >= RawRowCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw row '{0}' is out of range.", rawRow));
            }

            if (rawColumn < 0 || rawColumn >= RawColumnCount)
            {
                throw new GameFrameworkException(Utility.Text.Format("Raw column '{0}' is out of range.", rawColumn));
            }

            return m_RawValues[rawRow][rawColumn];
        }

        public bool SetCodeTemplate(string codeTemplateFileName, Encoding encoding)
        {
            try
            {
                m_CodeTemplate = File.ReadAllText(codeTemplateFileName, encoding);
                Debug.Log(Utility.Text.Format("Set code template '{0}' success.", codeTemplateFileName));
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError(Utility.Text.Format("Set code template '{0}' failure, exception is '{1}'.", codeTemplateFileName, exception));
                return false;
            }
        }

        public void SetCodeGenerator(DataTableCodeGenerator codeGenerator)
        {
            m_CodeGenerator = codeGenerator;
        }

        public bool GenerateCodeFile(string outputFileName, Encoding encoding, object userData = null)
        {
            if (string.IsNullOrEmpty(m_CodeTemplate))
            {
                throw new GameFrameworkException("You must set code template first.");
            }

            if (string.IsNullOrEmpty(outputFileName))
            {
                throw new GameFrameworkException("Output file name is invalid.");
            }

            try
            {
                StringBuilder stringBuilder = new StringBuilder(m_CodeTemplate);
                if (m_CodeGenerator != null)
                {
                    m_CodeGenerator(this, stringBuilder, userData);
                }

                using (FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter stream = new StreamWriter(fileStream, encoding))
                    {
                        stream.Write(stringBuilder.ToString());
                    }
                }

                Debug.Log(Utility.Text.Format("Generate code file '{0}' success.", outputFileName));
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError(Utility.Text.Format("Generate code file '{0}' failure, exception is '{1}'.", outputFileName, exception));
                return false;
            }
        }
    }
}
