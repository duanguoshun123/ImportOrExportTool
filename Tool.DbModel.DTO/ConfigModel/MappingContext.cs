using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO.ConfigModel
{
    public abstract class MappingContext<T> where T : class
    {
        public T Mapping
        {
            get { return this.Initialze(); }
        }

        protected abstract T Initialze();
    }
}
