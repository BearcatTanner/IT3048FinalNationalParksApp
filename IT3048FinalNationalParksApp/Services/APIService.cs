using IT3048FinalNationalParksApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT3048FinalNationalParksApp.Services
{
    internal class APIService
    {
        public async Task<Parks> GETPark(string ActivityName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=OH%2CIN%2CKY&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
    }
}
