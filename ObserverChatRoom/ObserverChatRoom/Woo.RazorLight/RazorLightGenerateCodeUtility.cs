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

    /// <summary>
    /// 根据razor模板生成.cs文件工具类
    /// 
    /// </summary>
    public class RazorLightGenerateCodeUtility
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

        private static string m_templateFile= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/WooDome.cshtml";
        //模板生成的dll文件路径
        private static string m_cacheDir= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/CacheFile/";
        //temp文件夹路径
        private static string m_baseDir= "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/";
        private static StrategyName m_strategyName = StrategyName.FileHash;
       // private string m_modelFilePath = "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/";
       //代码生成文件夹
        private static string CodePath = "C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/CodeFile/";

        /// <summary>
        /// 生成代码方法，提供给元数据生成方调用
        /// </summary>
        /// <param name="model">元数据model</param>
        /// <returns></returns>
        public static async Task CallGenerateCode(ConcreteModel model)
        {

            try
            {
                if (model.Services.Keys.Count() > 0)
                {
                    //多个服务可能使用同一个模板
                    m_templateFile = $"C:/WooCode/WooChatRoom/ObserverChatRoom/ObserverChatRoom/Woo.RazorTemp/Views/Services.cshtml";
                    foreach (var key in model.Services.Keys)
                    {
                        await RunCodeGeneration(model.Services[key], key);
                    }
                }



                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw new Exception($"生成异常{ex}");
            }
        }


        /// <summary>
        /// 编译.cshtml文件 生成对应的.cs文件
        /// </summary>
        /// <param name="metadatas">需要生成代码的元数据</param>
        /// <param name="csfileName">生成文件名称</param>
        /// <returns>不返回</returns>
        public static async  Task RunCodeGeneration(List<CallObjectMetadata> metadatas, string csfileName)
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
                    throw new RazorLightException($"razor 模板根目录{m_baseDir}不存在");
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
                throw new RazorLightException($"razor模板文件{m_templateFile}不存在.");
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
            var strtemp = engine.CompileRenderAsync(templateKey, metadatas).GetAwaiter().GetResult();
            await FileUtility.CreateWriteFileAsync(CodePath, $"{csfileName}.g.cs", strtemp);
            

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
