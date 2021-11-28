using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//این قسمت نقش مدل هاییو داره که فقط جنبه نمایشی دارن
//ینی با صدا زدن این تک متد ها خودمون به متدی که جنس لیت از کاستومرز داره میگیم که دوس داریم فقط چه چیزاییو نمایش بدی
namespace Accounting.ViewModels.Customers
{
   public class ListCustomerViewModel
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
    }
}
