using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REngine.Parsers;

namespace REngine
{
    internal class XConfig
    {
        public XConfig()
        {
            this.RuleDefinations = new Dictionary<string, RuleDefination>();
        }

        public bool ThrowExceptionIfNotfoundRule { get; set; }
        public string RulefilesPath { get; set; }
        public Dictionary<string, RuleDefination> RuleDefinations { get; set; }
    }
}
