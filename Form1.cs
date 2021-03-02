using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<Class1> add_data = new List<Class1>();

        public Form1()
        {



            InitializeComponent();
        }

        public void submit_Click(object sender, EventArgs e)
        {

            if (((Button)sender).Text == "submit")
            {
                Class1 objadd_data = new Class1();

                if (!string.IsNullOrEmpty(txt_name.Text))
                { objadd_data.name = txt_name.Text; }

                if (!string.IsNullOrEmpty(txt_phn.Text))
                { objadd_data.phnno = txt_phn.Text; }

                if (!string.IsNullOrEmpty(txt_address.Text))
                { objadd_data.address = txt_address.Text; }

                add_data.Add(objadd_data);


            }
            else if ((((Button)sender).Text == "Update"))
            {
                Class1 objuadd_datanew = add_data.Where(x => x.phnno == txt_phn.Text).FirstOrDefault();

                if (!string.IsNullOrEmpty(txt_name.Text))
                { objuadd_datanew.name = txt_name.Text; }

                if (!string.IsNullOrEmpty(txt_phn.Text))
                { objuadd_datanew.phnno = txt_phn.Text; }

                if (!string.IsNullOrEmpty(txt_address.Text))
                { objuadd_datanew.address = txt_address.Text; }


            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = add_data;
            txt_name.Text = string.Empty;
            txt_phn.Text = string.Empty;
            txt_address.Text = string.Empty;
            submit.Text = "submit";
            txt_phn.Enabled = true;

        }



        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int col_index = e.ColumnIndex;
            string col_header = dataGridView1.Columns[col_index].HeaderText;

            if (col_header == "EDIT")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string roll = (string)row.Cells[1].Value;

                Class1 myobjstu = add_data.Where(x => x.phnno == roll).FirstOrDefault();




                txt_name.Text = myobjstu.name;
                txt_phn.Text = myobjstu.phnno;
                txt_address.Text = myobjstu.address;
                submit.Text = "Update";
                txt_phn.Enabled = false;

            }
            if (col_header == "DELETE")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string roll = (string)row.Cells[1].Value;

                Class1 myobjstu = add_data.Where(x => x.phnno == roll).FirstOrDefault();

                add_data.Remove(myobjstu);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = add_data;
  
            }
        }

    }
}
   
