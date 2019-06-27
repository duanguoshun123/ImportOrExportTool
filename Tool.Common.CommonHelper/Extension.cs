using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Tool.Common.CommonHelper.EnumHelper.Enums;

namespace Tool.Common.CommonHelper
{
    public static class Extension
    {
        public static DataTable GetDataTable<T>()
        {
            Type t = typeof(T);  //创建类型
            FieldInfo[] fieldinfo = t.GetFields(); //获取字段信息对象集合
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(String));
            table.Columns.Add("Value", typeof(Int32));
            foreach (FieldInfo field in fieldinfo)
            {
                if (!field.IsSpecialName)
                {
                    DataRow row = table.NewRow();
                    row[0] = ((NoteAttribute)field.GetCustomAttribute(typeof(NoteAttribute))).Note;   //获取文本字段
                    row[1] = (int)field.GetRawConstantValue();  //获取int数值
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public static object GetAttributeInfo<T>(this Enum value, string property, Boolean nameInstead = false) where T : Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            T attribute = Attribute.GetCustomAttribute(field, typeof(T)) as T;

            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            if (attribute == null)
            {
                return null;
            }

            var properties = TypeDescriptor.GetProperties(typeof(T));
            var pro = properties.Find(property, true);
            if (pro != null)
            {
                return pro.GetValue(attribute);
            }
            return null;
        }
        public static List<string> GetEnumIds<T>()
        {
            List<string> ids = new List<string>();
            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                ids.Add(myCode.ToString());
            }
            return ids;
        }
        public static List<T> ConvertToModel<T>(this DataTable dt) where T : new()
        {
            // 定义集合
            IList<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);
            string tempName = "";

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;  // 检查DataTable是否包含此列

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite)
                        {
                            continue;
                        }

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                ts.Add(t);
            }
            return ts.ToList();
        }

        /// <summary>
        /// 对象指定的属性值
        /// </summary>
        /// <param name="info">object对象</param>
        /// <param name="field">属性名称</param>
        /// <returns></returns>
        public static object GetPropertyValue(this object info, string field)
        {
            if (info == null)
            {
                return null;
            }

            Type t = info.GetType();
            PropertyInfo property = t.GetProperties().SingleOrDefault(a => a.Name == field);
            if (property == null)
            {
                return string.Empty;
            }

            return property.GetValue(info, null);
        }
    }
}
