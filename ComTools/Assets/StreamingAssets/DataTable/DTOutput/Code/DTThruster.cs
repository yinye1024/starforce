//------------------------------------------------------------
// Game Framework
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2023-09-23 10:39:38.264
//------------------------------------------------------------

using LitJson;
using UnityGameFramework.Runtime;

namespace DataTable
{
    /// <summary>
    /// 推进器表。
    /// </summary>
    public class DTThruster : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取推进器编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取速度。
        /// </summary>
        public float Speed
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
            Speed = float.Parse(columnStrings[index++]);

            return true;
        }


    }
}
