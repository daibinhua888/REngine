using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine
{
    internal interface IJavascriptGenerator
    {
        string GenerateJS(string jsCode);
    }
}
