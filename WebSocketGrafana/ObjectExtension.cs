using System;

namespace WebSocketGrafana
{
    public static class ObjectExtension
    {
        public static object GetPropertyValue(this object src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", nameof(src));
            if (propName == null) throw new ArgumentException("Value cannot be null.", nameof(propName));

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop?.GetValue(src, null);
            }
        }
    }
}
