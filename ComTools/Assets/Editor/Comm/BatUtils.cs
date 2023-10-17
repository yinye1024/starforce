using ComTools;
using GameFramework;
using UnityEngine;

public class BatUtils
{
    
    public static void RunBat(string batFile,string workingDir)
    {
        
       
        if (!System.IO.File.Exists(batFile))
        {
            
            Debug.LogError(Utility.Text.Format("Check bat faile failure. batFile='{0}'", batFile));
        }
        else
        {
            var path = FormatPath(workingDir);
            RunBat(batFile, "", path);
        }
    }
    
    private static void RunBat(string batfile, string args, string workingDir = "")
    {
        var p = CreateShellExProcess(batfile, args, workingDir);
        p.Close();
    }

    private static string  FormatPath(string path)
    {
        path = path.Replace("/", "\\");
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            path = path.Replace("\\", "/");
        }

        return path;
    }

    private static System.Diagnostics.Process CreateShellExProcess(string cmd, string args, string workingDir = "")
    {
        var pStartInfo = new System.Diagnostics.ProcessStartInfo(cmd);
        pStartInfo.Arguments = args;
        pStartInfo.CreateNoWindow = false;
        pStartInfo.UseShellExecute = true;
        pStartInfo.RedirectStandardError = false;
        pStartInfo.RedirectStandardInput = false;
        pStartInfo.RedirectStandardOutput = false;
        if (!string.IsNullOrEmpty(workingDir))
            pStartInfo.WorkingDirectory = workingDir;
        return System.Diagnostics.Process.Start(pStartInfo);
    }


}
