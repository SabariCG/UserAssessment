using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpHuntGamingAssessment
{
    public class HiddenTools
    {
        private string _hiddenTools { get; set; }
        private string[] _tools { get; set; }

        public HiddenTools(string hiddenTools, string[] tools)
        {
            this._hiddenTools = hiddenTools;
            this._tools = tools;
        }

        public string[] GetFoundTools()
        {
            List<string> foundTools = new List<string>();

            foreach (string tool in this._tools)
            {
                char[] toolChars = tool.ToCharArray();
                bool isToolFound = true;

                int hiddenStartOfToolFirstCharIndex = this._hiddenTools.IndexOf(toolChars[0]);

                string subHiddenTools = this._hiddenTools.Substring(hiddenStartOfToolFirstCharIndex, (this._hiddenTools.Length - hiddenStartOfToolFirstCharIndex));

                foreach (char ch in toolChars)
                {
                    if (!subHiddenTools.Contains(ch))
                    {
                        isToolFound = false;
                        break;
                    }
                }

                if (isToolFound)
                    foundTools.Add(tool);
            }

            return foundTools.ToArray();
        }
    }
}
