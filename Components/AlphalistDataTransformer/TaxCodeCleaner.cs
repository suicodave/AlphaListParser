namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public class TaxCodeCleaner
    {
        public static string Apply(string name){
            name = NameCleaner.RemoveSpecialCharacters(name);

            name = NameCleaner.RemoveWhiteSpace(name);

            return name;
        }
    }
}