namespace CrossCutting.Common.Validation
{
    public static class EnumValidation
    {
        public static bool IsValidEnumValue<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse<TEnum>(value, out _);
        }

        public static TEnum ConvertStringToEnum<TEnum>(string value) where TEnum : struct
        {
            if (Enum.TryParse(value, out TEnum result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid value for enum type {typeof(TEnum).Name}");
            }
        }
    }
}
