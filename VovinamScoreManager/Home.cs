using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VovinamScoreManager.Program;

namespace VovinamScoreManager
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            pictureBox1.ImageLocation = "https://lh3.googleusercontent.com/qwRgyR4naJ619bgtCHwHc34X3sJNhwVacbYVWycuRbWVU2OmnDdeUcjGhd3jjot6Ius";
            if (ControlID.fullName.Equals(""))
            {
                txtTitle.Text = "";
            }
            else
            {
                txtTitle.Text = "Xin chào: " + ControlID.fullName;
            }
            if (ControlID.rule == -1)
            {
                button3.Visible = true;
                button2.Visible = true;
                button1.Visible = true;
                button3.Enabled = true;
                button2.Enabled = true;
                button1.Enabled = true;
                button6.Visible = true;
                button6.Enabled = true;
                button7.Visible = false;
                button7.Enabled = false;

            }
            else
            {
                button4.Visible = true;
                button4.Enabled = true;
                button7.Visible = true;
                button7.Enabled = true;
            }

            button5.Visible = true;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MngClass frm = new MngClass();
            this.Visible = false;

            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MngStudent frm = new MngStudent();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MngRank frm = new MngRank();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MngScore frm = new MngScore();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetUpClass frm = new SetUpClass();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewRank frm = new ViewRank();
            this.Visible = false;
            frm.ShowDialog();
            this.Close();
        }
    }
}
