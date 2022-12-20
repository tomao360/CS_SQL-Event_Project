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
    public partial class frmCategory : Form
    {
        static List<frmCategory> brothers;
        frmGuests parent;
        int index;
        public frmCategory(frmGuests Parent, string GuestName, string CategoryName, int Index)
        {
            InitializeComponent();
            parent = Parent;
            index = Index;
            lblGuestName.Text = GuestName;
            lblCategory.Text = CategoryName;
            ShowAllGuestsSelections();
            ShowCurrentGuestSelections();
        }

        public List<frmCategory> Brothers
        {
            set { brothers = value; }
        }

        // פונקציה המוסיפה מאכל לפי האורח ולפי הקטגוריה
        private void AddFood(string food)
        {
            string insert = "declare @guestCode int, @categoryCode int\r\nif exists(select code from Guests where GuestName = @guestName)\r\nbegin \r\n\tselect @guestCode = (select code from Guests where GuestName = @guestName)\r\nend\r\nelse\r\nbegin\r\n\tinsert into Guests values(@guestName)\r\n\tselect @guestCode = @@IDENTITY\r\nend\r\n\r\nif exists(select code from Categories where CategoryName = @categoryName)\r\nbegin \r\n\tselect @categoryCode = (select code from Categories where CategoryName = @categoryName)\r\n\tinsert into Foods values(@guestCode, @categoryCode, @foodName)\r\nend";

            if (!parent.Connect()) return;
            SqlCommand command = new SqlCommand(insert, parent.connection);
            command.Parameters.AddWithValue("@guestName", lblGuestName.Text);
            command.Parameters.AddWithValue("@categoryName", lblCategory.Text);
            command.Parameters.AddWithValue("@foodName", food);
            command.ExecuteNonQuery();
            parent.connection.Close();

            ShowAllGuestsSelections();
            ShowCurrentGuestSelections();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible= false;
            if (index > 0)
            {
                brothers[index-1].Visible = true;
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Visible = false;
            if (index < brothers.Count - 1)
            {
                brothers[index + 1].Visible = true;
            } 
            
        }

        private void ShowAllGuestsSelections()
        {
            string select = "select Guests.GuestName as 'שם אורח', Categories.CategoryName as 'שם קטגוריה',\r\nFoods.Name as 'שם מאכל' from Guests\r\ninner join Foods on Guests.code = Foods.GuestCode\r\ninner join Categories on Categories.code = Foods.CategoryCode";

            SqlDataAdapter adapter = new SqlDataAdapter(select, parent.connectionString);

            DataTable table = new DataTable();  
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void ShowCurrentGuestSelections()
        {
            string select = "select Guests.GuestName as 'שם אורח', Categories.CategoryName as 'שם קטגוריה',\r\nFoods.Name as 'שם מאכל' from Guests\r\ninner join Foods on Guests.code = Foods.GuestCode\r\ninner join Categories on Categories.code = Foods.CategoryCode\r\nwhere Categories.CategoryName = '" + lblCategory.Text + "' and Guests.GuestName = '" + lblGuestName.Text + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(select, parent.connectionString);

            // יצירת טבלה בזיכרון
            DataTable table = new DataTable();
            // מילוי הנתונים לתוך הטבלה הזמנית בזיכרון
            adapter.Fill(table);
            dataGridView2.DataSource = table;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            txtAddFood.Visible = true;
            btnOkAddFood.Visible = true;
        }

        private void btnOkAddFood_Click(object sender, EventArgs e)
        {
            txtAddFood.Visible = false;
            btnOkAddFood.Visible = false;
            AddFood(txtAddFood.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddFood(dataGridView1[2, e.RowIndex].Value.ToString());
        }
    }
}
