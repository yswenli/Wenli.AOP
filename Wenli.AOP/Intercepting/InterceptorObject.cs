/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：20b407cf-43e7-486c-ae73-d892ef93501f
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Intercepting
 * 类名称：InterceptorObject
 * 创建时间：2017/7/4 17:46:26
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Intercepting
{
    /// <summary>
    /// 拦截器实例基类
    /// </summary>
    public abstract class InterceptorObject : ContextBoundObject
    {
        /// <summary>
        /// 将要执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="funName"></param>
        /// <param name="args"></param>
        /// <returns>返回true继续，false将跳过后续方法</returns>
        public abstract bool MethodExecuting(object sender, string funName, object[] args);

        /// <summary>
        /// 已执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="funName"></param>
        /// <param name="args"></param>
        /// <param name="returnValue"></param>
        public abstract void MethodExecuted(object sender, string funName, object[] args, object returnValue);

    }
}
