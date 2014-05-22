using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace MySql
{
    public class MySqlServices
    {
        public DataTable AA(int startIndex,int count)
        {
                MySqlConnection myConnection = new MySqlConnection("server=lxismysql.mysql.rds.aliyuncs.com;port=3306;user id=dbn7wd778vj473e5;password=lixiang24;database=english_master;charset=utf8");
                myConnection.Open();
                //MySqlCommand command = new MySqlCommand("SELECT * FROM Article LIM", myConnection);
                MySqlDataAdapter adatper = new MySqlDataAdapter("SELECT * FROM Article LIMIT "+startIndex+","+count, myConnection);
                DataSet dataSet = new DataSet();
                adatper.Fill(dataSet);                                
                myConnection.Close();
                return dataSet.Tables[0];
        }
    }
}
