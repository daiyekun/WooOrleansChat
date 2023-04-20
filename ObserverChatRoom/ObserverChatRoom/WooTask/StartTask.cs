using Microsoft.Build.Utilities;
using System;
using System.Diagnostics;

namespace WooTask
{
    /// <summary>
    /// 任务
    /// </summary>
    public class StartTask: Microsoft.Build.Utilities.Task
    {
        /// <summary>
        /// 模板路径
        /// </summary>
        public string RazorTmpPath { get; set; }
        /// <summary>
        /// 代码路径
        /// </summary>
        public string CodePath { get; set; }
        /// <summary>
        /// 生成dll 路径
        /// </summary>
        public string CacheFilePath { get; set; }
        public override bool Execute()
        {
            var content = $"{DateTime.Now.ToString()}=>\t\nRazorTmpPath:=>{RazorTmpPath}=>\t\nCodePath:{CodePath}\t\nCacheFilePath:=>{CacheFilePath}";

            // Debugger.Launch();
            FileUtility.CreateWriteFileTest(@"C:\WooCode\WooChatRoom\ObserverChatRoom\ObserverChatRoom\WooTask\", "test.txt", content);
            
            Log.LogMessage("Hello Task!=================");

            return true;
        }

    }
}
