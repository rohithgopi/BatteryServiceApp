using SelectPdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatteryServiceApp.Pages
{
    public partial class GenerateQuote : System.Web.UI.Page
    {
        private bool startConversion = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblQuotation.Text = "Quotation No: " + Application["QuoteNo"].ToString();
            lblDate.Text = "Date : " + DateTime.Now.ToShortDateString();
            lblToAddress.Text = Application["QuoteTo"].ToString();
            lblItemTotal.Text = "Total : " + Application["PDFItemPrice"].ToString();
            lblNetPayable.Text = "Net Payable: " + Convert.ToString(Convert.ToInt32(Application["PDFItemPrice"].ToString()) - Convert.ToInt32(Application["PDFScrapPrice"].ToString())) + "/-";
            lblNetPayableWords.Text = ConvertNumbertoWords(Convert.ToInt32(Application["PDFItemPrice"].ToString()) - Convert.ToInt32(Application["PDFScrapPrice"].ToString())) + " ONLY";
            //Application["PDFMonth"]
            //Application["PdfDelivery"]
            if (DateTime.ParseExact(Application["PDFMonth"].ToString(), "MMMM", CultureInfo.CurrentCulture).Month >= Convert.ToInt32(DateTime.Now.ToString("MM")))
                lblDelivery.Text = Application["PDFMonth"].ToString() + " " + DateTime.Now.Year.ToString();
            else
                lblDelivery.Text = Application["PDFMonth"].ToString() + "" +DateTime.Now.AddYears(1).Year.ToString();
            lblValidity.Text = Application["PdfDelivery"].ToString();

            pnlScrapDetails.Style.Add("display", "none");
            if (Application["PDFScrapObject"] != null)
            {
                pnlScrapDetails.Style.Add("display", "block");
                lblScrapTotal.Text = "Total : " + Application["PDFScrapPrice"].ToString();
                GrvScrap.DataSource = Application["PDFScrapObject"];
                GrvScrap.DataBind();
            }

            GrvItem.DataSource = Application["PDFItemObject"];
            GrvItem.DataBind();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (startConversion)
            {
                // get html of the page
                TextWriter myWriter = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(myWriter);
                base.Render(htmlWriter);

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // create a new pdf document converting the html string of the page
                PdfDocument doc = converter.ConvertHtmlString(
                    myWriter.ToString(), Request.Url.AbsoluteUri);

                // save pdf document
                doc.Save(Response, false, "Sample.pdf");

                // close pdf document
                doc.Close();
            }
            else
            {
                // render web page in browser
                base.Render(writer);
            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            startConversion = true;
        }

        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " Lakhs ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}