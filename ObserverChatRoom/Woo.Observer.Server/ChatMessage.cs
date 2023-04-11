using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Observer.Server
{

    /// <summary>
    /// 消息对象
    /// </summary>
    [GenerateSerializer]
    public class ChatMessage
    {
        /// <summary>
        /// 发送名称
        /// </summary>
        [Id(0)]
        public string Name { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [Id(1)]
        public string Message { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        [Id(2)]
        public DateTime SendTime { get; set; }
    }
}
