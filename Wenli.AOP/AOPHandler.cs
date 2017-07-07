/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：9dcbf82d-d00f-4bcb-ac81-5602f6d9bfb7
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Factory
 * 类名称：AOPHandler
 * 创建时间：2017/7/4 17:44:31
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP
{
    /// <summary>
    /// 方法执行前
    /// </summary>
    /// <param name="target"></param>
    /// <param name="funName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public delegate bool OnMethodExecutingHandler(object target, string funName, object[] args);

    /// <summary>
    /// 方法执行后
    /// </summary>
    /// <param name="target"></param>
    /// <param name="funName"></param>
    /// <param name="args"></param>
    /// <param name="returnValue"></param>
    public delegate void OnMethodExecutedHandler(object target, string funName, object[] args, object returnValue);
}
