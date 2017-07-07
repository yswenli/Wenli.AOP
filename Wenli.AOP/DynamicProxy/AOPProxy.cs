/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：28b0490e-2601-49d3-a538-c9a6c8583242
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.DynamicProxy
 * 类名称：AOPProxy
 * 创建时间：2017/7/6 17:56:53
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wenli.AOP.DynamicProxy.Core;

namespace Wenli.AOP.DynamicProxy
{
    public class AOPProxy : IProxyInvocationHandler
    {
        Object obj = null;

        private AOPProxy(Object obj)
        {
            this.obj = obj;
        }

        ///<summary>
        /// 创建新代理实例的工厂方法。
        ///</summary>
        ///<param name="obj">对象的代理实例</param>
        public static Interface Create<Interface>(Object t)
        {
            if (t is Interface)
            {
                return (Interface)ProxyFactory.GetInstance().Create(new AOPProxy(t), t.GetType());
            }
            else
            {
                throw new Exception("传入的实例未继承接口");
            }
        }

        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters)
        {
            Object retVal = null;

            if ((Attribute.GetCustomAttribute(method, typeof(AOPMethodAttribute))) != null)
            {
                if (Prev(proxy, method, parameters))
                {
                    retVal = method.Invoke(obj, parameters);

                    Next(proxy, method, parameters, retVal);
                }
            }
            else
            {
                retVal = method.Invoke(obj, parameters);
            }
            return retVal;
        }

        #region event
        /// <summary>
        /// 方法执行前
        /// </summary>
        public static event OnMethodExecutingHandler OnMethodExecuting;

        /// <summary>
        /// 方法执行后
        /// </summary>
        public static event OnMethodExecutedHandler OnMethodExecuted;


        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        static bool Prev(Object proxy, System.Reflection.MethodInfo method, Object[] parameters)
        {
            var result = OnMethodExecuting?.Invoke(proxy, method.Name.ToString(), parameters);

            if (result.HasValue && result.Value)
            {
                return true;
            }
            return false;

        }


        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <param name="returnObj"></param>
        void Next(Object proxy, System.Reflection.MethodInfo method, Object[] parameters, object returnObj)
        {
            OnMethodExecuted?.Invoke(proxy, method.Name.ToString(), parameters, returnObj);
        }


        #endregion
    }
}
