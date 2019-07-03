using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Tool.BL.AOP.Extension;
using Tool.BL.AOP.SaveCheckForImport;
using Tool.BL.BussinessLayer.Tool.BL.BussinessLayer.Interface;
using Tool.Common.CommonHelper;
using Tool.DAL.DataAccessLayer;
using Tool.DbModel.DTO;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.BL.BussinessLayer.Tool.BL.BussinessLayer.Manager
{
    public class ImportManager : IImportManager
    {
        private const string operatorName = "admin";
        private CorporationProvider corporationProvider = new CorporationProvider();
        private AccountEntityProvider accountEntityProvider = new AccountEntityProvider();
        private UserProvider userProvider = new UserProvider();
        private PostInfoProvider postInfoProvider = new PostInfoProvider();
        private PermissionProvider permissionProvider = new PermissionProvider();
        private CommodityProvider commodityProvider = new CommodityProvider();
        private ExchangeProvider exchangeProvider = new ExchangeProvider();
        public Tuple<bool, string, MsgType> Import(Tuple<DataTable, ImportType, int> datas)
        {
            var corporationList = new List<WFCompany_Dto>();
            var profitCenterList = new List<WFAccountEntity_Dto>();
            var userInfo = new List<WFUser_Dto>();
            var userAddress = new List<WFOfficeAddress_Dto>();
            var postInfo = new List<WFPost_Dto>();
            var roleInfo = new List<WFRoleInfo_Dto>();
            var rolePriviledgeInfo = new List<WFRolePrivilege_Dto>();
            var commodityTypeInfo = new List<WFCommodityType_Dto>();
            var exchangeInfo = new List<WFCompany_Dto>();
            var departmentInfo = new List<WFAccountEntity_Dto>();
            var sPRolePriviledgeInfo = new List<WFRolePrivilege_Dto>();
            Tuple<List<WFRolePrivilege_Dto>, List<string>> SPRolePermissionInfo = new Tuple<List<WFRolePrivilege_Dto>, List<string>>(new List<WFRolePrivilege_Dto>(), new List<string>());
            // 法人
            if (datas.Item2 == ImportType.Corportation)
            {
                corporationList = datas.Item1.DataTableToList<WFCompany_Dto, SaveCheckForCoporation>();
            }
            // 利润中心
            if (datas.Item2 == ImportType.ProfitCenter)
            {
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    int index = 7;
                    for (int k = index; k >= 1; k--)
                    {
                        var accountEntity = AddWFAccountEntity(k);
                        if (accountEntity != null)
                        {
                            if (!profitCenterList.Any(p => p.IsAtomicAccounting == accountEntity.IsAtomicAccounting && p.Name == accountEntity.Name))
                            {
                                profitCenterList.Add(accountEntity);
                            }
                        }
                    }
                    WFAccountEntity_Dto AddWFAccountEntity(int indexNumber)
                    {
                        if (string.IsNullOrEmpty(datas.Item1.Rows[i][$"利润中心{indexNumber}"]?.ToString()))
                        {
                            index--;
                            return null;
                        }
                        var names = new List<string>();
                        var itemNames = datas.Item1.Rows[i]["所需指标（各个利润中心)"]?.ToString()?.Contains("、") == true ? datas.Item1.Rows[i]["所需指标（各个利润中心)"]?.ToString()?.Split('、')?.ToList() : datas.Item1.Rows[i]["所需指标（各个利润中心)"]?.ToString()?.Split('、')?.ToList();
                        var itemNames2 = datas.Item1.Rows[i]["所需指标（通用）"]?.ToString()?.Contains("、") == true ? datas.Item1.Rows[i]["所需指标（通用）"]?.ToString()?.Split('、')?.ToList() : datas.Item1.Rows[i]["所需指标（通用）"]?.ToString()?.Split('、')?.ToList();
                        var itemNames3 = datas.Item1.Rows[i]["所需指标（额外配置）"]?.ToString()?.Contains("、") == true ? datas.Item1.Rows[i]["所需指标（额外配置）"]?.ToString()?.Split('、')?.ToList() : datas.Item1.Rows[i]["所需指标（额外配置）"]?.ToString()?.Split('、')?.ToList();
                        names.AddRange(itemNames);
                        names.AddRange(itemNames2);
                        names.AddRange(itemNames3);
                        return new WFAccountEntity_Dto()
                        {
                            Type = 1,
                            Name = datas.Item1.Rows[i][$"利润中心{indexNumber}"]?.ToString(),
                            AccountingName = datas.Item1.Rows[i][$"利润中心{indexNumber}"]?.ToString(),
                            IsAccounting = true,
                            IsAtomicAccounting = indexNumber == index ? true : false,
                            IsHedgeAccounting = datas.Item1.Rows[i]["是否套保利润中心"]?.ToString() == "是" ? true : false,
                            ParentAccountEntityName = indexNumber - 1 == 0 ? null : datas.Item1.Rows[i][$"利润中心{indexNumber - 1}"]?.ToString(),
                            BusinessPlateName = indexNumber == index ? datas.Item1.Rows[i]["涵盖的业务板块"]?.ToString() : null,
                            Level = indexNumber,
                            Indicatornames = names
                        };
                    };
                }
            }
            // 用户
            if (datas.Item2 == ImportType.UserInfo)
            {
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    userInfo.Add(new WFUser_Dto()
                    {
                        Name = datas.Item1.Rows[i]["用户名"]?.ToString(),
                        LoginName = datas.Item1.Rows[i]["登录名"]?.ToString(),
                        MailAddress = datas.Item1.Rows[i]["邮件"]?.ToString(),
                        OfficePhone = datas.Item1.Rows[i]["办公电话"]?.ToString(),
                        Fax = datas.Item1.Rows[i]["传真"]?.ToString(),
                        WFOfficeAddressName = datas.Item1.Rows[i]["办公地址"]?.ToString()
                    });
                    userAddress.Add(new WFOfficeAddress_Dto()
                    {
                        Name = datas.Item1.Rows[i]["办公地址"]?.ToString(),
                        Address = datas.Item1.Rows[i]["办公地址"]?.ToString(),
                        EnglishAddress = "",
                    });
                }
            }
            // 品种
            if (datas.Item2 == ImportType.Commodity)
            {
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    commodityTypeInfo.Add(new WFCommodityType_Dto()
                    {
                        Name = datas.Item1.Rows[i]["品种名称"]?.ToString(),
                        AccountingName = datas.Item1.Rows[i]["品种名称"]?.ToString(),
                        Code = datas.Item1.Rows[i]["品种名称"]?.ToString(),
                        IsPricing = true,
                        IsFundamentalComponent = true,
                        WFCommodityCategoryName = datas.Item1.Rows[i]["品种类型"]?.ToString(),
                        WFUnitName = datas.Item1.Rows[i]["默认重量单位"]?.ToString(),
                    });
                }
            }
            // 岗位
            if (datas.Item2 == ImportType.Post)
            {
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(datas.Item1.Rows[i]["岗位名称"]?.ToString()))
                    {
                        roleInfo.Add(new WFRoleInfo_Dto()
                        {
                            Name = datas.Item1.Rows[i]["岗位名称"]?.ToString(),
                            UserNames = datas.Item1.Rows[i]["用户"]?.ToString().Split('、')?.ToList(),
                            IsForbiddenCorporation = datas.Item1.Rows[i]["是否限制法人"]?.ToString() == "是" ? true : false,
                            CorportionName = datas.Item1.Rows[i]["法人"]?.ToString(),
                            OurCorporationAccountEntitiesNames = datas.Item1.Rows[i]["岗位可操作的本法人的利润中心"]?.ToString().Trim().Split('、')?.ToList(),
                            PostNames = datas.Item1.Rows[i]["岗位分类"]?.ToString().Split('、')?.Where(p => !string.IsNullOrEmpty(p))?.ToList(),
                            OtherAccountEntitiesNames = datas.Item1.Rows[i]["岗位其他可见利润中心清单"]?.ToString().Trim().Split('、')?.ToList(),
                            OtherCorporationName = datas.Item1.Rows[i]["岗位其他可见法人清单"]?.ToString(),
                        });
                        if (!departmentInfo.Any(p => p.Name == datas.Item1.Rows[i]["法人"]?.ToString()))
                        {
                            departmentInfo.Add(new WFAccountEntity_Dto()
                            {
                                Name = datas.Item1.Rows[i]["法人"]?.ToString(),
                                IsAccounting = false,
                                Type = (int)DepartmentType.Department
                            });
                        }

                    }
                }
            }
            // 权限
            if (datas.Item2 == ImportType.Permission)
            {
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    var privilegeValue = string.IsNullOrEmpty(datas.Item1.Rows[i]["权限值"]?.ToString()) ? 0 : int.Parse(datas.Item1.Rows[i]["权限值"]?.ToString());
                    rolePriviledgeInfo.Add(new WFRolePrivilege_Dto()
                    {
                        Privilege = privilegeValue,
                        Module = ModuleEnumValue(datas.Item1.Rows[i]["系统平台"]?.ToString(), typeof(RouteContextModule)),
                        WFRoleInfoNames = datas.Item1.Rows[i]["岗位清单"]?.ToString()?.Split('、')?.ToList(),
                        ModuleName = datas.Item1.Rows[i]["系统平台"]?.ToString(),
                        PermissionName = datas.Item1.Rows[i]["权限名称"]?.ToString()
                    });
                }
            };
            // 标准岗位角色权限
            if (datas.Item2 == ImportType.SPRolePermission)
            {
                var listForSPNames = new List<string>();
                var listNotSPNames = new List<string>() { "系统平台", "权限值", "岗位清单", "权限名称", "权限英文名", "模块" };
                for (int i = 0; i < datas.Item1.Columns.Count; i++)
                {
                    if (!listNotSPNames.Contains(datas.Item1.Columns[i].ColumnName))
                    {
                        listForSPNames.Add(datas.Item1.Columns[i].ColumnName);
                    }
                }
                for (int i = 0; i < datas.Item1.Rows.Count; i++)
                {
                    var privilegeValue = string.IsNullOrEmpty(datas.Item1.Rows[i]["权限值"]?.ToString()) ? 0 : int.Parse(datas.Item1.Rows[i]["权限值"]?.ToString());
                    listForSPNames.ForEach(x =>
                    {
                        if (datas.Item1.Rows[i][x]?.ToString() == "是")
                        {
                            sPRolePriviledgeInfo.Add(new WFRolePrivilege_Dto()
                            {
                                Privilege = privilegeValue,
                                Module = ModuleEnumValue(datas.Item1.Rows[i]["系统平台"]?.ToString(), typeof(RouteContextModule)),
                                ModuleName = datas.Item1.Rows[i]["系统平台"]?.ToString(),
                                PermissionName = datas.Item1.Rows[i]["权限名称"]?.ToString(),
                                WFRoleInfoNames = new List<string>() { x }
                            });
                        }

                    });
                }
                SPRolePermissionInfo = new Tuple<List<WFRolePrivilege_Dto>, List<string>>(sPRolePriviledgeInfo, listForSPNames);
            }
            StringBuilder msg = new StringBuilder();
            Tuple<bool, string, MsgType> coporationsOpResult;
            Tuple<bool, string, MsgType> accoutEntityOpResult;
            Tuple<bool, string, MsgType> userInfoOpResult;
            Tuple<bool, string, MsgType> roleInfoOpResult;
            Tuple<bool, string, MsgType> rolePriviledgeOpResult;
            Tuple<bool, string, MsgType> commodityTypeOpResult;
            Tuple<bool, string, MsgType> spRolePermissionOpResult;
            bool isSuccess = true;
            MsgType type = MsgType.Default;
            if (corporationList != null && corporationList.Count != 0)
            {
                coporationsOpResult = ImportCorporation(corporationList);
                isSuccess = coporationsOpResult.Item1;
                msg.AppendLine(coporationsOpResult.Item2);
                type = coporationsOpResult.Item3;
            }
            if (profitCenterList != null && profitCenterList.Count != 0)
            {
                accoutEntityOpResult = ImportProfitCenter(profitCenterList);
                isSuccess = accoutEntityOpResult.Item1;
                msg.AppendLine(accoutEntityOpResult.Item2);
                type = accoutEntityOpResult.Item3;
            }
            if (userInfo != null && userInfo.Count != 0)
            {
                userInfoOpResult = ImportUserInfo(userInfo, userAddress);
                isSuccess = userInfoOpResult.Item1;
                msg.AppendLine(userInfoOpResult.Item2);
                type = userInfoOpResult.Item3;
            }
            if (roleInfo != null && roleInfo.Count != 0)
            {
                roleInfoOpResult = ImportPostInfo(roleInfo, departmentInfo);
                isSuccess = roleInfoOpResult.Item1;
                msg.AppendLine(roleInfoOpResult.Item2);
                type = roleInfoOpResult.Item3;
            }
            if (rolePriviledgeInfo != null && rolePriviledgeInfo.Count > 0)
            {
                rolePriviledgeOpResult = ImportPermissionInfo(rolePriviledgeInfo);
                isSuccess = rolePriviledgeOpResult.Item1;
                msg.AppendLine(rolePriviledgeOpResult.Item2);
                type = rolePriviledgeOpResult.Item3;
            }
            if (commodityTypeInfo != null && commodityTypeInfo.Count > 0)
            {
                commodityTypeOpResult = ImportCommodityTypeInfo(commodityTypeInfo);
                isSuccess = commodityTypeOpResult.Item1;
                msg.AppendLine(commodityTypeOpResult.Item2);
                type = commodityTypeOpResult.Item3;
            }
            if (SPRolePermissionInfo.Item1.Count > 0)
            {
                spRolePermissionOpResult = ImportSPRolePermissionsInfo(SPRolePermissionInfo);
                isSuccess = spRolePermissionOpResult.Item1;
                msg.AppendLine(spRolePermissionOpResult.Item2);
                type = spRolePermissionOpResult.Item3;
            }
            if (isSuccess)
            {
                return Tuple.Create(true, msg.ToString(), type);
            }
            else
            {
                return Tuple.Create(false, msg.ToString(), MsgType.Err);
            }

        }

        /// <summary>
        /// 导入法人主数据
        /// </summary>
        /// <param name="company_Dtos"></param>
        public Tuple<bool, string, MsgType> ImportCorporation(List<WFCompany_Dto> company_Dtos)
        {
            #region check
            var allCompany = corporationProvider.GetAllCorporations();
            var allCurrency = corporationProvider.GetAllCurrency()?.ToList();
            var listToAdd = new List<WFCompany_Dto>();
            StringBuilder errMsg = new StringBuilder();
            foreach (var item in company_Dtos)
            {
                if (allCompany.Any(p => p.WFCompanyId != item.WFCompanyId && (p.AccountingName == item.AccountingName || p.FullName == item.FullName || p.ShortName == item.ShortName)))
                {
                    Logger.Warn($"导入法人数据时,法人【{item.FullName}】已存在,不进行导入");
                    errMsg.AppendLine($"导入法人数据时,法人【{item.FullName}】已存在,不进行导入");
                }
                else
                {
                    if (company_Dtos.Count(p => p.AccountingName == item.AccountingName && p.FullName == item.FullName && p.ShortName == item.ShortName) > 1)
                    {
                        if (!listToAdd.Any(p => p.AccountingName == item.AccountingName && p.FullName == item.FullName && p.ShortName == item.ShortName))
                        {
                            Logger.Warn($"导入法人数据时,法人{item.FullName}存在重复，默认取第一条");
                            errMsg.AppendLine($"导入法人数据时,法人{item.FullName}存在重复，默认取第一条");
                            listToAdd.Add(item);
                        }
                    }
                    else
                    {
                        listToAdd.Add(item);
                    }
                }
            }
            listToAdd.ForEach(x =>
            {
                x.LastManipulationTime = DateTime.Now;
                x.CreationTime = DateTime.Now;
                x.Type = (int)CorporationTypeFlag.Client;
                x.MetaCompanyType = (int)MetaCompanyType.Corporation;
                x.RelationCategory = (int)CorporationRelationCategory.Internal;
                x.Abbreviation = x.ShortName;
                x.OurCorporationFunctionalCurrencyId = allCurrency.Where(p => p.Name == x.OurCorporationFunctionalCurrencyName)?.FirstOrDefault()?.WFCurrencyId;

            });
            #endregion

            #region 实现导入
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    company_Dtos = corporationProvider.AddCorporations(listToAdd)?.ToList();
                    var wFCorporationTypeConfiguration = new List<WFCorporationTypeConfiguration_Dto>();
                    company_Dtos.ForEach(x =>
                    {
                        wFCorporationTypeConfiguration.Add(new WFCorporationTypeConfiguration_Dto()
                        {
                            WFCompanyId = x.WFCompanyId,
                            CorporationType = x.Type,
                        });
                    });
                    var allCorporationTypeConfiguration = corporationProvider.GetAllCorporationTypeConfiguration();
                    var wFCorporationTypeConfigurationToAdd = new List<WFCorporationTypeConfiguration_Dto>();
                    wFCorporationTypeConfiguration.ForEach(x =>
                    {
                        if (!allCorporationTypeConfiguration.Any(p => p.WFCompanyId == x.WFCompanyId && p.CorporationType == x.CorporationType))
                        {
                            wFCorporationTypeConfigurationToAdd.Add(x);
                        }
                    });
                    wFCorporationTypeConfiguration = corporationProvider.AddCorporationTypeConfigurations(wFCorporationTypeConfigurationToAdd)?.ToList();
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg?.ToString()))
                    {
                        return Tuple.Create(true, errMsg?.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("导入法人时," + ex.Message);
                    return Tuple.Create(false, "导入法人时," + ex.Message, MsgType.Err);
                }
            }
            #endregion
        }

        /// <summary>
        /// 导入利润中心主数据
        /// </summary>
        /// <param name="company_Dtos"></param>
        public Tuple<bool, string, MsgType> ImportProfitCenter(List<WFAccountEntity_Dto> wFAccountEntity_Dto)
        {
            #region check
            var allProfitCenters = accountEntityProvider.GetAllAccountEntity();
            StringBuilder errMsg = new StringBuilder();
            var toAddList = new List<WFAccountEntity_Dto>();
            foreach (var item in wFAccountEntity_Dto)
            {
                if (allProfitCenters.Any(p => p.WFAccountEntityId != item.WFAccountEntityId && (p.AccountingName == item.AccountingName || p.Name == item.Name)))
                {
                    Logger.Warn($"导入利润中心主数据时,利润中心数据-名称【{item.AccountingName}】数据已存在，不进行导入");
                    errMsg.AppendLine($"【导入利润中心主数据时,利润中心数据-名称【{item.AccountingName}】数据已存在，不进行导入】");
                }
                else
                {
                    if (wFAccountEntity_Dto.Count(p => (p.AccountingName == item.AccountingName || p.Name == item.Name) && p.IsAccounting) > 1)
                    {
                        ///移除非正规的利润中心数据
                        if (item.AccountingName != item.ParentAccountEntityName)
                        {
                            if (!toAddList.Any(p => (p.AccountingName == item.AccountingName || p.Name == item.Name)))
                            {
                                Logger.Warn($"导入利润中心主数据时,利润中心数据-名称【{item.AccountingName}】重复,默认取第一条");
                                errMsg.AppendLine($"【导入利润中心主数据时,利润中心数据-名称【{item.AccountingName}】重复,默认取第一条】");
                                var sonAccountingEntities = wFAccountEntity_Dto.Where(p => p.ParentAccountEntityName == item.AccountingName)?.ToList();
                                if (sonAccountingEntities.All(p => p.ParentAccountEntityName == p.AccountingName))
                                {
                                    item.IsAtomicAccounting = true;
                                }
                                toAddList.Add(item);
                            }
                        }

                    }
                    else
                    {
                        toAddList.Add(item);
                    }

                }
            }
            #endregion

            #region 处理
            wFAccountEntity_Dto.ForEach(x =>
            {
                x.CreationTime = DateTime.Now;
                x.LastManipulationTime = DateTime.Now;
                x.Indicatornames.ForEach(y =>
                {
                    if (y == BaIndicatorProfitCenter.CapitalInterest.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.CapitalInterest;
                    }
                    if (y == BaIndicatorProfitCenter.SpotPosition.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.SpotPosition;
                    }
                    if (y == BaIndicatorProfitCenter.FuturePosition.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.FuturePosition;
                    }
                    if (y == BaIndicatorProfitCenter.OptionPosition.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.OptionPosition;
                    }
                    if (y == BaIndicatorProfitCenter.SecurityPosition.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.SecurityPosition;
                    }
                    if (y == BaIndicatorProfitCenter.ProfitAndLoss.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.ProfitAndLoss;
                    }
                    if (y == BaIndicatorProfitCenter.Cost.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.Cost;
                    }
                    if (y == BaIndicatorProfitCenter.CapitalOccupation.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.CapitalOccupation;
                    }
                    if (y == BaIndicatorProfitCenter.ForexPosition.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.ForexPosition;
                    }
                    if (y == BaIndicatorProfitCenter.HedgingLoopProfitAndLoss.GetAttributeInfo<NoteAttribute>("note")?.ToString())
                    {
                        x.Indicator = x.Indicator | (int)BaIndicatorProfitCenter.HedgingLoopProfitAndLoss;
                    }
                });
            });
            wFAccountEntity_Dto = toAddList;
            var listByLevel = wFAccountEntity_Dto.GroupBy(p => p.Level).OrderBy(p => p.Key)?.ToList();
            #endregion
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    var ccList = new List<WFAccountEntity_Dto>();
                    foreach (var item in listByLevel)
                    {
                        var addList = item?.ToList();
                        addList.ForEach(x =>
                        {
                            var parent = ccList?.Where(r => r.Name == x.ParentAccountEntityName || r.AccountingName == x.AccountingName)?.FirstOrDefault() ??
                          allProfitCenters?.Where(r => r.Name == x.ParentAccountEntityName)?.FirstOrDefault();
                            x.ParentDepartmentId = parent?.WFAccountEntityId;
                        });
                        var list = accountEntityProvider.AddAccountEntities(addList);
                        ccList.AddRange(list);
                    }
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"导入利润中心时,{ex.Message}");
                    return Tuple.Create(false, $"导入利润中心时,{ex.Message}", MsgType.Err);
                }
            }
        }

        /// <summary>
        /// 导入用户主数据
        /// </summary>
        /// <param name="company_Dtos"></param>
        public Tuple<bool, string, MsgType> ImportUserInfo(List<WFUser_Dto> wFUser_Dto, List<WFOfficeAddress_Dto> wFOfficeAddress_Dtos)
        {
            #region 处理
            var address = new List<WFOfficeAddress_Dto>();
            var userInfo = new List<WFUser_Dto>();
            StringBuilder errMsg = new StringBuilder();
            var allUserInfo = userProvider.GetAllUsers();
            var allAddressinfo = userProvider.GetAllOfficeAddress();
            wFOfficeAddress_Dtos.ForEach(x =>
            {
                if (allAddressinfo.Any(p => p.Name == x.Address))
                {
                    Logger.Warn($"导入用户主数据时，用户名-{x.Name}，地址已存在，不进行导入");
                    errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}，地址已存在，不进行导入】");
                }
                else
                {
                    if (wFOfficeAddress_Dtos.Count(p => p.Address == x.Address) > 1)
                    {
                        if (!address.Any(p => p.Name == x.Address))
                        {
                            Logger.Warn($"导入用户主数据时，用户名-{x.Name}，地址重复，默认只取第一条");
                            errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}，地址重复，默认只取第一条】");
                        }
                    }
                    else
                    {
                        address.Add(x);
                    }
                }
            });
            wFUser_Dto.ForEach(x =>
            {
                if (allUserInfo.Any(p => p.LoginName == x.LoginName || p.Name == x.Name))
                {
                    Logger.Warn($"导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}已存在，不进行导入");
                    errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}已存在，不进行导入】");
                }
                else if (string.IsNullOrEmpty(x.Name) || string.IsNullOrEmpty(x.LoginName))
                {
                    if (string.IsNullOrEmpty(x.Name))
                    {
                        Logger.Warn($"导入用户主数据时，登录名-{x.LoginName}对应的用户名-{x.Name}为空，不进行导入");
                        errMsg.AppendLine($"【导入用户主数据时，登录名-{x.LoginName}对应的用户名-{x.Name}为空，不进行导入】");
                    }
                    else
                    {
                        Logger.Warn($"导入用户主数据时，用户名-{x.Name}对应的登录名-{x.LoginName}为空，不进行导入");
                        errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}对应的登录名-{x.LoginName}为空，不进行导入】");
                    }
                }
                else
                {
                    if (!EmailRegex(x.MailAddress))
                    {
                        Logger.Warn($"导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}邮箱不符合，重置邮箱为空");
                        errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}邮箱不符合，重置邮箱为空】");
                        x.MailAddress = null;
                    }
                    if (wFUser_Dto.Count(p => p.Name == x.Name || p.LoginName == x.LoginName) > 1)
                    {
                        if (!userInfo.Any(p => p.Name == x.Name || p.LoginName == x.LoginName))
                        {
                            Logger.Warn($"导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}重复，默认只取第一条");
                            errMsg.AppendLine($"【导入用户主数据时，用户名-{x.Name}|登录名-{x.LoginName}重复，默认只取第一条】");
                            userInfo.Add(x);
                        }
                    }
                    else
                    {
                        userInfo.Add(x);
                    }
                }
            });

            #endregion

            #region 实现导入
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    wFOfficeAddress_Dtos = userProvider.AddOfficeAddress(address)?.ToList();
                    userInfo.ForEach(y =>
                    {
                        var addressForUser = wFOfficeAddress_Dtos.Where(p => p.Name == y.WFOfficeAddressName)?.FirstOrDefault();
                        y.WFOfficeAddressId = addressForUser?.WFOfficeAddressId;
                        y.CreationTime = DateTime.Now;
                        y.LastManipulationTime = DateTime.Now;
                        y.Password = "1b89e2e3c505088665eeb2903e1c6a87";
                    });
                    wFUser_Dto = userProvider.AddUsers(userInfo)?.ToList();
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"导入用户主数据，{ex.Message}");
                    return Tuple.Create(false, $"导入用户主数据，{ex.Message}", MsgType.Err);
                }

            }
            #endregion
        }

        /// <summary>
        /// 导入岗位主数据
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public Tuple<bool, string, MsgType> ImportPostInfo(List<WFRoleInfo_Dto> roleInfo, List<WFAccountEntity_Dto> departmentInfo)
        {
            #region 数据源获取
            var userRole = new List<WFUserRole_Dto>();
            var roleBusiness = new List<WFRoleBusiness_Dto>();
            var allDepartment = accountEntityProvider.GetAllDepartment()?.ToList();
            var allAccountEntity = accountEntityProvider.GetAllAccountEntity()?.ToList();
            var allUserInfo = userProvider.GetAllUsers()?.ToList();
            var allCompany = corporationProvider.GetAllCorporations()?.ToList();
            var allRoleInfo = postInfoProvider.GetAllRoleInfo();
            var allUserRoleInfo = postInfoProvider.GetAllUserRoleInfo();
            var allRoleBusinessInfo = postInfoProvider.GetAllRoleBusinessInfo();
            var roleInfoes = new List<WFRoleInfo_Dto>();
            var departmentList = new List<WFAccountEntity_Dto>();
            var allRolePrivilegeList = permissionProvider.GetAllRolePrivilege();
            StringBuilder errMsg = new StringBuilder();
            var rolePrivilegeToAdd = new List<WFRolePrivilege_Dto>();
            #endregion
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    #region 部门 处理&导入
                    var departmentToAdd = new List<WFAccountEntity_Dto>();
                    var parentDepartment = new WFAccountEntity_Dto();
                    #region 最高级部门 处理&导入
                    if (!allDepartment.Any(p => p.Name == "紫金集团"))
                    {
                        parentDepartment = new WFAccountEntity_Dto()
                        {
                            LastManipulationTime = DateTime.Now,
                            CreationTime = DateTime.Now,
                            Name = "紫金集团",
                            IsAccounting = false,
                            Type = (int)DepartmentType.Department,
                            AccountingName = "紫金集团",
                        };
                        parentDepartment = accountEntityProvider.AddAccountEntities(new List<WFAccountEntity_Dto>() { parentDepartment })?.FirstOrDefault();
                    }
                    #endregion

                    #region 子集部门 处理&导入
                    departmentInfo.ForEach(x =>
                               {
                                   x.ParentDepartmentId = parentDepartment.WFAccountEntityId;
                                   x.LastManipulationTime = DateTime.Now;
                                   x.CreationTime = DateTime.Now;
                                   x.AccountingName = x.Name;
                                   if (!allDepartment.Any(p => p.Name == x.Name))
                                   {
                                       departmentToAdd.Add(x);
                                   }
                               });
                    var postToAdd = new List<WFPost_Dto>();
                    var postNames = roleInfo.Select(p => p.PostNames?.FirstOrDefault())?.Distinct()?.ToList();
                    var allPostInfo = postInfoProvider.GetAllPost()?.ToList();
                    postNames.ForEach(x =>
                    {
                        if (!allPostInfo.Any(p => p.Name == x))
                        {
                            postToAdd.Add(new WFPost_Dto()
                            {
                                Name = x,
                                EnumValue = (short)ModuleEnumValue(x, typeof(RoleCategory)),
                            });
                        }
                    });
                    departmentInfo = accountEntityProvider.AddAccountEntities(departmentToAdd)?.ToList();
                    postToAdd = postInfoProvider.AddPosts(postToAdd)?.ToList();
                    #endregion
                    #endregion

                    #region 角色岗位 处理&导入 
                    bool isRepeatFlag = false;
                    roleInfo.ForEach(x =>
                    {
                        var roleInfoLink = allRoleInfo.Where(p => x.PostNames.Contains(p.Name))?.ToList();
                        var module = 0;
                        if (roleInfoLink != null && roleInfoLink.Count != 0)
                        {
                            var wFRoleInfoIds = roleInfoLink.Select(p => p.WFRoleInfoId)?.Distinct()?.ToList();
                            var modules = allRolePrivilegeList.Where(p => wFRoleInfoIds.Contains(p.WFRoleInfoId))?.Where(p => p.Module != null)?.Select(p => p.Module)?.OfType<int>()?.Distinct()?.ToList();
                            modules.ForEach(p =>
                            {
                                module = module | p;
                            });
                            x.CorporationId = allCompany.Where(p => p.FullName == x.CorportionName)?.FirstOrDefault()?.WFCompanyId;
                            x.CreationTime = DateTime.Now;
                            x.LastUpdateTime = DateTime.Now;
                            x.WFDepartmentId = allDepartment.Where(p => p.AccountingName == x.CorportionName)?.FirstOrDefault()?.WFAccountEntityId
                            ?? departmentInfo.Where(p => p.Name == x.CorportionName)?.FirstOrDefault()?.WFAccountEntityId;
                            x.Module = module == 0 ? default(int?) : module;
                            x.WFPostId = allPostInfo?.Where(p => p.Name == x.PostNames?.FirstOrDefault())?.FirstOrDefault()?.WFPostId ?? postToAdd?.Where(p => p.Name == x.PostNames?.FirstOrDefault())?.FirstOrDefault()?.WFPostId;
                            x.RoleType = (int)RoleType.Normal;
                            if (allRoleInfo.Any(p => p.Name == x.Name && p.WFRoleInfoId != x.WFRoleInfoId))
                            {
                                Logger.Warn($"导入角色岗位数据时,部门{x.Name}所在项已经存在，不进行导入");
                                errMsg.AppendLine($"【导入角色岗位数据时,部门{x.Name}所在项已经存在，不进行导入】");
                            }
                            else
                            {
                                if (roleInfo.Count(p => p.Name == x.Name) > 1)
                                {
                                    if (!roleInfoes.Any(p => p.Name == x.Name))
                                    {
                                        Logger.Warn($"导入角色岗位数据时,部门{x.CorportionName}存在重复，默认取第一条");
                                        errMsg.AppendLine($"【导入角色岗位数据时,部门{x.CorportionName}所在项存在重复，默认取第一条】");
                                        roleInfoes.Add(x);
                                    }
                                }
                                else
                                {
                                    roleInfoes.Add(x);
                                }
                            }
                        }
                        else
                        {
                            if (!(isRepeatFlag && roleInfo.Count(p => p.Name == x.Name) > 1))
                            {
                                if (!(x.PostNames == null || x.PostNames.Count == 0))
                                {
                                    Logger.Warn($"【导入角色岗位数据时,部门-{x.CorportionName}/岗位名称-{x.Name}不存在岗位-{x.PostNames}类型所对应的标准岗位角色，不进行导入】");
                                    errMsg.AppendLine($"【导入角色岗位数据时,部门-{x.CorportionName}/岗位名称-{x.Name}不存在岗位-{x.PostNames}类型所对应的标准岗位角色，不进行导入】");
                                }
                                else
                                {
                                    Logger.Warn($"【导入角色岗位数据时,部门-{x.CorportionName}/岗位名称-{x.Name}不存在岗位类型，不进行导入】");
                                    errMsg.AppendLine($"【导入角色岗位数据时,部门-{x.CorportionName}/岗位名称-{x.Name}不存在岗位类型，不进行导入】");
                                }
                                isRepeatFlag = roleInfo.Count(p => p.Name == x.Name) > 1;
                            }
                        }

                    });
                    roleInfo = JsonDeserialize<List<WFRoleInfo_Dto>>(ToJson(roleInfoes));
                    roleInfoes = postInfoProvider.AddRoleInfos(roleInfoes)?.ToList();
                    roleInfoes.ForEach(x =>
                    {
                        if (string.IsNullOrEmpty(x.QctKey))
                        {
                            x.QctKey = $"R{(x.WFRoleInfoId % 100000).ToString("D5")}";
                            x.LastUpdateTime = DateTime.Now;
                        }
                    });
                    this.postInfoProvider.UpdateRoleInfoByQcyKey(roleInfoes);
                    #endregion

                    #region 关联角色操作权限 & 关联业务权限  处理   
                    roleInfo.ForEach(x =>
                                {
                                    var roleInfoMap = roleInfoes.Where(p => p.Name == x.Name)?.FirstOrDefault() ?? allRoleInfo.Where(p => p.Name == x.Name)?.FirstOrDefault();
                                    // 关联的标准岗位角色
                                    var roleInfoLink = allRoleInfo.Where(p => x.PostNames.Contains(p.Name))?.ToList();
                                    var linkRoleInfoId = roleInfoLink.Select(p => p.WFRoleInfoId)?.Distinct()?.ToList() ?? new List<int>();
                                    // 关联的标准岗位角色权限
                                    var rolePrivilegeLinkList = allRolePrivilegeList.Where(p => linkRoleInfoId.Contains(p.WFRoleInfoId))?.ToList();
                                    var modules = rolePrivilegeLinkList?.Where(p => p.Module != null)?.Select(p => p.Module)?
                                    .OfType<int>()?.Distinct()?.ToList();
                                    x.WFRoleInfoId = roleInfoMap.WFRoleInfoId;
                                    var newSPRolePrivilege = JsonDeserialize<List<WFRolePrivilege_Dto>>(ToJson(rolePrivilegeLinkList));

                                    newSPRolePrivilege.ForEach(p =>
                                    {
                                        p.WFRolePrivilegeId = 0;
                                        p.WFRoleInfoId = x.WFRoleInfoId;
                                        p.CorporationId = x.CorporationId;
                                        if (!allRolePrivilegeList.Any(r => r.Module == p.Module && p.WFRoleInfoId == r.WFRoleInfoId && p.Privilege == r.Privilege))
                                        {
                                            rolePrivilegeToAdd.Add(p);
                                        }
                                    });
                                    x.UserNames?.ForEach(y =>
                                    {
                                        userRole.Add(new WFUserRole_Dto()
                                        {
                                            WFRoleInfoId = x.WFRoleInfoId,
                                            WFUserId = allUserInfo.Where(p => p.Name == y)?.FirstOrDefault()?.WFUserId,
                                            UserName = y,  //冗余
                                            DepartmentName = x.Name//冗余
                                        });
                                    });
                                    // 岗位可操作的本法人的利润中心
                                    x.OurCorporationAccountEntitiesNames?.ForEach(y =>
                                                {
                                                    if (!(allAccountEntity.Where(p => p.Name == y)?.FirstOrDefault()?.WFAccountEntityId == null))
                                                    {
                                                        modules.ForEach(r =>
                                                        {
                                                            roleBusiness.Add(new WFRoleBusiness_Dto()
                                                            {
                                                                WFRoleInfoId = x.WFRoleInfoId,
                                                                AccountEntityId = allAccountEntity.Where(p => p.Name == y)?.FirstOrDefault()?.WFAccountEntityId,
                                                                CorporationId = x.CorporationId,
                                                                DepartmentName = x.Name,//冗余
                                                                AccoutingName = y,
                                                                Module = r
                                                            });
                                                        });
                                                    }
                                                    else
                                                    {
                                                        Logger.Warn($"导入角色岗位数据-添加角色业务权限时,岗位名称-{x.Name},岗位可操作的本法人的利润中心-{y}不存在，此行数据不进行导入");
                                                        errMsg.AppendLine($"【导入角色岗位数据-添加角色业务权限时,岗位名称-{x.Name},岗位可操作的本法人的利润中心-{y}不存在，此行数据不进行导入】");
                                                    }
                                                });
                                    // 岗位其他可见利润中心清单
                                    x.OtherAccountEntitiesNames?.ForEach(y =>
                                                {
                                                    if (!(allAccountEntity.Where(p => p.Name == y)?.FirstOrDefault()?.WFAccountEntityId == null))
                                                    {
                                                        modules.ForEach(r =>
                                                        {
                                                            roleBusiness.Add(new WFRoleBusiness_Dto()
                                                            {
                                                                WFRoleInfoId = x.WFRoleInfoId,
                                                                AccountEntityId = allAccountEntity.Where(p => p.Name == y)?.FirstOrDefault()?.WFAccountEntityId,
                                                                CorporationId = allCompany.Where(p => p.FullName == x.OtherCorporationName)?.FirstOrDefault()?.WFCompanyId,
                                                                DepartmentName = x.Name,//冗余
                                                                AccoutingName = y,
                                                                Module = r
                                                            });
                                                        });
                                                    }
                                                    else
                                                    {
                                                        Logger.Warn($"导入角色岗位数据-添加角色业务权限时,岗位名称-{x.Name},岗位其他可见利润中心-{y}不存在，此行数据不进行导入");
                                                        errMsg.AppendLine($"【导入角色岗位数据-添加角色业务权限时,岗位名称-{x.Name},岗位其他可见利润中心-{y}不存在，此行数据不进行导入】");
                                                    }
                                                });
                                });
                    #endregion

                    #region 角色用户 处理&导入
                    var userRoleToAdd = new List<WFUserRole_Dto>();
                    foreach (var item in userRole)
                    {
                        if (allUserRoleInfo.Any(p => p.WFUserId == item.WFUserId && p.WFRoleInfoId == item.WFRoleInfoId && p.WFUserRoleId != item.WFUserRoleId))
                        {
                            Logger.Warn($"导入角色岗位数据-添加用户角色时,部门{item.DepartmentName},用户{item.UserName}所在项已经存在，不进行导入");
                            errMsg.AppendLine($"【导入角色岗位数据-添加用户角色时,部门{item.DepartmentName},用户{item.UserName}所在项已经存在，不进行导入】");
                        }
                        else
                        {
                            if (userRole.Count(p => p.WFUserId == item.WFUserId && p.WFRoleInfoId == item.WFRoleInfoId) > 1)
                            {
                                if (!userRoleToAdd.Any(p => p.WFUserId == item.WFUserId && p.WFRoleInfoId == item.WFRoleInfoId))
                                {
                                    Logger.Warn($"导入角色岗位数据-添加用户角色时,部门{item.DepartmentName},用户{item.UserName}重复，默认取第一条");
                                    errMsg.AppendLine($"【导入角色岗位数据-添加用户角色时,部门{item.DepartmentName},用户{item.UserName}所在项存在重复，默认取第一条】");
                                    userRoleToAdd.Add(item);
                                }
                            }
                            else
                            {
                                userRoleToAdd.Add(item);
                            }
                        }
                    }
                    userRole = postInfoProvider.AddUserRoles(userRoleToAdd)?.ToList();
                    #endregion

                    #region 角色业务权限 处理&导入
                    var roleBusinessToAdd = new List<WFRoleBusiness_Dto>();
                    foreach (var item in roleBusiness)
                    {
                        if (allRoleBusinessInfo.Any(p => p.AccountEntityId == item.AccountEntityId && p.WFRoleInfoId == item.WFRoleInfoId && p.CorporationId == item.CorporationId && p.Module == item.Module && p.WFRoleBusinessId != item.WFRoleBusinessId))
                        {
                            Logger.Warn($"导入角色岗位数据时,部门{item.DepartmentName},岗位操作利润中心{item.AccoutingName}所在项已经存在，不进行导入");
                            errMsg.AppendLine($"【导入角色岗位数据时,部门{item.DepartmentName},岗位操作利润中心{item.AccoutingName}所在项已经存在，不进行导入】");
                        }
                        else
                        {
                            if (roleBusiness.Count(p => p.AccountEntityId == item.AccountEntityId && p.WFRoleInfoId == item.WFRoleInfoId && p.CorporationId == item.CorporationId && p.Module == item.Module) > 1)
                            {
                                if (!roleBusinessToAdd.Any(p => p.AccountEntityId == item.AccountEntityId && p.WFRoleInfoId == item.WFRoleInfoId && p.CorporationId == item.CorporationId && p.Module == item.Module))
                                {
                                    Logger.Warn($"导入角色岗位数据-添加角色业务权限时,部门{item.DepartmentName},岗位操作利润中心{item.AccoutingName}重复，默认取第一条");
                                    errMsg.AppendLine($"【导入角色岗位数据-添加角色业务权限时,部门{item.DepartmentName},岗位操作利润中心{item.AccoutingName}所在项存在重复，默认取第一条】");
                                }
                                roleBusinessToAdd.Add(item);
                            }
                            else
                            {
                                roleBusinessToAdd.Add(item);
                            }
                        }
                    }
                    roleBusiness = postInfoProvider.AddRoleBusiness(roleBusinessToAdd)?.ToList();
                    #endregion

                    #region 角色操作权限 处理&导入
                    var rolePrivilegeToAddNew = new List<WFRolePrivilege_Dto>();
                    rolePrivilegeToAdd.ForEach(r =>
                    {
                        if (rolePrivilegeToAdd.Count(p => p.WFRolePrivilegeId == r.WFRolePrivilegeId && p.WFRoleInfoId == r.WFRoleInfoId
                     && p.Module == r.Module && r.Privilege == p.Privilege && r.CorporationId == p.CorporationId && r.TradeType == p.TradeType) > 1)
                        {
                            if (!rolePrivilegeToAddNew.Any(p => p.WFRolePrivilegeId == r.WFRolePrivilegeId && p.WFRoleInfoId == r.WFRoleInfoId
                  && p.Module == r.Module && r.Privilege == p.Privilege && r.CorporationId == p.CorporationId && r.TradeType == p.TradeType))
                            {
                                Logger.Warn($"导入角色岗位数据-添加操作权限时,角色-{roleInfo.FirstOrDefault(n => n.WFRoleInfoId == r.WFRoleInfoId)?.Name},模块-{ModuleEnumName(r.Module.Value, typeof(RouteContextModule))},权限值-{r.Privilege}重复，默认取第一条");
                                errMsg.AppendLine($"【导入角色岗位数据-添加操作权限时,角色-{roleInfo.FirstOrDefault(n => n.WFRoleInfoId == r.WFRoleInfoId)?.Name},模块-{ModuleEnumName(r.Module.Value, typeof(RouteContextModule))},权限值-{r.Privilege}重复，默认取第一条】");
                                rolePrivilegeToAddNew.Add(r);
                            }
                        }
                        else
                        {
                            rolePrivilegeToAddNew.Add(r);
                        }

                    });
                    //添加操作权限
                    permissionProvider.AddRolePrivileges(rolePrivilegeToAddNew);
                    #endregion

                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }

                }
                catch (Exception ex)
                {
                    Logger.Error($"导入岗位主数据时,{ex.Message}");
                    return Tuple.Create(false, $"导入岗位主数据时,{ex.Message}", MsgType.Err);
                }

            }
        }

        /// <summary>
        /// 导入权限主数据
        /// </summary>
        /// <param name="wFRolePrivilege_Dtos"></param>
        /// <returns></returns>
        public Tuple<bool, string, MsgType> ImportPermissionInfo(List<WFRolePrivilege_Dto> wFRolePrivilege_Dtos)
        {
            StringBuilder errMsg = new StringBuilder();
            var allRolePrivilege = permissionProvider.GetAllRolePrivilege();
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    var allRoleInfos = postInfoProvider.GetAllRoleInfo()?.ToList();
                    var listToAdd = new List<WFRolePrivilege_Dto>();
                    wFRolePrivilege_Dtos.ForEach(x =>
                    {
                        x.WFRoleInfoNames.ForEach(y =>
                        {
                            var roleInfo = allRoleInfos.Where(p => !p.IsDeleted && p.Name == y)?.FirstOrDefault();
                            if (roleInfo != null)
                            {
                                if (listToAdd.Any(p => p.Privilege == (int)x.Privilege && p.Module == x.Module && p.WFRoleInfoId == roleInfo.WFRoleInfoId))
                                {
                                    Logger.Warn($"导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】重复,默认取第一条;");
                                    errMsg.AppendLine($"【导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】重复,默认取第一条】");
                                }
                                else if (allRolePrivilege.Any(p => p.Privilege == (int)x.Privilege
                                && p.Module == x.Module
                                && p.WFRoleInfoId == roleInfo.WFRoleInfoId
                                && p.WFRolePrivilegeId != x.WFRolePrivilegeId))
                                {
                                    Logger.Warn($"导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】已存在,此行数据不导入;");
                                    errMsg.AppendLine($"【导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】已存在,此行数据不导入】");
                                }
                                else
                                {
                                    if ((int)x.Privilege != 0)
                                    {
                                        listToAdd.Add(new WFRolePrivilege_Dto()
                                        {
                                            Privilege = (int)x.Privilege,
                                            Module = x.Module,
                                            WFRoleInfoId = roleInfo.WFRoleInfoId
                                        });
                                    }
                                    else
                                    {
                                        Logger.Warn($"导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入;");
                                        errMsg.AppendLine($"【导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入】");
                                    }

                                }
                            }
                            else
                            {
                                Logger.Warn($"导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】库中不存在,此行数据不导入;");
                                errMsg.AppendLine($"【导入权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】库中不存在,此行数据不导入】");
                            }
                        });
                    });
                    var listRoleInfoIds = listToAdd.Select(p => p.WFRoleInfoId)?.Distinct()?.ToList();
                    permissionProvider.AddRolePrivileges(listToAdd);
                    var allRolePrivileges = permissionProvider.GetAllRolePrivilege()?.Where(p => listRoleInfoIds.Contains(p.WFRoleInfoId))?.ToList();
                    var needToUpdateRoleInfos = allRoleInfos?.Where(p => listRoleInfoIds.Contains(p.WFRoleInfoId))?.ToList();
                    var needToUpdateRoleBusiness = postInfoProvider.GetAllRoleBusinessInfo()?.Where(p => listRoleInfoIds.Contains(p.WFRoleInfoId))?.ToList();
                    var needToAddRoleBusiness = new List<WFRoleBusiness_Dto>();
                    //反向更新岗位module值
                    needToUpdateRoleInfos.ForEach(x =>
                    {
                        var modules = allRolePrivileges.Where(p => p.WFRoleInfoId == x.WFRoleInfoId)?.Select(p => p.Module)?.Distinct()?.ToList();
                        x.Module = 0;
                        modules.ForEach(y =>
                        {
                            x.Module = x.Module | y;
                        });
                        x.WFPost = null;
                    });
                    needToUpdateRoleBusiness.ForEach(x =>
                    {
                        x.WFRoleBusinessId = 0;
                        var modules = allRolePrivileges.Where(p => p.WFRoleInfoId == x.WFRoleInfoId && p.Module != x.Module)
                        ?.Select(p => p.Module)?.Distinct()?.ToList();        // 排除自身已经存在的业务权限
                        modules.ForEach(y =>
                        {
                            x.Module = y;
                            needToAddRoleBusiness.Add(x);
                        });
                    });
                    postInfoProvider.UpdateRolesInfo(needToUpdateRoleInfos);
                    postInfoProvider.AddRoleBusiness(needToAddRoleBusiness);
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"导入权限时{ ex.Message}");
                    return Tuple.Create(false, $"导入权限时{ ex.Message}", MsgType.Err);
                }

            }
        }

        /// <summary>
        /// 导入品种主数据
        /// </summary>
        /// <param name="wFRolePrivilege_Dtos"></param>
        /// <returns></returns>
        public Tuple<bool, string, MsgType> ImportCommodityTypeInfo(List<WFCommodityType_Dto> wFCommodityType_Dtos)
        {
            var allCommodityType = commodityProvider.GetAllCommodityType();
            StringBuilder errMsg = new StringBuilder();
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    #region 品类&品类类型
                    var allUnitInfo = commodityProvider.GetAllUnit();
                    var allCommodityCategoryInfo = commodityProvider.GetAllCommodityCategory();
                    var listToAdd = new List<WFCommodityType_Dto>();
                    #region 品类 处理&导入
                    var needToAddCategoryInfoes = new List<WFCommodityCategory_Dto>();
                    wFCommodityType_Dtos.ForEach(x =>
                    {
                        if (allCommodityCategoryInfo.Any(p => p.Name == x.WFCommodityCategoryName))
                        {
                            Logger.Warn($"导入品种-品种类型时品，品类类型【{x.WFCommodityCategoryName}】库中已存在,此行数据所涉及品类类型不导入;");
                            errMsg.AppendLine($"【导入品种-品种类型时,品类类型{x.WFCommodityCategoryName}】库中已存在,此行数据所涉及品类类型不导入】");
                        }
                        else
                        {
                            if (wFCommodityType_Dtos.Count(p => p.Name == x.WFCommodityCategoryName) > 1)
                            {
                                if (!needToAddCategoryInfoes.Any(p => p.Name == x.WFCommodityCategoryName))
                                {
                                    Logger.Warn($"导入品种-品种类型时品，品类类型【{x.WFCommodityCategoryName}】存在重复导入情况,默认只取第一条数据导入;");
                                    errMsg.AppendLine($"【导入品种-品种类型时,品类类型{x.WFCommodityCategoryName}】存在重复导入情况,默认只取第一条数据导入】");
                                    needToAddCategoryInfoes.Add(new WFCommodityCategory_Dto()
                                    {
                                        CreationTime = DateTime.Now,
                                        LastManipulationTime = DateTime.Now,
                                        IsBuiltIn = false,
                                        QctKey = x.WFCommodityCategoryName,
                                        Name = x.WFCommodityCategoryName,
                                    });
                                }

                            }
                            else
                            {
                                needToAddCategoryInfoes.Add(new WFCommodityCategory_Dto()
                                {
                                    CreationTime = DateTime.Now,
                                    LastManipulationTime = DateTime.Now,
                                    IsBuiltIn = false,
                                    QctKey = x.WFCommodityCategoryName,
                                    Name = x.WFCommodityCategoryName,
                                });
                            }
                        }
                    });
                    needToAddCategoryInfoes = commodityProvider.AddWFCommodityCategory(needToAddCategoryInfoes);
                    #endregion
                    #region 品类类型 处理&导入
                    bool isRepeatFlag = false;
                    wFCommodityType_Dtos.ForEach(x =>
                    {
                        var unitInfo = allUnitInfo.Where(p => !p.IsDeleted && p.Name == x.WFUnitName)?.FirstOrDefault();
                        var categoryInfo = allCommodityCategoryInfo.Where(p => p.Name == x.WFCommodityCategoryName)?.FirstOrDefault()
                        ?? needToAddCategoryInfoes.Where(p => p.Name == x.WFCommodityCategoryName)?.FirstOrDefault();
                        if (unitInfo != null && categoryInfo != null)
                        {
                            if (allCommodityType.Any(p => p.Name == x.Name && p.WFCommodityTypeId != x.WFCommodityTypeId))
                            {
                                Logger.Warn($"导入品种时品种【{x.Name}】库中已存在,此行数据不导入;");
                                errMsg.AppendLine($"【导入品种时品种【{x.Name}】库中已存在,此行数据不导入】");
                            }
                            else
                            {
                                if (wFCommodityType_Dtos.Count(p => p.Name == x.Name) > 1)
                                {
                                    if (!listToAdd.Any(p => p.Name == x.Name))
                                    {
                                        Logger.Warn($"导入品种时,品种【{x.Name}】重复,默认只取第一条;");
                                        errMsg.AppendLine($"【导入品种时,品种【{x.Name}】重复,默认只取第一条】");
                                        listToAdd.Add(new WFCommodityType_Dto()
                                        {
                                            Name = x.Name,
                                            AccountingName = x.AccountingName,
                                            Code = x.Code,
                                            IsPricing = x.IsPricing,
                                            IsFundamentalComponent = x.IsFundamentalComponent,
                                            CreationTime = DateTime.Now,
                                            LastManipulationTime = DateTime.Now,
                                            DefaultUnitId = unitInfo.WFUnitId,
                                            WFCommodityCategoryId = categoryInfo.WFCommodityCategoryId
                                        });
                                    }
                                }
                                else
                                {
                                    listToAdd.Add(new WFCommodityType_Dto()
                                    {
                                        Name = x.Name,
                                        AccountingName = x.AccountingName,
                                        Code = x.Code,
                                        IsPricing = x.IsPricing,
                                        IsFundamentalComponent = x.IsFundamentalComponent,
                                        CreationTime = DateTime.Now,
                                        LastManipulationTime = DateTime.Now,
                                        DefaultUnitId = unitInfo.WFUnitId,
                                        WFCommodityCategoryId = categoryInfo.WFCommodityCategoryId
                                    });
                                }
                            }
                        }
                        else
                        {
                            if (!(isRepeatFlag && wFCommodityType_Dtos.Count(p => p.Name == x.Name) > 1))
                            {
                                Logger.Warn($"导入品种时,默认重量单位【{x.WFUnitName}】或者品种类型【{x.WFCommodityCategoryName}】库中不存在,此行数据不导入;");
                                errMsg.AppendLine($"【导入品种时,默认重量单位【{x.WFUnitName}】或者品种类型【{x.WFCommodityCategoryName}】库中不存在,此行数据不导入】");
                                isRepeatFlag = wFCommodityType_Dtos.Count(p => p.Name == x.Name) > 1;
                            }
                        }
                    });
                    commodityProvider.AddCommodityType(listToAdd);
                    #endregion
                    #endregion
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Err);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }

                }
                catch (Exception ex)
                {
                    Logger.Error($"导入品种主数据时,{ex.Message}");
                    return Tuple.Create(false, $"导入品种主数据时,{ex.Message}", MsgType.Err);
                }

            }
        }

        /// <summary>
        /// 导入交易所主数据
        /// </summary>
        /// <param name="wFRolePrivilege_Dtos"></param>
        /// <returns></returns>
        public Tuple<bool, string> ImportExChangeInfo(List<WFCompany_Dto> wFCompany_Dto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    var allUnitInfo = commodityProvider.GetAllUnit();
                    var allCommodityCategoryInfo = commodityProvider.GetAllCommodityCategory();
                    var listToAdd = new List<WFCompany_Dto>();
                    var listCorporationTypeConfig = new List<WFCorporationTypeConfiguration_Dto>();
                    var listAdditionalConfiguration = exchangeProvider.GetWFAdditionalConfiguration();
                    wFCompany_Dto.ForEach(x =>
                    {
                        x.LastManipulationTime = DateTime.Now;
                        x.CreationTime = DateTime.Now;
                    });
                    var exchange = exchangeProvider.AddExcahnges(wFCompany_Dto)?.ToList();
                    exchange.ForEach(x =>
                    {
                        var exchangeOld = wFCompany_Dto.Where(p => p.ShortName == x.ShortName)?.FirstOrDefault();
                        listCorporationTypeConfig.Add(new WFCorporationTypeConfiguration_Dto()
                        {
                            CorporationType = x.Type,
                            TimeZoneId = exchangeOld.TimeZone,
                            WFCompanyId = x.WFCompanyId,
                            ExchangeTypeId = listAdditionalConfiguration.Where(p => p.Name == exchangeOld.ExchangeTypeName)?.FirstOrDefault()?.WFAdditionalConfigurationId,
                        });
                    });
                    listCorporationTypeConfig = exchangeProvider.AddCorporationTypeConfiguration(listCorporationTypeConfig)?.ToList();
                    trans.Complete();
                    return Tuple.Create(true, "");
                }
                catch (Exception ex)
                {
                    return Tuple.Create(false, ex.Message);
                }

            }
        }

        /// <summary>
        /// 导入标准岗位角色权限主数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Tuple<bool, string, MsgType> ImportSPRolePermissionsInfo(Tuple<List<WFRolePrivilege_Dto>, List<string>> list)
        {
            StringBuilder errMsg = new StringBuilder();
            var allRolePrivilege = permissionProvider.GetAllRolePrivilege();
            using (TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                try
                {
                    #region 标准岗位角色 处理&导入
                    var allRoleInfos = postInfoProvider.GetAllRoleInfo()?.ToList();
                    var listSPRoleInfos = new List<WFRoleInfo_Dto>();
                    list.Item2.ForEach(x =>
                    {
                        if (!allRoleInfos.Any(p => p.Name == x && !p.IsDeleted))
                        {
                            listSPRoleInfos.Add(new WFRoleInfo_Dto()
                            {
                                Name = x,
                                RoleType = (int)RoleType.Template,
                                CreationTime = DateTime.Now,
                                LastUpdateTime = DateTime.Now,
                            });
                        }
                    });
                    listSPRoleInfos = postInfoProvider.AddRoleInfos(listSPRoleInfos)?.ToList();
                    #endregion

                    #region 标准岗位角色操作权限 处理&导入
                    var listToAdd = new List<WFRolePrivilege_Dto>();
                    var isRepeartObj = new List<WFRolePrivilege_Dto>();
                    var groupDatas = list.Item1.GroupBy(p => new { p.Module, p.PermissionName, p.Privilege })?.ToList();
                    groupDatas.ForEach(g =>
                    {
                        var sPRolePrivileges = g.Select(p => p)?.ToList();
                        foreach (var x in sPRolePrivileges)
                        {
                            x.WFRoleInfoNames.ForEach(y =>
                            {
                                var roleInfo = allRoleInfos.Where(p => !p.IsDeleted && p.Name == y)?.FirstOrDefault() ?? listSPRoleInfos.Where(p => !p.IsDeleted && p.Name == y)?.FirstOrDefault();
                                if (roleInfo != null)
                                {
                                    if (allRolePrivilege.Any(p => p.Privilege == (int)x.Privilege
                                   && p.Module == x.Module
                                   && p.WFRoleInfoId == roleInfo.WFRoleInfoId
                                   && p.WFRolePrivilegeId != x.WFRolePrivilegeId))
                                    {
                                        Logger.Warn($"导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】已存在,此行数据不导入;");
                                        errMsg.AppendLine($"【导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】已存在,此行数据不导入】");
                                    }
                                    else
                                    {
                                        if (sPRolePrivileges.Count(p => p.Privilege == (int)x.Privilege && p.Module == x.Module && p.WFRoleInfoId == x.WFRoleInfoId) > 1)
                                        {
                                            if (!listToAdd.Any(p => p.Privilege == (int)x.Privilege && p.Module == x.Module && p.WFRoleInfoId == roleInfo.WFRoleInfoId))
                                            {
                                                Logger.Warn($"导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】重复,默认取第一条;");
                                                errMsg.AppendLine($"【导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】重复,默认取第一条】");
                                                if ((int)x.Privilege != 0)
                                                {
                                                    listToAdd.Add(new WFRolePrivilege_Dto()
                                                    {
                                                        Privilege = (int)x.Privilege,
                                                        Module = x.Module,
                                                        WFRoleInfoId = roleInfo.WFRoleInfoId
                                                    });
                                                }
                                                else
                                                {
                                                    Logger.Warn($"导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入;");
                                                    errMsg.AppendLine($"【导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入】");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((int)x.Privilege != 0)
                                            {
                                                listToAdd.Add(new WFRolePrivilege_Dto()
                                                {
                                                    Privilege = (int)x.Privilege,
                                                    Module = x.Module,
                                                    WFRoleInfoId = roleInfo.WFRoleInfoId
                                                });
                                            }
                                            else
                                            {
                                                Logger.Warn($"导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入;");
                                                errMsg.AppendLine($"【导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】,权限名【{x.PermissionName}】不存在权限值,此行数据不导入】");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!isRepeartObj.Any(p => p.Privilege == (int)x.Privilege && p.Module == x.Module && p.WFRoleInfoId == x.WFRoleInfoId))
                                    {
                                        Logger.Warn($"导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】库中不存在,此行数据不导入;");
                                        errMsg.AppendLine($"【导入标准角色岗位权限时,系统平台【{x.ModuleName}】,岗位名称【{y}】库中不存在,此行数据不导入】");
                                        isRepeartObj.Add(x);
                                    }
                                }
                            });
                        }

                    });
                    var listRoleInfoIds = listToAdd.Select(p => p.WFRoleInfoId)?.Distinct()?.ToList();

                    permissionProvider.AddRolePrivileges(listToAdd);
                    #endregion
                    trans.Complete();
                    if (!string.IsNullOrEmpty(errMsg.ToString()))
                    {
                        return Tuple.Create(true, errMsg.ToString(), MsgType.Warning);
                    }
                    else
                    {
                        return Tuple.Create(true, "", MsgType.Default);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"导入标准角色岗位权限时{ ex.Message}");
                    return Tuple.Create(false, $"导入标准角色岗位权限时{ ex.Message}", MsgType.Err);
                }

            }
        }
        public int ModuleEnumValue(string enumName, Type type)
        {
            #region 模块枚举处理
            if (type == typeof(RouteContextModule))
            {
                if (enumName == RouteContextModule.Mdm.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.Mdm;
                }
                if (enumName == RouteContextModule.Accounting.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.Accounting;
                }
                if (enumName == RouteContextModule.ExchangeBill.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.ExchangeBill;
                }
                if (enumName == RouteContextModule.Hedge.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.Hedge;
                }
                if (enumName == RouteContextModule.Project.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.Project;
                }
                if (enumName == RouteContextModule.SpotTrade.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RouteContextModule.SpotTrade;
                }
                else
                {
                    return 0;
                }
            }
            #endregion
            #region 岗位类别枚举
            if (type == typeof(RoleCategory))
            {
                if (enumName == RoleCategory.FutureTrader.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RoleCategory.FutureTrader;
                }
                if (enumName == RoleCategory.SpotExcutor.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RoleCategory.SpotExcutor;
                }
                if (enumName == RoleCategory.RiskManagement.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RoleCategory.RiskManagement;
                }
                if (enumName == RoleCategory.Saler.GetAttributeInfo<NoteAttribute>("Note")?.ToString())
                {
                    return (int)RoleCategory.Saler;
                }
                else
                {
                    return (int)RoleCategory.Other;
                }
            }
            return 0;
            #endregion     
        }
        public string ModuleEnumName(int value, Type type)
        {
            #region 模块枚举处理
            if (type == typeof(RouteContextModule))
            {
                if (value == (int)RouteContextModule.Mdm)
                {
                    return RouteContextModule.Mdm.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RouteContextModule.Accounting)
                {
                    return RouteContextModule.Accounting.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RouteContextModule.ExchangeBill)
                {
                    return RouteContextModule.ExchangeBill.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RouteContextModule.Hedge)
                {
                    return RouteContextModule.Hedge.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RouteContextModule.Project)
                {
                    return RouteContextModule.Project.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RouteContextModule.SpotTrade)
                {
                    return RouteContextModule.SpotTrade.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                else
                {
                    return "";
                }
            }
            #endregion
            #region 岗位类别枚举
            if (type == typeof(RoleCategory))
            {
                if (value == (int)RoleCategory.FutureTrader)
                {
                    return RoleCategory.FutureTrader.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RoleCategory.SpotExcutor)
                {
                    return RoleCategory.SpotExcutor.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RoleCategory.RiskManagement)
                {
                    return RoleCategory.RiskManagement.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                if (value == (int)RoleCategory.Saler)
                {
                    return RoleCategory.Saler.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
                else
                {
                    return RoleCategory.Other.GetAttributeInfo<NoteAttribute>("Note")?.ToString();
                }
            }
            return "";
            #endregion     
        }
        #region json api
        public T JsonDeserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None, defaultJsonSerializerSettings);
        }
        private readonly JsonSerializerSettings defaultJsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        #endregion
        public bool EmailRegex(string msg)
        {
            Regex re = new Regex(@"[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?");//实例化一个Regex对象

            return re.IsMatch(msg);
        }
    }
}
