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
    public class CorporationProvider
    {
        public IList<WFCompany_Dto> AddCorporations(List<WFCompany_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCompany_Dto, WFCompany>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFCompany, WFCompany_Dto>();
            }
        }
        public void UpdateCorporations(List<WFCompany_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCompany_Dto, WFCompany>();
                DataWriter.UpdateEntities(datas);
            }
        }

        public void DeleteCorporations(List<WFCompany_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCompany_Dto, WFCompany>();
                DataWriter.UpdateEntityByProperty(datas, new PropertiesBuilder<WFCompany>()
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
        public IList<WFCompany_Dto> GetAllCorporations()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCompany.Where(p => !p.IsDeleted)?.ToList();
                return result.AutoMapList<WFCompany, WFCompany_Dto>();
            }
        }
        public IList<WFCorporationTypeConfiguration_Dto> AddCorporationTypeConfigurations(List<WFCorporationTypeConfiguration_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCorporationTypeConfiguration_Dto, WFCorporationTypeConfiguration>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFCorporationTypeConfiguration, WFCorporationTypeConfiguration_Dto>();
            }
        }
        public IList<WFCorporationTypeConfiguration_Dto> GetAllCorporationTypeConfiguration()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCorporationTypeConfiguration.Where(p => !p.IsDeleted)?.ToList();
                return result.AutoMapList<WFCorporationTypeConfiguration, WFCorporationTypeConfiguration_Dto>();
            }
        }
        public IList<WFCurrency_Dto> GetAllCurrency()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCurrency.Where(p => !p.IsDeleted)?.ToList();
                return result.AutoMapList<WFCurrency, WFCurrency_Dto>();
            }
        }
    }
}
