namespace Models
{
    public class TaxResults_Model
    {
        public int RESULTS_ID { get; set; }
        public string postal_Code { get; set; }

        public decimal Rate { get; set; }

        public string Annaul_Salary { get; set; }

        public DateTime ADD_DATE { get; set; }

        public decimal Taxed_Amount { get; set; }

    }
}