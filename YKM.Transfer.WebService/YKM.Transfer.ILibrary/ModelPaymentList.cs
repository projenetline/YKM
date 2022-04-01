using System;

// ReSharper disable ArrangeAccessorOwnerBody

namespace YKM.Transfer.ILibrary
{
    // ReSharper disable InconsistentNaming

    public class ModelPaymentList
    {
        public class Payment
        {
            private DateTime _Date { get; set; }
            private int _ModuleNr { get; set; }
            private int _TrCode { get; set; }
            private double _Total { get; set; }
            private DateTime _ProcDate { get; set; }
            private DateTime _DiscountDueDate { get; set; }
            private int _PayNo { get; set; }
            private int _Days { get; set; }

            public DateTime Date { get { return _Date; } set { _Date = value; } }

            public int ModuleNr { get { return _ModuleNr; } set { _ModuleNr = value; } }

            public int TrCode { get { return _TrCode; } set { _TrCode = value; } }

            public double Total { get { return _Total; } set { _Total = value; } }

            public DateTime ProcDate { get { return _ProcDate; } set { _ProcDate = value; } }

            public DateTime DiscountDueDate { get { return _DiscountDueDate; } set { _DiscountDueDate = value; } }

            public int PayNo { get { return _PayNo; } set { _PayNo = value; } }

            public int Days { get { return _Days; } set { _Days = value; } }
        }
    }
}