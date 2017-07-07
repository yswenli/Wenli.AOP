# Wenli.AOP

weni.aop内部封装了三种方法拦截机制：DynamicProxy、Intercepting、Simple;

1.DynamicProxy使用的是dotnet emit 动态代理模式，直接对目标类的接口进行生成代理类，通过代理类的方法来实现拦截

2.Intercepting使用的是dotnet中的远程消息、边界对象机制来实现拦截

3.Simple使用的是dotnet中的RealProxy简单封装实现拦截

其中DynamicProxy需要有目标类的接口，Intercepting和Simple需要目标类继承ContextBoundObject、MarshalByRefObject

使用方式参照：<a href="https://github.com/yswenli/Wenli.AOP/tree/master/Wenli.AOP.Console" target="_blank">Wenli.AOP.Console</a>

<img src="https://github.com/yswenli/Wenli.AOP/blob/master/Wenli.AOP.Console/wenli.aop.png?raw=true" alt="wenli.aop" />


