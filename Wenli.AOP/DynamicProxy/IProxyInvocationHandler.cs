/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：2f5a00ab-db32-4644-8568-92fa03b98d77
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.DynamicProxy
 * 类名称：IProxyInvocationHandler
 * 创建时间：2017/7/6 17:53:55
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wenli.AOP.DynamicProxy
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}
