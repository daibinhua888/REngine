using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuleEngine;

namespace REngineTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sales");
            {
                float result = REngine.InvokeAsFloat("sales", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = REngine.InvokeAsFloat("sales", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("discount group");
            {
                var result = REngine.InvokeAsFloat("discount group", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = REngine.InvokeAsFloat("discount group", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m1");
            {
                var result = REngine.InvokeAsFloat("m1", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = REngine.InvokeAsFloat("m1", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m2");
            {
                var result = REngine.InvokeAsFloat("m2", string.Format("companyId-{0}", 100));
                Console.WriteLine("         " + result);

                result = REngine.InvokeAsFloat("m2", string.Format("companyId-{0}", 5));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("m3");
            {
                var result = REngine.InvokeAsFloat("m3");
                Console.WriteLine("         " + result);
            }


            Console.WriteLine("折扣规则 - 简单使用");
            {
                var result = REngine.InvokeAsFloat("折扣规则", REngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - A公司");
            {
                var result = REngine.InvokeAsFloat("折扣规则", "A公司", REngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - B公司");
            {
                var result = REngine.InvokeAsFloat("折扣规则", "B公司", REngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            Console.WriteLine("折扣规则 - 区分公司 - C公司");
            {
                var result = REngine.InvokeAsFloat("折扣规则", "C公司", REngine.CreateParameter("customerScore", 220));
                Console.WriteLine("         " + result);
            }

            DateTime begin = DateTime.Now;

            int totalCount = 5000;

            while (totalCount-- >0)
            {
                var result = REngine.InvokeAsFloat("折扣规则");
            }

            var elapsed = DateTime.Now - begin;
            double tps = (double)5000 / elapsed.TotalSeconds;

            Console.WriteLine("5000次调用共花费了{0}秒", elapsed.TotalSeconds);
            Console.WriteLine("TPS: {0}次/秒", tps);

            Console.ReadKey();
        }
    }
}