/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：5b3c7648-aec0-4065-92e6-74e36f57d874
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console
 * 类名称：Test
 * 创建时间：2017/7/4 17:48:06
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wenli.AOP.Intercepting;

namespace Wenli.AOP.Console
{
    using Console = System.Console;

    [Interceptor]
    public class Test : InterceptorObject
    {
        public override bool MethodExecuting(object sender, string funName, object[] args)
        {
            Console.WriteLine("执行前：sender:" + sender + " funName: " + funName + string.Format(" args:{0},{1}", args));
            return true;
        }

        public override void MethodExecuted(object sender, string funName, object[] args, object returnValue)
        {
            Console.WriteLine("执行后：sender:" + sender + " funName:" + funName + string.Format(" args:{0},{1}", args) + " returnValue:" + returnValue);
        }

        [InterceptorMethod]
        public int Calc(int x, int y)
        {
            return x + y;
        }

    }
}
