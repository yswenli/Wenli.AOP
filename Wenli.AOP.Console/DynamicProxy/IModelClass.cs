namespace Wenli.AOP.Console.DynamicProxy
{
    public interface IModelClass
    {
        [AOPMethodAttribute]
        int Calc(int x, int y);
    }
}