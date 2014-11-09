REngine
=======

Rule Engine

AppSetting配置：<br />
&nbsp;&nbsp;&nbsp;&nbsp;&lt;appSettings&gt;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key="REngine.RulefilesPath" value="E:\rules"/&gt;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key="REngine.ThrowExceptionIfNotfoundRule" value="1"/&gt;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/appSettings&gt;<br />
	<br />
规则文件(*.rule)定义如下：<br />
&nbsp;&nbsp;&nbsp;&nbsp;#region 折扣规则<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rule default<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 1;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;end rule<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rule A公司<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(customerScore&gt;=0&&customerScore&lt;100)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 1;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(customerScore&gt;=100&&customerScore&lt;300)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0.8;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0.5;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;end rule<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rule B公司<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(customerScore&gt;=0&&customerScore&lt;100)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0.9;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(customerScore&gt;=100&&customerScore&lt;300)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0.7;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return 0.6;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;end rule<br />
&nbsp;&nbsp;&nbsp;&nbsp;#endregion<br />
			<br />
C#代码如下：<br />
			REngine.LoadSettings();<br />
			<br />
			Console.WriteLine("折扣规则 - 简单使用");<br />
            {<br />
                var result = REngine.InvokeAsFloat("折扣规则", REngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - A公司");<br />
            {<br />
                var result = REngine.InvokeAsFloat("折扣规则", "A公司", REngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - B公司");<br />
            {<br />
                var result = REngine.InvokeAsFloat("折扣规则", "B公司", REngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />
			<br />
            Console.WriteLine("折扣规则 - 区分公司 - C公司");<br />
            {<br />
                var result = REngine.InvokeAsFloat("折扣规则", "C公司", REngine.CreateParameter("customerScore", 220));<br />
                Console.WriteLine("         " + result);<br />
            }<br />