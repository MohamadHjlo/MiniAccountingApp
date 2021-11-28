using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Context;
using Accounting.Utility.Gradiant_Color;
using ValidationComponents;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace AccountingApp
{
    public partial class FrmLogin : Form
    {
        public bool IsEdit = false;
        GradiantClr gc = new GradiantClr();
        public FrmLogin()
        {
            InitializeComponent();
            gc.PaintGradient(btnLogin, LinearGradientMode.Vertical, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));
            gc.PaintGradient(this, LinearGradientMode.Vertical,  Color.FromArgb(255, 133, 255, 216), Color.FromArgb(44,253,7,177 ));

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    if (IsEdit)
                    {
                        FrmLogin frmLogin = new FrmLogin();
                        var login = db.LoginRepository.Get().First();//وقتی میبینی با دو خط کد لاگین ریپو میتونی همه متدای گت و... رو صدا بزنی صدقه سری جنریک ریپوزیتوریه
                        login.UserName = txtUsername.Text;
                        login.Password = txtPaassword.Text;
                        db.LoginRepository.Update(login);
                        db.Save();
                        RtlMessageBox.Show("عملیات با موفقیت انجام شد", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        if (DialogResult == DialogResult.OK)
                        {
                            frmLogin.Hide();
                        }
                    }
                    else
                    {
                        if (db.LoginRepository.Get(l => l.UserName == txtUsername.Text && l.Password == txtPaassword.Text).Any())
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            RtlMessageBox.Show("کاربر یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                this.Text = "تنظیمات ورود به برنامه";
                btnLogin.Text = "ذخیره تغییرات";
                pcWelcom.Hide();
                using (UnitOfWork db = new UnitOfWork())
                {
                    var login = db.LoginRepository.Get().First();
                    txtUsername.Text = login.UserName;
                    txtPaassword.Text = login.Password;
                }
            }
            else
            {
                pcPass.Hide();
            }
        }

        private void BtnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Aqua;
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.HotPink;
            
        }
    }
}
