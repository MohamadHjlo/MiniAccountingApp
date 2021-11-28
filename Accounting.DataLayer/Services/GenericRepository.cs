using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Accounting.DataLayer.Services
{//کلمه داخل کوچیکتر بزرگتر ینی از نوع انتیتی 
    public class GenericRepository<TEntity> where TEntity : class//برای سادگی میتونی اون تی انتیتی داخل علامت و هرجای دیگه این کلاسو نیبل کاستومر درنظر بگیری ولی چون با چندین تیبل قراره رابطه برقرار کنه این کلاس این اسم مجهول الهویت داده شده
    {

        private Accounting_DBEntities _db;

        private DbSet<TEntity> _dbSet;//دیبی ست تیبل و جدول هاییه که در اینده این ریپوزیتوری باس بهش وصل بشه

        public GenericRepository(Accounting_DBEntities db)//کانستراکتور..میگه هرکی خواست تورو فرا بخونه اول باس ورودی داخل پرانتزو بده و تو با خط اولیه نمونه سازی از بستر میکنی و با خط دومیه تیبل مجهولی که باس ریپو بش وصل بشه رو استاد میکنی و میدیش به دیبی ست
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();//درواقع دیبی ست الان دیگه نماینده هر تیبلی در اینده هست الان فقط با تیبل کاستومر درگیریم بعدا بیشترم میشن
        }
        //کلمه اول که نوشته لکسپریشن همون یعنی لامدا بگیر از کار بر با توجه به شرطی که تو کد میزنه
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)//به جا لیست ازین استفاده کردیم که گنده جنریکاس و برا بعد که تغییر قیافه میده دردسر نمیشه از هرجنس جنریکیو برمیگردونه
        {
            IQueryable<TEntity> query = _dbSet;//با قابلیت لیزی لود  یه اینترفیسه برا کار کردن با منابع داده

            if (where != null)//اگه کاربر شرط گذاشته بود
            {
                query = query.Where(where);
            }
            return query.ToList();
        }

        public virtual TEntity GetById(object Id)
        {
            return _dbSet.Find(Id);
        }
        //ویرچوال این اجازرو میده تو موارد خاص اگه خاستیم مواردی اضافه تر یا کم تر هم به متد اضافه کنیم و رفتار خاص دیگه ای به اون فراخوانده شده بدیم
        public virtual void Insert(TEntity entity)//دیگه اسم کاستومر نمیدیم به این متغیرا چون اون فقط یه تیبله این کلاس قراره خودش هی تغییر شکل به تیبلای برنامه بده نیازی نداریم دیگه برا هر تیبل یه کلاس ریپو جدید بسازیم
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }           
            _dbSet.Remove(entity);

            
        }

        public virtual void Delete(object Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }


    }
}
