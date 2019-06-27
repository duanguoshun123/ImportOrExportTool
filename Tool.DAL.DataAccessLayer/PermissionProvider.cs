using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.DAL.DataAccessLayer.AutoMapper;
using Tool.DbModel.DTO;
using Tool.EF.DbContext;

namespace Tool.DAL.DataAccessLayer
{
    public class PermissionProvider
    {
        public void AddRolePrivileges(List<WFRolePrivilege_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRolePrivilege_Dto, WFRolePrivilege>();
                DataWriter.BulkInsertEntities(datas);//?.AutoMapList<WFRolePrivilege, WFRolePrivilege_Dto>();
            }
        }
        public void UpdateRolePrivileges(List<WFRolePrivilege_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRolePrivilege_Dto, WFRolePrivilege>();
                DataWriter.UpdateEntities(datas);
            }
        }
        public void DeleteRolePrivileges(List<WFRolePrivilege_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRolePrivilege_Dto, WFRolePrivilege>();
                DataWriter.DeleteEntities(datas);
            }
        }
        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public IList<WFRolePrivilege_Dto> GetAllRolePrivilege()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFRolePrivilege?.ToList();
                return result.AutoMapList<WFRolePrivilege, WFRolePrivilege_Dto>();
            }
        }

    }
}
