﻿using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcDemo.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serverAddress = "localhost:50051";
            //创建连接通道，端口80
            var channel = new Channel(serverAddress, ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);

            //请求
            var reply1 = await client.SayHelloAsync(
                new HelloRequest { Name = "wu", LanguageEnum = HelloRequest.Types.Language.EnUs });
            Console.WriteLine($"{reply1.Message} Num:{reply1.Num}");
            var reply2 = await client.SayHelloAsync(
                new HelloRequest { Name = "wu", LanguageEnum = HelloRequest.Types.Language.ZhCn });
            Console.WriteLine($"{reply2.Message} Num:{reply2.Num}");

            //使用完后应释放资源
            await channel.ShutdownAsync();
            Console.WriteLine("已断开连接");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
