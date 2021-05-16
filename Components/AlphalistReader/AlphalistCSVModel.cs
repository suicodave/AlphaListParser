namespace AlphaListParser.Components.AlphalistReader
{
    public class AlphalistModel
    {
        public string CorporateName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxBase { get; set; }
        public decimal WithHoldingTax { get; set; }
    }
}