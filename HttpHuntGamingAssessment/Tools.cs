using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHuntGamingAssessment
{
    public class Tools
    {
        private int _maximumWeight { get; set; }
        private Tool[] _tools { get; set; }

        public Tools(Tool[] tools, int maxWeight)
        {
            this._tools = tools;
            this._maximumWeight = maxWeight;
        }

        public string[] GetSortedTools()
        {
            List<string> toolsToTakeSorted = new List<string>();

            Dictionary<int, string[]> combinedToolsWeight = new Dictionary<int, string[]>();

            foreach (Tool toolA in this._tools)
            {
                List<Tool> combinedTools = new List<Tool>();

                foreach (Tool toolB in this._tools)
                {
                    if (toolB.name != toolA.name)
                    {
                        combinedTools.Add(toolB);
                    }
                }

                int totalWeight = combinedTools.Sum(i => i.weight);

                if(!combinedToolsWeight.ContainsKey(totalWeight))
                {
                    combinedToolsWeight.Add(totalWeight, combinedTools.Select(c => c.name).ToArray());
                }
            }

            foreach (int toolsWeight in combinedToolsWeight.Keys)
            {
                if (toolsWeight <= this._maximumWeight)
                {
                    toolsToTakeSorted = combinedToolsWeight[toolsWeight].OrderBy(item => item).ToList();
                }
            }

            return toolsToTakeSorted.ToArray();
        }
    }
}