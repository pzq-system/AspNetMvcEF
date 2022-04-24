using Common.Output;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Repository
{
    public class BaseRepository : ServiceBase, IBaseRepository
    {

        public T Find<T>(int id) where T : class
        {
            return context.Set<T>().Find(id) ?? null;
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return context.Set<T>();
        }

        public T Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            if (funcWhere != null)
            {
                return context.Set<T>().Where(funcWhere).FirstOrDefault() ?? null;
            }
            return context.Set<T>().FirstOrDefault() ?? null;
        }

        public IQueryable<T> Query<T, S>(Expression<Func<T, bool>> funcWhere, Expression<Func<T, S>> funcOrderBy, bool isAsc = true) where T : class
        {
            var list = Set<T>();
            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderBy);
            }
            else
            {
                list = list.OrderByDescending(funcOrderBy);
            }
            return list;
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderBy, bool isAsc = true) where T : class
        {
            var list = Set<T>();
            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderBy);
            }
            else
            {
                list = list.OrderByDescending(funcOrderBy);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = list.Count()
            };
            return result;
        }

        public IQueryable<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderBy, out int toTal, bool isAsc = true) where T : class
        {
            var list = Set<T>();
            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderBy);
            }
            else
            {
                list = list.OrderByDescending(funcOrderBy);
            }
            toTal = list.Count();
            return list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public T Insert<T>(T t) where T : class
        {
            context.Set<T>().Add(t);
            Commit();
            return t;

        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            context.Set<T>().AddRange(tList);
            Commit();
            return tList;
        }

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为 UnChanged
            context.Entry<T>(t).State = EntityState.Modified;
            Commit();//保存 然后重置为UnChanged
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                context.Set<T>().Attach(t);
                context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            context.Set<T>().Remove(t);
            Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            context.Set<T>().Attach(t);
            context.Set<T>().Remove(t);
            Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                context.Set<T>().Attach(t);
            }
            context.Set<T>().RemoveRange(tList);
            Commit();
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
