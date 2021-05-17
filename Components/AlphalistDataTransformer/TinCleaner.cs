using System;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class TinCleaner
    {
        public static string Apply(string name)
        {
            return name;
        }


        public static string NormalizeTin(string name)
        {
            return NameCleaner.RemoveSpecialCharacters(name);
        }

        public static string GetBaseTin(string name)
        {
            name = NormalizeTin(name);
            
            return name.Substring(0, 9);
        }

        public static string GetUnsanitizedBranchId(string name)
        {
            name = NormalizeTin(name);

            int startingIndex = 9;

            int remainingLength = name.Length - startingIndex;

            return name.Substring(startingIndex, remainingLength);
        }

        public static string GetBranchId(string name)
        {
            int branchIdLength = 4;

            string unsanitizedBranchId = GetUnsanitizedBranchId(name);

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