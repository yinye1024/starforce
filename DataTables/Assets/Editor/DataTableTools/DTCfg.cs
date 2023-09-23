
using System.IO;
using GameFramework;


namespace DataTableTools
{
    public static class DTCfg
    {
        public const string ExcelPath = "Assets/StreamingAssets/DataTable/DTInput/Excel";
        
        public const string TxtOutPath = "Assets/StreamingAssets/DataTable/DTOutput/Txt";
        
        public const string JsonOutPath = "Assets/StreamingAssets/DataTable/DTOutput/Json";

        private const string CodeOutPath = "Assets/StreamingAssets/DataTable/DTOutput/Code";
        
        public const string CodeNameSpace = "DataTable";
        public const string CodeNamePrefix= "DT";

        public const string CSharpCodeTemplateFilePath = "Assets/Editor/DataTableTools/Configs/DataTableCodeTemplate.txt";

        public static string BuildExcelFilePath(string fileName)
        {
            string filePath = Path.Combine(ExcelPath, fileName + ".xlsx");
            return filePath;
        }
        
        public static string BuildTxtOutFilePath(string fileName)
        {
            string filePath = Path.Combine(TxtOutPath, fileName + ".txt");
            return Utility.Path.GetRegularPath(filePath);
        }
        
        public static string BuildJsonOutFilePath(string fileName)
        {
            string filePath = Path.Combine(JsonOutPath, fileName + ".txt");
            return Utility.Path.GetRegularPath(filePath);
        }
        public static string BuildTxtOutByteFilePath(string fileName)
        {
            string filePath = Path.Combine(DTCfg.TxtOutPath, fileName + ".bytes");
            return filePath;
        }
        public static string BuildCodeOutFilePath(string fileName)
        {
            string filePath = Path.Combine(CodeOutPath, "DT" + fileName + ".cs");
            return Utility.Path.GetRegularPath(filePath);
        }
        
    }
}
