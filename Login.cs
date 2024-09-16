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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ResetPass_Click(object sender, EventArgs e)
        {
            UserName.Text = string.Empty;
            Password.Text = string.Empty;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(UserName)) || string.IsNullOrEmpty(Convert.ToString(Password)))
            {
                MessageBox.Show("User Name and Password are rerquired !");

            }else if(UserName.Text == "Admin" && Password.Text == "Admin")
            {
                Train Obj = new Train();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Creditinails !");
                UserName.Text = string.Empty;
                Password.Text = string.Empty;
            }
        }
    }
}
