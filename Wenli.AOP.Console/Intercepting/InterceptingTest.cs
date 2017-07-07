/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：b5638b92-032d-453e-83d0-d429ad8afcf9
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.Intercepting
 * 类名称：InterceptingTest
 * 创建时间：2017/7/7 10:45:48
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console.Intercepting
{

    using Console = System.Console;

    public static class InterceptingTest
    {

        static InterceptingTest()
        {
            Console.WriteLine("当前模式为Intercepting");
        }

        public static void Test()
        {
            var model = new ModelClass();

            model.Calc(222, 2222);
        }
    }
}
