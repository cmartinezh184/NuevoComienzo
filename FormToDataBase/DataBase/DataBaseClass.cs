using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FormToDataBase.DataBase
{
    class Class1
    {


        private bool (){
            HtmlElement htmlelement = web.Document.GetElementById("userInfoNav");
            if (htmlelement == null)
            {
                return;
            }
            else
            {
                statsTextBox.Text = web.Document.GetElementById("userInfoNav").OuterText;
            }

}

        private void Agregar()
        {
            string connetionString = null;
            string sql = null;
            connetionString = "Data Source=DESKTOP-ULLHLPN;Initial Catalog=DBForm;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "insert into Main ([Firt Name], [Last Name]) values(@first,@last)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@first", textbox2.text);
                    cmd.Parameters.AddWithValue("@last", textbox3.text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");
                }
            }
        }

    }
}
