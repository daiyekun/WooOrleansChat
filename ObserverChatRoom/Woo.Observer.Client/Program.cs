using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using Orleans.Serialization.WireProtocol;
using Woo.Observer.Server;

namespace Woo.Observer.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
             .UseOrleansClient(client =>
             {
                 client.UseLocalhostClustering().Configure<ClusterOptions>(options =>
                 {
                     options.ClusterId = "GameChat";
                     options.ServiceId = "GameChat";
                 });
             })
             .UseConsoleLifetime()
             .Build();
            await host.StartAsync();
            Console.WriteLine("orleans ====客户端---启动====");
            IClusterClient client = host.Services.GetRequiredService<IClusterClient>();
            try
            {
                while (true)
                {
                    //首先创建Grain引用
                    //var friend = client.GetGrain<IGameRole>("A");
                    //Chat c = new Chat();
                    //创建可用于订阅observable grain的引用。
                    //var obj = await client.CreateObjectReference<IChat>(c);
                    //订阅该实例以接收消息。
                    //await friend.Subscribe(obj);
                    Console.WriteLine("""
                    /j> 房间号
                    /s>发送消息
                    请输入：

                    """);
                    Console.WriteLine("=================================");
                    string? readline = Console.ReadLine();
                    ReadLine(client, readline);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
;

            Console.WriteLine("等待");
            Console.ReadKey();
        }

        private static void ReadLine(IClusterClient client,string readstr)
        {
           var temarrstr= readstr.Split('>');
            Console.WriteLine($"长度：{temarrstr.Length}");
            if (temarrstr.Length is not (2 or 3))
            {
                Console.WriteLine("格式输入错误，输入格式如下：");
                Console.WriteLine("""
                    /j> 房间号
                    /s>发送消息

                    """);
                return;
            }
            switch (temarrstr[0])
            {
                case "/j"://加入房间
                          //创建一个grain引用 
                    var roomgrain1 = client.GetGrain<IChatRoomGrain>(temarrstr[1]);
                    Chat c = new Chat();
                    //为chat创建一个引用，用来订阅grain
                    var obj = client.CreateObjectReference<IChat>(c);
                    //订阅该实例以接收消息。
                     roomgrain1.Subscribe(obj);
                    Console.WriteLine($"{temarrstr[1]}:{DateTime.Now}加入。。。。");
                    break;
                case "/s"://发送消息
                    var graind1 = client.GetGrain<IChatRoomGrain>(temarrstr[1]);
                    var msg = new ChatMessage {
                        Name = temarrstr[1],
                        SendTime=DateTime.Now,
                        Message= temarrstr[2]
                    
                    };
                    graind1.SendUpdateMessage(msg);
                    break;
                default: Console.WriteLine("未知命令.....");
                    break;

            }

        }
    }
}