using RobotMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DAL.DataAccessLayer.AutoMapper
{
    internal static class AutoMapper
    {
        static AutoMapper()
        {
            #region 绑定的初始化

            Mapper.Initialize(config =>
            {
              
            });

            #endregion 绑定的初始化
        }

        public static M AutoMap<T, M>(this T item)
            where T : class
            where M : class
        {
            return item.RobotMap<T, M>();
        }

        public static List<M> AutoMapList<T, M>(this List<T> items)
            where T : class
            where M : class
        {
            return items.RobotMap<T, M>();
        }

        public static List<M> AutoMapList<T, M>(this IEnumerable<T> items)
            where T : class
            where M : class
        {
            return items.RobotMap<T, M>();
        }
    }
}
