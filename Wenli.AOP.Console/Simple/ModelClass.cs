/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：23944429-3904-4dae-ac9a-09d22ab7b79e
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP.Console.Simple
 * 类名称：ModelClass
 * 创建时间：2017/7/7 10:41:12
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP.Console.Simple
{
    public class ModelClass : MarshalByRefObject
    {
        public int Calc(int x, int y)
        {
            return x + y;
        }
    }
}
