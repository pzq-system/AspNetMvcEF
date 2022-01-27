using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend
{
    public static class ListExtensions
    {

        /// <summary>
        /// 判断list是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this List<T> list)
        {
            if (list == null)
            {
                return list == null ? true : false;
            }
            return list.Count == 0 ? true : false;
        }

        /// <summary>
        /// 判断list是否不为空,list数据条数大于0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool NotNull<T>(this List<T> list)
        {
            if (list != null)
            {
                return list.Count > 0 ? true : false; ;
            }
            return false;
        }
    }
}
