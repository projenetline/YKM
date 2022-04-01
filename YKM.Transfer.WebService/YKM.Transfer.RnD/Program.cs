using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YKM.Transfer.RnD.ykmService;

namespace YKM.Transfer.RnD
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ykmService.ykmWebServiceSoapClient();
            TestService(client);
            PostCliet(client);

        }

        private static void PostCliet(ykmService.ykmWebServiceSoapClient client)
        {
            var clCard = new ykmService.ModelClCard()
            {
                Address1 = "Deneme Adres 1",
                Address2 = "Deneme Adres 2",
                ArkmanId = 1,
                AuxilCode = "TEST",
                AuxilCode2 = "TEST",
                AuxilCode3 = "TEST",
                AuxilCode4 = "TEST",
                AuxilCode5 = "TEST",
                City = "İSTANBUL",
                CityCode = "34",
                Code = "DENEME001",
                Contact = "BURAK DOĞAN",
                Contact2 = "",
                Contact3 = "",
                Country = "TÜRKİYE",
                CountryCode = "TR",
                EMail = "burak.dogan@netline.net.tr",
                EMail2 = "",
                EMail3 = "",
                ExpBrws = 1,
                Fax = "",
                FaxCode = "",
                FinBrws = 1,
                GlCode = "",
                ImpBrws = 1,
                OhpCode = "",
                PersCompany = 1,
                PostalCode = "",
                PurchBrws = 1,
                SalesBrws = 1,
                TaxId = "",
                TCKNO = "12345678901",
                TaxOffice = "TEST",
                Telephone1 = "",
                Telephone1Code = "",
                Telephone2 = "",
                Telephone2Code = "",
                Title = "DENEME CARİSİ",
                Id = 1,
                Title2 = "",
                Town = "ŞİŞLİ",
                TradingGrp = "",
                WebUrl = "www.netline.net.tr"
            };

            var list = new List<ModelClCard>();
            list.Add(clCard);

            var result = client.PostClCard(list.ToArray(), new ModelUser() { UserName = "arkman", UserPassword = "x4347ybr" });

            Console.WriteLine($"Cari Kart Aktarım Sonucu:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Id       : " + result[i].Id);
                Console.WriteLine("Arkman Id:" + result[i].ArkmanId);
                foreach (var item in result[i].ErrorMessage)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------------------------");
            }
            Console.ReadKey();
        }

        private static void TestService(ykmService.ykmWebServiceSoapClient client)
        {
            var a = client.Test();
            Console.WriteLine(a);
            Console.WriteLine("---------------------------");
        }
    }
}
