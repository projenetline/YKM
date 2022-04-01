// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable InconsistentNaming
namespace YKM.Transfer.ILibrary
{
    public class ModelClCard
    {
        public ModelClCard()
        {
            _Id = 0;
            _AuxilCode = "";
            _AuxilCode2 = "";
            _AuxilCode3 = "";
            _AuxilCode4 = "";
            _AuxilCode5 = "";
            _Country = "TÜRKİYE";
            _PostalCode = "";
            _Fax = "";
            _FaxCode = "";
            _EMail = "";
            _EMail2 = "";
            _EMail3 = "";
            _TradingGrp = "";
            _OhpCode = "";
            _Contact = "";
            _Contact2 = "";
            _Contact3 = "";
            _PurchBrws = 1;
            _SalesBrws = 1;
            _ImpBrws = 1;
            _ExpBrws = 1;
            _FinBrws = 1;
        }

        private int _Id { get; set; }
        private string _Code { get; set; }
        private string _Title { get; set; }
        private string _Title2 { get; set; }
        private string _AuxilCode { get; set; }
        private string _AuxilCode2 { get; set; }
        private string _AuxilCode3 { get; set; }
        private string _AuxilCode4 { get; set; }
        private string _AuxilCode5 { get; set; }
        private string _Address1 { get; set; }
        private string _Address2 { get; set; }
        private string _Town { get; set; }
        private string _City { get; set; }
        private string _CityCode { get; set; }
        private string _Country { get; set; }
        private string _CountryCode { get; set; }
        private string _PostalCode { get; set; }
        private string _Telephone1Code { get; set; }
        private string _Telephone1 { get; set; }
        private string _Telephone2Code { get; set; }
        private string _Telephone2 { get; set; }
        private string _Fax { get; set; }
        private string _FaxCode { get; set; }
        private string _TaxId { get; set; }
        private string _TaxOffice { get; set; }
        private string _Contact { get; set; }
        private string _Contact2 { get; set; }
        private string _Contact3 { get; set; }
        private string _EMail { get; set; }
        private string _EMail2 { get; set; }
        private string _EMail3 { get; set; }
        private string _TradingGrp { get; set; }
        private string _GlCode { get; set; }
        private string _OhpCode { get; set; }
        private byte _PersCompany { get; set; }
        private string _TCKNO { get; set; }
        private string _WebUrl { get; set; }
        private int _PurchBrws { get; set; }
        private int _SalesBrws { get; set; }
        private int _ImpBrws { get; set; }
        private int _ExpBrws { get; set; }
        private int _FinBrws { get; set; }
        private int _ArkmanId { get; set; }

        public int Id { get { return _Id; } set { _Id = value; } }

        public int ArkmanId { get { return _ArkmanId; } set { _ArkmanId = value; } }

        public string Code { get { return _Code; } set { _Code = value; } }

        public string Title { get { return _Title; } set { _Title = value; } }

        public string Title2 { get { return _Title2; } set { _Title2 = value; } }

        public string AuxilCode { get { return _AuxilCode; } set { _AuxilCode = value; } }

        public string AuxilCode2 { get { return _AuxilCode2; } set { _AuxilCode2 = value; } }

        public string AuxilCode3 { get { return _AuxilCode3; } set { _AuxilCode3 = value; } }

        public string AuxilCode4 { get { return _AuxilCode4; } set { _AuxilCode4 = value; } }

        public string AuxilCode5 { get { return _AuxilCode5; } set { _AuxilCode5 = value; } }

        public string Address1 { get { return _Address1; } set { _Address1 = value; } }

        public string Address2 { get { return _Address2; } set { _Address2 = value; } }

        public string Town { get { return _Town; } set { _Town = value; } }

        public string City { get { return _City; } set { _City = value; } }

        public string CityCode { get { return _CityCode; } set { _CityCode = value; } }

        public string Country { get { return _Country; } set { _Country = value; } }

        public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

        public string PostalCode { get { return _PostalCode; } set { _PostalCode = value; } }

        public string Telephone1Code { get { return _Telephone1Code; } set { _Telephone1Code = value; } }

        public string Telephone1 { get { return _Telephone1; } set { _Telephone1 = value; } }

        public string Telephone2Code { get { return _Telephone2Code; } set { _Telephone2Code = value; } }

        public string Telephone2 { get { return _Telephone2; } set { _Telephone2 = value; } }

        public string FaxCode { get { return _FaxCode; } set { _FaxCode = value; } }

        public string Fax { get { return _Fax; } set { _Fax = value; } }

        public string TaxId { get { return _TaxId; } set { _TaxId = value; } }

        public string TaxOffice { get { return _TaxOffice; } set { _TaxOffice = value; } }

        public string Contact { get { return _Contact; } set { _Contact = value; } }

        public string Contact2 { get { return _Contact2; } set { _Contact2 = value; } }

        public string Contact3 { get { return _Contact3; } set { _Contact3 = value; } }

        public string EMail { get { return _EMail; } set { _EMail = value; } }

        public string EMail2 { get { return _EMail2; } set { _EMail2 = value; } }

        public string EMail3 { get { return _EMail3; } set { _EMail3 = value; } }

        public string TradingGrp { get { return _TradingGrp; } set { _TradingGrp = value; } }

        public string GlCode { get { return _GlCode; } set { _GlCode = value; } }

        public string OhpCode { get { return _OhpCode; } set { _OhpCode = value; } }

        public byte PersCompany { get { return _PersCompany; } set { _PersCompany = value; } }

        public string TCKNO { get { return _TCKNO; } set { _TCKNO = value; } }

        public string WebUrl { get { return _WebUrl; } set { _WebUrl = value; } }

        public int PurchBrws { get { return _PurchBrws; } set { _PurchBrws = value; } }

        public int SalesBrws { get { return _SalesBrws; } set { _SalesBrws = value; } }

        public int ImpBrws { get { return _ImpBrws; } set { _ImpBrws = value; } }

        public int ExpBrws { get { return _ExpBrws; } set { _ExpBrws = value; } }

        public int FinBrws { get { return _FinBrws; } set { _FinBrws = value; } }
    }
}