using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Business;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Accounting;
using System.Diagnostics;
using Accounting.Utility.Gradiant_Color;



namespace AccountingApp
{
    public partial class Form1 : Form
    {

        bool isHower = false;
        bool isHower2 = false;
        bool isHower3 = false;
        bool isHower4 = false;
        public Form1()
        {
            InitializeComponent();
            GradiantClr gc = new GradiantClr();
            
            gc.PaintGradient(groupBox1, LinearGradientMode.Vertical, Color.Transparent, Color.FromArgb(255, 192, 255, 101));
            gc.PaintGradient(groupBox2, LinearGradientMode.Vertical, Color.FromArgb(255, 192, 255, 101), Color.FromArgb(132, 255, 218));
            gc.PaintGradient(flowLayoutPanel1, LinearGradientMode.Vertical, Color.Transparent, Color.FromArgb(255, 192,255,101));
            gc.PaintGradient(pictureBox12, LinearGradientMode.Vertical, Color.FromArgb(255,192,255,101), Color.FromArgb(132, 255, 218));


            gc.PaintGradient(btnRefreshAccount, LinearGradientMode.BackwardDiagonal, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));
            gc.PaintGradient(btnGame, LinearGradientMode.BackwardDiagonal, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));
            gc.PaintGradient(btnCalculator, LinearGradientMode.BackwardDiagonal, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));
            gc.PaintGradient(tsOptiones, LinearGradientMode.Vertical, Color.Transparent, Color.FromArgb(184, 248, 235));
            gc.PaintGradient(btnNotebook, LinearGradientMode.BackwardDiagonal, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            FrmCustomers frmCustomers = new FrmCustomers();
            frmCustomers.ShowDialog();
        }

        private void BtnNewAccounting_Click(object sender, EventArgs e)
        {
            frmNewAccounting frmNewAccounting = new frmNewAccounting();
            frmNewAccounting.ShowDialog();
        }

        private void BtnReportPay_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeId = 2;
            frmReport.ShowDialog();
        }

        private void BtnReportRecive_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeId = 1;
            frmReport.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)//فکت: شروطی که برا فرما میزاریم برا اینه که فرمی ک قراره باز بشه میخوایم جواب بده ینی مثلا اینجا میشه اگه کاربر وجود داشت اجازه ورود بده
            {
                lblDate.Text = DateTime.Now.ToShamsiCalender() + "         ";
                this.Show();
                Report();
            }
            else
            {
                Application.Exit();
            }
        }

        void Report()
        {
            ReportViewModel report = Account.ReportFormMain();//اون متد داخل کلاس داخل لایه بیزینسو اوردیم اینجا
            lblPay.Text = report.Pay.ToString("#,0");
            lblRecive.Text = report.Recive.ToString("#,0");
            lblBalance.Text = report.AccountBalance.ToString("#,0");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            lblAuthor.ForeColor = Color.Magenta;
            if (isHower == true)
            {
                btnReportRecive.ForeColor = Color.Magenta;
            }
            if (isHower2 == true)
            {
                btnReportPay.ForeColor = Color.Magenta;
            }
            if (isHower3 == true)
            {
                btnNewAccounting.ForeColor = Color.Magenta;
            }
            if (isHower4 == true)
            {
                btnNewCustomer.ForeColor = Color.Magenta;
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {

            lblAuthor.ForeColor = Color.GreenYellow;
            if (isHower == true)
            {
                btnReportRecive.ForeColor = Color.GreenYellow;
            }
            if (isHower2 == true)
            {
                btnReportPay.ForeColor = Color.GreenYellow;
            }
            if (isHower3 == true)
            {
                btnNewAccounting.ForeColor = Color.GreenYellow;
            }
            if (isHower4 == true)
            {
                btnNewCustomer.ForeColor = Color.GreenYellow;
            }
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {

            lblAuthor.ForeColor = Color.Aqua;
            if (isHower == true)
            {
                btnReportRecive.ForeColor = Color.Aqua;
            }
            if (isHower2 == true)
            {
                btnReportPay.ForeColor = Color.Aqua;
            }
            if (isHower3 == true)
            {
                btnNewAccounting.ForeColor = Color.Aqua;
            }
            if (isHower4 == true)
            {
                btnNewCustomer.ForeColor = Color.Aqua;
            }
        }

        private void BtnEditLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();

        }

        private void BtnReportRecive_MouseHover(object sender, EventArgs e)
        {
            isHower = true;

        }

        private void BtnReportRecive_MouseLeave(object sender, EventArgs e)
        {
            isHower = false;
            btnReportRecive.ForeColor = Color.Black;
        }

        private void BtnReportPay_MouseHover(object sender, EventArgs e)
        {
            isHower2 = true;
        }
        private void BtnReportPay_MouseLeave(object sender, EventArgs e)
        {
            isHower2 = false;
            btnReportPay.ForeColor = Color.Black;
        }

        private void BtnNewAccounting_MouseHover(object sender, EventArgs e)
        {
            isHower3 = true;
        }

        private void BtnNewAccounting_MouseLeave(object sender, EventArgs e)
        {
            isHower3 = false;
            btnNewAccounting.ForeColor = Color.Black;
        }

        private void BtnNewCustomer_MouseHover(object sender, EventArgs e)
        {
            isHower4 = true;
        }

        private void BtnNewCustomer_MouseLeave(object sender, EventArgs e)
        {
            isHower4 = false;
            btnNewCustomer.ForeColor = Color.Black;
        }

        private void BtnRefreshAccount_Click(object sender, EventArgs e)
        {
            Report();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Dooz\WindowsFormsApplication6\bin\Debug\WindowsFormsApplication6");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Calculator\WindowsFormsApplication4\bin\Debug\WindowsFormsApplication4");

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Daftarcheh\Daftarcheh\bin\Debug\Daftarcheh");

        }
        private void BtnRefreshAccount_MouseHover(object sender, EventArgs e)
        {
            btnRefreshAccount.BackColor = Color.Aqua;
        }

        private void BtnRefreshAccount_MouseLeave(object sender, EventArgs e)
        {
            btnRefreshAccount.BackColor = Color.HotPink;

        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            btnGame.BackColor = Color.Aqua;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            btnGame.BackColor = Color.HotPink;
        }
        private void Button2_MouseHover(object sender, EventArgs e)
        {
            btnCalculator.BackColor = Color.Aqua;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            btnCalculator.BackColor = Color.Aqua;
        }

        private void Button3_MouseHover(object sender, EventArgs e)
        {
            btnNotebook.BackColor = Color.Red;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            btnNotebook.BackColor = Color.Pink;
        }

    }
}
