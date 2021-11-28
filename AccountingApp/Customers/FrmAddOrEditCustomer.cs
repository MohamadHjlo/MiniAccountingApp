using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using ValidationComponents;
using System.Drawing.Drawing2D;
using System.Drawing;
using Accounting.Utility.Gradiant_Color;

namespace AccountingApp
{
    public partial class FrmAddOrEditCustomer : Form
    {
        GradiantClr gc = new GradiantClr();
        public int customerId = 0;
        UnitOfWork db = new UnitOfWork();
        public FrmAddOrEditCustomer()
        {
            InitializeComponent();
            gc.PaintGradient(btnSave, LinearGradientMode.Vertical, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));
            gc.PaintGradient(SelectPhoto, LinearGradientMode.Vertical, Color.FromArgb(224, 58, 151), Color.FromArgb(255, 0, 44));

        }

        private void SelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                pcCustomer.ImageLocation = openFile.FileName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                    string path = Application.StartupPath + "/Images/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    pcCustomer.Image.Save(path + imageName);
                    Customers customers = new Customers()
                    {
                        Address = txtAddress.Text,
                        Email = txtEmail.Text,
                        FullName = txtName.Text,
                        Mobile = txtMobile.Text,
                        CustomerImage = imageName
                    };
                    if (customerId == 0)
                    {
                        db.CustomerRepository.InsertCustomer(customers);
                    }
                    else
                    {
                        customers.CustomerID = customerId;
                        db.CustomerRepository.UpdateCustomer(customers);

                    }
                    DialogResult = DialogResult.OK;//جوابی که به فرم مادر گزارش میکنه
                    db.Save();
                }

            }
        }
        private void FrmAddOrEditCustomer_Load(object sender, EventArgs e)
        {
            if (customerId != 0)
            {
                this.Text = "ویرایش شخص";
                btnSave.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomerById(customerId);
                txtName.Text = customer.FullName;
                txtEmail.Text = customer.Email;
                txtMobile.Text = customer.Mobile;
                txtAddress.Text = customer.Address;
                pcCustomer.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;

            }
        }
    }
}
