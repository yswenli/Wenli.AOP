/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：8c56d61f-7b21-4359-b5d6-f87a05c70b6f
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.Intercepting
 * 类名称：ModelClass
 * 创建时间：2017/7/7 10:45:00
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console.Intercepting
{
    using AOP.Intercepting;
    using Console = System.Console;

    [Interceptor]
    public class ModelClass : InterceptorObject
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

        [AOPMethodAttribute]
        public int Calc(int x, int y)
        {
            return x + y;
        }

    }
}
