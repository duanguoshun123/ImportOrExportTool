using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Common.CommonHelper
{
    public class NoteAttribute : Attribute
    {
        /// <summary>
        /// 不支持多语言
        /// </summary>
        public NoteAttribute(string note)
        {
            this.Note = note;
        }

        /// <summary>
        /// 解释
        /// </summary>
        public string Note { get; set; }
    }
}
