using RazorLight;
using RazorLight.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Woo.Models;

namespace Woo.RazorLight
{
    public class RazorLightUtility
    {
        private enum StrategyName
        {
            Simple,
            FileHash
        }
        private static readonly Dictionary<StrategyName, IFileSystemCachingStrategy> s_strategyMap = new()
        {
            [StrategyName.Simple] = SimpleFileCachingStrategy.Instance,
            [StrategyName.FileHash] = FileHashCachingStrategy.Instance
        };

        private string m_templateFile= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/WooDome.cshtml";
        //模板生成的dll文件路径
        private string m_cacheDir= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/CacheFile/";
        //temp文件夹路径
        private string m_baseDir= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/";
        private StrategyName m_strategyName = StrategyName.FileHash;
       // private string m_modelFilePath = "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/";
       //代码生成文件夹
        private string CodePath = "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/CodeFile/";
        
        ///// <summary>
        ///// 生成代码方法，提供给元数据生成方调用
        ///// </summary>
        ///// <param name="model">元数据model</param>
        ///// <returns></returns>
        //public async Task CallGenerateCode(RazorDataModel model)
        //{
            
         

        //   await Task.CompletedTask;
        //}


        /// <summary>
        /// 编译.cshtml文件 生成对应的.cs文件
        /// </summary>
        /// <param name="model">需要生成代码的元数据</param>
        /// <returns>不返回</returns>
        public async  Task RunCodeGeneration(RazorDataModel model)
        {
            string templateKey;
            if (m_baseDir == null)
            {
                m_templateFile = Path.GetFullPath(m_templateFile);
                m_baseDir = Path.GetDirectoryName(m_templateFile);
                templateKey = Path.GetFileName(m_templateFile);
            }
            else
            {
                if (!Directory.Exists(m_baseDir))
                {
                    throw new RazorLightException($"The razor template base directory {m_baseDir} does not exist.");
                }
                m_baseDir = Path.GetFullPath(m_baseDir);
                if (Path.IsPathRooted(m_templateFile))
                {
                    templateKey = Path.GetRelativePath(m_baseDir, m_templateFile);
                }
                else
                {
                    templateKey = m_templateFile;
                    m_templateFile = Path.GetFullPath(Path.Combine(m_baseDir, m_templateFile));
                }
            }

            if (!File.Exists(m_templateFile))
            {
                throw new RazorLightException($"The razor template file {m_templateFile} does not exist.");
            }

            if (m_cacheDir == null)
            {
                m_cacheDir = Path.GetDirectoryName(m_templateFile);
            }
            else if (!Directory.Exists(m_cacheDir))
            {
                Directory.CreateDirectory(m_cacheDir);
            }

            var provider = new FileSystemCachingProvider(m_baseDir, m_cacheDir, s_strategyMap[m_strategyName]);
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(m_baseDir, "")
                .UseCachingProvider(provider)
                .Build();
            //var cacheResult = engine.Handler.Cache.RetrieveTemplate(templateKey);
            //dll文件生成一次，如一旦.cshtml文件有更改，代码会自动生成
            var strtemp = engine.CompileRenderAsync(templateKey, model).GetAwaiter().GetResult();
            await FileUtility.CreateWriteFileAsync(CodePath, $"{model.InterfaceName}.cs", strtemp);
            

            //if (m_modelFilePath == null)
            //{
            //    engine.CompileTemplateAsync(templateKey).GetAwaiter().GetResult();
            //    var strpath = provider.GetAssemblyFilePath(templateKey, m_templateFile);
            //    //Console.WriteLine(strpath);
            //}
            //else
            //{

            //    var strtemp = engine.CompileRenderAsync(templateKey, model).GetAwaiter().GetResult();
            //    await FileUtility.CreateWriteFileAsync(CodePath, $"{model.InterfaceName}.cs", strtemp);

            //}


        }
    }
}
