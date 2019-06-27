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
    public class CommodityProvider
    {
        public void AddCommodityType(List<WFCommodityType_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCommodityType_Dto, WFCommodityType>();
                DataWriter.AddEntities(datas)?.AutoMapList<WFCommodityType, WFCommodityType_Dto>();
            }
        }
        public void UpdateCommodityType(List<WFCommodityType_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCommodityType_Dto, WFCommodityType>();
                DataWriter.UpdateEntities(datas);
            }
        }
        public void DeleteCommodityType(List<WFCommodityType_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCommodityType_Dto, WFCommodityType>();
                DataWriter.DeleteEntities(datas);
            }
        }
        /// <summary>
        /// 获取所有的品类
        /// </summary>
        /// <returns></returns>
        public IList<WFCommodityType_Dto> GetAllCommodityType()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCommodityType?.ToList();
                return result.AutoMapList<WFCommodityType, WFCommodityType_Dto>();
            }
        }
        public List<WFUnit_Dto> GetAllUnit()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFUnit?.ToList();
                return result.AutoMapList<WFUnit, WFUnit_Dto>();
            }
        }

        public List<WFCommodityCategory_Dto> GetAllCommodityCategory()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCommodityCategory?.ToList();
                return result.AutoMapList<WFCommodityCategory, WFCommodityCategory_Dto>();
            }
        }
        public List<WFCommodityCategory_Dto> AddWFCommodityCategory(List<WFCommodityCategory_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCommodityCategory_Dto, WFCommodityCategory>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFCommodityCategory, WFCommodityCategory_Dto>();
            }
        }
    }
}
