using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleEngine.Parsers
{
    internal class ParseHelper
    {
        public static List<string> FilterEmptyRow(string[] lines)
        {
            List<string> filteredLines = new List<string>();
            foreach (string line in lines)
                if (line.Trim().Length > 0)
                    filteredLines.Add(line.Trim());
            return filteredLines;
        }

        public static string GetInnerRawContent(List<string> lines, int startRowIndex, int endRowIndex)
        {
            string str = string.Empty;
            int i = startRowIndex;
            while (i <= endRowIndex)
                str += lines[i++] + "\r\n";
            return str;
        }
    }
}
