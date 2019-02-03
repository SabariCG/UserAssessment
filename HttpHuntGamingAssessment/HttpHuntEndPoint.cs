using System;

namespace HttpHuntGamingAssessment
{
    public class HttpHuntEndPoint
    {
        public readonly string BaseUrl;
        public readonly string InputUrl;
        public readonly string OutputUrl;

        public HttpHuntEndPoint(string baseUrl)
        {
            BaseUrl = baseUrl;
            InputUrl = baseUrl + "/input";
            OutputUrl = baseUrl + "/output";
        }
    }
}
