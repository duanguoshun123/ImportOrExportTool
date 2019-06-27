using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.DbModel.Model;

namespace Tool.DbModel.DTO.ConfigModel
{
    public class ImportMappingModel
    {
        /// <summary>
        /// 记录类型
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// 期货组合字段(交易所、品种、合约)有效性验证
        /// </summary>
        public bool NeedCheckFutureContract { get; set; }
        /// <summary>
        /// 验证交易所和品种的组合(期货费用记录)
        /// </summary>
        public bool NeedCheckExchangCom { get; set; }
        /// <summary>
        /// 验证类型和数值的组合
        /// （当类型为递延方向时，数值必须为"多付空" "空付多"）
        /// </summary>
        public bool NeedCheckTypeValue { get; set; }
        /// <summary>
        /// 验证交易日期和合约日期的组合
        /// (交易日期不能大于合约日期)
        /// </summary>
        public bool CheckTradeContractDate { get; set; }
        /// <summary>
        /// 是否需要根据过滤验证写的权限
        /// </summary>
        public bool CheckFilterWriteAble { get; set; }
        /// <summary>
        /// 需要验证现货币种和物料的组合(针对现货)
        /// </summary>
        public bool CheckCurrencyMaterial { get; set; }
        /// <summary>
        /// 验证业务类型 币种 品种 交易所的组合（针对其他收支记录）
        /// 对于期货：需验证交易所品种组合
        /// 对于现货：需验证币种品种组合
        /// </summary>
        public bool CheckTypeCurrencyCommodity { get; set; }
        /// <summary>
        /// 需要验证交易账户与币种的组合
        /// </summary>
        public bool CheckAccountCurrency { get; set; }

        /// <summary>
        /// 验证买/卖、手数组合
        /// </summary>
        public bool CheckDirectionVolume { get; set; }

        /// <summary>
        /// 验证买/卖、计价重量组合
        /// </summary>
        public bool CheckDirectionValuationWeight { get; set; }

        /// <summary>
        /// 验证买/卖、重量组合
        /// </summary>
        public bool CheckDirectionWeight { get; set; }

        /// <summary>
        /// 验证买/卖、数量组合
        /// </summary>
        public bool CheckDirectionQuantity { get; set; }

        /// <summary>
        /// 验证开始日期、结束日期组合
        /// </summary>
        public bool CheckStartDateEndDate { get; set; }

        /// <summary>
        /// 验证行权日期、开始日期组合
        /// </summary>
        public bool CheckStrikeDateStartDate { get; set; }

        /// <summary>
        /// 验证法人、交易账户
        /// </summary>
        public bool CheckCorporationTradeAccount { get; set; }

        /// <summary>
        /// 验证资金利率参数（币种、利润中心、法人、品种）
        /// </summary>
        public bool CheckCapitalInterestRateParameter { get; set; }


        /// <summary>
        /// 验证品种、币种组合
        /// </summary>
        public bool CheckCommodityCurrency { get; set; }

        /// <summary>
        /// 验证品种、重量单位组合
        /// </summary>
        public bool CheckCommodityWeightUnit { get; set; }

        /// <summary>
        /// 验证主力合约
        /// </summary>
        public bool CheckDominantContract { get; set; }

        /// <summary>
        /// 验证利润中心、策略组合
        /// </summary>
        public bool CheckProfitCenterStrategy { get; set; }

        /// <summary>
        /// 验证授权设置利润中心、策略至少选一个
        /// </summary>
        public bool CheckAuthorizationProfitCenterStrategy { get; set; }

        /// <summary>
        /// 验证对接现货信息
        /// </summary>
        public bool CheckTR_HfIntegrationPriced { get; set; }

        public List<ImportModel> ImportModels { get; set; }

        public ImportMappingModel()
        {
            this.ImportModels = new List<ImportModel>();
            this.ObjectName = null;
            this.NeedCheckExchangCom = false;
            this.NeedCheckFutureContract = false;
            this.NeedCheckTypeValue = false;
            this.CheckProfitCenterStrategy = false;
            this.CheckAuthorizationProfitCenterStrategy = false;
        }
    }
}
