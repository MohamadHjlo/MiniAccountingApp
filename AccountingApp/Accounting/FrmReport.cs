using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Accounting.DataLayer.Context;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Customers;
using System.Drawing.Drawing2D;
using System.Drawing;
using Accounting.Utility.Gradiant_Color;
using Stimulsoft.Controls.Win.DotNetBar;

namespace AccountingApp
{
    public partial class FrmReport : Form
    {
        public int TypeId = 0;//تعیین درامد بودن یا هزینه بودن فرم
        GradiantClr gc = new GradiantClr();
        public FrmReport()
        {
            
            InitializeComponent();

            gc.PaintGradient(toolStrip1, LinearGradientMode.Vertical, Color.Transparent, Color.Transparent);
            gc.PaintGradient(pcb, LinearGradientMode.BackwardDiagonal, Color.Transparent, Color.Transparent);
            gc.PaintGradient(btnFilter, LinearGradientMode.ForwardDiagonal, Color.FromArgb(255, 43, 162), Color.FromArgb(255, 24, 64));
            gc.PaintGradient(this, LinearGradientMode.BackwardDiagonal, Color.FromArgb(0,255,249), Color.FromArgb(115, 255, 128));

        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<ListCustomerViewModel> list = new List<ListCustomerViewModel>();

                list.Add(new ListCustomerViewModel()
                {
                    CustomerID = 0,
                    FullName = "انتخاب کنید"
                });
                list.AddRange(db.CustomerRepository.GetNameCustomers());//اد رنج ینی ادامشو از این جنس ورودی بچین زیرش
                cbCustomer.DataSource = list;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerID";

            }
            if (TypeId == 1)
            {
                this.Text = "گزارش دریافتی ها";
            }
            else
            {
                this.Text = "گزارش پرداختی ها";
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }
        void Filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<Accounting.DataLayer.Accounting> result = new List<Accounting.DataLayer.Accounting>();
                DateTime? startDate;
                DateTime? endDate;
                if ((int)cbCustomer.SelectedValue != 0)//0لطفا انتخاب کنید بود
                {
                    int customerId = int.Parse(cbCustomer.SelectedValue.ToString());
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeId && a.CostomerID == customerId));//تعیین میکنه رو گزارش پرداختیا زده یا دریافتیا
                }
                else
                {
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeId));
                }
                try
                {
                    if (txtFromdate.Text != "    /  /")//باید این دوتا باکسو تبدیل به نوع دیت تایم کنیم چون بانک نوعش دیت تایم و تازه میلادیه ولی اینا شمسی دارن میگیرن
                    {
                        startDate = Convert.ToDateTime(txtFromdate.Text);
                        startDate = DateConvertor.ToMiladi(startDate.Value);
                        result = result.Where(r => r.DateTitle >= startDate.Value).ToList();
                    }
                    if (txtToDate.Text != "    /  /")
                    {
                        endDate = Convert.ToDateTime(txtToDate.Text);
                        endDate = DateConvertor.ToMiladi(endDate.Value);
                        result = result.Where(r => r.DateTitle <= endDate.Value).ToList();
                    }
                }
                catch
                {
                    RtlMessageBox.Show("لطفا تاریخ را صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvReport.Rows.Clear();
                foreach (var accounting in result)//با این داریم زور میزنیم  تو گرید جای ستون ایدی نام رو دستی وارد کنیم پس باید تمامی ستون هارو دوباره ادرس بدیم بسازیم یا اینکه از کاری که اون سری رفتیم تو لایه مدلز استفاده کنیم
                {
                    var customerName = db.CustomerRepository.GetNameCustomerById(accounting.CostomerID);
                    dgvReport.Rows.Add(accounting.ID, customerName, accounting.Amount, accounting.DateTitle.ToShamsi(), accounting.Description);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReport.CurrentRow != null)
            {
                if (RtlMessageBox.Show("ایا از حذف مطمئن هستید", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        int id = int.Parse(dgvReport.CurrentRow.Cells[0].Value.ToString());
                        db.AccountingRepository.Delete(id);
                        db.Save();
                        Filter();
                    }
                }
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReport.CurrentRow != null)
            {
                int id = int.Parse(dgvReport.CurrentRow.Cells[0].Value.ToString());
                frmNewAccounting frmNew = new frmNewAccounting();
                frmNew.AccountID = id;
                if (frmNew.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }
        }

        private void CbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click_1(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable(); //قراره مستقیم  از همین جدول هاییه که تو برنامه موجوده بگیریم نمیخوایم باز کوئری بزنیم برا اطلاعات
            dtPrint.Columns.Add("Customer");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("Date");
            dtPrint.Columns.Add("Describtion");
            foreach (DataGridViewRow item in dgvReport.Rows)//داریم مقادیر خط تیبل ساختگیمونو از تیبل اصلی برنامه میگیریم خط و ستون
            {
                dtPrint.Rows.Add(
                    item.Cells[0].Value.ToString(),
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[3].Value.ToString()
                  );
            }
            stiPrint.Load(Application.StartupPath + "/Report.mrt");
            stiPrint.RegData("DT", dtPrint);
            stiPrint.Show();
        }
    }
}
