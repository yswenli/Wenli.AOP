/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：211e30bc-0c25-425f-b8e2-1a4959385786
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Factory
 * 类名称：AOPProxy
 * 创建时间：2017/7/4 17:44:48
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;

namespace Wenli.AOP.Simple
{
    /// <summary>
    /// AOP的代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class AOPProxy<T> : RealProxy
    {
        private T _target;

        /// <summary>
        /// AOP的代理
        /// </summary>
        /// <param name="target"></param>
        public AOPProxy(T target)
            : base(typeof(T))
        {
            this._target = target;
        }

        #region event
        /// <summary>
        /// 方法执行前
        /// </summary>
        public event OnMethodExecutingHandler OnMethodExecuting;

        /// <summary>
        /// 方法执行后
        /// </summary>
        public event OnMethodExecutedHandler OnMethodExecuted;

        #endregion

        /// <summary>
        /// 代理执行
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage callmessage = (IMethodCallMessage)msg;

            //方法开始  
            Prev(callmessage);

            //调用真实方法  
            object returnValue = callmessage.MethodBase.Invoke(this._target, callmessage.Args);

            //方法调用完成  
            Next(callmessage, returnValue);

            ReturnMessage message = new ReturnMessage(returnValue, new object[0], 0, null, callmessage);

            return message;
        }

        bool Prev(IMethodCallMessage msg)
        {
            var result = this.OnMethodExecuting?.Invoke(this._target, msg.MethodName.ToString(), msg.Args);
            if (result.HasValue && result.Value)
            {
                return true;
            }
            return false;

        }

        void Next(IMethodCallMessage msg, object returnObj)
        {
            this.OnMethodExecuted?.Invoke(this._target, msg.MethodName.ToString(), msg.Args, returnObj);
        }


    }
}
