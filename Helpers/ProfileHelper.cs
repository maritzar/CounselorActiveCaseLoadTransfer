namespace Counselor_Active_CaseLoad_Transfer.Helper
{

    public static class ProfileHelper
    {

        public static string GetProfileElement(string fieldName, string fields, string values)
        {
            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(fields) || string.IsNullOrEmpty(values))
                return null;

            // Only handle string type fields (:S:)
            int fieldNameStart = fields.IndexOf(fieldName + ":S", StringComparison.Ordinal);
            if (fieldNameStart == -1)
                return null;

            fieldNameStart += fieldName.Length + 3;

            // Get the field token
            string fieldNameToken = fields.Substring(fieldNameStart);

            // Get the values for the offset and length
            int valueStart = FnGetElement(fieldNameToken, 1, ':');
            int valueLength = FnGetElement(fieldNameToken, 2, ':');

            if (valueLength == 0)
                return string.Empty;

            // Return the string
            return values.Substring(valueStart, valueLength);
        }

        // Helper method to mimic dbo.fn_getelement
        private static int FnGetElement(string input, int index, char delimiter)
        {
            var parts = input.Split(delimiter);
            if (index - 1 < 0 || index - 1 >= parts.Length)
                return 0;

            return int.TryParse(parts[index - 1], out int result) ? result : 0;
        }

    }

}
