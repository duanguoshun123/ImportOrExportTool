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
    public class UserProvider
    {
        public IList<WFUser_Dto> AddUsers(List<WFUser_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFUser_Dto, WFUser>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFUser, WFUser_Dto>();
            }
        }
        public void UpdateUsers(List<WFUser_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFUser_Dto, WFUser>();
                DataWriter.UpdateEntities(datas);
            }
        }

        public void DeleteUsers(List<WFUser_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFUser_Dto, WFUser>();
                DataWriter.UpdateEntityByProperty(datas, new PropertiesBuilder<WFUser>()
                    .Append(p => p.IsDeleted)
                    .Append(p => p.LastManipulationTime)
                    .PropertyNames
                 );
            }
        }
        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public IList<WFUser_Dto> GetAllUsers()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFUser.Where(p => !p.IsDeleted)?.ToList();
                return result.AutoMapList<WFUser, WFUser_Dto>();
            }
        }

        public IList<WFOfficeAddress_Dto> GetAllOfficeAddress()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFOfficeAddress?.ToList();
                return result.AutoMapList<WFOfficeAddress, WFOfficeAddress_Dto>();
            }
        }

        public IList<WFOfficeAddress_Dto> AddOfficeAddress(List<WFOfficeAddress_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFOfficeAddress_Dto, WFOfficeAddress>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFOfficeAddress, WFOfficeAddress_Dto>();
            }
        }
    }
}
