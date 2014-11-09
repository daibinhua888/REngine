using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REngine;

namespace REngineTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            XEngine.LoadSettings();//load文件、设置如没有找到具体rule，是否报错

            Console.WriteLine("sales");
            {
                float result = XEngine.InvokeAsFloat("sales", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = XEngine.InvokeAsFloat("sales", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("discount group");
            {
                var result = XEngine.InvokeAsFloat("discount group", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = XEngine.InvokeAsFloat("discount group", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m1");
            {
                var result = XEngine.InvokeAsFloat("m1", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = XEngine.InvokeAsFloat("m1", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m2");
            {
                var result = XEngine.InvokeAsFloat("m2", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = XEngine.InvokeAsFloat("m2", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m3");
            {
                var result = XEngine.InvokeAsFloat("m3");
                Console.WriteLine("         " + result);
            }


            Console.WriteLine("折扣规则 - 简单使用");
            {
                var result = XEngine.InvokeAsFloat("折扣规则", XEngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - A公司");
            {
                var result = XEngine.InvokeAsFloat("折扣规则", "A公司", XEngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - B公司");
            {
                var result = XEngine.InvokeAsFloat("折扣规则", "B公司", XEngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - C公司");
            {
                var result = XEngine.InvokeAsFloat("折扣规则", "C公司", XEngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            DateTime begin = DateTime.Now;

            int totalCount = 5000;

            while (totalCount-- >0)
            {
                var result = XEngine.InvokeAsFloat("折扣规则");
            }

            var elapsed = DateTime.Now - begin;
            double tps = (double)5000 / elapsed.TotalSeconds;

            Console.WriteLine("5000次调用共花费了{0}秒", elapsed.TotalSeconds);
            Console.WriteLine("TPS: {0}次/秒", tps);

            Console.ReadKey();
        }
    }
}