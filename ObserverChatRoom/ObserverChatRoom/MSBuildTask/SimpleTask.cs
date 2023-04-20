using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Task = Microsoft.Build.Utilities.Task;

namespace MSBuildTask
{

    /// <summary>
    /// 直接使用Microsoft.Build.Utilities.Task
    /// ITask需要自己实现引擎
    /// </summary>
    public class SimpleTask : Task
    {
        //public IBuildEngine BuildEngine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public ITaskHost HostObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

       
        [Microsoft.Build.Framework.Required]
        public string? OutputFile
        {
            get; set;
          

        }

        public override bool Execute()
        {
            Log.LogWarning($"测试信息==={OutputFile}");
            Log.LogMessage(MessageImportance.High, "messageResource3");
            Console.WriteLine("=================================");
            return false;
        }
    }
}