/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：3b1a54b0-8539-4967-a631-5ffd913a5237
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.DynamicProxy
 * 类名称：DynamicProxyTest
 * 创建时间：2017/7/7 10:49:15
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console.DynamicProxy
{

    using Console = System.Console;

    static class DynamicProxyTest
    {
        static DynamicProxyTest()
        {
            Console.WriteLine("当前模式为DynamicProxy");

            Wenli.AOP.DynamicProxy.AOPProxy.OnMethodExecuting += AOPProxy_OnMethodExecuting;
            Wenli.AOP.DynamicProxy.AOPProxy.OnMethodExecuted += AOPProxy_OnMethodExecuted;
        }
        private static bool AOPProxy_OnMethodExecuting(object target, string funName, object[] args)
        {
            Console.WriteLine("执行前：sender:" + target + " funName: " + funName + string.Format(" args:{0},{1}", args));
            return true;
        }

        private static void AOPProxy_OnMethodExecuted(object target, string funName, object[] args, object returnValue)
        {
            Console.WriteLine("执行后：sender:" + target + " funName:" + funName + string.Format(" args:{0},{1}", args) + " returnValue:" + returnValue);
        }

        public static void Test()
        {
            var model = new ModelClass();

            var modelProxy = Wenli.AOP.DynamicProxy.AOPProxy.Create<IModelClass>(model);

            modelProxy.Calc(111, 11111);
        }
    }
}
