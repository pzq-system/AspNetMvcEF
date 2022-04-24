using Common.Output;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;


namespace Repository
{
    public interface IBaseRepository : IService
    {
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;

        /// <summary>
        /// 提供对单表的查询
        /// 不推荐对外开放
        /// </summary>
        /// <typeparam name="T">IQueryable类型集合</typeparam>
        /// <returns></returns>
        [Obsolete("尽量避免使用，using 带表达式目录树的 代替")]
        IQueryable<T> Set<T>() where T : class;

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        T Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T, S>(Expression<Func<T, bool>> funcWhere, Expression<Func<T, S>> funcOrderBy, bool isAsc = true) where T : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderBy, bool isAsc = true) where T : class;


        IQueryable<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderBy, out int toTal, bool isAsc = true) where T : class;

        /// <summary>
        /// 新增数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>返回带主键的实体</returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// 新增数据，即时Commit;
        /// 多条sql 一个连接，事务插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 更新数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : class;

        /// <summary>
        /// 更新数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 根据主键删除数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        void Delete<T>(int Id) where T : class;

        /// <summary>
        /// 删除数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// 删除数据，即时Commit;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;

        /// <summary>
        /// 立刻全部保存
        /// 把增/删的savechange给放到这里，保证事务的
        /// </summary>
        void Commit();
    }
}
