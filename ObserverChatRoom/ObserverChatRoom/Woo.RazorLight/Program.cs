using Microsoft.CodeAnalysis;
using System.Reflection;
using Woo.Models;

namespace Woo.RazorLight
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("开始生成代码测试==================begin");
            //RazorLightUtility lightUtility = new RazorLightUtility();

            //var model = new RazorDataModel {
            //    InterfaceName = "LoginOrRegister"
            //};
            //await lightUtility.RunCodeGeneration(model);
            var model = CreateMateData();
            await RazorLightGenerateCodeUtility.CallGenerateCode(model);

            Console.WriteLine("开始生成代码测试==================end");
            Console.ReadKey();
        }


        private static ConcreteModel CreateMateData()
        {
            ConcreteModel model = new ConcreteModel();
            Dictionary<string, List<CallObjectMetadata>> services = new Dictionary<string, List<CallObjectMetadata>>();
            List<CallObjectMetadata> listmates = new List<CallObjectMetadata>() {
              //第一个
              new CallObjectMetadata
              {
                  MethodName="LoginOrRegister",
                  ServiceId=1,
                  MethodId=1,
                  RequestMetadatas=new List<RequestMetadata>{
                   new RequestMetadata{
                    Type="string",
                    Name="token",
                    DefaultValue="string.Empty",//是不是可以不需要给定默认值，或者生成就是defalut

                     }

                    },
                  ResponseMetadatas=new ResponseMetadata{
                      Type="List<GameCharacterInfo>",

                   }

               },
                //第二个
               new CallObjectMetadata
              {
                  MethodName="LoginOut",
                  ServiceId=1,
                  MethodId=2,
                  RequestMetadatas=new List<RequestMetadata>{
                   new RequestMetadata{
                    Type="string",
                    Name="token",
                    DefaultValue="string.Empty",//是不是可以不需要给定默认值，或者生成就是defalut

                     }

                    },
                  ResponseMetadatas=new ResponseMetadata{
                      Type="bool",

                   }

               }


            };
            services.Add("LoginService", listmates);
            model.Services = services;
            return model;
        }
    }
}