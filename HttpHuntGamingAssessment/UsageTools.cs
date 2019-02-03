using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpHuntGamingAssessment
{
    public class UsageTools
    {
        private ToolUsage[] _toolsUsage { get; set; }

        public UsageTools(ToolUsage[] toolsUsage)
        {
            this._toolsUsage = toolsUsage;
        }

        public ToolsSortedOnUsage[] GetSortedToolUsage()
        {
            List<ToolsSortedOnUsage> toolsSortedOnUsage = new List<ToolsSortedOnUsage>();

            foreach (ToolUsage tool in this._toolsUsage)
            {
                ToolsSortedOnUsage toolSortedOnUsage = new ToolsSortedOnUsage(tool.name, (tool.useEndTime - tool.useStartTime).TotalMinutes);

                if (toolsSortedOnUsage.Any(l => l.name == tool.name))
                {
                    toolsSortedOnUsage.Where(l => l.name == tool.name).ToList().ForEach(l => l.timeUsedInMinutes += toolSortedOnUsage.timeUsedInMinutes);
                }
                else
                {
                    toolsSortedOnUsage.Add(toolSortedOnUsage);
                }
            }

            return toolsSortedOnUsage.OrderByDescending(l => l.timeUsedInMinutes).ToList().ToArray();
        }
    }
}
