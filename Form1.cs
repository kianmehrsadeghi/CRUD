using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        db humandb = new db();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = humandb.humans.ToList();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
        Human human = new Human() {FirstName=tbFirstName.Text,LastName=tbLastName.Text,Age=Convert.ToByte(tbAge.Text),NationalCode= tbNationalCode.Text};
        bool b = human.register(human);
            if (b == true)
            {
                MessageBox.Show("Registered successfully.");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = humandb.humans.ToList();
            }
            else
            {
                MessageBox.Show("This national code exists in the database.");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Human human = new Human();
                if (tbSearch.Text == string.Empty)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = human.readall();
                }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readname(tbSearch.Text);
            }
            }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            MessageBox.Show(Convert.ToString(id));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Human human = new Human();
            int id = Convert.ToInt32(tbID.Text);
            DialogResult warning = MessageBox.Show("Are you sure you want to delete this row? This action is irreversible.", "Warning", MessageBoxButtons.YesNo);
            if (warning == DialogResult.Yes)
            {
                human.delete(id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readall();
            }
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult warning = MessageBox.Show("Are you sure you want to change this row?", "Warning", MessageBoxButtons.YesNo);
            if (warning == DialogResult.Yes)
            {
                Human human = new Human() { FirstName=tbFirstName.Text,LastName=tbLastName.Text,Age=Convert.ToByte(tbAge.Text),NationalCode=tbNationalCode.Text};
                int id = Convert.ToInt32(tbIDUpdate.Text);
                human.update(human, id);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readall();
            }
        }
    }
    }
