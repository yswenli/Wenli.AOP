.assembly Wenli.AOP.Console.DTest.Proxy
{
	.class public sealed ansi Wenli.AOP.Console.DTestProxy extends class [Wenli.AOP.Console]Wenli.AOP.Console.DTest
	{
		.method private hidebysig specialname instance void .ctor() cil managed
		{
			.locals init ()
			IL_0000:  ldarg.0
			IL_0001:  call instance void Wenli.AOP.Console.DTest::.ctor()
			IL_0006:  ret
		}
		
		.method public hidebysig specialname instance void .ctor() cil managed
		{
			.locals init ()
			IL_0000:  ldarg.0
			IL_0001:  call instance void Wenli.AOP.Console.DTest::.ctor()
			IL_0006:  ldarg.0
			IL_0007:  ldarg.1
			IL_0008:  stfld Wenli.AOP.Console.DTest Wenli.AOP.Console.DTestProxy::wrappedObject
			IL_000D:  ldarg.0
			IL_000E:  ldarg.2
			IL_000F:  stfld Wenli.AOP.DynamicProxy.Handler.IInvocationHandler[] Wenli.AOP.Console.DTestProxy::invokeHandlers
			IL_0014:  ret
		}
		
		.method private virtual hidebysig instance class [Wenli.AOP.Console]Wenli.AOP.Console.DTest get_Target() cil managed
		{
			.locals init ()
			IL_0000:  ldarg.0
			IL_0001:  ldfld Wenli.AOP.Console.DTest Wenli.AOP.Console.DTestProxy::wrappedObject
			IL_0006:  ret
		}
		
		.method private hidebysig instance valuetype [mscorlib]System.Boolean OnBeforeMethodInvocation() cil managed
		{
			.locals init ([0] valuetype [mscorlib]System.Boolean V_0, [1] int32 V_1)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc V_1
			IL_0004:  ldarg.0
			IL_0005:  ldfld Wenli.AOP.DynamicProxy.Handler.IInvocationHandler[] Wenli.AOP.Console.DTestProxy::invokeHandlers
			IL_000A:  ldloc V_1
			IL_000D:  ldelem.ref
			IL_000E:  ldarg.1
			IL_000F:  ldarg.2
			IL_0010:  callvirt instance valuetype [mscorlib]System.Boolean Wenli.AOP.DynamicProxy.Handler.IInvocationHandler::BeforeMethodInvocation()
			IL_0015:  stloc V_0
			IL_0018:  ldloc V_0
			IL_001B:  brtrue IL_001F
			IL_001D:  br IL_0034
			IL_001F:  ldloc V_1
			IL_0022:  ldc.i4.1
			IL_0023:  add
			IL_0024:  stloc V_1
			IL_0027:  ldloc V_1
			IL_002A:  ldarg.0
			IL_002B:  ldfld Wenli.AOP.DynamicProxy.Handler.IInvocationHandler[] Wenli.AOP.Console.DTestProxy::invokeHandlers
			IL_0030:  ldlen
			IL_0031:  conv.i4
			IL_0032:  blt IL_0004
			IL_0034:  ldloc V_0
			IL_0037:  ret
		}
		
		.method private hidebysig instance void OnAfterMethodInvocation() cil managed
		{
			.locals init ([0] int32 V_0, [1] valuetype [mscorlib]System.Boolean V_1)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc V_0
			IL_0004:  ldarg.0
			IL_0005:  ldfld Wenli.AOP.DynamicProxy.Handler.IInvocationHandler[] Wenli.AOP.Console.DTestProxy::invokeHandlers
			IL_000A:  ldloc V_0
			IL_000D:  ldelem.ref
			IL_000E:  ldarg.1
			IL_000F:  ldarg.2
			IL_0010:  ldarg.3
			IL_0011:  ldarg 4
			IL_0017:  callvirt instance valuetype [mscorlib]System.Boolean Wenli.AOP.DynamicProxy.Handler.IInvocationHandler::AfterMethodInvocation()
			IL_001C:  stloc V_1
			IL_001F:  ldloc V_1
			IL_0022:  brfalse IL_002B
			IL_0024:  ldarg 4
			IL_002A:  throw
			IL_002B:  ldloc V_0
			IL_002E:  ldc.i4.1
			IL_002F:  add
			IL_0030:  stloc V_0
			IL_0033:  ldloc V_0
			IL_0036:  ldarg.0
			IL_0037:  ldfld Wenli.AOP.DynamicProxy.Handler.IInvocationHandler[] Wenli.AOP.Console.DTestProxy::invokeHandlers
			IL_003C:  ldlen
			IL_003D:  conv.i4
			IL_003E:  blt IL_0004
			IL_0040:  ret
		}
		
		.method private virtual hidebysig instance string ToStringProxy() cil managed
		{
			.locals init ([0] object[] V_0, [1] valuetype [mscorlib]System.Boolean V_1, [2] class [mscorlib]System.Type V_2, [3] class [mscorlib]System.Exception V_3, [4] object V_4, [5] class [mscorlib]System.Reflection.MethodBase V_5, [6] string V_6)
			IL_0000:  ldnull
			IL_0001:  stloc V_3
			IL_0004:  ldc.i4 0
			IL_0009:  newarr object
			IL_000E:  stloc V_0
			IL_0011:  ldtoken instance string object::ToString()
			IL_0016:  call class System.Reflection.MethodBase System.Reflection.MethodBase::GetMethodFromHandle()
			IL_001B:  stloc V_5
			IL_001E:  ldarg.0
			IL_001F:  ldloc V_5
			IL_0022:  ldloc V_0
			IL_0025:  call instance valuetype [mscorlib]System.Boolean Wenli.AOP.Console.DTestProxy::OnBeforeMethodInvocation()
			IL_002A:  stloc V_1
			IL_002D:  ldloc V_1
			IL_0030:  brfalse IL_0093
			.try
			{
				IL_0032:  ldarg.0
				IL_0033:  ldfld Wenli.AOP.Console.DTest Wenli.AOP.Console.DTestProxy::wrappedObject
				IL_0038:  callvirt instance string object::ToString()
				IL_003D:  stloc V_6
				IL_0040:  ldarg.0
				IL_0041:  ldloc V_5
				IL_0044:  ldloc V_0
				IL_0047:  ldloc V_6
				IL_004A:  castclass object
				IL_004F:  stloc V_4
				IL_0052:  ldloca V_4
				IL_0055:  ldloc V_3
				IL_0058:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_005D:  ldloc V_4
				IL_0060:  castclass string
				IL_0065:  stloc V_6
			}
			catch class [mscorlib]System.Exception
			{
				IL_0068:  stloc V_3
				IL_006B:  ldarg.0
				IL_006C:  ldloc V_5
				IL_006F:  ldloc V_0
				IL_0072:  ldloc V_6
				IL_0075:  castclass object
				IL_007A:  stloc V_4
				IL_007D:  ldloca V_4
				IL_0080:  ldloc V_3
				IL_0083:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_0088:  ldloc V_4
				IL_008B:  castclass string
				IL_0090:  stloc V_6
			}
			IL_0093:  ldloc V_6
			IL_0096:  ret
		}
		
		.method private virtual hidebysig instance valuetype [mscorlib]System.Boolean EqualsProxy() cil managed
		{
			.locals init ([0] object[] V_0, [1] valuetype [mscorlib]System.Boolean V_1, [2] class [mscorlib]System.Type V_2, [3] class [mscorlib]System.Exception V_3, [4] object V_4, [5] class [mscorlib]System.Reflection.MethodBase V_5, [6] valuetype [mscorlib]System.Boolean V_6)
			IL_0000:  ldnull
			IL_0001:  stloc V_3
			IL_0004:  ldc.i4 1
			IL_0009:  newarr object
			IL_000E:  stloc V_0
			IL_0011:  ldtoken instance valuetype System.Boolean object::Equals()
			IL_0016:  call class System.Reflection.MethodBase System.Reflection.MethodBase::GetMethodFromHandle()
			IL_001B:  stloc V_5
			IL_001E:  ldloc V_0
			IL_0021:  ldc.i4 0
			IL_0026:  ldarg 1
			IL_002C:  stelem.ref
			IL_002D:  ldarg.0
			IL_002E:  ldloc V_5
			IL_0031:  ldloc V_0
			IL_0034:  call instance valuetype [mscorlib]System.Boolean Wenli.AOP.Console.DTestProxy::OnBeforeMethodInvocation()
			IL_0039:  stloc V_1
			IL_003C:  ldloc V_0
			IL_003F:  ldc.i4 0
			IL_0044:  ldelem.ref
			IL_0045:  castclass object
			IL_004A:  starg 1
			IL_0050:  ldloc V_1
			IL_0053:  brfalse IL_00BC
			.try
			{
				IL_0055:  ldarg.0
				IL_0056:  ldfld Wenli.AOP.Console.DTest Wenli.AOP.Console.DTestProxy::wrappedObject
				IL_005B:  ldarg 1
				IL_0061:  callvirt instance valuetype System.Boolean object::Equals()
				IL_0066:  stloc V_6
				IL_0069:  ldarg.0
				IL_006A:  ldloc V_5
				IL_006D:  ldloc V_0
				IL_0070:  ldloc V_6
				IL_0073:  box valuetype [mscorlib]System.Boolean
				IL_0078:  stloc V_4
				IL_007B:  ldloca V_4
				IL_007E:  ldloc V_3
				IL_0081:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_0086:  ldloc V_4
				IL_0089:  unbox.any valuetype [mscorlib]System.Boolean
				IL_008E:  stloc V_6
			}
			catch class [mscorlib]System.Exception
			{
				IL_0091:  stloc V_3
				IL_0094:  ldarg.0
				IL_0095:  ldloc V_5
				IL_0098:  ldloc V_0
				IL_009B:  ldloc V_6
				IL_009E:  box valuetype [mscorlib]System.Boolean
				IL_00A3:  stloc V_4
				IL_00A6:  ldloca V_4
				IL_00A9:  ldloc V_3
				IL_00AC:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_00B1:  ldloc V_4
				IL_00B4:  unbox.any valuetype [mscorlib]System.Boolean
				IL_00B9:  stloc V_6
			}
			IL_00BC:  ldloc V_6
			IL_00BF:  ret
		}
		
		.method private virtual hidebysig instance int32 GetHashCodeProxy() cil managed
		{
			.locals init ([0] object[] V_0, [1] valuetype [mscorlib]System.Boolean V_1, [2] class [mscorlib]System.Type V_2, [3] class [mscorlib]System.Exception V_3, [4] object V_4, [5] class [mscorlib]System.Reflection.MethodBase V_5, [6] int32 V_6)
			IL_0000:  ldnull
			IL_0001:  stloc V_3
			IL_0004:  ldc.i4 0
			IL_0009:  newarr object
			IL_000E:  stloc V_0
			IL_0011:  ldtoken instance int32 object::GetHashCode()
			IL_0016:  call class System.Reflection.MethodBase System.Reflection.MethodBase::GetMethodFromHandle()
			IL_001B:  stloc V_5
			IL_001E:  ldarg.0
			IL_001F:  ldloc V_5
			IL_0022:  ldloc V_0
			IL_0025:  call instance valuetype [mscorlib]System.Boolean Wenli.AOP.Console.DTestProxy::OnBeforeMethodInvocation()
			IL_002A:  stloc V_1
			IL_002D:  ldloc V_1
			IL_0030:  brfalse IL_0093
			.try
			{
				IL_0032:  ldarg.0
				IL_0033:  ldfld Wenli.AOP.Console.DTest Wenli.AOP.Console.DTestProxy::wrappedObject
				IL_0038:  callvirt instance int32 object::GetHashCode()
				IL_003D:  stloc V_6
				IL_0040:  ldarg.0
				IL_0041:  ldloc V_5
				IL_0044:  ldloc V_0
				IL_0047:  ldloc V_6
				IL_004A:  box int32
				IL_004F:  stloc V_4
				IL_0052:  ldloca V_4
				IL_0055:  ldloc V_3
				IL_0058:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_005D:  ldloc V_4
				IL_0060:  unbox.any int32
				IL_0065:  stloc V_6
			}
			catch class [mscorlib]System.Exception
			{
				IL_0068:  stloc V_3
				IL_006B:  ldarg.0
				IL_006C:  ldloc V_5
				IL_006F:  ldloc V_0
				IL_0072:  ldloc V_6
				IL_0075:  box int32
				IL_007A:  stloc V_4
				IL_007D:  ldloca V_4
				IL_0080:  ldloc V_3
				IL_0083:  call instance void Wenli.AOP.Console.DTestProxy::OnAfterMethodInvocation()
				IL_0088:  ldloc V_4
				IL_008B:  unbox.any int32
				IL_0090:  stloc V_6
			}
			IL_0093:  ldloc V_6
			IL_0096:  ret
		}
	}
}
