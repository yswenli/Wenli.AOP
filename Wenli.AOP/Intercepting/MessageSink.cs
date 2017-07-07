/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：2d01789a-bb1c-40b2-a647-ff88d412d924
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Intercepting
 * 类名称：MessageSink
 * 创建时间：2017/7/4 17:46:47
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Wenli.AOP.Intercepting
{
    /// <summary>
    /// 拦截消息处理
    /// </summary>
    public sealed class MessageSink : IMessageSink
    {


        //下一个接收器
        private IMessageSink _nextSink;
        /// <summary>
        /// 下一个接收器
        /// </summary>
        public IMessageSink NextSink
        {
            get
            {
                return _nextSink;
            }
        }

        private InterceptorObject _interceptorObject;



        /// <summary>
        /// 拦截消息处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nextSink"></param>
        public MessageSink(InterceptorObject sender, IMessageSink nextSink)
        {
            this._interceptorObject = sender;
            this._nextSink = nextSink;
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;

            //方法调用消息接口
            IMethodCallMessage call = msg as IMethodCallMessage;

            //InterceptorMethodAttribute
            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(AOPMethodAttribute))) == null)
            {
                retMsg = _nextSink.SyncProcessMessage(msg);
            }
            else
            {
                if (this._interceptorObject.MethodExecuting(this._interceptorObject, call.MethodBase.Name, call.Args))
                {
                    retMsg = _nextSink.SyncProcessMessage(msg);

                    var returnValue = ((IMethodReturnMessage)retMsg).ReturnValue;

                    this._interceptorObject.MethodExecuted(this._interceptorObject, call.MethodBase.Name, call.Args, returnValue);
                }
            }

            return retMsg;
        }

        /// <summary>
        /// 异步消息处理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="replySink"></param>
        /// <returns></returns>
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
    }
}
