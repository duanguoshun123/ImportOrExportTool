using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DAL.DataAccessLayer
{
    public class PropertiesBuilder<TEntity>
    where TEntity : class, new()

    {
        private readonly HashSet<string> _PropertyNames;

        public PropertiesBuilder()
            : this(new HashSet<string>())
        {

        }
        private PropertiesBuilder(HashSet<string> propertyNames)
        {
            _PropertyNames = propertyNames;
        }
        public IEnumerable<string> PropertyNames { get { return _PropertyNames; } }

        public PropertiesBuilder<TEntity> Append<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            var propertyName = GetPropertyName(property);
            _PropertyNames.Add(propertyName);
            return this;
        }

        public PropertiesBuilder<TDestination> As<TDestination>()
            where TDestination : class, new()
        {
            return new PropertiesBuilder<TDestination>(this._PropertyNames);
        }

        public static string GetPropertyName<TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            return ((MemberExpression)property.Body).Member.Name;
        }
    }
}
