using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Common.CommonHelper.EnumHelper
{
    public class Enums
    {
        public enum ImportType
        {
            [Note("所有主数据")]
            All = 0,
            [Note("法人")]
            Corportation = 1,
            [Note("利润中心")]
            ProfitCenter = 2,
            [Note("岗位")]
            Post = 3,
            [Note("权限")]
            Permission = 4,
            [Note("用户")]
            UserInfo = 5,
            [Note("品种")]
            Commodity = 6,
            //[Note("交易所")]
            //Exchange = 7,
            [Note("标准岗位角色权限")]
            SPRolePermission = 8,
        }
        public enum MsgType
        {
            Default,
            Err = 1,
            Warning = 2
        }
        /// <summary>
        /// 数据类型
        /// </summary>
        public enum DataType
        {
            [Note("字符串")]
            String,
            [Note("yyyy-MM-dd HH:mm:ss")]
            FullDateTime,
            [Note("DataType.yyyyMMdd")]
            IntDateTime,
            [Note("DataType.yyyy-MM-dd")]
            ShortDateTime,
            [Note("数值")]
            Decimal,
            [Note("整数")]
            Long,
            [Note("数值")]
            Double,
            [Note("布尔值")]
            Bool,
            [Note("数值")]
            Short,
            [Note("时间")]
            TimeSpan,
            [Note("整数")]
            Int
        }
        /// <summary>
        /// 递延方向
        /// </summary>
        public enum DeferredDirection
            : int
        {
            [Note("多付空")]
            ExcessSpace = 1,

            [Note("空付多")]
            EmptyPayMore = -1
        }

        public enum BaIndicatorProfitCenter
        {
            /// <summary>
            /// 现货持仓
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("现货持仓")]
            SpotPosition = 1 << 0,

            /// <summary>
            /// 期货持仓
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("期货持仓")]
            FuturePosition = 1 << 1,

            /// <summary>
            /// 期权持仓
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("期权持仓")]
            OptionPosition = 1 << 2,

            /// <summary>
            /// 证券持仓
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("证券持仓")]
            SecurityPosition = 1 << 3,

            /// <summary>
            /// 利润
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("利润")]
            ProfitAndLoss = 1 << 4,

            /// <summary>
            /// 费用
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("费用")]
            Cost = 1 << 5,

            /// <summary>
            /// 资金占用
            /// IndicatorType: ProfitCenterAndAccountFlag.ProfitCenter
            /// </summary>
            [Note("资金占用")]
            CapitalOccupation = 1 << 6,

            /// <summary>
            /// 外汇持仓
            /// </summary>
            [Note("外汇持仓")]
            ForexPosition = 1 << 7,

            /// <summary>
            /// 资金成本
            /// </summary>
            [Note("资金成本")]
            CapitalInterest = 1 << 8,

            /// <summary>
            /// 套保环盈亏
            /// </summary>
            [Note("套保环盈亏")]
            HedgingLoopProfitAndLoss = 1 << 9,
        }

        public enum RouteContextModule
        {
            /// <summary>
            /// 1 主数据管理
            /// </summary>
            [Note("主数据管理")]
            Mdm = 1 << 0,

            /// <summary>
            /// 2 现货贸易
            /// </summary>
            [Note("现货贸易")]
            SpotTrade = 1 << 1,

            /// <summary>
            /// 4 清算
            /// </summary>
            [Note("清算")]
            Accounting = 1 << 2,

            /// <summary>
            /// 8 票据
            /// </summary>
            [Note("票据")]
            ExchangeBill = 1 << 3,

            /// <summary>
            /// 16 项目
            /// </summary>
            [Note("项目")]
            Project = 1 << 4,

            /// <summary>
            /// 32 套期保值
            /// </summary>
            [Note("套期保值")]
            Hedge = 1 << 5,
        }

        /// <summary>
        /// 公司具体类型 Flag
        /// </summary>
        [Flags]
        public enum CorporationTypeFlag
        {
            /// <summary>
            /// 1 贸易公司
            /// </summary>
            [Note("贸易公司")]
            Client = 1 << 0,

            /// <summary>
            /// 4 作价市场 market
            /// 市场、交易所、所内质押
            /// </summary>
            [Note("作价市场")]
            Exchange = 1 << 2,

            /// <summary>
            /// 16 融资
            /// 所外质押
            /// Broker 经纪公司
            /// </summary>
            [Note("融资")]
            Financing = 1 << 4,

            ///// <summary>
            ///// 我方公司法人 64
            ///// </summary>
            //[Note("公司法人")]
            //[Obsolete]
            //Corporation = 1 << 6,

            ///// <summary>
            ///// 物流公司 256
            ///// </summary>
            //[Note("物流公司")]
            //[Obsolete("仓库地点、仓库公司")]
            //Logistics = 1 << 8,

            /// <summary>
            /// （新） 物流公司 256
            /// </summary>
            [Note("物流公司")]
            Logistics = 1 << 8,

            ///// <summary>
            ///// 现货作价市场 1024
            ///// </summary>
            //[Note("现货作价市场")]
            //[Obsolete("将并入 作价市场")]
            //SpotPriceMakingMarket = 1 << 10,

            ///// <summary>
            ///// 仓库地点 4096
            ///// </summary>
            //[Note("仓库地点")]
            //[Obsolete]
            //Warehouse = 1 << 12,

            ///// <summary>
            ///// 信用组 16384
            ///// </summary>
            //[Note("信用组")]
            //[Obsolete]
            //Group = 1 << 14,

            /// <summary>
            /// 65536 银行
            /// 票据
            /// </summary>
            [Note("银行")]
            Bank = 1 << 16,

            /// <summary>
            /// 262144 仓库公司
            /// </summary>
            [Note("仓库公司")]
            WarehousingCompany = 1 << 18,
        }
        /// <summary>
        /// 超公司类型
        /// </summary>
        public enum MetaCompanyType
        {
            /// <summary>
            /// 公司
            /// </summary>
            [Note("公司")]
            Corporation = 1,

            /// <summary>
            /// 仓库地点
            /// </summary>
            [Note("仓库地点")]
            WarehousePlace = 2,

            /// <summary>
            /// 信用组
            /// </summary>
            [Note("信用组")]
            CreditGroup = 3,
        }

        /// <summary>
        /// 公司内外分类
        /// </summary>
        public enum CorporationRelationCategory
        {
            /// <summary>
            /// 外部
            /// </summary>
            [Note("外部")]
            External = 1,

            /// <summary>
            /// 内部，我方
            /// </summary>
            [Note("内部")]
            Internal = 2,
        }

        /// <summary>
        /// 部门类别
        /// </summary>
        //[Flags]
        public enum DepartmentType
        {
            /// <summary>
            /// 非业务部门
            /// </summary>
            [Note("非业务部门")]
            Department = 1,

            /// <summary>
            /// 业务部门
            /// </summary>
            [Note("业务部门")]
            BusinessDepartment = 2,

            //[Note("核算主体")]
            //AccountEntity = 4,
        }

        /// <summary>
        /// 岗位类别
        /// </summary>
        public enum RoleCategory
        {
            /// <summary>
            /// 其他岗位类别
            /// </summary>
            [Note("其他岗位类别")]
            Other = 1,

            ///// <summary>
            ///// 系统管理员
            ///// </summary>
            //[Note("系统管理员")]
            //Admin = 10,

            /// <summary>
            /// 现货执行人员
            /// </summary>
            [Note("现货执行人员")]
            SpotExcutor = 11,

            ///// <summary>
            ///// 现货执行组长
            ///// </summary>
            //[Note("现货执行组长")]
            //SpotExcutorLeader = 12,

            ///// <summary>
            ///// 现货执行主管
            ///// </summary>
            //[Note("现货执行主管")]
            //SpotExcutorManager = 13,

            /// <summary>
            /// 业务员
            /// </summary>
            [Note("业务员")]
            Saler = 20,

            ///// <summary>
            ///// 事业部副总经理
            ///// </summary>
            //[Note("事业部副总经理")]
            //DepartmentManager = 21,

            ///// <summary>
            ///// 事业部总经理
            ///// </summary>
            //[Note("事业部总经理")]
            //GeneralManager = 22,

            ///// <summary>
            ///// 总裁
            ///// </summary>
            //[Note("总裁")]
            //President = 23,

            ///// <summary>
            ///// 业务主管
            ///// </summary>
            //[Note("业务主管")]
            //SalerManager = 24,

            ///// <summary>
            ///// 核算人员
            ///// </summary>
            //[Note("核算人员")]
            //Accounting = 30,

            /// <summary>
            /// 风险控制人员
            /// </summary>
            [Note("风险控制人员")]
            RiskManagement = 30,

            ///// <summary>
            ///// 核算主管
            ///// </summary>
            //[Note("核算主管")]
            //AccountingManager = 31,

            ///// <summary>
            ///// 财务人员
            ///// </summary>
            //[Note("财务人员")]
            //Financial = 40,

            ///// <summary>
            ///// 财务主管
            ///// </summary>
            //[Note("财务主管")]
            //FinancialManager = 41,

            ///// <summary>
            ///// 期货执行人员
            ///// </summary>
            //[Note("期货执行人员")]
            //FutureExcutor = 50,

            ///// <summary>
            ///// 期货执行主管
            ///// </summary>
            //[Note("期货执行主管")]
            //FutureExcutorManager = 51,

            ///// <summary>
            ///// 资金部门执行人员
            ///// </summary>
            //[Note("资金部门执行人员")]
            //TreasuryExcutor = 60,

            ///// <summary>
            ///// 资金部门主管
            ///// </summary>
            //[Note("资金部门主管")]
            //TreasuryManager = 61,

            ///// <summary>
            ///// 内控专员
            ///// </summary>
            //[Note("内控专员")]
            //InternalControlSpecialist = 70,

            ///// <summary>
            ///// 内控部长
            ///// </summary>
            //[Note("内控部长")]
            //InternalControlManager = 71,

            ///// <summary>
            ///// 物流岗位
            ///// </summary>
            //[Note("物流执行人员")]
            //LogisticsExcutor = 80,

            ///// <summary>
            ///// 运维人员
            ///// </summary>
            //[Note("运维人员")]
            //SRE = 90,

            /// <summary>
            /// 期货人员
            /// </summary>
            [Note("期货人员")]
            FutureTrader = 100,
        }

        /// <summary>
        /// 角色分类
        /// </summary>
        public enum RoleType
        {
            /// <summary>
            /// 普通
            /// </summary>
            [Note("普通")]
            Normal = 0,

            /// <summary>
            /// 内置
            /// </summary>
            [Note("内置")]
            BuiltIn = 1,

            /// <summary>
            /// 模板
            /// </summary>
            [Note("模板")]
            Template = 2,
        }

    }
}
