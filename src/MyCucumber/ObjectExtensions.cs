using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyCucumber
{
    public static class ObjectExtensions
    {
        public static string String(this object input)
        {
            if (input == null) return null;
            return Convert.ToString(input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// <c>false</c> unless <c>true</c>.
        /// </summary>
        public static bool Bool(this object input)
        {
            if (input == null) return false;
            return new[] { "is", "yes", "was", "has", "gets", "did", "true", "1" }.Contains(input.String().ToLowerInvariant());
        }

        /// <summary>
        /// Case from a string to any other type that supports IConvertible
        /// </summary>
        public static IEnumerable<object> CastAppropriately(this string[] values, Type[] intendedTypes)
        {
            for (var i=0; i<values.Length && i<intendedTypes.Length; i++)
            {
                // bool
                if (intendedTypes[i] == typeof(bool))
                {
                    yield return values[i].Bool();
                    continue;
                }

                // enum
                if (intendedTypes[i].IsEnum)
                {
                    yield return Enum.Parse(intendedTypes[i], values[i], true);
                    continue;
                }

                yield return Convert.ChangeType(values[i], intendedTypes[i]);
            }
        }
    }
}
