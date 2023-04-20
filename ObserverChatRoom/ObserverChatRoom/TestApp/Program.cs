using System.Text;

namespace TestApp
{

    /// <summary>
    /// 模拟生成代码的控制台.exe程序
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine($"测试cmd:{args[0]}");
          
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"time:{DateTime.Now}\t\t参数\n");
            foreach ( string item in args )
            {
                stringBuilder.Append($"{item}\n");

            }
            FileUtility.CreateWriteFileTest(@"C:\\WooCode\\WooChatRoom\\ObserverChatRoom\\ObserverChatRoom\\TestApp","wootest.txt", $"参数:{stringBuilder.ToString()}");
        }
    }
}