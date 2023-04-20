using System.Diagnostics;
using Btask = Microsoft.Build.Utilities.Task;

namespace FirstBuildTask
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
            Debugger.Launch();
            Log.LogWarning("test message:" + this.outputFile);
            FileUtility.CreateWriteFileAsync(@"C:\WooCode\WooChatRoom\ObserverChatRoom\ObserverChatRoom\FirstBuildTask\", "woo.txt", this.outputFile);
            return true;
        }
    }
}