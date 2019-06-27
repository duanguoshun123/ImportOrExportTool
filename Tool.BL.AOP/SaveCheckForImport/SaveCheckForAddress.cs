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
    public class SaveCheckForAddress : MappingContext<ImportMappingModel>
    {
        protected override ImportMappingModel Initialze()
        {
            ImportMappingModel model = new ImportMappingModel();
            model.ImportModels.Add(new ImportModel()
            {
                Code = "Name",
                ColumnName = "办公地址",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "Address",
                ColumnName = "办公地址",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "AccountingName",
                ColumnName = "法人Code",
            });
            return model;
        }
    }
}
