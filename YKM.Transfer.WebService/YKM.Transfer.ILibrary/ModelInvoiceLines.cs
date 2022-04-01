using System;
using System.Collections.Generic;

// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable InconsistentNaming

namespace YKM.Transfer.ILibrary
{
    public class TransactionLine
    {
        public TransactionLine()
        {
            PreeAccLines = new List<PreeAccLine>();
        }

        private int _Id { get; set; }
        private int _Type { get; set; }
        private string _MasterCode { get; set; }
        private double _Quantity { get; set; }
        private double _Price { get; set; }
        private string _Description { get; set; }
        private double _DiscountRate { get; set; }
        private int _VatIncluded { get; set; }
        private double _VatRate { get; set; }
        private double _VatAmount { get; set; }
        private double _VatBase { get; set; }
        private string _UnitCode { get; set; }
        private double _UnitConv1 { get; set; }
        private double _UnitConv2 { get; set; }
        private string _OhpCode1 { get; set; }
        private string _OhpCode2 { get; set; }
        private string _GlCode1 { get; set; }
        private string _GlCode2 { get; set; }
        private double _TotalNet { get; set; }
        private double _BaseAmount { get; set; }
        private double _Total { get; set; }
        private int _SourceIndex { get; set; }
        private string _PurchGlCode { get; set; }
        private string _AuxilCode { get; set; }

        public int Id { get { return _Id; } set { _Id = value; } }

        public int Type { get { return _Type; } set { _Type = value; } }

        public string MasterCode { get { return _MasterCode; } set { _MasterCode = value; } }

        public double Quantity { get { return _Quantity; } set { _Quantity = value; } }

        public double Price { get { return _Price; } set { _Price = value; } }

        public string Description { get { return _Description; } set { _Description = value; } }

        public double DiscountRate { get { return _DiscountRate; } set { _DiscountRate = value; } }

        public int VatIncluded { get { return _VatIncluded; } set { _VatIncluded = value; } }

        public double VatRate { get { return _VatRate; } set { _VatRate = value; } }

        public double VatAmount { get { return _VatAmount; } set { _VatAmount = value; } }

        public double VatBase { get { return _VatBase; } set { _VatBase = value; } }

        public string UnitCode { get { return _UnitCode; } set { _UnitCode = value; } }

        public double UnitConv1 { get { return _UnitConv1; } set { _UnitConv1 = value; } }

        public double UnitConv2 { get { return _UnitConv2; } set { _UnitConv2 = value; } }

        public string OhpCode1 { get { return _OhpCode1; } set { _OhpCode1 = value; } }

        public string OhpCode2 { get { return _OhpCode2; } set { _OhpCode2 = value; } }

        public string GlCode1 { get { return _GlCode1; } set { _GlCode1 = value; } }

        public string GlCode2 { get { return _GlCode2; } set { _GlCode2 = value; } }

        public double TotalNet { get { return _TotalNet; } set { _TotalNet = value; } }

        public double BaseAmount { get { return _BaseAmount; } set { _BaseAmount = value; } }

        public double Total { get { return _Total; } set { _Total = value; } }

        public List<PreeAccLine> PreeAccLines { get; set; }

        public int SourceIndex { get { return _SourceIndex; } set { _SourceIndex = value; } }

        public string PurchGlCode { get { return _PurchGlCode; } set { _PurchGlCode = value; } }

        public string AuxilCode { get { return _AuxilCode; } set { _AuxilCode = value; } }
    }

    //public class ModelPreeAccLines
    //{
    //    public List<PreeAccLine> AccLines { get; set; }

    //    public ModelPreeAccLines()
    //    {
    //        AccLines = new List<PreeAccLine>();
    //    }
    //}

    public class PreeAccLine
    {
        private int _LineNr { get; set; }
        private double _DistRate { get; set; }
        private DateTime _Date { get; set; }
        private int _TSign { get; set; }
        private int _ModuleNr { get; set; }
        private string _CenterCode { get; set; }

        public int LineNr { get { return _LineNr; } set { _LineNr = value; } }

        public double DistRate { get { return _DistRate; } set { _DistRate = value; } }

        public DateTime Date { get { return _Date; } set { _Date = value; } }

        public int TSign { get { return _TSign; } set { _TSign = value; } }

        public int ModuleNr { get { return _ModuleNr; } set { _ModuleNr = value; } }

        public string CenterCode { get { return _CenterCode; } set { _CenterCode = value; } }
    }
}