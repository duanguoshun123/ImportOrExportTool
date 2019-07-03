using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.BL.BussinessLayer.Tool.BL.BussinessLayer.Interface
{
    public interface IImportManager
    {
        Tuple<bool, string, MsgType> Import(Tuple<DataTable, ImportType,int> datas);
    }
}
