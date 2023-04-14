namespace Woo.Observer.Server
{
    public class Chat : IChat
    {
        /// <summary>
        /// 处理消息
        /// 接受到消息处理方法
        /// 比如这里就是直接客户端打印
        /// </summary>
        /// <param name="chatMessage">消息对象</param>
        /// <returns></returns>
        public Task ReceiveMessage(ChatMessage chatMessage)
        {
            if (chatMessage.MsgType == 0)
            {
                Console.WriteLine($"[{chatMessage.Name}/t{chatMessage.SendTime}]:{chatMessage.Message}");
            }else if (chatMessage.MsgType == 1)
            {
                Console.WriteLine($"{chatMessage.Message}");
            }
            else
            {
                Console.WriteLine($"未知消息.....");
            }
           
           
             
            return Task.CompletedTask;
        }
    }
}