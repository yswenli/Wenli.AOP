using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console
{
    using DynamicProxy;
    using Intercepting;
    using Simple;
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Wenli.AOP 测试";

            Console.WriteLine("Wenli.AOP 测试");

            var readLine = string.Empty;


            var dc = Console.ForegroundColor;

            while (true)
            {
                if (string.IsNullOrEmpty(readLine))
                {
                    

                    Console.WriteLine("输入1进入 Simple，输入2进入 Intercepting ，输入3进入 DynamicProxy");

                    readLine = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(readLine))
                {

                    switch (readLine)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            SimpleTest.Test();

                            break;

                        case "2":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            InterceptingTest.Test();

                            break;

                        case "3":
                            Console.ForegroundColor = ConsoleColor.Green;
                            DynamicProxyTest.Test();

                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Green;
                            DynamicProxyTest.Test();

                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    DynamicProxyTest.Test();
                }
                readLine = "";
                Console.ForegroundColor = dc;
            }
        }

    }
}
