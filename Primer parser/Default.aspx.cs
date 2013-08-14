using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Primer_parser
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadButton1Click(object sender, EventArgs e)
        {
            RadTextBox2.Visible = false;
            RadGrid1.Visible = false;
            RadTextBox3.Visible = false;
            Label2.Visible = false;

            var helper = new Helper();
            var cosito = helper.DigoTrue(RadTextBox1.Text);
            //RadTextBox2.Text = cosito;
            if (cosito.Any())
            {
                RadGrid1.DataSource = cosito;
                RadGrid1.DataBind();
                RadGrid1.Visible = true;
                RadTextBox3.Text = cosito.Count.ToString();
                RadTextBox3.Visible = true;
                Label2.Visible = true;
            }
            else
            {
                RadTextBox2.Text = "Algo salio mal.. revisar url";
                RadTextBox2.Visible = true;
            }
          
        }
    }
}