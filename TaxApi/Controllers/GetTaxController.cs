
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace TaxApi.Controllers
{
    public class GetTaxController : ApiController
    {
 
            [HttpPost]
            [ActionName("GetTaxCalcuation_History")]
            public  List<TaxResults_Model> GetTaxCalcuation_History([FromBody] TaxResults_Model model)
        {
            Datalayer.Datalayer obj = new Datalayer.Datalayer();
 
            try
            { 
                 return obj.GetTaxCalcuation_History();
           
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                obj = null;
            } 

        }

   
    }
}
