/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：6be2381e-84f6-4bb7-bba5-9215f9f8bf1c
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.DynamicProxy.Core
 * 类名称：ProxyFactory
 * 创建时间：2017/7/6 17:55:25
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Wenli.AOP.DynamicProxy.Core
{
    public class ProxyFactory
    {
        private static ProxyFactory instance;
        private static Object lockObj = new Object();

        private Hashtable typeMap = Hashtable.Synchronized(new Hashtable());
        private static readonly Hashtable opCodeTypeMapper = new Hashtable();

        private const string PROXY_SUFFIX = "Proxy";
        private const string ASSEMBLY_NAME = "ProxyAssembly";
        private const string MODULE_NAME = "ProxyModule";
        private const string HANDLER_NAME = "handler";

        static ProxyFactory()
        {
            opCodeTypeMapper.Add(typeof(System.Boolean), OpCodes.Ldind_I1);
            opCodeTypeMapper.Add(typeof(System.Int16), OpCodes.Ldind_I2);
            opCodeTypeMapper.Add(typeof(System.Int32), OpCodes.Ldind_I4);
            opCodeTypeMapper.Add(typeof(System.Int64), OpCodes.Ldind_I8);
            opCodeTypeMapper.Add(typeof(System.Double), OpCodes.Ldind_R8);
            opCodeTypeMapper.Add(typeof(System.Single), OpCodes.Ldind_R4);
            opCodeTypeMapper.Add(typeof(System.UInt16), OpCodes.Ldind_U2);
            opCodeTypeMapper.Add(typeof(System.UInt32), OpCodes.Ldind_U4);
        }

        private ProxyFactory()
        {

        }

        public static ProxyFactory GetInstance()
        {
            if (instance == null)
            {
                CreateInstance();
            }

            return instance;
        }

        private static void CreateInstance()
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new ProxyFactory();
                }
            }
        }

        public Object Create(IProxyInvocationHandler handler, Type objType, bool isObjInterface)
        {
            string typeName = objType.FullName + PROXY_SUFFIX;

            Type type = (Type)typeMap[typeName];

            if (type == null)
            {
                if (isObjInterface)
                {
                    type = CreateType(handler, new Type[] { objType }, typeName);
                }
                else
                {
                    type = CreateType(handler, objType.GetInterfaces(), typeName);
                }

                typeMap.Add(typeName, type);
            }

            return Activator.CreateInstance(type, new object[] { handler });
        }

        public Object Create(IProxyInvocationHandler handler, Type objType)
        {
            return Create(handler, objType, false);
        }

        private Type CreateType(IProxyInvocationHandler handler, Type[] interfaces, string dynamicTypeName)
        {
            Type retVal = null;

            if (handler != null && interfaces != null)
            {
                Type objType = typeof(System.Object);
                Type handlerType = typeof(IProxyInvocationHandler);

                AppDomain domain = Thread.GetDomain();
                AssemblyName assemblyName = new AssemblyName();
                assemblyName.Name = ASSEMBLY_NAME;
                assemblyName.Version = new Version(1, 0, 0, 0);

                //该代理创建一个新的组件
                AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

                // 为这个代理创建一个新模块
                ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(MODULE_NAME);

                // 将类设置为公共和密封的
                TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed;

                // 收集代理信息并创建一个新的类型生成器。继承对象并实现传入接口的对象
                TypeBuilder typeBuilder = moduleBuilder.DefineType(dynamicTypeName, typeAttributes, objType, interfaces);

                // 定义成员变量以容纳委托人
                FieldBuilder handlerField = typeBuilder.DefineField(HANDLER_NAME, handlerType, FieldAttributes.Private);


                // 构建一个构造函数，该构造函数以委托对象作为惟一参数
                //ConstructorInfo defaultObjConstructor = objType.GetConstructor( new Type[0] );
                ConstructorInfo superConstructor = objType.GetConstructor(new Type[0]);
                ConstructorBuilder delegateConstructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { handlerType });

                #region( "Constructor IL Code" )
                ILGenerator constructorIL = delegateConstructor.GetILGenerator();

                // 加载 "this"
                constructorIL.Emit(OpCodes.Ldarg_0);
                // 加载第一构造函数参数
                constructorIL.Emit(OpCodes.Ldarg_1);
                // 将第一个参数设置到处理程序字段中
                constructorIL.Emit(OpCodes.Stfld, handlerField);
                // 加载 "this"
                constructorIL.Emit(OpCodes.Ldarg_0);
                // 调用超级构造函数
                constructorIL.Emit(OpCodes.Call, superConstructor);
                // 构造 return
                constructorIL.Emit(OpCodes.Ret);
                #endregion

                // 对于接口定义的每个方法，在调用处理程序调用方法的动态类型中构建相应的方法。
                foreach (Type interfaceType in interfaces)
                {
                    GenerateMethod(interfaceType, handlerField, typeBuilder);
                }

                retVal = typeBuilder.CreateType();
            }

            return retVal;
        }

        private void GenerateMethod(Type interfaceType, FieldBuilder handlerField, TypeBuilder typeBuilder)
        {
            MetaDataFactory.Add(interfaceType);

            MethodInfo[] interfaceMethods = interfaceType.GetMethods();

            if (interfaceMethods != null)
            {

                for (int i = 0; i < interfaceMethods.Length; i++)
                {
                    MethodInfo methodInfo = interfaceMethods[i];
                    //                          
                    ParameterInfo[] methodParams = methodInfo.GetParameters();
                    int numOfParams = methodParams.Length;
                    Type[] methodParameters = new Type[numOfParams];

                    // 将参数转换成类
                    for (int j = 0; j < numOfParams; j++)
                    {
                        methodParameters[j] = methodParams[j].ParameterType;
                    }

                    // 为接口中的方法创建一个新的生成器
                    MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                        methodInfo.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        CallingConventions.Standard,
                        methodInfo.ReturnType, methodParameters);

                    #region( "Handler Method IL Code" )
                    ILGenerator methodIL = methodBuilder.GetILGenerator();

                    // 如果定义了返回类型，则会发出一个局部变量的声明。
                    if (!methodInfo.ReturnType.Equals(typeof(void)))
                    {
                        methodIL.DeclareLocal(methodInfo.ReturnType);
                        if (methodInfo.ReturnType.IsValueType && !methodInfo.ReturnType.IsPrimitive)
                        {
                            methodIL.DeclareLocal(methodInfo.ReturnType);
                        }
                    }

                    if (numOfParams > 0)
                    {
                        methodIL.DeclareLocal(typeof(System.Object[]));
                    }

                    Label handlerLabel = methodIL.DefineLabel();

                    Label returnLabel = methodIL.DefineLabel();

                    // 加载 "this"
                    methodIL.Emit(OpCodes.Ldarg_0);
                    // 加载 handler 实例变量
                    methodIL.Emit(OpCodes.Ldfld, handlerField);
                    // 如果处理程序实例变量不是空跳到handlerlabel
                    methodIL.Emit(OpCodes.Brtrue_S, handlerLabel);
                    // 句柄为null，如果方法的返回类型不是空的，返回null，否则返回
                    if (!methodInfo.ReturnType.Equals(typeof(void)))
                    {
                        if (methodInfo.ReturnType.IsValueType && !methodInfo.ReturnType.IsPrimitive && !methodInfo.ReturnType.IsEnum)
                        {
                            methodIL.Emit(OpCodes.Ldloc_1);
                        }
                        else
                        {
                            // 在堆栈上加载null
                            methodIL.Emit(OpCodes.Ldnull);
                        }
                        // 存储空返回值
                        methodIL.Emit(OpCodes.Stloc_0);
                        // 跳 return
                        methodIL.Emit(OpCodes.Br_S, returnLabel);
                    }

                    // 处理程序不是空的，所以继续执行
                    methodIL.MarkLabel(handlerLabel);

                    // 加载 "this"
                    methodIL.Emit(OpCodes.Ldarg_0);
                    // 加载 handler
                    methodIL.Emit(OpCodes.Ldfld, handlerField);
                    // 加载 "this" 直到它需要调用调用
                    methodIL.Emit(OpCodes.Ldarg_0);
                    // 负载的接口的名称，用来从metadatafactory获得MethodInfo对象
                    methodIL.Emit(OpCodes.Ldstr, interfaceType.FullName);
                    // 加载index，用来从metadatafactory获得MethodInfo对象
                    methodIL.Emit(OpCodes.Ldc_I4, i);
                    // 在 MetaDataFactory 中调用 GetMethod
                    methodIL.Emit(OpCodes.Call, typeof(MetaDataFactory).GetMethod("GetMethod", new Type[] { typeof(string), typeof(int) }));

                    // 将参数数加载到堆栈上
                    methodIL.Emit(OpCodes.Ldc_I4, numOfParams);
                    // 创建一个新数组
                    methodIL.Emit(OpCodes.Newarr, typeof(System.Object));

                    // 如果我们有任何参数，则迭代并将每个元素的值设置为相应的参数。
                    if (numOfParams > 0)
                    {
                        methodIL.Emit(OpCodes.Stloc_1);
                        for (int j = 0; j < numOfParams; j++)
                        {
                            methodIL.Emit(OpCodes.Ldloc_1);
                            methodIL.Emit(OpCodes.Ldc_I4, j);
                            methodIL.Emit(OpCodes.Ldarg, j + 1);
                            if (methodParameters[j].IsValueType)
                            {
                                methodIL.Emit(OpCodes.Box, methodParameters[j]);
                            }
                            methodIL.Emit(OpCodes.Stelem_Ref);
                        }
                        methodIL.Emit(OpCodes.Ldloc_1);
                    }

                    // 调用Invoke方法
                    methodIL.Emit(OpCodes.Callvirt, typeof(DynamicProxy.IProxyInvocationHandler).GetMethod("Invoke"));

                    if (!methodInfo.ReturnType.Equals(typeof(void)))
                    {
                        // 如果返回类型如果一个值类型，然后拆箱的返回值，这样我们就不会有垃圾。
                        if (methodInfo.ReturnType.IsValueType)
                        {
                            methodIL.Emit(OpCodes.Unbox, methodInfo.ReturnType);
                            if (methodInfo.ReturnType.IsEnum)
                            {
                                methodIL.Emit(OpCodes.Ldind_I4);
                            }
                            else if (!methodInfo.ReturnType.IsPrimitive)
                            {
                                methodIL.Emit(OpCodes.Ldobj, methodInfo.ReturnType);
                            }
                            else
                            {
                                methodIL.Emit((OpCode)opCodeTypeMapper[methodInfo.ReturnType]);
                            }
                        }

                        // 结果存储
                        methodIL.Emit(OpCodes.Stloc_0);
                        // 跳转到返回语句
                        methodIL.Emit(OpCodes.Br_S, returnLabel);
                        // 标记返回语句
                        methodIL.MarkLabel(returnLabel);
                        // 在返回之前加载所存储的值。这要么是 NULL（如果处理程序为null）或来自调用的返回值。
                        methodIL.Emit(OpCodes.Ldloc_0);
                    }
                    else
                    {
                        // 弹出由于方法返回类型无效而从堆栈中调用返回的返回值。
                        methodIL.Emit(OpCodes.Pop);
                        //标记返回语句
                        methodIL.MarkLabel(returnLabel);
                    }
                    methodIL.Emit(OpCodes.Ret);
                    #endregion

                }
            }

            // 迭代父接口并递归调用此方法。
            foreach (Type parentType in interfaceType.GetInterfaces())
            {
                GenerateMethod(parentType, handlerField, typeBuilder);
            }
        }
    }
}
