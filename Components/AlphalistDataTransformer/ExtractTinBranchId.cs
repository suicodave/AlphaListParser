using System;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class ExtractTinBranchId
    {
        public static string Apply(string name)
        {
            int branchIdLength = 4;

            string unsanitizedBranchId = ExtractUnsanitizedTinBranchId.Apply(name);

            int stringLength = unsanitizedBranchId.Length;

            if (stringLength < branchIdLength)
            {
                int numberOfZeroes = Math.Abs(stringLength - branchIdLength);

                string leadingZeroes = new String('0', numberOfZeroes);

                return $"{leadingZeroes}{unsanitizedBranchId}";
            }


            int startingIndex = stringLength - branchIdLength;

            return unsanitizedBranchId.Substring(startingIndex, 4);
        }
    }
}