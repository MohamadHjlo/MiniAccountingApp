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
using System.Drawing.Drawing2D;
using Accounting.Utility.Gradiant_Color;

namespace AccountingApp
{
    public partial class FrmCustomers : Form
    {
        GradiantClr gc = new GradiantClr();
        public FrmCustomers()
        {
            InitializeComponent();
            gc.PaintGradient(toolStrip1, LinearGradientMode.BackwardDiagonal, Color.FromArgb(214, 255, 186, 248), Color.Transparent);

        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();

        }
        void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvCustomers.AutoGenerateColumns = false;
                dgvCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            }
        }

        private void BtnRefreshCustomer_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            BindGrid();
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgvCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtFilter.Text);
            }
        }

        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (dgvCustomers.CurrentRow != null)
                {
                    string name = dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                    if (RtlMessageBox.Show($" با این کار تمام تراکنش های مربوط به این شخص نیز حذف میشوند.  آیا از حذف و تراکنش های مربوط به   {name}  مطمئن هستید ؟", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int customerId = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                        db.CustomerRepository.DeleteCustomer(customerId);
                        db.Save();
                        BindGrid();

                    }
                }
                else
                {
                    RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
                }
            }
        }
        private void BtnAddnewCustomer_Click(object sender, EventArgs e)
        {
            FrmAddOrEditCustomer frmAdd = new FrmAddOrEditCustomer();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }
        private void BtnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int customerID = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                FrmAddOrEditCustomer frmAddOrEdit = new FrmAddOrEditCustomer();
                frmAddOrEdit.customerId = customerID;
                if (frmAddOrEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا شخصی را انتخاب کنید");
            }

        }
    }
}
