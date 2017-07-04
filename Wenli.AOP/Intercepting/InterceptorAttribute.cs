/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：fa251345-fa47-441b-81ee-254970d28f98
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Intercepting
 * 类名称：InterceptorAttribute
 * 创建时间：2017/7/4 17:45:37
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Wenli.AOP.Intercepting
{
    /// <summary>
    /// 拦截器特性
    /// 要实施拦截的类标签
    /// 使用此标签的类需要继承InterceptorObject
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class InterceptorAttribute : ContextAttribute, IContributeObjectSink
    {
        /// <summary>
        /// 拦截器特性
        /// </summary>
        public InterceptorAttribute()
            : base("InterceptorAttribute")
        {

        }

        /// <summary>
        /// 实现IContributeObjectSink接口当中的消息接收器接口
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            var o = (InterceptorObject)obj;
            return new MessageSink(o, next);
        }
    }
}
