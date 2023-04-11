using Microsoft.Extensions.Logging;
using Orleans.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Woo.Observer.Server
{

    public class ChatRoomGrain:Grain, IChatRoomGrain
    {
        private readonly ObserverManager<IChat> _subsManager;
        public ChatRoomGrain(ILogger<ChatRoomGrain> logger)
        {
            _subsManager =
                new ObserverManager<IChat>(
                    TimeSpan.FromMinutes(5), logger);
        }

       /// <summary>
       /// 客户端调用此进行订阅
       /// </summary>
       /// <param name="observer">订阅者</param>
       /// <returns></returns>
        public Task Subscribe(IChat observer)
        {
            _subsManager.Subscribe(observer, observer);

            return Task.CompletedTask;
        }

       /// <summary>
       /// 客户端调用此进行取消订阅
       /// </summary>
       /// <param name="observer"></param>
       /// <returns></returns>
        public Task UnSubscribe(IChat observer)
        {
            _subsManager.Unsubscribe(observer);

            return Task.CompletedTask;
        }

        public Task SendUpdateMessage(ChatMessage chatMessage)
        {
            _subsManager.Notify(s => s.ReceiveMessage(chatMessage));

            return Task.CompletedTask;
        }

    }
}
