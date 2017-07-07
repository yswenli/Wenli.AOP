# Wenli.AOP

weni.aop内部封装了三种方法拦截机制：DynamicProxy、Intercepting、Simple;

1.DynamicProxy使用的是dotnet emit 动态代理模式，直接对目标类的接口进行生成代理类，通过代理类的方法来实现拦截

2.Intercepting使用的是dotnet中的远程消息、边界对象机制来实现拦截

3.Simple使用的是dotnet中的RealProxy简单封装实现拦截

其中DynamicProxy需要有目标类的接口，Intercepting和Simple需要目标类继承ContextBoundObject、MarshalByRefObject

<img src="https://github.com/yswenli/Wenli.AOP/blob/master/Wenli.AOP.Console/wenli.aop.png?raw=true" alt="wenli.aop" />

使用方式如下：

 static class DynamicProxyTest
    {
        static DynamicProxyTest()
        {
            Console.WriteLine("当前模式为DynamicProxy");

            Wenli.AOP.DynamicProxy.AOPProxy.OnMethodExecuting += AOPProxy_OnMethodExecuting;
            Wenli.AOP.DynamicProxy.AOPProxy.OnMethodExecuted += AOPProxy_OnMethodExecuted;
        }
        private static bool AOPProxy_OnMethodExecuting(object target, string funName, object[] args)
        {
            Console.WriteLine("执行前：sender:" + target + " funName: " + funName + string.Format(" args:{0},{1}", args));
            return true;
        }

        private static void AOPProxy_OnMethodExecuted(object target, string funName, object[] args, object returnValue)
        {
            Console.WriteLine("执行后：sender:" + target + " funName:" + funName + string.Format(" args:{0},{1}", args) + " returnValue:" + returnValue);
        }

        public static void Test()
        {
            var model = new ModelClass();

            var modelProxy = Wenli.AOP.DynamicProxy.AOPProxy.Create<IModelClass>(model);

            modelProxy.Calc(111, 11111);
        }
    }
    
    
    
    
public static class InterceptingTest
    {

        static InterceptingTest()
        {
            Console.WriteLine("当前模式为Intercepting");
        }

        public static void Test()
        {
            var model = new ModelClass();

            model.Calc(222, 2222);
        }
    }
    
    
    
    
    public static class SimpleTest
    {
        static SimpleTest()
        {
            Console.WriteLine("当前模式为Simple");

            AOPFactory.OnMethodExecuting += AOPFactory_OnMethodExecuting;
            AOPFactory.OnMethodExecuted += AOPFactory_OnMethodExecuted;
        }

        private static bool AOPFactory_OnMethodExecuting(object target, string funName, object[] args)
        {
            Console.WriteLine("执行前：sender:" + target + " funName: " + funName + string.Format(" args:{0},{1}", args));
            return true;
        }

        private static void AOPFactory_OnMethodExecuted(object target, string funName, object[] args, object returnValue)
        {
            Console.WriteLine("执行后：sender:" + target + " funName:" + funName + string.Format(" args:{0},{1}", args) + " returnValue:" + returnValue);
        }

        public static void Test()
        {
            var model= AOPFactory.Create<ModelClass>();

            model.Calc(111, 2222);
        }


       
    }
    
