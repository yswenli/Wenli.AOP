/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：2621f037-08c1-446a-b07b-9132c5ab28e6
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Factory
 * 类名称：AOPFactory
 * 创建时间：2017/7/4 17:44:04
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Simple
{
    /// <summary>
    /// AOP包装工厂
    /// 使用方法
    /// AOPFactory.OnMethodExecuting+=..
    /// AOPFactory.OnMethodExecuted+=..
    ///var userRepository=AOPFactory.Create<UserRepository>();
    /// 
    /// </summary>
    public abstract class AOPFactory
    {
        #region events
        /// <summary>
        /// 方法执行前
        /// 若此事件返回true则继续执行方法本体
        /// </summary>
        public static event OnMethodExecutingHandler OnMethodExecuting;
        /// <summary>
        /// 方法执行后
        /// </summary>
        public static event OnMethodExecutedHandler OnMethodExecuted;
        #endregion



        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            //创建真实实例  
            T instance = Activator.CreateInstance<T>();
            //创建真实代理  
            AOPProxy<T> aopProxy = new AOPProxy<T>(instance);

            aopProxy.OnMethodExecuting += AopProxy_OnMethodExecuting;

            aopProxy.OnMethodExecuted += AopProxy_OnMethodExecuted;

            T transparentProxy = (T)aopProxy.GetTransparentProxy();
            //返回透明代理  
            return transparentProxy;
        }

        private static bool AopProxy_OnMethodExecuting(object target, string funName, object[] args)
        {
            return OnMethodExecuting.Invoke(target, funName, args);
        }

        private static void AopProxy_OnMethodExecuted(object target, string funName, object[] args, object returnValue)
        {
            OnMethodExecuted.Invoke(target, funName, args, returnValue);
        }
    }
}
