/*****************************************************************************************************
 * 本代码版权归@wenli所有，All Rights Reserved (C) 2015-2017
 *****************************************************************************************************
 * CLR版本：4.0.30319.42000
 * 唯一标识：b1c821f5-08ce-4975-8d07-4db96b1e2c30
 * 机器名称：WENLI-PC
 * 联系人邮箱：wenguoli_520@qq.com
 *****************************************************************************************************
 * 项目名称：$projectname$
 * 命名空间：Wenli.AOP
 * 类名称：AOPMethodAttribute
 * 创建时间：2017/7/6 11:22:05
 * 创建人：wenli
 * 创建说明：
 *****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wenli.AOP
{
    /// <summary>
    /// 准备拦截方法上的标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AOPMethodAttribute : Attribute
    {
    }
}
