using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Parsers
{
    internal class RuleParser
    {
        public static List<RuleDefination> ParseRules(string text)
        {
            List<RuleDefination> rules = new List<RuleDefination>();

            if (text == null)
                return rules;
            if (text.Trim().Length <= 0)
                return rules;

            string[] lines = text.Split("\r\n".ToCharArray());
            if (lines == null)
                return rules;
            if (lines.Length == 0)
                return rules;

            List<string> filteredLines = ParseHelper.FilterEmptyRow(lines);

            RuleDefination rule = null;
            int ruleIndex = -1;
            for (int i = 0; i < filteredLines.Count; i++)
            {
                string line = filteredLines[i];

                if (line.Trim().Length > 4 && line.Substring(0, 4) == "rule")
                {
                    ruleIndex = i;

                    rule = new RuleDefination();
                    rule.RuleName = line.Substring(5).Trim('"');
                }
                else if (line.Trim().Length >= 8 && line.Substring(0, 8) == "end rule")
                {
                    if(rule==null)
                        throw new Exception("Rule Parse error");

                    if (rule != null)
                    {
                        rule.RuleContent = ParseHelper.GetInnerRawContent(filteredLines, ruleIndex + 1, i - 1);
                        rules.Add(rule);

                        ruleIndex = -1;
                    }   
                }
            }

            if (rules.Count == 0)
                throw new Exception("Rule cannot be empty");

            return rules;
        }
    }
}
