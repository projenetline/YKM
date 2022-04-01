using System;
using System.Web.Services;
using YKM.Transfer.ILibrary;
using System.Collections.Generic;

namespace YKM.Transfer.WebService
{
    /// <summary>
    /// Summary description for ykmWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class ykmWebService : System.Web.Services.WebService
    {
        private readonly Utility _utility = new Utility();

        private readonly DbManager dbManager = new DbManager();

        [WebMethod]
        public string Test()
        {
            return "Test Başarılı";
        }

        [WebMethod]
        public List<ModelResult> PostClCard(List<ModelClCard> clCardList, ModelUser user)
        {
            if (user.UserName != "arkman" || user.UserPassword != "x4347ybr")
            {
                LogHelper.Logger.Error($"Yetkisiz Giriş! Kullanıcı Adı: {user.UserName} Şifre: {user.UserPassword}");

                var loginResult = new ModelResult();

                loginResult.ErrorMessage.Add("Kullanıcı Adı ve Şifre Bilgilerinizi Kontrol Ediniz.");

                var loginResultList = new List<ModelResult> {loginResult};

                return loginResultList;
            }

            try
            {
                LogHelper.Logger.Info($"Cari Kart Aktarımına Başlanıyor. Aktarılacak Kayıt Sayısı: #{clCardList.Count}");

                dbManager.LogClCard(clCardList);

                LogHelper.Logger.Info("Gelen Cari Listesi Veri Tabanına Kayıt Edildi.");

                return _utility.PostHelper(clCardList);
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Info($"Cari Kart Aktarımı Sırasında Hata Oluştu. {ex} - {ex.Message}");

                var modelResult = new ModelResult();

                modelResult.ErrorMessage.Add(ex.Message);

                var modelResults = new List<ModelResult> {modelResult};

                return modelResults;
            }
        }

        [WebMethod]
        public List<ModelResult> PostInvoice(List<ModelInvoice> invoiceList, ModelUser user)
        {
            if (user.UserName != "arkman" || user.UserPassword != "x4347ybr")
            {
                LogHelper.Logger.Error($"Yetkisiz Giriş! Kullanıcı Adı: {user.UserName} Şifre: {user.UserPassword}");

                var loginResult = new ModelResult();

                loginResult.ErrorMessage.Add("Kullanıcı Adı ve Şifre Bilgilerinizi Kontrol Ediniz.");

                var loginResultList = new List<ModelResult> { loginResult };

                return loginResultList;
            }

            LogHelper.Logger.Info($"Fatura Aktarımına Başlanıyor. Aktarılacak Kayıt Sayısı: #{invoiceList.Count}");

            dbManager.LogInvoice(invoiceList);

            LogHelper.Logger.Info("Gelen Fatura Listesi Veri Tabanına Kayıt Edildi.");

            try
            {
                return _utility.PostHelper(invoiceList);
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Info($"Fatura Aktarımı Sırasında Hata Oluştu. {ex} - {ex.Message}");

                var modelResult = new ModelResult();

                modelResult.ErrorMessage.Add(ex.Message);

                var modelResults = new List<ModelResult> {modelResult};

                return modelResults;
            }
        }
    }
}