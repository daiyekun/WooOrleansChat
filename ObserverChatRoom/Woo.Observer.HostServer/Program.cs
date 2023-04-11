using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Woo.Observer.HostServer

{
    /// <summary>
    /// 启动silo host
    /// </summary>
    public class Program
    {

        static async Task Main(string[] args)
        {
            Console.Title = "服务器启动.......";

            await Host.CreateDefaultBuilder(args)
                  .UseOrleans(siloBuilder =>
                    {

                        //配置本地集群
                        siloBuilder.UseLocalhostClustering()
                                    .Configure<ClusterOptions>(options =>
                                    {
                        options.ClusterId = "GameChat";
                        options.ServiceId = "GameChat";

                    })
                                    ;
                        //配置内存存储状态变量
                        siloBuilder.AddMemoryGrainStorage("localGameRole");



                    }).RunConsoleAsync();

                        Console.ReadLine();
                        Console.ReadKey();
                    }
    }
}