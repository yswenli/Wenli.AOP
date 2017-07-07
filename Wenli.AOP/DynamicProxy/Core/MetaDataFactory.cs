/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：5860c390-0841-4366-a99f-645befc2b43d
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.DynamicProxy.Core
 * 类名称：MetaDataFactory
 * 创建时间：2017/7/6 17:54:43
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wenli.AOP.DynamicProxy.Core
{
    public class MetaDataFactory
    {
        private static Hashtable typeMap = new Hashtable();

        /// <summary>
        /// Class constructor.  Private because this is a static class.
        /// </summary>
        private MetaDataFactory()
        {
        }

        ///<summary>
        /// Method to add a new Type to the cache, using the type's fully qualified
        /// name as the key
        ///</summary>
        ///<param name="interfaceType">Type to cache</param>
        public static void Add(Type interfaceType)
        {
            if (interfaceType != null)
            {
                lock (typeMap.SyncRoot)
                {
                    if (!typeMap.ContainsKey(interfaceType.FullName))
                    {
                        typeMap.Add(interfaceType.FullName, interfaceType);
                    }
                }
            }
        }

        ///<summary>
        /// Method to return the method of a given type at a specified index.
        ///</summary>
        ///<param name="name">Fully qualified name of the method to return</param>
        ///<param name="i">Index to use to return MethodInfo</param>
        ///<returns>MethodInfo</returns>
        public static MethodInfo GetMethod(string name, int i)
        {
            Type type = null;
            lock (typeMap.SyncRoot)
            {
                type = (Type)typeMap[name];
            }

            MethodInfo[] methods = type.GetMethods();
            if (i < methods.Length)
            {
                return methods[i];
            }

            return null;
        }
    }
}
