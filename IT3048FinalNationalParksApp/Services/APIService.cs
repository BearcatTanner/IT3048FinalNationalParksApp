using IT3048FinalNationalParksApp.Models;
using Newtonsoft.Json;

namespace IT3048FinalNationalParksApp.Services
{
    internal class APIService
    {
        public async Task<Parks> GETParksOH()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=OH&" +
                $"&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
        public async Task<Parks> GETParksQueryOH(string query)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=OH&q=" +
                $"{query}&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
        public async Task<Parks> GETParksIN()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=IN&" +
                $"&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
        public async Task<Parks> GETParksQueryIN(string query)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=IN&q=" +
                $"{query}&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
        public async Task<Parks> GETParksKy()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=IN&" +
                $"&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
        public async Task<Parks> GETParksQueryKY(string query)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync
                ($"https://developer.nps.gov/api/v1/parks?stateCode=IN&q=" +
                $"{query}&api_key=tanbDLVroQ7S3zgYdIiTSD0XvXJFFapIGmghgRzK");
            return JsonConvert.DeserializeObject<Parks>(response);
        }
    }
}