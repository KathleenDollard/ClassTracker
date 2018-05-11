using System;
using System.Globalization;
using System.Reflection;

namespace KadGen.Functional.Common
{
    public static class ReflectionHelpers
    {
        public static T CreateInstanceWithPublicOrNonPublicConstructor<T>(params object[] parameters)
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var obj = Activator.CreateInstance(typeof(T), bindingFlags, null, parameters, CultureInfo.CurrentCulture);
            return (T)obj;
        }
    }
}
