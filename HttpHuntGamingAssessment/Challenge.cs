using System;

namespace HttpHuntGamingAssessment
{
    public class Challenge
    {
        public string stage { get; set; }
        public string statement { get; set; }
        public string instructions { get; set; }
        public SampleInput sampleInput { get; set; }
        public SampleOutput sampleOutput { get; set; }
    }

    public class ChallengeProxy
    {
        public string stage { get; set; }
        public string statement { get; set; }
        public string instructions { get; set; }
        public SampleInputProxy sampleInput { get; set; }
        public SampleOutput sampleOutput { get; set; }
    }

    public class SampleInput
    {
        public Input input { get; set; }
    }

    public class SampleInputProxy
    {
        public InputProxy input { get; set; }
    }

    public class Input
    {
        public string encryptedMessage { get; set; }
        public int key { get; set; }
        public string hiddenTools { get; set; }
        public string[] tools { get; set; }
        public ToolUsage[] toolUsage { get; set; }
    }

    public class InputProxy
    {
        public Tool[] tools { get; set; }
        public int maximumWeight { get; set; }
    }

    public class ToolUsage
    {
        public string name { get; set; }
        public DateTime useStartTime { get; set; }
        public DateTime useEndTime { get; set; }
    }

    public class Tool
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int value { get; set; }
    }

    public class SampleOutput
    {
        public Output output { get; set; }
    }

    public class Output
    {
        public string message { get; set; }
        public string[] toolsFound { get; set; }
        public ToolsSortedOnUsage[] toolsSortedOnUsage { get; set; }
        public string[] toolsToTakeSorted { get; set; }
        public Output()
        {

        }

        public Output(string msg)
        {
            this.message = msg;
        }
        public Output(string[] tools)
        {
            this.toolsFound = tools;
        }

        public Output(ToolsSortedOnUsage[] toolsSortedOnUsage)
        {
            this.toolsSortedOnUsage = toolsSortedOnUsage;
        }
    }

    public class ToolsSortedOnUsage
    {
        public string name { get; set; }
        public double timeUsedInMinutes { get; set; }

        public ToolsSortedOnUsage(string name, double minutes)
        {
            this.name = name;
            this.timeUsedInMinutes = minutes;
        }
    }
}
