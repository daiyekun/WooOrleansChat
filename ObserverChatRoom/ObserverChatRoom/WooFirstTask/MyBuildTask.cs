using System;
using System.Diagnostics;
using Btask = Microsoft.Build.Utilities.Task;

namespace WooFirstTask
{
    public class MyBuildTask : Btask
    {
        private string outputFile;

        [Microsoft.Build.Framework.Required]
        public string OutputFile
        {
            get { return outputFile; }
            set { outputFile = value; }
        }

        public override bool Execute()
        {
           // Debugger.Launch();
            //Log.LogWarning($"test message123{DateTime.Now}:" + outputFile);
            outputFile = $"{DateTime.Now}==>{outputFile}";
            FileUtility.CreateWriteFileTest(@"C:\WooCode\WooChatRoom\ObserverChatRoom\ObserverChatRoom\WooFirstTask\", "woo.txt", outputFile);
            return true;
        }
    }
}