using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrainMangementSystem
{
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
            Con = new functions();
            Con.Connection();

            ShowDriver();
            loadTrainCodes();
        }

        functions Con;

        private void ShowDriver()
        {
            string query = "SELECT * FROM Drivers";
            
            DataTable DriversData = Con.GetData(query);
            DriversViewTable.DataSource = DriversData;

        }

        private void loadTrainCodes()
        {
            string query = "SELECT number, trainCode FROM Trains";

            DataTable trainCodesData = Con.GetData(query);

            trainCodes.DataSource = trainCodesData;
            trainCodes.DisplayMember = "number";
            trainCodes.ValueMember = "trainCode";

        }

        private void clearInputs()
        {
            DriverName.Text = string.Empty;
            trainCodes.Text = string.Empty;
            PhoneNum.Text = string.Empty;
            Address.Text = string.Empty;
            dob.Text = string.Empty;

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Train Obj = new Train();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Passengers Obj = new Passengers();
            Obj.Show();
            this.Hide();
        }

        private void AddPassenger_Click(object sender, EventArgs e)
        {
            bool isInvalidInput = string.IsNullOrEmpty(DriverName?.Text) ||
                      string.IsNullOrEmpty(PhoneNum?.Text) ||
                      string.IsNullOrEmpty(Address?.Text) ||
                      (!radioButtonMale.Checked && !radioButtonFemale.Checked) ||
                      string.IsNullOrEmpty(dob?.Text) ||
                      string.IsNullOrEmpty(trainCodes?.Text);

            if (isInvalidInput)
            {
                MessageBox.Show("Invalid Data !");
            }
            else
            {
                try
                {
                    string name = DriverName.Text;
                    int trainCodesInput = (int)trainCodes.SelectedValue;
                    string phone = PhoneNum.Text;
                    string genderInput = radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "";
                    string address = Address.Text;
                    DateTime dobInput = DateTime.Parse(dob.Text);

                    string Query = "INSERT INTO Drivers VALUES('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, name, genderInput, dobInput, phone, address, trainCodesInput);

                    Con.setData(Query);

                    MessageBox.Show("Driver Added Successfully");

                    ShowDriver();
                    clearInputs();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        int key = 0;
        private void label7_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Driver");
            }
            else
            {
                try
                {

                    string Query = "DELETE FROM Drivers WHERE id = '{0}'";
                    Query = string.Format(Query, key);

                    Con.setData(Query);
                    MessageBox.Show("Driver Deleted Successfully");
                    ShowDriver();
                    clearInputs();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            bool isInvalidInput = string.IsNullOrEmpty(DriverName?.Text) ||
                     string.IsNullOrEmpty(PhoneNum?.Text) ||
                     string.IsNullOrEmpty(Address?.Text) ||
                     (!radioButtonMale.Checked && !radioButtonFemale.Checked) ||
                     string.IsNullOrEmpty(dob?.Text) ||
                     string.IsNullOrEmpty(trainCodes?.Text);

            if (isInvalidInput)
            {
                MessageBox.Show("Invalid or Missing data !");
            }
            else
            {
                try
                {
                    string name = DriverName.Text;
                    int trainCodesInput = (int)trainCodes.SelectedValue;
                    string phone = PhoneNum.Text;
                    string genderInput = radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "";
                    string address = Address.Text;
                    DateTime dobInput = DateTime.Parse(dob.Text);

                    string Query = "UPDATE Trains SET name = '{0}', gender = '{1}', dob = '{2}', phone = '{3}',address = '{4}',trainCode = '{5}' WHERE id = '{6}'";
                    Query = string.Format(Query, name, genderInput, dobInput, phone, address, trainCodesInput, key);

                    Con.setData(Query);
                    MessageBox.Show("Driver Updated Successfully");
                    ShowDriver();
                    clearInputs();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void DriversViewTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DriversViewTable.CurrentRow != null)
            {
                DataGridViewRow row = DriversViewTable.Rows[e.RowIndex];
                DriverName.Text = row.Cells[1].Value?.ToString();
                PhoneNum.Text = row.Cells[4].Value?.ToString();
                Address.Text = row.Cells[5].Value?.ToString();
                trainCodes.SelectedValue = row.Cells[6].Value?.ToString();

                string gender = row.Cells[2].Value?.ToString();
                if (gender == "Male")
                {
                    radioButtonMale.Checked = true;
                }
                else if (gender == "Female")
                {
                    radioButtonFemale.Checked = true;
                }

                DateTime dobDate;
                if (DateTime.TryParse(row.Cells[3].Value?.ToString(), out dobDate))
                {
                    dob.Text = dobDate.ToString("MM/dd/yyyy");
                }
                else
                {
                    MessageBox.Show("Invalid departure date format.");
                    dob.Text = "";
                }

                if (string.IsNullOrEmpty(DriverName.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0]?.Value?.ToString() ?? "0");
                }
            }
        }
    }
}
