using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Observer.Server
{

    /// <summary>
    /// 聊天
    /// </summary>
    public interface IChatRoomGrain:IGrainWithStringKey
    {

        /// <summary>
        /// 订阅接口
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        Task Subscribe(IChat observer);
        /// <summary>
        /// 取消订阅接口
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        Task UnSubscribe(IChat observer);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns></returns>
        Task SendUpdateMessage(ChatMessage chatMessage);
    }
}
