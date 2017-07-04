using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console
{
    using Factory;
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Wenli.AOP 测试";

            var readLine = string.Empty;


            var dc = Console.ForegroundColor;

            while (true)
            {

                if (string.IsNullOrEmpty(readLine))
                {
                    Console.WriteLine("Wenli.AOP 测试,输入F进入Factory，默认为Intercepting");

                    readLine = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(readLine) && readLine.ToUpper() == "F")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("当前模式为AOPFactory");
                    AOPFactory.OnMethodExecuting += AOPFactory_OnMethodExecuting;
                    AOPFactory.OnMethodExecuted += AOPFactory_OnMethodExecuted;
                    AOPFactory.Create<FTest>().Calc(111, 2222);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("当前模式为Intercepting");
                    new Test().Calc(666, 888);
                }
                Console.WriteLine("测试完成，按回车继续！");
                Console.ReadLine();

                readLine = "";
                Console.ForegroundColor = dc;
            }
        }



        private static bool AOPFactory_OnMethodExecuting(object target, string funName, object[] args)
        {
            Console.WriteLine("执行前：sender:" + target + " funName: " + funName + string.Format(" args:{0},{1}", args));
            return true;
        }

        private static void AOPFactory_OnMethodExecuted(object target, string funName, object[] args, object returnValue)
        {
            Console.WriteLine("执行后：sender:" + target + " funName:" + funName + string.Format(" args:{0},{1}", args) + " returnValue:" + returnValue);
        }
    }
}
