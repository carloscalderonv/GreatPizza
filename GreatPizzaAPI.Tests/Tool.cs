using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreatPizzaAPI.Tests
{
    public static class Tool
    {
        public static async Task<Tout> ReadAsAsync<Tout>(this System.Net.Http.HttpContent content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Tout>(await content.ReadAsStringAsync());
        }
    }
}
