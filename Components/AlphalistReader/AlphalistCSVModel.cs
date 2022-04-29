using AlphaListParser.Components.AlphalistDataTransformer;

namespace AlphaListParser.Components.AlphalistReader
{
    public class AlphalistCSVModel
    {
        public int Sequence { get; set; }

        private string _CorporateName { get; set; }

        public string CorporateName
        {
            get => _CorporateName;
            set
            {
                _CorporateName = NameCleaner.Apply(value);
            }
        }

        private string _FirstName { get; set; }
        public string FirstName
        {
            get => _FirstName; set
            {
                _FirstName = NameCleaner.Apply(value);
            }
        }

        private string _MiddleName { get; set; }
        public string MiddleName
        {
            get => _MiddleName; set
            {
                _MiddleName = NameCleaner.Apply(value);
            }
        }

        private string _LastName { get; set; }
        public string LastName
        {
            get => _LastName; set
            {
                _LastName = NameCleaner.Apply(value);
            }
        }

        public string BaseTin => ExtractBaseTin.Apply(TaxIdentificationNumber);
        public string BranchId => ExtractTinBranchId.Apply(TaxIdentificationNumber);

        public string TaxIdentificationNumber { get; set; }

        private string _TaxCode { get; set; }
        public string TaxCode
        {
            get => _TaxCode; set
            {
                _TaxCode = TaxCodeCleaner.Apply(value);
            }
        }

        public decimal TaxBase { get; set; }
        public decimal WithHoldingTax { get; set; }
        public decimal TaxRate { get; set; } = 0;


    }
}