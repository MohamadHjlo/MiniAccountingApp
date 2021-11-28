using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable//وظیفه کنترل کردن بستر ارتباط با بانک و جلوگیری از دسترسی کلاس های خارجی بطور مستقیم به بانک
    {
        //Accounting_DbEntities = همون کانتکست یا بستر ارتباط با بانک اطلاعاتی
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)//این همون ای ک.ریپوزیتوریه در واقع فقط یه اسم بش دادیم بشه به کاربردش
                {
                    _customerRepository = new CustomerRepository(db);//اینجام سمت چپ همون اسم اینترفیسه مثل اینه ک داری از اینتفریس یه چندریختی میزنی به کلاس ارث بری کنندش
                }
                return _customerRepository;//پس ازین به بعد برا ارتباط با بانکم فقط کافیه بعد از نمونه سازی از ی.اف ورک متد پابلیک کاستومرو فرواخوانی کنی این خودش تزریق و این داستانارو انجام میده و تورو متصل به اینترفیس و زیر مجموعش میکنه اینجوری این تنها راه اتصال به بانک و اینترفیسه
            }
        }


        private GenericRepository<Accounting> _accountinRepository;
        public GenericRepository<Accounting> AccountingRepository
        {
            get
            {
                if (_accountinRepository == null)
                {
                    _accountinRepository = new GenericRepository<Accounting>(db);
                }
                return _accountinRepository;
            }
        }


        private GenericRepository<Login> _loginRepository;

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new GenericRepository<Login>(db);
                }
                return _loginRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }

    }
}
