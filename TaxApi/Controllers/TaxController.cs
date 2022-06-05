
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using System.Web.Http;

namespace TaxApi.Controllers
{
    public class TaxController : ApiController
    {
 
            [HttpPost]
            [ActionName("CalculateTax")]
            public  void CalculateTax([FromBody] TaxResults_Model model)
        {
            Datalayer.Datalayer obj = new Datalayer.Datalayer();
 
            try
            { 
                  obj.CalculateTax(Convert.ToString(model.Annaul_Salary),model.postal_Code);
           
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
