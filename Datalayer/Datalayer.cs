using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class Datalayer
    {
        #region Connection objects 
        static readonly string strCon = "Data Source=.;Initial Catalog=TaxCalculator;User ID=taxuser;Password=taxuser;connect timeout=0;Max Pool Size=20000";
//        static readonly string strCon = "Data Source=.;Initial Catalog=TaxCalculator;User ID=taxuser;Password=taxuser;connect timeout=0;Max Pool Size=20000";

        SqlConnection con; 
        SqlCommand cmd;
        SqlDataAdapter da;
        #endregion

        public void CalculateTax(string Annual_Income , string Postal_Code)
        {
            con = new SqlConnection(strCon);

            cmd = new SqlCommand();

            cmd.CommandText = "[dbo].[spx_Calculate_Tax]";

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = con; cmd.CommandTimeout = 0;

            cmd.Parameters.Add("@ANNUAL_INCOME", SqlDbType.Int).Value = Annual_Income;

            cmd.Parameters.Add("@POSTAL_CODE", SqlDbType.NVarChar).Value = Postal_Code; 
            try
            {
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public List<TaxResults_Model> GetTaxCalcuation_History()
        {
            con = new SqlConnection(strCon);
            cmd = new SqlCommand();
            cmd.CommandText = "[dbo].[spx_GetTaxCalcuation_History]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con; cmd.CommandTimeout = 0;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            List<TaxResults_Model> m_List = new List<TaxResults_Model>();
            try
            {
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TaxResults_Model m = new TaxResults_Model();
                        m.RESULTS_ID = Convert.ToInt32(dt.Rows[i]["RESULTS_ID"]);
                        m.Rate = Convert.ToInt32(dt.Rows[i]["RATE"]);
                        m.ADD_DATE = Convert.ToDateTime(dt.Rows[i]["ADD_DATE"]);
                        m.postal_Code = Convert.ToString(dt.Rows[i]["POSTAL_CODE"]);
                        m.Annaul_Salary = Convert.ToString(dt.Rows[i]["ANNUAL_INCOME"]);
                        m.Taxed_Amount = Convert.ToDecimal(dt.Rows[i]["Taxed_Amount"]);
                        m_List.Add(m);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return m_List;
        }

        

   
    }
}
