using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooTask
{
    public class FileUtility
    {

        /// <summary>
        /// 写入内容到文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="filePath">路径</param>
        /// <param name="content">内容</param>
        /// <param name="overwrite">文件存在是否覆写，默认：<see>true:覆写</see>" 传入false不覆写/></param>
        /// <returns></returns>
        public static  void CreateWriteFileTest(string filePath, string fileName, string content, bool overwrite = true)
        {
           // Debugger.Launch();
            string destFilePath = Path.Combine(filePath, fileName);
             File.WriteAllText(destFilePath, content);




        }
    }
}
