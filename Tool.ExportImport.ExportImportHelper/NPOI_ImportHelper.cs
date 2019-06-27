using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.Common.CommonHelper;
using Tool.DbModel.DTO;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.ExportImport.ExportImportHelper
{
    public class NPOI_ImportHelper
    {
        private IWorkbook workbook = null;
        public NPOI_ImportHelper(string filePath)
        {
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook(fs);
            else if (filePath.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook(fs);
        }
        public List<Tuple<DataTable, ImportType>> ExcelToDataTable(ImportType importType)
        {
            ISheet sheet = null;
            var result = new List<Tuple<DataTable, ImportType>>();
            try
            {
                switch (importType)
                {
                    case ImportType.All:
                        break;
                    case ImportType.Corportation:
                        sheet = workbook.GetSheet("法人");
                        break;
                    case ImportType.ProfitCenter:
                        sheet = workbook.GetSheet("利润中心");
                        break;
                    case ImportType.Post:
                        sheet = workbook.GetSheet("岗位");
                        break;
                    case ImportType.Permission:
                        sheet = workbook.GetSheet("权限");
                        break;
                    case ImportType.UserInfo:
                        sheet = workbook.GetSheet("用户");
                        break;
                    case ImportType.Commodity:
                        sheet = workbook.GetSheet("品种");
                        break;
                    //case ImportType.Exchange:
                    //    sheet = workbook.GetSheet("交易所");
                    //    break;
                    default:
                        break;
                }
                // 只导入单个sheet
                if (sheet != null)
                {
                    int startRow = 0;
                    DataTable table = new DataTable();
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum;
                    List<Tuple<string, int>> repeatColumns = new List<Tuple<string, int>>();
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        ICell cell = firstRow.GetCell(i);
                        if (cell != null && !string.IsNullOrEmpty(cell.StringCellValue))
                        {
                            string cellValue = cell.StringCellValue.Trim();
                            if (!string.IsNullOrEmpty(cellValue))
                            {
                                DataColumn column = new DataColumn(cellValue);
                                if (table.Columns.IndexOf(cellValue) > -1)
                                {
                                    repeatColumns.Add(Tuple.Create(cellValue, i));
                                    continue;
                                }
                                table.Columns.Add(column);
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    //每行数据的个数就是列数 这个列数为实际上有值的列数
                    cellCount = table.Columns.Count;

                    //最后一列的标号
                    int rowMaxIndex = sheet.LastRowNum;
                    for (int i = startRow; i <= rowMaxIndex; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.Cells.Count == 0
                            || row.Cells.ToList().All(q => GetCellValue(q) == null || string.IsNullOrEmpty(GetCellValue(q).ToString()))) continue; //没有数据的行默认是null　

                        if (row.FirstCellNum < 0) continue;
                        DataRow dataRow = table.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                var value = GetCellValue(row.GetCell(j));
                                var stringValue = new List<string>();
                                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                                {
                                    stringValue.Add(value.ToString());
                                }
                                // 存在重复
                                if (repeatColumns != null && repeatColumns.Count > 0)
                                {
                                    var repeatData = repeatColumns.Where(p => p.Item1 == table.Columns[j].ColumnName)?.ToList();
                                    repeatData.ForEach(x =>
                                    {
                                        if (!string.IsNullOrEmpty(row.GetCell(x.Item2)?.ToString()))
                                        {
                                            stringValue.Add(row.GetCell(x.Item2)?.ToString());
                                        }
                                    });
                                }
                                value = string.Join("、", stringValue);
                                dataRow[j] = value;
                            }
                        }
                        table.Rows.Add(dataRow);
                    }
                    result.Add(new Tuple<DataTable, ImportType>(table, importType));
                }
                else //查 所有
                {
                    if (sheet == null && importType != ImportType.All)
                    {
                        throw new Exception("未找到导入的数据");
                    }
                    for (int k = 0; k < workbook.NumberOfSheets; k++)
                    {
                        sheet = workbook.GetSheetAt(k);
                        if (!ConstValue.ImportValues.Contains(sheet.SheetName))
                        {
                            continue;
                        }
                        int startRow = 0;
                        DataTable table = new DataTable();
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum;
                        List<Tuple<string, int>> repeatColumns = new List<Tuple<string, int>>();
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null && !string.IsNullOrEmpty(cell.StringCellValue))
                            {
                                string cellValue = cell.StringCellValue.Trim();
                                if (!string.IsNullOrEmpty(cellValue))
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    if (table.Columns.IndexOf(cellValue) > -1)
                                    {
                                        repeatColumns.Add(Tuple.Create(cellValue, i));
                                        continue;
                                    }
                                    table.Columns.Add(column);
                                }
                            }
                            startRow = sheet.FirstRowNum + 1;
                        }
                        //每行数据的个数就是列数 这个列数为实际上有值的列数
                        cellCount = table.Columns.Count;

                        //最后一列的标号
                        int rowMaxIndex = sheet.LastRowNum;
                        for (int i = startRow; i <= rowMaxIndex; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null || row.Cells.Count == 0
                                || row.Cells.ToList().All(q => GetCellValue(q) == null || string.IsNullOrEmpty(GetCellValue(q).ToString()))) continue; //没有数据的行默认是null　

                            if (row.FirstCellNum < 0) continue;
                            DataRow dataRow = table.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                {
                                    var value = GetCellValue(row.GetCell(j));
                                    var stringValue = new List<string>();
                                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                                    {
                                        stringValue.Add(value.ToString());
                                    }
                                    // 存在重复
                                    if (repeatColumns != null && repeatColumns.Count > 0)
                                    {
                                        var repeatData = repeatColumns.Where(p => p.Item1 == table.Columns[j].ColumnName)?.ToList();
                                        repeatData.ForEach(x =>
                                        {
                                            if (!string.IsNullOrEmpty(row.GetCell(x.Item2)?.ToString()))
                                            {
                                                stringValue.Add(row.GetCell(x.Item2)?.ToString());
                                            }
                                        });
                                    }
                                    value = string.Join("、", stringValue);
                                    dataRow[j] = value;
                                }
                            }
                            table.Rows.Add(dataRow);
                        }
                        switch (sheet.SheetName)
                        {
                            case "法人":
                                result.Add(Tuple.Create(table, ImportType.Corportation));
                                break;
                            case "利润中心":
                                result.Add(Tuple.Create(table, ImportType.ProfitCenter));
                                break;
                            case "岗位":
                                result.Add(Tuple.Create(table, ImportType.Post));
                                break;
                            case "权限":
                                result.Add(Tuple.Create(table, ImportType.Permission));
                                break;
                            case "用户":
                                result.Add(Tuple.Create(table, ImportType.UserInfo));
                                break;
                            case "品种":
                                result.Add(Tuple.Create(table, ImportType.Commodity));
                                break;
                            //case "交易所":
                            //    result.Add(Tuple.Create(table, ImportType.Exchange));
                            //    break;
                            default:
                                break;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception("导入发生异常");
            }
        }
        private object GetCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell.CellType != CellType.Blank)
                {
                    switch (cell.CellType)
                    {
                        //Date Type的数据CellType是Numeric
                        case CellType.Numeric:
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                //两种时间格式  不带时间光日期的为14
                                if (cell.CellStyle.DataFormat == 14)
                                {
                                    value = cell.DateCellValue.ToShortDateString().Trim();
                                    break;
                                }

                                //带时间的为22
                                if (cell.CellStyle.DataFormat == 22)
                                {
                                    value = cell.DateCellValue;
                                    break;
                                }
                            }
                            else
                            {
                                // Numeric type
                                value = cell.NumericCellValue;
                            }
                            break;
                        case CellType.Boolean:
                            // Boolean type
                            value = cell.BooleanCellValue;
                            break;
                        case CellType.Formula:
                            //对于公式，要判断是否有值在做处理
                            try
                            {
                                HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                                e.EvaluateInCell(cell);
                                value = cell.ToString().Replace("\n", "").Replace("\t", "").Replace("\r", "").Trim();
                            }
                            catch
                            {
                                value = GetFormulaCellValue(cell);
                            }
                            break;
                        case CellType.Error:
                            value = "";
                            break;
                        default:
                            // String type
                            value = cell.StringCellValue.Replace("\n", "").Replace("\t", "").Replace("\r", "").Trim();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                value = "";
            }
            return value ?? "".ToString().Trim();
        }
        private object GetFormulaCellValue(ICell cell)
        {
            object value = null;

            //首先判断是否有值 ErrorCellValue有值说明无值
            try
            {
                value = cell.ErrorCellValue;
                value = "";
                return value;
            }
            catch
            {
                value = "";
            }

            try
            {
                if (DateUtil.IsCellDateFormatted(cell))//日期
                {
                    //两种时间格式  不带时间光日期的为14
                    if (cell.CellStyle.DataFormat == 14)
                    {
                        value = cell.DateCellValue.ToShortDateString();
                        return value;
                    }

                    //带时间的为22
                    if (cell.CellStyle.DataFormat == 22)
                    {
                        value = cell.DateCellValue;
                        return value;
                    }
                }
                else
                {
                    try
                    {
                        value = cell.NumericCellValue;
                        return value;
                    }
                    catch
                    {
                        value = "";
                    }
                }
            }
            catch
            {
                value = "";
            }

            try
            {
                value = cell.StringCellValue.Replace("\n", "").Replace("\t", "").Replace("\r", "");
                return value;
            }
            catch
            {
                value = "";
            }

            try
            {
                value = cell.RichStringCellValue;
                return value;
            }
            catch
            {
                value = "";
            }

            return value;
        }
    }
}
