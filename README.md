REngine
=======

Rule Engine

AppSetting配置：<br />
	<appSettings><br />
		<add key="XExtractor.RulefilesPath" value="E:\rules"/><br />
		<add key="XExtractor.ThrowExceptionIfNotfoundRule" value="1"/><br />
	</appSettings><br />
	<br />
规则文件(*.rule)定义如下：<br />
			#region 折扣规则<br />
				rule default<br />
					return 1;<br />
				end rule<br />
				rule A公司<br />
					if(customerScore>=0&&customerScore<100)<br />
						return 1;<br />
					if(customerScore>=100&&customerScore<300)<br />
						return 0.8;<br />
					return 0.5;<br />
				end rule<br />
				rule B公司<br />
					if(customerScore>=0&&customerScore<100)<br />
						return 0.9;<br />
					if(customerScore>=100&&customerScore<300)<br />
						return 0.7;<br />
					return 0.6;<br />
				end rule<br />
			#endregion<br />
			<br />
C#代码如下：<br />
			XEngine.LoadSettings();<br />
			<br />
			Console.WriteLine("折扣规则 - 简单使用");<br />
            {<br />
                var result = XEngine.InvokeAsFloat("折扣规则", XEngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - A公司");<br />
            {<br />
                var result = XEngine.InvokeAsFloat("折扣规则", "A公司", XEngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - B公司");<br />
            {<br />
                var result = XEngine.InvokeAsFloat("折扣规则", "B公司", XEngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - C公司");<br />
            {<br />
                var result = XEngine.InvokeAsFloat("折扣规则", "C公司", XEngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />