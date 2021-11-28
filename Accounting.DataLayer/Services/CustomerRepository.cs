using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Accounting.DataLayer.Repositories;
using Accounting.ViewModels.Customers;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        Accounting_DBEntities db;//نماینده بانک
                                 //کاری که انجام میشه برا اینه که جلوگیری بشه از نمونه سازی زیاد از نماینده بانک با اسمای متفاوت که به ازای هربار نمونه سازی از این انتیتی سبزه یه بستر بانک اطلاعاتی ایجاد میشه که چون بعدا مجبوریم به چند ریپوزیتوری متصل شیم ده ها بستر ایجاد میشه و فضارو سنگین میکنه پس این تزریقه برا جلوگیری از اینه

        public CustomerRepository(Accounting_DBEntities context)//یارو مجبوره نمونه بسازه و این متد اون نمونه رو همون دی بی نیکنه درواقع هر اشغالی بدی با هر اسمی انگار یه بستر همیشه وجود داره
        {
            db = context;
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer)
        {
            db.Customers.Add(customer);
            return true;
        }

        public bool UpdateCustomer(Customers customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            return true;
        }

        public bool DeleteCustomer(Customers customer)
        {
            db.Entry(customer).State = EntityState.Deleted;
            return true;
        }

        public bool DeleteCustomer(int customerId)
        {
            var deleteallrecords = db.Accounting.Where(p => p.CostomerID == customerId);
            db.Accounting.RemoveRange(deleteallrecords);
            var customer = GetCustomerById(customerId);
            DeleteCustomer(customer);
            return true;
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter)).ToList();
        }

        public List<ListCustomerViewModel> GetNameCustomers(string filter = "")
        {
            if (filter == "")//اگه دقت کنی خط پایینی همون درس تو لامبدا و لینکه که میتونستی از یه پروپرتی با نیو کردن شرط بزاری چه خواصی از توش برداشته شه 
            {
              return  db.Customers.Select(c => new ListCustomerViewModel() { FullName = c.FullName , CustomerID = c.CustomerID}).ToList();//تعریف شده برا نمایش دادن داخل گرید ویو چون تو حالت عادی نال تعریف شده ولی تو تکست باکس چون عبارتی توش وارد میکنی دیگه نال نیست و خط پایین اجرا میشه
            }
            return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel() { FullName = c.FullName, CustomerID = c.CustomerID }).ToList();//تعریف شده برا اون تکست باکسه
        }

        public int GEtCustomerIdbyName(string name)
        {
            return db.Customers.First(c => c.FullName == name).CustomerID;
        }

        public string GetNameCustomerById(int customerId)
        {
            return db.Customers.Find(customerId).FullName;
        }
    }
}
