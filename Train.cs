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
    public partial class Train : Form
    {
        public Train()
        {
            InitializeComponent();
            Con = new functions();
            Con.Connection();
            showTrains();
        }
        functions Con;

        private void showTrains()
        {
            string Query = "SELECT * FROM Trains";

            DataTable trainData = Con.GetData(Query);

            TrainTableView.DataSource = trainData;
        }

        public void clearBoxes()
        {
            TrainNameInput.Text = string.Empty;
            CapacityInput.Text = string.Empty;
            TrainCodeInput.Text = string.Empty;
            DepartureInput.Text = string.Empty;
            ArrivalInput.Text = string.Empty;
            DepartureDateInput.Text = string.Empty;
            ArrivalDateInput.Text = string.Empty;
            TrainCondition.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Drivers Obj = new Drivers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Passengers Obj = new Passengers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void brandMini_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && TrainTableView.CurrentRow != null)
            {
                DataGridViewRow row = TrainTableView.Rows[e.RowIndex];
                
                TrainNameInput.Text = row.Cells[1].Value?.ToString();
                DepartureInput.Text = row.Cells[2].Value?.ToString();
                ArrivalInput.Text   = row.Cells[3].Value?.ToString();
                CapacityInput.Text  = row.Cells[6].Value?.ToString();
                TrainCondition.Text = row.Cells[7].Value?.ToString();
                TrainCodeInput.Text = row.Cells[8].Value?.ToString();

                DateTime depDate, arrDate;
                if (DateTime.TryParse(row.Cells[4].Value?.ToString(), out depDate))
                {
                    DepartureDateInput.Text = depDate.ToString("MM/dd/yyyy"); // Format it as needed
                }
                else
                {
                    MessageBox.Show("Invalid departure date format.");
                    DepartureDateInput.Text = ""; // Clear the input if invalid
                }

                // Check and parse ArrivalDateInput
                if (DateTime.TryParse(row.Cells[5].Value?.ToString(), out arrDate))
                {
                    ArrivalDateInput.Text = arrDate.ToString("MM/dd/yyyy"); // Format it as needed
                }
                else
                {
                    MessageBox.Show("Invalid arrival date format.");
                    ArrivalDateInput.Text = ""; // Clear the input if invalid
                }

                if (string.IsNullOrEmpty(TrainNameInput.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0]?.Value?.ToString() ?? "0");
                }
            }
        }

        private void AddTrain_Click(object sender, EventArgs e)
        {
            bool isInvalidInput = string.IsNullOrEmpty(TrainNameInput?.Text) ||
                      string.IsNullOrEmpty(CapacityInput?.Text) ||
                      string.IsNullOrEmpty(TrainCodeInput?.Text) ||
                      string.IsNullOrEmpty(DepartureInput?.Text) ||
                      string.IsNullOrEmpty(ArrivalInput?.Text);
            if (isInvalidInput)
            {
                MessageBox.Show("Invalid or Missing data !");
            }
            else
            {
                try
                {
                    string nameInput = TrainNameInput.Text;
                    int capacityInput = Convert.ToInt32(CapacityInput.Text);
                    string CodeInput = TrainCodeInput.Text;
                    string dapInput = DepartureInput.Text;
                    string arrivalInput = ArrivalInput.Text;
                    DateTime depDateInput = DateTime.Parse(DepartureDateInput.Text);
                    DateTime arrDateInput = DateTime.Parse(ArrivalDateInput.Text);
                    string ConditionInput = TrainCondition.Text;

                    string Query = "INSERT INTO Trains VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                    Query = string.Format(Query, nameInput, dapInput, arrivalInput, depDateInput, arrDateInput, capacityInput, ConditionInput, CodeInput);

                    Con.setData(Query);
                    MessageBox.Show("Train Added Successfully");
                    showTrains();
                    clearBoxes();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            bool isInvalidInput = string.IsNullOrEmpty(TrainNameInput?.Text) ||
                      string.IsNullOrEmpty(CapacityInput?.Text) ||
                      string.IsNullOrEmpty(TrainCodeInput?.Text) ||
                      string.IsNullOrEmpty(DepartureInput?.Text) ||
                      string.IsNullOrEmpty(ArrivalInput?.Text);
            if (isInvalidInput)
            {
                MessageBox.Show("Invalid or Missing data !");
            }
            else
            {
                try
                {
                    string nameInput = TrainNameInput.Text;
                    int capacityInput = Convert.ToInt32(CapacityInput.Text);
                    string CodeInput = TrainCodeInput.Text;
                    string dapInput = DepartureInput.Text;
                    string arrivalInput = ArrivalInput.Text;
                    DateTime depDateInput = DateTime.Parse(DepartureDateInput.Text);
                    DateTime arrDateInput = DateTime.Parse(ArrivalDateInput.Text);
                    string ConditionInput = TrainCondition.Text;

                    string Query = "UPDATE Trains SET trainName = '{0}', departure = '{1}', arrival = '{2}', dep_date = '{3}',arrival_date = '{4}',capacity = '{5}', condition ='{6}',number = '{7}' WHERE trainCode = '{8}'";
                    Query = string.Format(Query, nameInput, dapInput, arrivalInput, depDateInput, arrDateInput, capacityInput, ConditionInput, CodeInput , key);

                    Con.setData(Query);
                    MessageBox.Show("Train Updated Successfully");
                    showTrains();
                    clearBoxes();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
            if (key == 0)
            {
                MessageBox.Show("Select a train");
            }
            else
            {
                try
                {

                    string Query = "DELETE FROM Trains WHERE trainCode = '{0}'";
                    Query = string.Format(Query, key);

                    Con.setData(Query);
                    MessageBox.Show("Train Deleted Successfully");
                    showTrains();
                    clearBoxes();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
    }
}
