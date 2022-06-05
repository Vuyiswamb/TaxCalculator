using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {


        [HttpPost]
        public  void CalculateTax([FromBody] TaxResults_Model model)
        {
            Datalayer.Datalayer? obj = new Datalayer.Datalayer();
 
            try
            { 
                  obj.CalculateTax(model.Annaul_Salary,model.postal_Code);
           
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
