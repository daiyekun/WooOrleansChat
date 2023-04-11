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
            Console.WriteLine($"[{chatMessage.Name}/t{chatMessage.SendTime}]:{chatMessage.Message}");
            return Task.CompletedTask;
        }
    }
}