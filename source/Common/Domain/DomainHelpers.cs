using System;
using System.Linq;

namespace Common.Domain
{
    public static class DomainHelpers
    {
        public static TPKey GetPKey<TPKey>(this IHasPKey<TPKey> item)
        {
            if (item == null)
            {
                return default(TPKey);
            }
            return item.GetPKey();
        }

        // This is not intended for a catch all public library
        // implement your own conventions here. Examples shown.
        public static TPKey GetPKey<TPKey>(object item)
        {
            if (item == null)
            {
                return default(TPKey);
            }
            if (item is IHasPKey)
            {
                if (item is IHasPKey<TPKey> domainItem)
                {
                    return domainItem.GetPKey();
                }
                throw new InvalidCastException("Requested key type differs from the objects key type");
            }
            return GetPKeyByConvention<TPKey>(item);
        }

        // This is not intended for a catch all public library
        // implement your own conventions here. Examples shown.
        private static TPKey GetPKeyByConvention<TPKey>(object item)
        {
            if (item == null)
            {
                return default(TPKey);
            }
            // only look at valid types
            // Alternatively use IsAssignableTo below if you want castable types, I didn't
            var properties = item.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(TPKey));
            if (!properties.Any())
            {
                new InvalidOperationException("Cannot get primary key for type with no properties");
            }
            var idProp = properties
                    .Where(p => p.Name == "Id")
                    .FirstOrDefault();
            if (idProp != null)
            {
                return (TPKey)idProp.GetValue(item);
            }
            idProp = properties
                .Where(p => p.Name.Contains("Id"))
                .FirstOrDefault();
            if (idProp != null)
            {
                return (TPKey)idProp.GetValue(item);
            }
            // This might be dangerous - it's just the first matching type
            idProp = properties
                        .First();
            return (TPKey)idProp.GetValue(item);
        }
    }
}
