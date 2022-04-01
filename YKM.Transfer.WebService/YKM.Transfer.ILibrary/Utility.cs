using System.Collections.Generic;

// ReSharper disable PossibleNullReferenceException

namespace YKM.Transfer.ILibrary
{
    public class Utility
    {
        private static TransferManager _transferManager;
        private static DbManager dbManager;

        public List<ModelResult> PostHelper<T>(List<T> modelList) where T : class
        {
            if (_transferManager == null)
                _transferManager = new TransferManager();

            if (dbManager == null)
                dbManager = new DbManager();

            var modelResultList = new List<ModelResult>();

            var myValidators = new MyValidators();

            foreach (var model in modelList)
            {
                var modelResult = new ModelResult();

                if (model.GetType() == typeof(ModelInvoice))
                {
                    var invoice = model as ModelInvoice;
                    modelResult.ArkmanId = invoice.ArkmanId;

                    var entId = dbManager.ControlInvoice(invoice.ArkmanId);

                    if (entId > 0)
                    {
                        modelResult.ErrorMessage.Add($"Fatura Daha Önce Aktarılmış. Arkman Id: #{invoice.ArkmanId} EntId: #{entId}");

                        LogHelper.Logger.Info($"Fatura Daha Önce Aktarılmış. Arkman Id: #{invoice.ArkmanId} EntId: #{entId}");

                        modelResult.Id = entId;

                        modelResultList.Add(modelResult);

                        continue;
                    }

                    var validationResult = myValidators.IsInvoiceValid(model as ModelInvoice, null);

                    if (validationResult != null)
                    {
                        foreach (var validationResultMemberName in validationResult.MemberNames)
                        {
                            LogHelper.Logger.Info(
                                "Fatura Aktarılırken Doğrulama Hatası Oluştu. İlgili Alan Adı: " +
                                validationResultMemberName +
                                $"\nsadas{validationResult.ErrorMessage}");

                            modelResult.ErrorMessage.Add("İlgili Alan Adı: " + validationResultMemberName);
                        }

                        modelResult.ErrorMessage.Add(validationResult.ErrorMessage);

                        modelResultList.Add(modelResult);

                        dbManager.LogInvoiceResult(modelResult);

                        continue;
                    }

                    var result = _transferManager.PostInvoice(model as ModelInvoice);

                    dbManager.LogInvoiceResult(result);

                    modelResultList.Add(result);
                }
                else if (model.GetType() == typeof(ModelClCard))
                {
                    var clCard = model as ModelClCard;
                    modelResult.ArkmanId = clCard.ArkmanId;

                    var entId = dbManager.ControlClCard(clCard.ArkmanId);

                    if (entId > 0)
                    {
                        modelResult.ErrorMessage.Add($"Cari Daha Önce Aktarılmış. Arkman Id: #{clCard.ArkmanId} EntId: #{entId}");

                        LogHelper.Logger.Info($"Cari Daha Önce Aktarılmış. Arkman Id: #{clCard.ArkmanId} EntId: #{entId}");

                        modelResult.Id = entId;

                        modelResultList.Add(modelResult);

                        continue;
                    }

                    var validationResult = myValidators.IsClCardValid(model as ModelClCard, null);

                    if (validationResult != null)
                    {
                        foreach (var validationResultMemberName in validationResult.MemberNames)
                        {
                            LogHelper.Logger.Info(
                                "Cari Aktarılırken Doğrulama Hatası Oluştu. İlgili Alan Adı: " +
                                validationResultMemberName +
                                $"\n{validationResult.ErrorMessage}");

                            modelResult.ErrorMessage.Add("İlgili Alan Adı: " + validationResultMemberName);
                        }

                        modelResult.ErrorMessage.Add(validationResult.ErrorMessage);

                        modelResultList.Add(modelResult);

                        dbManager.LogClCardResult(modelResult);

                        continue;
                    }

                    var result = _transferManager.PostClCard(model as ModelClCard);

                    dbManager.LogClCardResult(result);

                    modelResultList.Add(result);
                }
            }

            return modelResultList;
        }
    }
}