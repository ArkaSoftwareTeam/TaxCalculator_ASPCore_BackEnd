namespace CTaxCalculator.Framework.Utilities.OutServices.DateTimes
{
    public static class UnicodeConstants
    {
        public const char RleChar = (char)0x202B;

        /// <summary>
        /// .را روی متن اعمال می کند RLE ,در صورتی که متن حاوی کلمات فارسی باشد
        ///  
        /// </summary>
        public static string ApplyRle(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            return text.ContainsFarsi() ? $"{RleChar}{text}" : text;
        }
    }
}
