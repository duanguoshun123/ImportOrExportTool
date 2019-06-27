using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.EF.DbContext;

namespace Tool.DAL.DataAccessLayer
{
    public static class DataWriter
    {
        public static List<T> AddEntities<T>(IList<T> objList) where T : class
        {
            InitalCreationTime<T>(objList);
            InitalLastUpdateTime<T>(objList);
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    for (int i = 0; i < objList.Count; ++i)
                    {
                        context.Entry<T>(objList[i]).State = EntityState.Added;
                    }
                    context.SaveChanges();
                }
                return objList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region 查看 EntityValidationErrors 详细信息的解决方法

            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    var msg = string.Empty;
            //    var errors = (from u in ex.EntityValidationErrors select u.ValidationErrors).ToList();
            //    foreach (var item in errors)
            //        msg += item.FirstOrDefault().ErrorMessage;
            //}

            #endregion 查看 EntityValidationErrors 详细信息的解决方法
        }

        public static void UpdateEntities<T>(IList<T> objList) where T : class
        {
            InitalLastUpdateTime<T>(objList);
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    for (int i = 0; i < objList.Count; ++i)
                    {
                        context.Entry<T>(objList[i]).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteEntities<T>(IList<T> objList) where T : class
        {
            InitalLastUpdateTime<T>(objList);
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    for (int i = 0; i < objList.Count; ++i)
                    {
                        context.Entry<T>(objList[i]).State = EntityState.Deleted;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void InitalCreationTime<T>(IList<T> objList)
        {
            //自动赋值创建时间
            var creationTime = typeof(T).GetProperty("CreationTime");
            if (creationTime != null)
            {
                DateTime dt = DateTime.Now;
                foreach (var obj in objList)
                {
                    creationTime.SetValue(obj, dt);
                }
            }
        }

        private static void InitalLastUpdateTime<T>(IList<T> objList)
        {
            //自动赋值更新时间
            var lastUpdateTime = typeof(T).GetProperty("LastUpdateTime");
            if (lastUpdateTime != null)
            {
                DateTime dt = DateTime.Now;
                foreach (var obj in objList)
                {
                    lastUpdateTime.SetValue(obj, dt);
                }
            }
        }

        public static void UpdateEntityByProperty<T>(IList<T> objList, IEnumerable<string> fieldNames) where T : class
        {
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    if (!fieldNames.Any())
                    {
                        return;
                    }
                    for (int i = 0; i < objList.Count; ++i)
                    {
                        context.Set<T>().Attach(objList[i]);
                        if (fieldNames != null)
                        {
                            foreach (var item in fieldNames)
                            {
                                context.Entry<T>(objList[i]).Property(item).IsModified = true;
                            }
                        }
                        else
                        {
                            context.Entry<T>(objList[i]).State = EntityState.Modified;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateEntityByPropertySingle<T>(T obj, IEnumerable<string> fieldNames) where T : class
        {
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    if (!fieldNames.Any())
                    {
                        return;
                    }

                    context.Set<T>().Attach(obj);
                    if (fieldNames != null)
                    {
                        foreach (var item in fieldNames)
                        {
                            context.Entry<T>(obj).Property(item).IsModified = true;
                        }
                    }
                    else
                    {
                        context.Entry<T>(obj).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BulkInsertEntities<T>(IList<T> objList) where T : class
        {
            try
            {
                using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
                {
                    if (!context.Database.Exists())
                        context.Database.Create();
                    context.BulkInsert<T>(objList);
                    context.BulkSaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
