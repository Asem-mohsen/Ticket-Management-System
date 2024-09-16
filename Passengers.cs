using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainMangementSystem
{
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
            Con = new functions();
            Con.Connection();
            showPassengers();

        }
        functions Con;

        private void showPassengers()
        {
            string Query = "SELECT * FROM Passengers";
            DataTable PassengersData = Con.GetData(Query);

            PassengersViewTable.DataSource = PassengersData;

        }

        private void clearInputs()
        {
            PassName.Text = string.Empty;
            email.Text = string.Empty;
            PhoneNum.Text = string.Empty;
            Password.Text = string.Empty;
            Address.Text = string.Empty;
            dob.Text = string.Empty;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Train Obj = new Train();
            Obj.Show();
            this.Hide();
        }

        private void AddPassenger_Click(object sender, EventArgs e)
        {
            bool isInvalidInput = string.IsNullOrEmpty(PassName?.Text) ||
                      string.IsNullOrEmpty(PhoneNum?.Text) ||
                      string.IsNullOrEmpty(Address?.Text) ||
                      (!radioButtonMale.Checked && !radioButtonFemale.Checked) ||
                      string.IsNullOrEmpty(dob?.Text) ||
                      string.IsNullOrEmpty(email?.Text) ||
                      string.IsNullOrEmpty(Password?.Text);
            if (isInvalidInput)
            {
                MessageBox.Show("Invalid Data !");
            }
            else
            {
                try
                {
                    string name       = PassName.Text;
                    string emailInput = email.Text;
                    string password   = Password.Text;
                    string phone      = PhoneNum.Text;
                    string genderInput= radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "";
                    string address    = Address.Text;
                    DateTime dobInput = DateTime.Parse(dob.Text);

                    string Query = "INSERT INTO Passengers VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                    Query = string.Format(Query, name, emailInput, password, genderInput, dobInput, phone, address);

                    Con.setData(Query);

                    MessageBox.Show("Passenger Added Successfully");

                    showPassengers();
                    clearInputs();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Drivers Obj = new Drivers();
            Obj.Show();
            this.Hide();
        }
    }
}
