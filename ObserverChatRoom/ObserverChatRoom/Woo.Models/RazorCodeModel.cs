using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Models
{

    /// <summary>
    /// request 元数据
    /// </summary>
    public  class RequestMetadata
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } 
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; } 
    }

    // 方法的返回值
    public class ResponseMetadata
    {
        // 类型
        public string Type { get; set; } // 应该用什么类型???
    }
    /// <summary>
    /// 接口中每一个方法元数据
    /// </summary>

   public class CallObjectMetadata
    {
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 服务ID标识
        /// </summary>

        public ushort ServiceId { get; set; }
        /// <summary>
        /// 方法ID标识
        /// </summary>
        public ushort MethodId { get; set; }

        /// <summary>
        /// 形参描述
        /// </summary>
        public List<RequestMetadata> RequestMetadatas { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        public ResponseMetadata ResponseMetadatas { get; set; }
    }

    /// <summary>
    /// 最终传输model
    /// </summary>
    public class ConcreteModel
    {
        /// <summary>
        /// key:服务名称 最终生成作为类文件名称
        /// value:接口下的所有方法元数据
        /// 第一种类型
        /// </summary>
        public Dictionary<string, List<CallObjectMetadata>> Services { get; set; }
    }
}
