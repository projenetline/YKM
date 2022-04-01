using System.ComponentModel.DataAnnotations;

namespace YKM.Transfer.ILibrary
{
    public class MyValidators
    {
        public ValidationResult IsInvoiceValid(ModelInvoice invoice, ValidationContext context)
        {
            if (invoice.Type == 0)
                return AddValidateMessage(
                    "#" + invoice.ArkmanId +
                    " Arkman Id'li Fatura İçin Tip Belirtilmelidir.\nSatınalma Faturası: 1\nAlınan Hizmet Faturası: 4\nPerakende Satış:7\nToptan Satış:8\n",
                    "Type");

            if (string.IsNullOrWhiteSpace(invoice.Number))
                return AddValidateMessage(
                    "#" + invoice.ArkmanId + " Arkman Id'li Fatura İçin Fatura Numarası Belirtilmelidir.", "Number");

            if (string.IsNullOrWhiteSpace(invoice.ArpCode))
            {
                return AddValidateMessage(
                    "#" + invoice.ArkmanId + " Arkman Id'li Fatura İçin Cari Kod Belirtilmelidir.", "ArpCode");
            }

            if (invoice.Lines.Count == 0)
            {
                return AddValidateMessage("#" + invoice.ArkmanId + " Arkman Id'li Faturaya Ait Satır Bulunamadı",
                    "Lines");
            }

            var lineCount = 1;

            foreach (var line in invoice.Lines)
            {
                if ((line.Type == 0 || line.Type == 4) && string.IsNullOrEmpty(line.MasterCode))
                    return AddValidateMessage(
                        "#" + invoice.ArkmanId + " Id'li Fatura İçin " + lineCount +
                        " No'lu Satır da Ürün/Hizmet Kodu Belirtilmelidir.\n(Satır Sayısı 1'den Başlatılarak Hesaplanmıştır.)",
                        "Line.MasterCode");

                lineCount += 1;
            }

            return ValidationResult.Success;
        }

        public ValidationResult IsClCardValid(ModelClCard clCard, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(clCard.Code))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin Kod Belirtilmelidir.",
                    "Code");
            }

            if (string.IsNullOrWhiteSpace(clCard.Title))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin Ünvan Belirtilmelidir.",
                    "Title");
            }

            if (string.IsNullOrWhiteSpace(clCard.Address1))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin Adres Belirtilmelidir.",
                    "Address1");
            }

            if (string.IsNullOrWhiteSpace(clCard.City))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin İl Belirtilmelidir.",
                    "City");
            }

            if (string.IsNullOrWhiteSpace(clCard.Town))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin İlçe Belirtilmelidir.",
                    "Town");
            }

            if (string.IsNullOrWhiteSpace(clCard.Country))
            {
                return AddValidateMessage("#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin Ülke Belirtilmelidir.",
                    "Country");
            }

            if (string.IsNullOrWhiteSpace(clCard.TCKNO) && string.IsNullOrEmpty(clCard.TaxId))
            {
                return AddValidateMessage(
                    "#" + clCard.ArkmanId +
                    " Arkman Id'li Cari Kart İçin TC Kimlik No veya Vergi Numarası Belirtilmelidir.", "TCKNO, TaxId");
            }

            if (string.IsNullOrWhiteSpace(clCard.TaxOffice))
            {
                return AddValidateMessage(
                    "#" + clCard.ArkmanId + " Arkman Id'li Cari Kart İçin Vergi Dairesi Belirtilmelidir.", "TaxOffice");
            }

            return ValidationResult.Success;
        }

        public ValidationResult AddValidateMessage(string message, string field)
        {
            return new ValidationResult(message, new[] {field});
        }
    }
}