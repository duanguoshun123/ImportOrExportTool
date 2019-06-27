using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.DbModel.DTO;
using Tool.DbModel.DTO.ConfigModel;
using Tool.DbModel.Model;

namespace Tool.BL.AOP.SaveCheckForImport
{
    public class SaveCheckForProfitCenter : MappingContext<ImportMappingModel>
    {
        protected override ImportMappingModel Initialze()
        {
            ImportMappingModel model = new ImportMappingModel();
            model.ImportModels.Add(new ImportModel()
            {
                Code = "WFAccountEntityId",
                ColumnName = "ID",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "Name",
                ColumnName = "名称",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "AccountingName",
                ColumnName = "利润中心名称",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "ParentDepartmentId",
                ColumnName = "法人Code",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "Type",
                ColumnName = "类别",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "IsAccounting",
                ColumnName = "是否利润中心",
            });
            return model;
        }
    }
}
