using System;
using System.Threading.Tasks;
using MarkApp.DataObjects;
using MarkApp.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MarkApp.Services
{
    public class ApiService:IApiService
    {
        #region Constructors
        public ApiService()
        {
        }
        #endregion

        #region Private Members
        private const string ApiUrl = "https://reqres.in";
        #endregion

        #region Implementations
        public async Task<bool> PostDataAsync(Diary diary)
        {
            bool IsSuccess = false;
            try
            {
                var payload = JsonConvert.SerializeObject(diary);
                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(new Uri(ApiUrl) + "api/Diary", httpContent);
                    IsSuccess = response.IsSuccessStatusCode;
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IsSuccess;
        }
        #endregion
    }
}
