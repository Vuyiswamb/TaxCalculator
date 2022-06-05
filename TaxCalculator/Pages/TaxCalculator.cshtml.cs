
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using TaxCalculator.CommonFuntions;

namespace TaxCalculator.Pages
{
    public class TaxCalculatorModel : PageModel
    {

        [BindProperty]
        public TaxResults_Model Taxdata { get; set; }

        
        public  IActionResult OnPost()
        {
            if(ModelState.IsValid==false)
            {
                return Page();
            }

            //Call web api 
            ApiCalls? obj = new ApiCalls();
            try
            {
                 obj.CalculateTaxAsync(Taxdata);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                obj = null;

            } 
            return RedirectToPage("./TaxCalculator"); 
        }

        [BindProperty]
        public List<TaxResults_Model>? ResultsHistory { get; set; }
        public async Task<ActionResult> OnGetAsync()
        {  //Call web api 
            ApiCalls? obj = new ApiCalls();
            try
            {
                ResultsHistory = await obj.GetTaxCalcuation_History();

            }
            catch(Exception )
            { }
            finally
            {
                obj = null;
            }
            return Page();
        }
    }
}
