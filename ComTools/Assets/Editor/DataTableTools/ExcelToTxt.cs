using System.IO;
using System.Text;
using GameFramework;
using NPOI.SS.UserModel;
using UnityEditor;
using UnityEngine;

namespace ComTools
{
    public static class ExcelToTxt
    {
        public static void ExportTxt(string fileName)
        {
            string filePath = DTCfg.BuildExcelFilePath(fileName);
            string savePath = DTCfg.BuildTxtOutFilePath(fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //npoi读取并解析excel的sheet数据
                var workbook = WorkbookFactory.Create(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                //遍历sheet数据，转换成项目需要的txt格式
                var txt = ReadDataTable2Txt(sheet);
                //写入到工程目录
                File.WriteAllText(savePath, txt);
            }
            AssetDatabase.Refresh();
            Debug.Log(Utility.Text.Format("Generate txt file '{0}' success.", savePath));
        }
//第一行为表头，第二行为字段名 第三行为类型
        private static string ReadDataTable2Txt(ISheet sheet)
        {
            // 获取表格有多少列 
            int columns = sheet.GetRow(3).LastCellNum;
            // 获取表格有多少行 
            int rows = sheet.LastRowNum + 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("#"); //读取TableName
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(0)?.GetCell(j);
                if (cell != null)
                {
                    sb.Append("\t" + cell);
                }
                else
                {
                    sb.Append("\t");
                }
            }

            sb.Append("\r\n#"); //读取FiledName
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(1)?.GetCell(j);
                if (cell != null)
                {
                    sb.Append("\t" + cell);
                }
                else
                {
                    sb.Append("\t");
                }
            }

            sb.Append("\r\n#"); //读取FiledType
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(2)?.GetCell(j);
                if (cell != null)
                {
                    sb.Append("\t" + cell);
                }
                else
                {
                    sb.Append("\t");
                }
            }

            sb.Append("\r\n#"); //读取FiledDesc
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(3)?.GetCell(j);
                if (cell != null)
                {
                    var desc = cell.ToString();
                    sb.Append("\t" + desc);
                }
                else
                {
                    sb.Append("\t");
                }
            }

            //读取第4行后的表数据
            sb.Append("\r\n");
            for (int i = 4; i < rows; i++)
            {
                var first = sheet.GetRow(i)?.GetCell(0);
                if (first == null) continue;
                
                for (int j = 0; j < columns; j++)
                {
                    sb.Append("\t");
                    var cell = sheet.GetRow(i)?.GetCell(j);
                    if (cell != null)
                    {
                        sb.Append(cell);
                    }
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
    
        public static string FormatDesc(string desc)
        {
            // 去除空白字符
            // desc = desc.Trim();

            // // 如果内容是数字，则进行数字格式化
            // if (double.TryParse(desc, out double numberValue))
            // {
            //     // 保留两位小数
            //     return numberValue.ToString("F2");
            // }
            //
            // // 如果内容是日期，则进行日期格式化
            // if (DateTime.TryParse(desc, out DateTime dateValue))
            // {
            //     // yyyy-MM-dd格式
            //     return dateValue.ToString("yyyy-MM-dd");
            // }
            // 如果内容是文本，则将其转为小写
            return desc.ToLower();
        }
    
    }
}