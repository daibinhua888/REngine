REngine
=======

Rule Engine

AppSetting配置：<br />
	&lt;appSettings&gt;
		<add key="XExtractor.RulefilesPath" value="E:\rules"/>
		<!--<add key="XExtractor.ThrowExceptionIfNotfoundRule" value="1"/>-->
	</appSettings>

规则文件(*.rule)定义如下：
			#region 折扣规则
				rule default
					return 1;
				end rule
				rule A公司
					if(customerScore>=0&&customerScore<100)
						return 1;
					if(customerScore>=100&&customerScore<300)
						return 0.8;
					return 0.5;
				end rule
				rule B公司
					if(customerScore>=0&&customerScore<100)
						return 0.9;
					if(customerScore>=100&&customerScore<300)
						return 0.7;
					return 0.6;
				end rule
			#endregion

C#代码如下：
			XEngine.LoadSettings();

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