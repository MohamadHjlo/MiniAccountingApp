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
using ValidationComponents;
using System.Drawing.Drawing2D;
using Accounting.Utility.Gradiant_Color;


namespace AccountingApp
{
    public partial class frmNewAccounting : Form
    {
        GradiantClr gc = new GradiantClr();
        public int AccountID = 0;//تعیین ادیت بودن یا افزودن بودن

        UnitOfWork db;
        public frmNewAccounting()
        {
            InitializeComponent();
            gc.PaintGradient(btnSave, LinearGradientMode.Vertical, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));

        }

        private void FrmNewAccounting_Load(object sender, EventArgs e)
        {
            db = new UnitOfWork();
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers();
            if (AccountID != 0)
            {
                var account = db.AccountingRepository.GetById(AccountID);
                txtAmount.Text = account.Amount.ToString();
                txtDescribtion.Text = account.Description;
                txtName.Text = db.CustomerRepository.GetNameCustomerById(account.CostomerID);
                if (account.TypeID == 1)//یک مشخصه دریافتیا بود
                {
                    rbRecive.Checked = true;
                }
                else
                {
                    rbPay.Checked = true;
                }
                this.Text = "ویرایش";
                btnSave.Text = "ویرایش";
                db.Dispose();
            }
        }
        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers(txtFilter.Text);//دلیل اینکه کدش مثل بالاییه اینه که ما تو متد گت نیم کاستومرز هر دوحالتو با شرط ساختیم
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbRecive.Checked)//تعیین رادیو باتن ها
                {
                    db = new UnitOfWork();
                    Accounting.DataLayer.Accounting accounting = new Accounting.DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CostomerID = db.CustomerRepository.GEtCustomerIdbyName(txtName.Text),
                        TypeID = (rbRecive.Checked) ? 1 : 2,//جدید....کاندیشن ایف هست اسمش و علامت سوال به معنی ایف و عدد اول بعدعلامت شرط اول و دونقطه به معنی الز ینی اگه یک اجرا نشد دورو بده
                        DateTitle = DateTime.Now,
                        Description = txtDescribtion.Text,
                    };
                    if (AccountID == 0)
                    {
                        db.AccountingRepository.Insert(accounting);
                        db.Save();
                    }
                    else
                    {
                        accounting.ID = AccountID;//دیگه صفر نیست چون ویرایشه
                        db.AccountingRepository.Update(accounting);
                    }
                    db.Save();
                    db.Dispose();//بجا یوزینگ و اون اشغال بازیا با این جیگر مشکلا حل شد
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را وارد کنید");
                }
            }
        }
    }
}
