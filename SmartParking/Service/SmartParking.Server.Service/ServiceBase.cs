using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartParking.Server.IService;

namespace SmartParking.Server.Service
{
    public class ServiceBase : IServiceBase
    {
        //操作数据的对象
        protected DbContext Context { get; private set; }

        public ServiceBase(IEFContext.IEFContext eFContext)
        {
            Context = eFContext.CreateDBContext();
        }
        public T Find<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return Context.Set<T>().Where<T>(funcWhere);
        }

        public T Insert<T>(T t) where T : class
        {
            Context.Set<T>().Add(t);
            Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            Context.Set<T>().AddRange(tList);
            Commit();
            return tList;
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为Unchanged
            Context.Entry<T>(t).State = EntityState.Modified;
            Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                Context.Set<T>().Attach(t);
                Context.Entry<T>(t).State = EntityState.Modified;
            }
            Commit();
        }

        public void Delete<T>(int id) where T : class
        {
            T t = Find<T>(id);
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Remove(t);
            Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Attach(t);
            Context.Set<T>().Remove(t);
            Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                Context.Set<T>().Attach(t);
            }
            Context.Set<T>().RemoveRange(tList);
            Commit();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            if (Context != null) Context.Dispose();
        }
    }
}
