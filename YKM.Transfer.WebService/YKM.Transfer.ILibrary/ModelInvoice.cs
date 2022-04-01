// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YKM.Transfer.ILibrary
{
    [CustomValidation(typeof(MyValidators), "IsInvoiceValid")]
    public class ModelInvoice
    {
        public ModelInvoice()
        {
            _Lines = new List<TransactionLine>();
            _PaymentList = new List<ModelPaymentList.Payment>();
        }

        private int _Id { get; set; }
        private int _Type { get; set; }
        private string _Number { get; set; }
        private DateTime _Date { get; set; }
        private int _Time { get; set; }
        private int _ArkmanId { get; set; }

        private string _ArpCode { get; set; }

        //private string _ArpCodeShpm { get; set; }
        private string _GlCode { get; set; }

        private DateTime _DocDate { get; set; }
        private string _DocNumber { get; set; }
        private string _Note1 { get; set; }
        private string _Note2 { get; set; }
        private string _Note3 { get; set; }
        private string _Note4 { get; set; }

        private string _OhpCode { get; set; }

        //private string _ProjectCode { get; set; }
        private string _AuxilCode { get; set; }

        private string _AuthCode { get; set; }
        private string _PaymentCode { get; set; }
        private string _SalesManCode { get; set; }
        private string _TradingGrp { get; set; }
        private int _SourceWh { get; set; }
        private int _SourceCostGrp { get; set; }
        private int _Division { get; set; }
        private int _Department { get; set; }

        private int _Factory { get; set; }

        //private int _VatIncludedGrs { get; set; }
        private string _VatExceptCode { get; set; }

        /* E-Fatura - E-Arşiv Ortak Alanlar */
        private int _EInvoiceType { get; set; } // 1: Özel Matrah // 2: İstisna // 3: Araç Tescil // 4: Tevkifat 

        private int _EInvoice { get; set; } // 1: E-Fatura // 2: E-Arşiv
        private int _EArchiveDeTrIntPaymentType { get; set; } // 1: Kredi Kartı // 2: Eft / Havale // 3: Kapıda Ödeme // 4: Ödeme Aracısı // 5: Diğer
        private int _EDurationType { get; set; }

        /* E-Arşiv Alanları */
        private int _EStatus_EArsiv { get; set; } //E-Arşiv faturası oluşturulacak mı oluşturulmayacak mı

        private string _EArchiveDeTrInstallMentNumber_EArsiv { get; set; } // Tesisat Numarası
        private int _EArchiveDeTrEArchiveStatus_EArsiv { get; set; }
        private int _EArchiveDeTrSendMod_EArsiv { get; set; } // Elektronik mi kağıt mı
        private string _EArchiveDeTrIntPaymentDesc_EArsiv { get; set; } // Ödeme Şekli Açıklaması
        private string _EArchiveDeTrIntPaymentAgent_EArsiv { get; set; } // Ödeme Aracısı Açıklaması
        private DateTime _EArchiveDeTrIntPaymentDate_EArsiv { get; set; }
        private int _EArchiveDeTrInsteadOfDesp_EArsiv { get; set; }

        /* E-Fatura Alanları */
        private int _EInsteadOfDispatch_EFatura { get; set; }

        private DateTime _EStartDate_EFatura { get; set; }
        private DateTime _EEndDate_EFatura { get; set; }
        private string _EDescription_EFatura { get; set; }
        private int _EDuration_EFatura { get; set; }

        private List<TransactionLine> _Lines { get; set; }
        private List<ModelPaymentList.Payment> _PaymentList { get; set; }

        public int EInvoiceType { get { return _EInvoiceType; } set { _EInvoiceType = value; } }

        public int EInvoice { get { return _EInvoice; } set { _EInvoice = value; } }

        public int EArchiveDeTrIntPaymentType { get { return _EArchiveDeTrIntPaymentType; } set { _EArchiveDeTrIntPaymentType = value; } }

        public int EDurationType { get { return _EDurationType; } set { _EDurationType = value; } }

        public int EStatus_EArsiv { get { return _EStatus_EArsiv; } set { _EStatus_EArsiv = value; } }

        public string EArchiveDeTrInstallMentNumber_EArsiv
        {
            get { return _EArchiveDeTrInstallMentNumber_EArsiv; }
            set { _EArchiveDeTrInstallMentNumber_EArsiv = value; }
        }

        public int EArchiveDeTrEArchiveStatus_EArsiv
        {
            get { return _EArchiveDeTrEArchiveStatus_EArsiv; }
            set { _EArchiveDeTrEArchiveStatus_EArsiv = value; }
        }

        public int EArchiveDeTrSendMod_EArsiv { get { return _EArchiveDeTrSendMod_EArsiv; } set { _EArchiveDeTrSendMod_EArsiv = value; } }

        public string EArchiveDeTrIntPaymentDesc_EArsiv
        {
            get { return _EArchiveDeTrIntPaymentDesc_EArsiv; }
            set { _EArchiveDeTrIntPaymentDesc_EArsiv = value; }
        }

        public string EArchiveDeTrIntPaymentAgent_EArsiv
        {
            get { return _EArchiveDeTrIntPaymentAgent_EArsiv; }
            set { _EArchiveDeTrIntPaymentAgent_EArsiv = value; }
        }

        public DateTime EArchiveDeTrIntPaymentDate_EArsiv
        {
            get { return _EArchiveDeTrIntPaymentDate_EArsiv; }
            set { _EArchiveDeTrIntPaymentDate_EArsiv = value; }
        }

        public int EArchiveDeTrInsteadOfDesp_EArsiv
        {
            get { return _EArchiveDeTrInsteadOfDesp_EArsiv; }
            set { _EArchiveDeTrInsteadOfDesp_EArsiv = value; }
        }

        public int EInsteadOfDispatch_EFatura { get { return _EInsteadOfDispatch_EFatura; } set { _EInsteadOfDispatch_EFatura = value; } }

        public DateTime EStartDate_EFatura { get { return _EStartDate_EFatura; } set { _EStartDate_EFatura = value; } }

        public DateTime EEndDate_EFatura { get { return _EEndDate_EFatura; } set { _EEndDate_EFatura = value; } }

        public string EDescription_EFatura { get { return _EDescription_EFatura; } set { _EDescription_EFatura = value; } }

        public int EDuration_EFatura { get { return _EDuration_EFatura; } set { _EDuration_EFatura = value; } }

        public List<TransactionLine> Lines { get { return _Lines; } set { _Lines = value; } }

        public List<ModelPaymentList.Payment> PaymentList { get { return _PaymentList; } set { _PaymentList = value; } }

        public string Number { get { return _Number; } set { _Number = value; } }

        public int Type { get { return _Type; } set { _Type = value; } }

        public int Id { get { return _Id; } set { _Id = value; } }

        public DateTime Date { get { return _Date; } set { _Date = value; } }

        public int Time { get { return _Time; } set { _Time = value; } }

        public string ArpCode { get { return _ArpCode; } set { _ArpCode = value; } }

        //public string ArpCodeShpm { get { return _ArpCodeShpm; } set { _ArpCodeShpm = value; } }

        public string GlCode { get { return _GlCode; } set { _GlCode = value; } }

        public DateTime DocDate { get { return _DocDate; } set { _DocDate = value; } }

        public string DocNumber { get { return _DocNumber; } set { _DocNumber = value; } }

        public string DocTrackNr { get; set; }

        public string Note1 { get { return _Note1; } set { _Note1 = value; } }

        public string Note2 { get { return _Note2; } set { _Note2 = value; } }

        public string Note3 { get { return _Note3; } set { _Note3 = value; } }

        public string Note4 { get { return _Note4; } set { _Note4 = value; } }

        public string OhpCode { get { return _OhpCode; } set { _OhpCode = value; } } // Masraf Merkezi Kodu

        //public string ProjectCode { get { return _ProjectCode; } set { _ProjectCode = value; } }

        public string AuxilCode { get { return _AuxilCode; } set { _AuxilCode = value; } }

        public string AuthCode { get { return _AuthCode; } set { _AuthCode = value; } }

        public string PaymentCode { get { return _PaymentCode; } set { _PaymentCode = value; } }

        public string SalesManCode { get { return _SalesManCode; } set { _SalesManCode = value; } }

        public string TradingGrp { get { return _TradingGrp; } set { _TradingGrp = value; } }

        public int SourceWh { get { return _SourceWh; } set { _SourceWh = value; } }

        public int SourceCostGrp { get { return _SourceCostGrp; } set { _SourceCostGrp = value; } }

        public int Division { get { return _Division; } set { _Division = value; } }

        public int Department { get { return _Department; } set { _Department = value; } }

        public int Factory { get { return _Factory; } set { _Factory = value; } }

        //public int VatIncludedGrs { get { return _VatIncludedGrs; } set { _VatIncludedGrs = value; } }

        public string VatExceptCode { get { return _VatExceptCode; } set { _VatExceptCode = value; } }

        public int ArkmanId { get { return _ArkmanId; } set { _ArkmanId = value; } }
    }
}