/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：e625747a-c912-468a-a0fc-252188b8eaf3
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.Simple
 * 类名称：SimpleTest
 * 创建时间：2017/7/7 10:42:08
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wenli.AOP.Simple;

namespace Wenli.AOP.Console.Simple
{
    using Console = System.Console;

    public static class SimpleTest
    {
        static SimpleTest()
        {
            Console.WriteLine("当前模式为Simple");

            AOPFactory.OnMethodExecuting += AOPFactory_OnMethodExecuting;
            AOPFactory.OnMethodExecuted += AOPFactory_OnMethodExecuted;
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

        public static void Test()
        {
            var model= AOPFactory.Create<ModelClass>();

            model.Calc(111, 2222);
        }


       
    }
}
