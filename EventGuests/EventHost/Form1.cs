using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace EventHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            lstCategory.Text = "";
        }

        public string connectionString = @"data source=localhost\SQLEXPRESS; initial catalog=Dishes_For_Guests;  integrated security = SSPI; persist security info=False;";

        public SqlConnection connection;

        public bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void AddCategory(string category)
        {
            string insert = "declare @categoryCode int\r\nif not exists (select code from Categories where @categoryName = CategoryName)\r\nbegin \r\n\tinsert into Categories values(@categoryName)\r\n\tselect @categoryCode = @@IDENTITY\r\nend";

            if (!Connect()) return;
            SqlCommand command = new SqlCommand(insert, connection);
            command.Parameters.AddWithValue("@categoryName", txtCategory.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ShowAllCategories()
        {
            if (!Connect()) return;
            string select = "select CategoryName from Categories";
            SqlCommand command = new SqlCommand(select, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstCategory.Items.Add(reader[0].ToString());
                }
            }

            connection.Close();
        }

        private void ShowSumOfOrders()
        {
            string select = "select Name as 'שם מאכל', COUNT(*) as 'כמות הזמנות' from Foods group by Name";
            SqlDataAdapter adapter = new SqlDataAdapter(select, connectionString);

            DataTable table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void enterBtn_Click(object sender, EventArgs e)
        {
            AddCategory(txtCategory.Text);
            ShowAllCategories();
            txtCategory.Text = "";
            ShowSumOfOrders();
        }
    }
}
