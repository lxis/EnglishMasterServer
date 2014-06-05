using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        myButton.InnerText = "yyy";
        

        DataTable dataSet = new MySqlServices().AA(1,100);
        GridView1.DataSource = dataSet;
        GridView1.DataBind();

    }
}