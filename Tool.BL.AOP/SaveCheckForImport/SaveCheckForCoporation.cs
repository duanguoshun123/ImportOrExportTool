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
    public class SaveCheckForCoporation : MappingContext<ImportMappingModel>
    {
        protected override ImportMappingModel Initialze()
        {
            ImportMappingModel model = new ImportMappingModel();
            model.ImportModels.Add(new ImportModel()
            {
                Code = "ShortName",
                ColumnName = "简称",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "FullName",
                ColumnName = "全称",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "AccountingName",
                ColumnName = "法人Code",
            });
            model.ImportModels.Add(new ImportModel()
            {
                Code = "OurCorporationFunctionalCurrencyName",
                ColumnName = "本位币",
            });
            return model;
        }
    }
}
