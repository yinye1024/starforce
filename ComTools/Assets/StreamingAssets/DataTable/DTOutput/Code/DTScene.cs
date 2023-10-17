//------------------------------------------------------------
// Game Framework
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-09-23 10:39:38.260
//------------------------------------------------------------

using LitJson;
using UnityGameFramework.Runtime;

namespace DataTable
{
    /// <summary>
    /// 场景配置表。
    /// </summary>
    public class DTScene : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取场景编号。
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
        /// 获取背景音乐编号。
        /// </summary>
        public int BackgroundMusicId
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
            BackgroundMusicId = int.Parse(columnStrings[index++]);

            return true;
        }


    }
}
