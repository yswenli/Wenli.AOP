# Wenli.AOP

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
    
