#if NET35

namespace Microsoft.SqlServer.Types
{
    internal static class EnumExtension
    {
        public static bool HasFlag(this Enum value, Enum flag)
        {
            if (flag == null)
            {
                throw new ArgumentNullException(nameof(flag));
            }

            if (value.GetType() != flag.GetType())
            {
                throw new ArgumentException("Argument_EnumTypeDoesNotMatch");
            }

            var enumType = value.GetType();
            var enumUnderlyingType = Enum.GetUnderlyingType(enumType);
            var underlyingValue = Convert.ChangeType(value, enumUnderlyingType);
            return ((int)underlyingValue & (int)Convert.ChangeType(flag, enumUnderlyingType)) ==
                   (int)Convert.ChangeType(flag, enumUnderlyingType);
        }
    }
}
#endif