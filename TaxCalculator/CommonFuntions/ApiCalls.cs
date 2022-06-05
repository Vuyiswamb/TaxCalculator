 
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.CommonFuntions
{
    public class ApiCalls
    {
        static readonly HttpClient httpClienta = new HttpClient();
        public async Task CalculateTaxAsync(TaxResults_Model model)
        {
            try
            {

                httpClienta.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClienta.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                 
                var Json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = false
                    }
                }); 

                HttpContent httpContent = new StringContent(Json, Encoding.UTF8, "application/json");

                var response = await httpClienta.PostAsync(string.Format("http://api.vimalsoft.com/api/Tax/CalculateTax"), httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                     
                }

            }
            catch (Exception ex)
            { 
                //log error 
            }
        }


        public async Task<List<TaxResults_Model>> GetTaxCalcuation_History()
        {

            List<TaxResults_Model> results = null;


            try
            {
                TaxResults_Model model = new TaxResults_Model();
                httpClienta.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClienta.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var Json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = false
                    }
                });

                HttpContent httpContent = new StringContent(Json, Encoding.UTF8, "application/json");

                var response = await httpClienta.PostAsync(string.Format("http://api.vimalsoft.com/api/GetTax/GetTaxCalcuation_History"), httpContent);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                     results = JsonConvert.DeserializeObject<List<TaxResults_Model>>(content);
                }

            }
            catch (Exception ex)
            {   //log error 
            }

            return results;
        }



    }
}
