using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RuleEngine
{
    internal class DefaultJavascriptGenerator : IJavascriptGenerator
    {
        public string GenerateJS(string jsCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GeneratePreservedJS());
            sb.AppendLine();
            sb.AppendLine("function _GET_RETURN()");
            sb.AppendLine("{");
            sb.AppendLine(jsCode);
            sb.AppendLine("}");
            sb.AppendLine();
            sb.AppendLine("_RESULT_RETURN=_GET_RETURN();");

            return sb.ToString();
        }

        private string _js = string.Empty;
        private string GeneratePreservedJS()
        {
            if (!string.IsNullOrEmpty(_js))
                return _js;

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", "underscore-min.js");
            _js = File.ReadAllText(path);

            return _js;
        }
    }
}
