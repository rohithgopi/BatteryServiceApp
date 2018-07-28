using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SelectPdf;

namespace BatteryServiceApp.Pages
{
    public partial class Quote : System.Web.UI.Page
    {
        private int ctr = 1;
        private int scrapCtr = 1;
        Table table = null;
        Table scrapTable = null;
        public int itemCount = 0;
        public int scrapCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlScrapPanel.Attributes.Add("display", "none");
                    BtnAddScrap.Visible = false;
                    table = new Table();
                    table.ID = "tableBuild";
                    Session["table"] = table;
                    ViewState["ctr"] = ctr;
                    
                }
                ctr = (Int32)ViewState["ctr"];
                if(ViewState["scrapCtr"] != null)
                    scrapCtr = (Int32)ViewState["scrapCtr"];
                table = (Table)Session["table"];
                if(Session["scrapTable"] != null)
                    scrapTable = (Table)Session["scrapTable"];
                if (scrapTable != null)
                    pnlScrapPanel.Controls.Add(scrapTable);
                pnlQuotePanel.Controls.Add(table);
                if (!IsPostBack)
                    GenerateTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void GenerateTable()
        {
            try
            {
                Table tableItem = new Table();
                tableItem.ID = "tblItem" + ctr;
                TableRow tblItem = new TableRow();
                TableCell cellItem = new TableCell();

                Panel pnlTable = new Panel();
                pnlTable.ID = "pnlItem" + ctr;
                pnlTable.CssClass = "panel";
                pnlTable.BorderColor = System.Drawing.Color.CadetBlue;
                pnlTable.BorderWidth = 1;
                pnlTable.BorderStyle = BorderStyle.Solid;
                pnlTable.GroupingText = "Item " + ctr;

                //Row & Cell Item
                TableRow rowItem = new TableRow();
                TableCell cellItemLabel = new TableCell();
                TableCell cellItemText = new TableCell();
                cellItemText.ColumnSpan = 4;
                TextBox txtItem = new TextBox();
                Label lblItem = new Label();
                lblItem.ID = "lblItem" + ctr;
                lblItem.Text = "Description : ";
                cellItemLabel.Controls.Add(lblItem);
                rowItem.Cells.Add(cellItemLabel);
                txtItem.ID = "txtItem" + ctr;
                txtItem.Attributes.Add("class","form - control");
                txtItem.Width = Unit.Percentage(100);
                cellItemText.Controls.Add(txtItem);
                rowItem.Cells.Add(cellItemText);
                //tableItem.Rows.Add(rowItem);

                //Cell Quantity
                TableCell cellQuantityLabel = new TableCell();
                TableCell cellQuantityText = new TableCell();
                cellQuantityLabel.HorizontalAlign = HorizontalAlign.Right;
                TextBox txtQuantity = new TextBox();
                Label lblQuantity = new Label();
                cellQuantityText.ColumnSpan = 2;
                lblQuantity.ID = "lblQuantity" + ctr;
                lblQuantity.Text = "Quantity : ";
                cellQuantityLabel.Controls.Add(lblQuantity);
                rowItem.Cells.Add(cellQuantityLabel);
                txtQuantity.ID = "txtQuantity" + ctr;
                txtQuantity.TextMode = TextBoxMode.Number;
                txtQuantity.Width = 140;
                txtQuantity.CssClass = "form - control";
                cellQuantityText.Controls.Add(txtQuantity);
                rowItem.Cells.Add(cellQuantityText);
                tableItem.Rows.Add(rowItem);

                //2nd Row
                //Cell Unit
                TableRow rowUnit = new TableRow();
                TableCell cellUnitLabel = new TableCell();
                cellUnitLabel.Width = 90;
                TableCell cellUnitText = new TableCell();
                TextBox txtUnit = new TextBox();
                Label lblUnit = new Label();
                lblUnit.ID = "lblUnit" + ctr;
                lblUnit.Text = "Unit Price: ";
                cellUnitLabel.Controls.Add(lblUnit);
                rowUnit.Cells.Add(cellUnitLabel);
                txtUnit.ID = "txtUnit" + ctr;
                txtUnit.Width = 100;
                txtUnit.TextMode = TextBoxMode.Number;
                txtUnit.CssClass = "form - control";
                cellUnitText.Controls.Add(txtUnit);
                rowUnit.Cells.Add(cellUnitText);
                //tableItem.Rows.Add(rowItem);

                //Cell HSN
                TableCell cellHSNLabel = new TableCell();
                TableCell cellHSNText = new TableCell();
                cellHSNLabel.Width = 90;
                cellHSNLabel.HorizontalAlign = HorizontalAlign.Center;
                TextBox txtHSN = new TextBox();
                Label lblHSN = new Label();
                lblHSN.ID = "lblHSN" + ctr;
                lblHSN.Text = "HSN Code : ";
                cellHSNLabel.Controls.Add(lblHSN);
                rowUnit.Cells.Add(cellHSNLabel);
                txtHSN.ID = "txtHSN" + ctr;
                txtHSN.Width = 140;
                cellHSNText.Controls.Add(txtHSN);
                rowUnit.Cells.Add(cellHSNText);

                //Cell Warranty
                TableCell cellWarrantyLabel = new TableCell();
                TableCell cellWarrantyDropDown = new TableCell();
                cellWarrantyLabel.Width = 90;
                cellWarrantyLabel.HorizontalAlign = HorizontalAlign.Center;
                DropDownList ddlWarranty = new DropDownList();
                Label lblWarranty = new Label();
                lblWarranty.ID = "lblWarranty" + ctr;
                lblWarranty.Text = "Warranty : ";
                cellWarrantyLabel.Controls.Add(lblWarranty);
                rowUnit.Cells.Add(cellWarrantyLabel);
                ddlWarranty.ID = "ddlWarranty" + ctr;
                ddlWarranty.Items.Insert(0, new ListItem() { Text = "None", Value = "None" });
                ddlWarranty.Items.Insert(1, new ListItem() { Text = "3 Months", Value = "3 Months" });
                ddlWarranty.Items.Insert(2, new ListItem() { Text = "6 Months", Value = "6 Months" });
                ddlWarranty.Items.Insert(3, new ListItem() { Text = "9 Months", Value = "9 Months" });
                ddlWarranty.Items.Insert(4, new ListItem() { Text = "1 Year", Value = "1 Year" });
                ddlWarranty.Items.Insert(5, new ListItem() { Text = "2 Years", Value = "2 Years" });
                ddlWarranty.Items.Insert(6, new ListItem() { Text = "3 Years", Value = "3 Years" });
                ddlWarranty.Items.Insert(7, new ListItem() { Text = "4 Years", Value = "4 Years" });
                ddlWarranty.Items.Insert(8, new ListItem() { Text = "5 Years", Value = "5 Years" });
                ddlWarranty.Width = 140;
                cellWarrantyDropDown.Controls.Add(ddlWarranty);
                rowUnit.Cells.Add(cellWarrantyDropDown);

                //Cell GST
                TableCell cellGSTLabel = new TableCell();
                TableCell cellGSTDropDown = new TableCell();
                cellGSTLabel.Width = 90;
                cellGSTLabel.HorizontalAlign = HorizontalAlign.Center;
                DropDownList ddlGST = new DropDownList();
                Label lblGST = new Label();
                lblGST.ID = "lblGST" + ctr;
                lblGST.Text = "GST % : ";
                cellGSTLabel.Controls.Add(lblGST);
                rowUnit.Cells.Add(cellGSTLabel);
                ddlGST.ID = "ddlGST" + ctr;
                ddlGST.Items.Insert(0, new ListItem() { Text = "5", Value = "5" });
                ddlGST.Items.Insert(1, new ListItem() { Text = "18", Value = "18" });
                ddlGST.Items.Insert(2, new ListItem() { Text = "28", Value = "28" });
                ddlGST.Width = 100;
                cellGSTDropDown.Controls.Add(ddlGST);
                rowUnit.Cells.Add(cellGSTDropDown);

                tableItem.Rows.Add(rowUnit);

                pnlTable.Controls.Add(tableItem);
                cellItem.Controls.Add(pnlTable);
                tblItem.Cells.Add(cellItem);
                table.Rows.Add(tblItem);

                //pnlQuotePanel.Controls.Add(pnlTable);
                ctr++;
                Session["table"] = table;
                ViewState["ctr"] = ctr;

                itemCount = itemCount + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneratecrapTable()
        {
            try
            {
                Table tableItem = new Table();
                tableItem.ID = "tblScrapItem" + scrapCtr;
                TableRow tblItem = new TableRow();
                TableCell cellItem = new TableCell();

                Panel pnlTable = new Panel();
                pnlTable.ID = "pnlScrapItem" + scrapCtr;
                pnlTable.CssClass = "panel";
                pnlTable.BorderColor = System.Drawing.Color.CadetBlue;
                pnlTable.BorderWidth = 1;
                pnlTable.BorderStyle = BorderStyle.Solid;
                pnlTable.GroupingText = "Scrap " + scrapCtr;

                
                //Row & Cell Item
                TableRow rowItem = new TableRow();
                TableCell cellItemLabel = new TableCell();
                TableCell cellItemText = new TableCell();
                TextBox txtItem = new TextBox();
                Label lblItem = new Label();
                lblItem.ID = "lblScrapItem" + scrapCtr;
                lblItem.Text = "Description : ";
                cellItemLabel.Controls.Add(lblItem);
                rowItem.Cells.Add(cellItemLabel);
                txtItem.ID = "txtScrapItem" + scrapCtr;
                txtItem.Width = Unit.Percentage(100);
                txtItem.CssClass = "form - control";
                cellItemText.Controls.Add(txtItem);
                rowItem.Cells.Add(cellItemText);
                //tableItem.Rows.Add(rowItem);

                //Cell Quantity
                TableCell cellQuantityLabel = new TableCell();
                TableCell cellQuantityText = new TableCell();
                cellQuantityLabel.HorizontalAlign = HorizontalAlign.Right;
                TextBox txtQuantity = new TextBox();
                Label lblQuantity = new Label();
                lblQuantity.ID = "lblScrapQuantity" + scrapCtr;
                lblQuantity.Text = "Quantity : ";
                cellQuantityLabel.Controls.Add(lblQuantity);
                rowItem.Cells.Add(cellQuantityLabel);
                txtQuantity.ID = "txtScrapQuantity" + scrapCtr;
                txtQuantity.TextMode = TextBoxMode.Number;
                txtQuantity.Width = 140;
                txtQuantity.CssClass = "form - control";
                cellQuantityText.Controls.Add(txtQuantity);
                rowItem.Cells.Add(cellQuantityText);
                tableItem.Rows.Add(rowItem);

                //2nd Row
                //Cell Unit
                TableRow rowUnit = new TableRow();
                TableCell cellUnitLabel = new TableCell();
                cellUnitLabel.Width = 90;
                TableCell cellUnitText = new TableCell();
                TextBox txtUnit = new TextBox();
                Label lblUnit = new Label();
                lblUnit.ID = "lblScrapUnit" + scrapCtr;
                lblUnit.Text = "Unit : ";
                cellUnitLabel.Controls.Add(lblUnit);
                rowUnit.Cells.Add(cellUnitLabel);
                txtUnit.ID = "txtScrapUnit" + scrapCtr;
                txtUnit.Width = 100;
                txtUnit.TextMode = TextBoxMode.Number;
                txtUnit.CssClass = "form - control";
                cellUnitText.Controls.Add(txtUnit);
                rowUnit.Cells.Add(cellUnitText);
                //tableItem.Rows.Add(rowItem);

                //Cell HSN
                TableCell cellHSNLabel = new TableCell();
                TableCell cellHSNText = new TableCell();
                cellHSNLabel.Width = 90;
                cellHSNLabel.HorizontalAlign = HorizontalAlign.Center;
                TextBox txtHSN = new TextBox();
                Label lblHSN = new Label();
                lblHSN.ID = "lblScrapHSN" + scrapCtr;
                lblHSN.Text = "HSN Code : ";
                cellHSNLabel.Controls.Add(lblHSN);
                rowUnit.Cells.Add(cellHSNLabel);
                txtHSN.ID = "txtScrapHSN" + scrapCtr;
                txtHSN.Width = 140;
                cellHSNText.Controls.Add(txtHSN);
                rowUnit.Cells.Add(cellHSNText);

                tableItem.Rows.Add(rowUnit);

                pnlTable.Controls.Add(tableItem);
                cellItem.Controls.Add(pnlTable);
                tblItem.Cells.Add(cellItem);
                scrapTable.Rows.Add(tblItem);

                //pnlQuotePanel.Controls.Add(pnlTable);
                scrapCtr++;

                Session["scrapTable"] = scrapTable;
                ViewState["scrapCtr"] = scrapCtr;

                scrapCount = scrapCount + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            GenerateTable();
        }

        protected void chkScrap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScrap.Checked)
            {
                pnlScrapPanel.Attributes.Add("display","block");
                BtnAddScrap.Visible = true;

                scrapTable = new Table();
                scrapTable.ID = "tableScrap";
                Session["scrapTable"] = scrapTable;
                ViewState["scrapCtr"] = scrapCtr;
                pnlScrapPanel.Controls.Add(scrapTable);
                GeneratecrapTable();
            }
            else
            {
                scrapTable = null;
                scrapCtr = 1;
                Session["scrapTable"] = null;
                ViewState["scrapCtr"] = null;
                pnlScrapPanel.Visible = false;
                BtnAddScrap.Visible = false;
            }
        }

        protected void BtnAddScrap_Click(object sender, EventArgs e)
        {
            GeneratecrapTable();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            itemCount = ctr - 1;
            scrapCount = scrapCtr - 1;

            Application["PDFItemObject"] = null;
            Application["PDFItemPrice"] = null;
            Application["PDFScrapObject"] = null;
            Application["PDFScrapPrice"] = 0;
            Application["PDFMonth"] = ddlMonth.SelectedValue;
            Application["PdfDelivery"] = ddlDelivery.SelectedValue;
            Application["QuoteTo"] = txtQuoteAddress.Text.Replace("\n", "<br>");
            Application["QuoteNo"] = txtQuoteNumber.Text;
            int total = 0;
            int scrapTotal = 0;

            DataTable dtItemData = new DataTable();
            dtItemData.Columns.Add("No");
            dtItemData.Columns.Add("Qty");
            dtItemData.Columns.Add("HsnCode");
            dtItemData.Columns.Add("Description");
            dtItemData.Columns.Add("UnitPrice");
            dtItemData.Columns.Add("Gst");
            dtItemData.Columns.Add("GstRate");
            dtItemData.Columns.Add("NetPrice");
            dtItemData.Columns.Add("Warranty");
            dtItemData.Columns.Add("TotalPrice");

            DataTable dtScrapData = new DataTable();
            dtScrapData.Columns.Add("No");
            dtScrapData.Columns.Add("Qty");
            dtScrapData.Columns.Add("HsnCode");
            dtScrapData.Columns.Add("Description");
            dtScrapData.Columns.Add("UnitPrice");
            dtScrapData.Columns.Add("Gst");
            dtScrapData.Columns.Add("GstRate");
            dtScrapData.Columns.Add("NetPrice");
            dtScrapData.Columns.Add("TotalPrice");

            if (scrapCount > 0)
            {
                for (int scrapItem = 1; scrapItem <= scrapCount; scrapItem++)
                {
                    string sItem = string.Empty;
                    string sQuantity = string.Empty;
                    string sUnit = string.Empty;
                    string sHSN = string.Empty;
                    string sWarranty = string.Empty;
                    int iGst = 0;

                    int GstRate = 0;

                    sItem = ((TextBox)scrapTable.FindControl("pnlScrapItem" + Convert.ToString(scrapItem)).FindControl("txtScrapItem" + Convert.ToString(scrapItem))).Text;
                    sQuantity = ((TextBox)scrapTable.FindControl("pnlScrapItem" + Convert.ToString(scrapItem)).FindControl("txtScrapQuantity" + Convert.ToString(scrapItem))).Text;
                    sUnit = ((TextBox)scrapTable.FindControl("pnlScrapItem" + Convert.ToString(scrapItem)).FindControl("txtScrapUnit" + Convert.ToString(scrapItem))).Text;
                    sHSN = ((TextBox)scrapTable.FindControl("pnlScrapItem" + Convert.ToString(scrapItem)).FindControl("txtScrapHSN" + Convert.ToString(scrapItem))).Text;
                    iGst = 18;
                    GstRate = (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity)) * (iGst) / 100;

                    DataRow dr = dtScrapData.NewRow();
                    dr["No"] = scrapItem;
                    dr["Qty"] = sQuantity;
                    dr["HsnCode"] = sHSN;
                    dr["Description"] = sItem;
                    dr["UnitPrice"] = sUnit;
                    dr["Gst"] = iGst;
                    dr["GstRate"] = GstRate;
                    dr["NetPrice"] = (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));
                    
                    dr["TotalPrice"] = GstRate + (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));

                    dtScrapData.Rows.Add(dr);

                    scrapTotal = scrapTotal + GstRate + (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));

                }
                Application["PDFScrapObject"] = dtScrapData;
                Application["PDFScrapPrice"] = scrapTotal;
            }

            if (itemCount > 0)
            {
                for (int item = 1; item <= itemCount; item++)
                {
                    string sItem = string.Empty;
                    string sQuantity = string.Empty;
                    string sUnit = string.Empty;
                    string sHSN = string.Empty;
                    string sWarranty = string.Empty;
                    string sGst = string.Empty;

                    int GstRate = 0;

                    sItem = ((TextBox)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("txtItem"  +Convert.ToString(item))).Text;
                    sQuantity = ((TextBox)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("txtQuantity" + Convert.ToString(item))).Text;
                    sUnit = ((TextBox)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("txtUnit" + Convert.ToString(item))).Text;
                    sHSN = ((TextBox)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("txtHSN" + Convert.ToString(item))).Text;
                    sWarranty = ((DropDownList)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("ddlWarranty" + Convert.ToString(item))).SelectedValue;
                    sGst = ((DropDownList)table.FindControl("pnlItem" + Convert.ToString(item)).FindControl("ddlGST" + Convert.ToString(item))).SelectedValue;
                    GstRate = (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity)) * (Convert.ToInt32(sGst)) / 100;

                    DataRow dr =  dtItemData.NewRow();
                    dr["No"] = item;
                    dr["Qty"] = sQuantity;
                    dr["HsnCode"] = sHSN;
                    dr["Description"] = sItem;
                    dr["UnitPrice"] = sUnit;
                    dr["Gst"] = sGst;
                    dr["GstRate"] = GstRate;
                    dr["NetPrice"] = (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));
                    dr["Warranty"] = sWarranty;
                    dr["TotalPrice"] = GstRate + (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));

                    dtItemData.Rows.Add(dr);

                    total = total + GstRate + (Convert.ToInt32(sUnit) * Convert.ToInt32(sQuantity));

                }
                Application["PDFItemPrice"] = total;
                Application["PDFItemObject"] = dtItemData;
                Session["table"] = table;
                ViewState["ctr"] = ctr;
                Session["scrapTable"] = scrapTable;
                ViewState["scrapCtr"] = scrapCtr;

                string url = Request.Url.AbsoluteUri.Replace("Quote","") + "GenerateQuote.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=1000,height=800,left=100,top=100,resizable=yes');";
                ScriptManager.RegisterStartupScript(this,this.GetType(), "script", s, true);


            }

        }
    }
}