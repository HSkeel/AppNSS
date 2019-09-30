using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NorthShoreSurfApp.Services
{
    public class MSWComponent
    {
        public double Height { get; set; }
        public double Period { get; set; }
        public double Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class MSWComponents
    {
        public MSWComponent Combined { get; set; }
        public MSWComponent Primary { get; set; }
        public MSWComponent Secondary { get; set; }
    }

    public class MSWSwell
    {
        public double AbsMinBreakingHeight { get; set; }
        public double AbsMaxBreakingHeight { get; set; }
        public int Probability { get; set; }
        public string Unit { get; set; }
        public double MinBreakingHeight { get; set; }
        public double MaxBreakingHeight { get; set; }
        public MSWComponents Components { get; set; }
    }

    public class MSWWind
    {
        public int Speed { get; set; }
        public int Direction { get; set; }
        public string CompassDirection { get; set; }
        public int Chill { get; set; }
        public int Gusts { get; set; }
        public string Unit { get; set; }
    }

    public class MSWCondition
    {
        public int Pressure { get; set; }
        public int Temperature { get; set; }
        public string Weather { get; set; }
        public string UnitPressure { get; set; }
        public string Unit { get; set; }
    }

    public class MSWCharts
    {
        public string Swell { get; set; }
        public string Period { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Sst { get; set; }
    }

    public class MSWData
    {
        public int Timestamp { get; set; }
        public int LocalTimestamp { get; set; }
        public int IssueTimestamp { get; set; }
        public int FadedRating { get; set; }
        public int SolidRating { get; set; }
        public MSWSwell Swell { get; set; }
        public MSWWind Wind { get; set; }
        public MSWCondition Condition { get; set; }
        public MSWCharts Charts { get; set; }
    }

    class MSWParameters
    {
        public const string SpotId = "spot_id";
        public const string Unit = "unit";

        public const string LokkenSpotId = "3925";
        public const string EuropeanUnit = "eu";
    }

    public class MSWService
    {
        private const string Url = "http://magicseaweed.com/api/f5765b35508cf1489b0f5915a21b1891/forecast";       
        private HttpClient _client;

        public MSWService()
        {
            _client = new HttpClient();
        }

        public async Task<List<MSWData>> GetForecastAsync()
        {
            List<MSWData> list = null;

            var uriBuilder = new UriBuilder(Url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[MSWParameters.SpotId] = MSWParameters.LokkenSpotId;
            query[MSWParameters.Unit] = MSWParameters.EuropeanUnit;
            uriBuilder.Query = query.ToString();           
            var uri = uriBuilder.Uri;
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<MSWData>>(content);
            }

            return list;
        }
    }
}
