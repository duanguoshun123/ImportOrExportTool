using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.DbModel.Model
{
    public class ImportModel
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; }
        /// <summary>
        /// 表头
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 对应的属性值
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否允许为空 默认不允许为空
        /// </summary>
        public bool AllowNullOrEmpty { get; set; }
        /// <summary>
        /// 是否允许包含小写字母 默认允许
        /// </summary>
        public bool? AllowContainLetter { get; set; }
        /// <summary>
        /// 允许小于0 默认允许
        /// </summary>
        public bool? AllowLessThanZero { get; set; }
        /// <summary>
        /// 是否检查账期 默认不检查
        /// </summary>
        public bool? NeedCheckDate { get; set; }
        /// <summary>
        /// 是否可选
        /// </summary>
        public bool IsOptional { get; set; }
        /// <summary>
        /// 验证利润中心 父节点利润中心不允许添加
        /// </summary>
        public bool NeedCheckProfitCenter { get; set; }
        /// <summary>
        /// 获取绑定集合
        /// </summary>
        public IList<object> BindingList { get; set; }
        /// <summary>
        /// 绑定集合的属性值
        /// </summary>
        public string BindingMember { get; set; }
        /// <summary>
        /// 要储存的属性值
        /// </summary>
        public string BindingValue { get; set; }

        /// <summary>
        /// 数值必须介于0到1之间 （默认不是必须）
        /// </summary>
        public bool? AllowGreaterThanZeroAndLessThanOne { get; set; }

        /// <summary>
        /// 是否验证策略
        /// </summary>
        public bool IsVerifyStrategy { get; set; }

        public ImportModel()
        {
            this.AllowContainLetter = true;
            this.AllowLessThanZero = true;
            AllowGreaterThanZeroAndLessThanOne = true;
            this.AllowNullOrEmpty = false;
            this.DataType = DataType.String;
            IsVerifyStrategy = false;
        }

    }
}