/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：186c1aa9-1539-4a72-80c3-b2ecd34f4167
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.DynamicProxy
 * 类名称：ModelClass
 * 创建时间：2017/7/7 10:48:09
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console.DynamicProxy
{
    public class ModelClass : IModelClass
    {
        public int Calc(int x, int y)
        {
            return x + y;
        }
    }
}
