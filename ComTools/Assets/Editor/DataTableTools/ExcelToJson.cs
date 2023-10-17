using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using UnityEditor;
using LitJson;
using JsonWriter = LitJson.JsonWriter;

namespace ComTools
{
    public class ExcelToJson
    {

        public static void ExportTxt(string fileName)
        {
            string filePath = DTCfg.BuildExcelFilePath(fileName);
            string savePath = DTCfg.BuildJsonOutFilePath(fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //npoi读取并解析excel的sheet数据
                var workbook = WorkbookFactory.Create(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                //遍历sheet数据，转换成json格式的文本
                var txt = ReadDataTable2Json(sheet);
                //写入到工程目录
                File.WriteAllText(savePath, txt,Encoding.UTF8);
            }
            AssetDatabase.Refresh();
        }

        // static string ReadDataTable2Json(ISheet sheet)
        // {
        //     // 获取表格有多少列 
        //     int columns = sheet.GetRow(3).LastCellNum;
        //     // 获取表格有多少行 
        //     int rows = sheet.LastRowNum + 1;
        //
        //     JArray array = new JArray();
        //     for (int i = 0; i < rows; i++)
        //     {
        //         var first = sheet.GetRow(i)?.GetCell(0);
        //         if (first != null)
        //         {
        //             JArray line = new JArray();
        //             for (int j = 0; j < columns; j++)
        //             {
        //                 var fieldType = sheet.GetRow(3).GetCell(j);
        //                 var cell = sheet.GetRow(i)?.GetCell(j);
        //                 var value = cell?.ToString();
        //                 line.Add(value);
        //             }
        //             array.Add(line);
        //         }
        //     }
        //     return array.ToString(Formatting.Indented);
        // }


        private static string ReadDataTable2Json(ISheet sheet)
        {
            // 获取表格有多少列
            int columns = sheet.GetRow(3).LastCellNum;
            // 获取表格有多少行
            int rows = sheet.LastRowNum + 1;

            JsonData array = new JsonData();
            for (int i = 0; i < rows; i++)
            {
                var first = sheet.GetRow(i)?.GetCell(0);
                if (first != null)
                {
                    JsonData line = new JsonData();
                    for (int j = 0; j < columns; j++)
                    {
                        // var fieldType = sheet.GetRow(3).GetCell(j);
                        var cell = sheet.GetRow(i)?.GetCell(j);
                        var value = cell?.ToString();
                        line.Add(value);
                    }
                    array.Add(line);
                }
            }

            // // 在使用JsonMapper.ToJson()方法生成JSON字符串时，中文字符可能会被转换为Unicode转义序列，如\u4e00。这实际上并不是乱码，而是Unicode的另一种表示方式。
            // // 大多数JSON解析器都能正确处理这些转义序列。
            // string jsonStr = JsonMapper.ToJson(array);
            // // 把Unicode转义序列转回来
            // jsonStr = System.Text.RegularExpressions.Regex.Unescape(jsonStr);
            
            
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n");
            foreach (var item in array)
            {
                sb.Append("  ");
                string itemStr = JsonMapper.ToJson(item);
                itemStr = System.Text.RegularExpressions.Regex.Unescape(itemStr);
                sb.Append(itemStr);
                sb.Append(",\n");
            }
            if (array.Count > 0)
            {
                sb.Remove(sb.Length - 2, 2);  // 删除最后一个逗号
            }
            sb.Append("\n]");
            string formattedJsonStr = sb.ToString();
            return formattedJsonStr;
        }

    
    }
}