using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.DAL.DataAccessLayer.AutoMapper;
using Tool.DbModel.DTO;
using Tool.EF.DbContext;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.DAL.DataAccessLayer
{
    public class ExchangeProvider
    {
        public IList<WFCompany_Dto> AddExcahnges(List<WFCompany_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCompany_Dto, WFCompany>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFCompany, WFCompany_Dto>();
            }
        }
        public void UpdateExcahnges(List<WFCompany_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCompany_Dto, WFCompany>();
                DataWriter.UpdateEntities(datas);
            }
        }

        public void DeleteExcahnges(List<WFCompany_Dto> dtos)
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
        public IList<WFCompany_Dto> GetAllExcahnges()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFCompany.Where(p => p.Type == (int)CorporationTypeFlag.Exchange).Where(p => !p.IsDeleted)?.ToList();
                return result.AutoMapList<WFCompany, WFCompany_Dto>();
            }
        }
        public IList<WFInstrument_Dto> AddInstrument(List<WFInstrument_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFInstrument_Dto, WFInstrument>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFInstrument, WFInstrument_Dto>();
            }
        }
        public IList<WFInstrumentCategory_Dto> AddInstrument(List<WFInstrumentCategory_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFInstrumentCategory_Dto, WFInstrumentCategory>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFInstrumentCategory, WFInstrumentCategory_Dto>();
            }
        }

        public IList<WFCorporationTypeConfiguration_Dto> AddCorporationTypeConfiguration(List<WFCorporationTypeConfiguration_Dto> dtos)
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var datas = dtos.AutoMapList<WFCorporationTypeConfiguration_Dto, WFCorporationTypeConfiguration>();
                return DataWriter.AddEntities(datas)?.AutoMapList<WFCorporationTypeConfiguration, WFCorporationTypeConfiguration_Dto>();
            }
        }
        public IList<WFAdditionalConfiguration_Dto> GetWFAdditionalConfiguration()
        {
            using (OperationSystem_HBMSEntities context = new OperationSystem_HBMSEntities())
            {
                var result = context.WFAdditionalConfiguration?.ToList();
                return result.AutoMapList<WFAdditionalConfiguration, WFAdditionalConfiguration_Dto>();
            }
        }
    }
}
