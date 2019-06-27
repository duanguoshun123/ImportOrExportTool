using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tool.Common.CommonHelper;
using Tool.DbModel.DTO.ConfigModel;
using Tool.DbModel.Model;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.BL.AOP.Extension
{
    public static class Extension
    {
        public static List<T> DataTableToList<T, M>(this DataTable dataTable)
   where T : class
   where M : MappingContext<ImportMappingModel>
        {
            MappingContext<ImportMappingModel> context = Activator.CreateInstance<M>();
            var models = context.Mapping.ImportModels;
            if (models == null || models.Count == 0)
                return null;
            List<T> dataList = new List<T>();
            foreach (var row in dataTable.Select())
            {
                T data = Activator.CreateInstance<T>();
                PropertyInfo[] properties = typeof(T).GetProperties();
                if (ResolveExcelData(row, data, properties, models))
                    dataList.Add(data);
            }
            return dataList;
        }
        private static bool ResolveExcelData(DataRow row, object tradeObject, PropertyInfo[] properties, List<ImportModel> importModels)
        {
            bool result = false;

            foreach (var property in properties)
            {
                //如果该属性是数据来源，则为手工录入
                if (property.Name == "FeedSource")
                {
                    property.SetValue(tradeObject, "FS0001", null);
                    continue;
                }
                var model = importModels.SingleOrDefault(a => a.Code == property.Name);
                //如果该属性不是配置中的则不做处理
                if (model == null)
                    continue;
                //如果该属性是可空的又恰好为空则忽略
                if (model.AllowNullOrEmpty && string.IsNullOrEmpty(row[model.ColumnName].ToString()))
                    continue;
                //如果该属性在配置中但不在Excel中则不赋值（这种情况只有可选项）
                if (!row.Table.Columns.Contains(model.ColumnName) && model.IsOptional)
                    continue;
                //如果该属性是在集合中绑定的，则mapping
                if (model.BindingList != null && !string.IsNullOrEmpty(model.BindingValue) && !string.IsNullOrEmpty(model.BindingMember) && !model.IsVerifyStrategy)
                {
                    var obj = model.BindingList.FirstOrDefault(a => a.GetPropertyValue(model.BindingMember).ToString() == row[model.ColumnName].ToString());
                    property.SetValue(tradeObject, obj.GetPropertyValue(model.BindingValue), null);
                    result = true;
                    continue;
                }
                if (model.BindingList != null && !string.IsNullOrEmpty(model.BindingValue) && !string.IsNullOrEmpty(model.BindingMember) && model.IsVerifyStrategy)
                {
                    var columnNames = row[model.ColumnName].ToString();
                    if (columnNames == null)
                    {
                        result = true;
                        continue;
                    }
                    var ids = columnNames.TrimEnd(',').Split(',');
                    string names = "";
                    foreach (var id in ids)
                    {
                        var obj = model.BindingList.FirstOrDefault(a => a.GetPropertyValue(model.BindingMember).ToString() == id);
                        names += obj.GetPropertyValue(model.BindingValue) + ",";
                    }
                    names = names?.TrimStart(',');
                    names = names?.TrimEnd(',');
                    property.SetValue(tradeObject, names, null);
                    result = true;
                    continue;
                }

                switch (model.DataType)
                {
                    case DataType.String:
                        {
                            var data = row[model.ColumnName].ToString();
                            property.SetValue(tradeObject, data, null);
                            result = true;
                            break;
                        }
                    case DataType.IntDateTime:
                        {
                            var data = row[model.ColumnName].ToString();
                            DateTime time = DateTime.Parse(data);
                            string timeStr = time.ToString(model.DataType.GetAttributeInfo<NoteAttribute>("Note")?.ToString());
                            int newTime = int.Parse(timeStr);
                            property.SetValue(tradeObject, newTime, null);
                            result = true;
                            break;
                        }
                    case DataType.ShortDateTime:
                    case DataType.FullDateTime:
                        {
                            var data = row[model.ColumnName].ToString();
                            DateTime time = DateTime.Parse(data);
                            string timeStr = time.ToString(model.DataType.GetAttributeInfo<NoteAttribute>("Note")?.ToString());
                            DateTime newTime = DateTime.Parse(timeStr);
                            property.SetValue(tradeObject, newTime, null);
                            result = true;
                            break;
                        }
                    case DataType.Decimal:
                        {
                            var data = row[model.ColumnName].ToString();
                            if (data.Equals(DeferredDirection.ExcessSpace.GetAttributeInfo<NoteAttribute>("Note")?.ToString()))
                                data = "1";
                            if (data.Equals(DeferredDirection.EmptyPayMore.GetAttributeInfo<NoteAttribute>("Note")?.ToString()))
                                data = "-1";
                            data = Decimal.Parse(data.ToString(), System.Globalization.NumberStyles.Float).ToString();
                            Decimal value = Decimal.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.Int:
                        {
                            var data = row[model.ColumnName].ToString();
                            Int32 value = int.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.Long:
                        {
                            var data = row[model.ColumnName].ToString();
                            long value = long.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.Double:
                        {
                            var data = row[model.ColumnName].ToString();
                            Double value = Double.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.Bool:
                        {
                            var data = row[model.ColumnName].ToString();
                            bool value = bool.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.Short:
                        {
                            var data = row[model.ColumnName].ToString();
                            short value = short.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                    case DataType.TimeSpan:
                        {
                            var data = row[model.ColumnName].ToString();
                            TimeSpan value = TimeSpan.Parse(data);
                            property.SetValue(tradeObject, value, null);
                            result = true;
                            break;
                        }
                }
            }
            return result;
        }
    }
}
