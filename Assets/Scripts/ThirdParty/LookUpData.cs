using System;

namespace ThirdParty
{
    [Serializable]
    public class LookUpData
    {
        public string query;
        public string status;
        public string country;
        public string countryCode;
        public string region;
        public string regionName;
        public string city;
        public string zip;
        public float lat;
        public float lon;
        public string timezone;
        public string isp;
        public string org;
        public string asName;
    }
}