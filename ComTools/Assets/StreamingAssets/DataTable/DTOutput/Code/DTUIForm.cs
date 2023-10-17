//------------------------------------------------------------
// Game Framework
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-09-23 10:39:38.267
//------------------------------------------------------------

using LitJson;
using UnityGameFramework.Runtime;

namespace DataTable
{
    /// <summary>
    /// 界面配置表。
    /// </summary>
    public class DTUIForm : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取界面编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string AssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面组名称。
        /// </summary>
        public string UIGroupName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取是否允许多个界面实例。
        /// </summary>
        public bool AllowMultiInstance
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取是否暂停被其覆盖的界面。
        /// </summary>
        public bool PauseCoveredUIForm
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            JsonData line = JsonMapper.ToObject(dataRowString);
            string[] columnStrings = new string[line.Count];
            for (int j = 0; j < line.Count; j++) 
            {
                string tmp = (string)line[j];
                columnStrings[j] = tmp.Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            AssetName = columnStrings[index++];
            UIGroupName = columnStrings[index++];
            AllowMultiInstance = bool.Parse(columnStrings[index++]);
            PauseCoveredUIForm = bool.Parse(columnStrings[index++]);

            return true;
        }


    }
}
