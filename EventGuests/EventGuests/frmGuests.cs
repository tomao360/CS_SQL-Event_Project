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

namespace EventGuests
{
    public partial class frmGuests : Form
    {
        public frmGuests()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            showALlGuests("");
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

        private void enterGuest(string name)
        {
            if (!Connect()) return;
            string insert = "if not exists (select * from Guests where GuestName = @guestName)\r\nbegin\r\n\tinsert into Guests values(@guestName)\r\nend";
            SqlCommand command = new SqlCommand(insert, connection);
            command.Parameters.AddWithValue("@guestName", name);
            try
            {
                int number = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

        }

        private void showALlGuests(string name)
        {
            GuestListBox.Items.Clear();

            if (!Connect()) return;
            string select = "select GuestName from Guests where GuestName like '%" + name + "%'";
            SqlCommand command = new SqlCommand(select, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GuestListBox.Items.Add(reader[0].ToString());
                }
            }

            connection.Close();
        }

        private void GuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuestNameTextBox.Text = GuestListBox.Text;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (GuestNameTextBox.Text == "") return;
            enterGuest(GuestNameTextBox.Text);
            CreateFormsByCategories(GuestNameTextBox.Text);
            GuestNameTextBox.Text = "";
        }

        private void GuestNameTextBox_TextChanged(object sender, EventArgs e)
        {
            showALlGuests(GuestNameTextBox.Text);
        }

        // פונקציה הפותחת טפסים לפי הקטגוריות בטבלה במסד נתונים
        private void CreateFormsByCategories(string guestName)
        {
            string select = "select CategoryName from Categories";
            if (!Connect() ) return;
            SqlCommand command = new SqlCommand(select, connection);
            SqlDataReader reader = command.ExecuteReader();

            // רשימת טפסים
            List<frmCategory> categories= new List<frmCategory>();

            int index = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // בניית טופס חדש לכל קטגוריה במערך ולהכניסו לרשימה של הטפסים
                    categories.Add(new frmCategory(this, guestName, reader[0].ToString(), index++));
                }

                categories.First().Brothers = categories;
                categories.First().Show();

            }

            connection.Close();
        }
    }
}
