using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Observer.Server
{

    /// <summary>
    /// 定义观察者接口
    /// </summary>
    public interface IChat : IGrainObserver
    {
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="chatMessage">消息对象</param>
        /// <returns></returns>
        Task ReceiveMessage(ChatMessage chatMessage);
    }
}
