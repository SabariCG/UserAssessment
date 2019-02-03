using System;
using System.Configuration;
using System.Net;

using Newtonsoft.Json;

namespace HttpHuntGamingAssessment
{
    class Program
    {
        public static string userId = ConfigurationManager.AppSettings["UserId"].ToString();
        static void Main(string[] args)
        {
            try
            {
                HttpHuntEndPoint httpHuntEndPoint = new HttpHuntEndPoint(ConfigurationManager.AppSettings["HttpHuntBaseUrl"].ToString());

                WebClient webClient = new WebClient();
                webClient.Headers.Add("userId", userId);

                CallStageOne(httpHuntEndPoint, webClient);
                CallStageTwo(httpHuntEndPoint, webClient);
                CallStageThree(httpHuntEndPoint, webClient);
                CallStageFour(httpHuntEndPoint, webClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void CallStageOne(HttpHuntEndPoint httpHuntEndPoint, WebClient webClient)
        {
            Input input = JsonConvert.DeserializeObject<Input>(webClient.DownloadString(httpHuntEndPoint.InputUrl));

            Decrypt decrypt = new Decrypt(input.encryptedMessage, input.key);

            Output output = new Output(decrypt.GetDecrypedMessage());

            string outputJson = JsonConvert.SerializeObject(output, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            webClient.Headers.Add("content-type", "application/json");
            webClient.UploadString(httpHuntEndPoint.OutputUrl, outputJson);
        }

        static void CallStageTwo(HttpHuntEndPoint httpHuntEndPoint, WebClient webClient)
        {
            Input input = JsonConvert.DeserializeObject<Input>(webClient.DownloadString(httpHuntEndPoint.InputUrl));

            HiddenTools tools = new HiddenTools(input.hiddenTools, input.tools);

            Output output = new Output(tools.GetFoundTools());

            string outputJson = JsonConvert.SerializeObject(output, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            webClient.Headers.Add("content-type", "application/json");
            webClient.UploadString(httpHuntEndPoint.OutputUrl, outputJson);
        }

        static void CallStageThree(HttpHuntEndPoint httpHuntEndPoint, WebClient webClient)
        {
            Input input = JsonConvert.DeserializeObject<Input>(webClient.DownloadString(httpHuntEndPoint.InputUrl));

            UsageTools usageTools = new UsageTools(input.toolUsage);

            Output output = new Output(usageTools.GetSortedToolUsage());

            string outputJson = JsonConvert.SerializeObject(output, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            webClient.Headers.Add("content-type", "application/json");
            webClient.UploadString(httpHuntEndPoint.OutputUrl, outputJson);
        }

        static void CallStageFour(HttpHuntEndPoint httpHuntEndPoint, WebClient webClient)
        {
            InputProxy input = JsonConvert.DeserializeObject<InputProxy>(webClient.DownloadString(httpHuntEndPoint.InputUrl));

            Tools tools = new Tools(input.tools, input.maximumWeight);

            Output output = new Output();
            output.toolsToTakeSorted = tools.GetSortedTools();

            string outputJson = JsonConvert.SerializeObject(output, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            webClient.Headers.Add("content-type", "application/json");
            webClient.UploadString(httpHuntEndPoint.OutputUrl, outputJson);
        }
    }
}
