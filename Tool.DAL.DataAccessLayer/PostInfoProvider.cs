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
    public class PostInfoProvider
    {
        public IList<WFPost_Dto> AddPosts(List<WFPost_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFPost_Dto, WFPost>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFPost, WFPost_Dto>();
            }
        }
        public void UpdatePosts(List<WFPost_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFPost_Dto, WFPost>();
                DataWriter.UpdateEntities(datas);
            }
        }
        public void UpdateRoleInfoByQcyKey(List<WFRoleInfo_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRoleInfo_Dto, WFRoleInfo>();
                DataWriter.UpdateEntityByProperty(datas, new PropertiesBuilder<WFRoleInfo>().Append(x => x.QctKey).Append(x => x.LastUpdateTime).PropertyNames);
            }
        }
        public void UpdateRolesInfo(List<WFRoleInfo_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRoleInfo_Dto, WFRoleInfo>();
                DataWriter.UpdateEntities(datas);
            }
        }
        public void UpdateRoleInfoByModule(List<WFRoleInfo_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRoleInfo_Dto, WFRoleInfo>();
                DataWriter.UpdateEntityByProperty(datas, new PropertiesBuilder<WFRoleInfo>().Append(x => x.Module).Append(x => x.LastUpdateTime).PropertyNames);
            }
        }
        public void DeletePosts(List<WFPost_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFPost_Dto, WFPost>();
                DataWriter.DeleteEntities(datas);
            }
        }
        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public IList<WFPost_Dto> GetAllPost()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFPost?.ToList();
                return result.AutoMapList<WFPost, WFPost_Dto>();
            }
        }

        public IList<WFRoleInfo_Dto> AddRoleInfos(List<WFRoleInfo_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRoleInfo_Dto, WFRoleInfo>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFRoleInfo, WFRoleInfo_Dto>();
            }
        }
        public IList<WFUserRole_Dto> AddUserRoles(List<WFUserRole_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFUserRole_Dto, WFUserRole>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFUserRole, WFUserRole_Dto>();
            }
        }
        public IList<WFRoleBusiness_Dto> AddRoleBusiness(List<WFRoleBusiness_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFRoleBusiness_Dto, WFRoleBusiness>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFRoleBusiness, WFRoleBusiness_Dto>();
            }
        }

        /// <summary>
        /// 获取所有的角色岗位信息
        /// </summary>
        /// <returns></returns>
        public IList<WFRoleInfo_Dto> GetAllRoleInfo()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFRoleInfo?.ToList();
                return result.AutoMapList<WFRoleInfo, WFRoleInfo_Dto>();
            }
        }
        /// <summary>
        /// 获取所有的用户角色信息
        /// </summary>
        /// <returns></returns>
        public IList<WFUserRole_Dto> GetAllUserRoleInfo()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFUserRole?.ToList();
                return result.AutoMapList<WFUserRole, WFUserRole_Dto>();
            }
        }

        /// <summary>
        /// 获取所有的业务角色信息
        /// </summary>
        /// <returns></returns>
        public IList<WFRoleBusiness_Dto> GetAllRoleBusinessInfo()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFRoleBusiness?.ToList();
                return result.AutoMapList<WFRoleBusiness, WFRoleBusiness_Dto>();
            }
        }
    }
}
