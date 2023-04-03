using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VovinamScoreManager.Models;
using VovinamScoreManager.Services;
using static VovinamScoreManager.Program;

namespace VovinamScoreManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        AccountServices context = new AccountServices();
        private void button2_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string pass = txtPass.Text;
            if (userName.Trim().Equals("") && pass.Trim().Equals(""))
            {
                string message = "Vui Lòng điền đầy đủ thông tin đăng nhập";
                MessageBox.Show(message);
            }
            else
            {
                Account a = context.Login(userName, pass);
                if (a != null)
                {
                    //đẩy rule vs accountID
                    ControlID.accountID = a.Id;
                    ControlID.rule = a.AccRule;
                    ControlID.fullName = a.FullName;
                    Home frm = new Home();
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    string message = "Tài khoản không tồn tại hoặc sai thông tin đăng nhập";
                    MessageBox.Show(message);
                }
            }
        }
    }
}
