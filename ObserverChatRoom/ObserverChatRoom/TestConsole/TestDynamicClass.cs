using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
  

    public class RequestMetadata : DynamicObject
    {
        /// <summary>
        /// 类型
        /// </summary>
        public decimal Type { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public decimal Name { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public decimal DefaultValue { get; set; }
    }
}
