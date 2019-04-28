using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcDemo.Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var greeting = string.Empty;
            switch (request.LanguageEnum)
            {
                case HelloRequest.Types.Language.EnUs:
                    greeting = "Hello";
                    break;
                case HelloRequest.Types.Language.ZhCn:
                    greeting = "ÄãºÃ";
                    break;
            }

            return Task.FromResult(new HelloReply
            {
                Message = $"{greeting} {request.Name}",
                Num = new Random().Next()
            });
        }
    }
}
