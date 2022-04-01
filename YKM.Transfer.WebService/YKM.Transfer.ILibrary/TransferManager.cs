using System;
using UnityObjects;

namespace YKM.Transfer.ILibrary
{
    // ReSharper disable UseNullPropagation

    public class TransferManager
    {
        private static bool _loginLock;

        public TransferManager()
        {
            if (_loginLock == false)
            {
                var logoUserName = ConfigHelper.Get<string>("LogoUserName");
                var logoUserPass = ConfigHelper.Get<string>("LogoUserPassword");
                var logoFirmNumber = ConfigHelper.Get<int>("LogoFirmNumber");
                var logoFirmPeriod = ConfigHelper.Get<int>("LogoFirmPeriod");

                if (!UnityManager.LogIn(logoUserName, logoUserPass, logoFirmNumber, logoFirmPeriod))
                {
                    LogHelper.Logger.Info("Logo Girişi Yapılırken Hata Oluştu.");
                }
                else
                {
                    LogHelper.Logger.Info("Logo Girişi Başarılı");
                }

                _loginLock = true;
            }
        }

        public ModelResult PostGlAccount(ModelClCard clCard)
        {
            var data = UnityManager._UnityApplication.NewDataObject(DataObjectType.doGLAccount);

            data.New();

            data.DataFields.FieldByName("CODE").Value = clCard.Code;
            data.DataFields.FieldByName("DESCRIPTION").Value = clCard.Title;
            data.DataFields.FieldByName("ACCOUNT_TYPE").Value = 2;

            return Post(data, clCard.ArkmanId);
        }

        public ModelResult PostClCard(ModelClCard clCard)
        {
            //var resultModelGlAccount = PostGlAccount(clCard);

            //if (resultModelGlAccount.ErrorMessage.Count > 0)
            //    return resultModelGlAccount;

            var data = UnityManager._UnityApplication.NewDataObject(DataObjectType.doAccountsRP);

            data.New();

            data.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
            data.DataFields.FieldByName("CODE").Value = clCard.Code;

            //data.DataFields.FieldByName("GL_CODE").Value = clCard.GlCode;
            data.DataFields.FieldByName("TITLE").Value = clCard.Title;
            data.DataFields.FieldByName("TITLE2").Value = clCard.Title2;
            data.DataFields.FieldByName("AUXIL_CODE").Value = clCard.AuxilCode;
            data.DataFields.FieldByName("AUXIL_CODE2").Value = clCard.AuxilCode2;
            data.DataFields.FieldByName("AUXIL_CODE3").Value = clCard.AuxilCode3;
            data.DataFields.FieldByName("AUXIL_CODE4").Value = clCard.AuxilCode4;
            data.DataFields.FieldByName("AUXIL_CODE5").Value = clCard.AuxilCode5;
            data.DataFields.FieldByName("AUTH_CODE").Value = clCard.OhpCode;
            data.DataFields.FieldByName("ADDRESS1").Value = clCard.Address1;
            data.DataFields.FieldByName("ADDRESS2").Value = clCard.Address2;

            //data.DataFields.FieldByName("CITY_CODE").Value = clCard.AccountType;
            data.DataFields.FieldByName("CITY").Value = clCard.City;

            //data.DataFields.FieldByName("CITY_CODE").Value = clCard.CityCode;
            data.DataFields.FieldByName("TOWN").Value = clCard.Town;
            data.DataFields.FieldByName("COUNTRY").Value = clCard.Country;

            //data.DataFields.FieldByName("COUNTRY_CODE").Value = clCard.CountryCode;
            data.DataFields.FieldByName("POSTAL_CODE").Value = clCard.PostalCode;
            data.DataFields.FieldByName("TELEPHONE1").Value = clCard.Telephone1;
            data.DataFields.FieldByName("TELEPHONE1_CODE").Value = clCard.Telephone1Code;
            data.DataFields.FieldByName("TELEPHONE2").Value = clCard.Telephone2;
            data.DataFields.FieldByName("TELEPHONE2_CODE").Value = clCard.Telephone2Code;
            data.DataFields.FieldByName("FAX").Value = clCard.Fax;
            data.DataFields.FieldByName("FAX_CODE").Value = clCard.FaxCode;
            data.DataFields.FieldByName("TAX_OFFICE").Value = clCard.TaxOffice;
            data.DataFields.FieldByName("E_MAIL").Value = clCard.EMail;
            data.DataFields.FieldByName("E_MAIL2").Value = clCard.EMail2;
            data.DataFields.FieldByName("E_MAIL3").Value = clCard.EMail3;
            data.DataFields.FieldByName("WEB_URL").Value = clCard.WebUrl;
            data.DataFields.FieldByName("CONTACT").Value = clCard.Contact;
            data.DataFields.FieldByName("CONTACT2").Value = clCard.Contact2;
            data.DataFields.FieldByName("CONTACT3").Value = clCard.Contact3;
            data.DataFields.FieldByName("PURCHBRWS").Value = 1;
            data.DataFields.FieldByName("SALESBRWS").Value = 1;
            data.DataFields.FieldByName("IMPBRWS").Value = 1;
            data.DataFields.FieldByName("EXPBRWS").Value = 1;
            data.DataFields.FieldByName("FINBRWS").Value = 1;
            data.DataFields.FieldByName("TRADING_GRP").Value = clCard.TradingGrp;

            if (clCard.TCKNO != "")
            {
                data.DataFields.FieldByName("TCKNO").Value = clCard.TCKNO;
                clCard.PersCompany = 1;
            }
            else
            {
                data.DataFields.FieldByName("TAX_ID").Value = clCard.TaxId;
                clCard.PersCompany = 1;
            }

            var result = Post(data, clCard.ArkmanId);

            if (result.ErrorMessage.Count == 0)
            {
                LogHelper.Logger.Info($"Cari Aktarıldı. LOGICALREF: #{result.Id} ArkmanId: #{result.ArkmanId}");
            }
            else
            {
                foreach (var error in result.ErrorMessage)
                {
                    LogHelper.Logger.Info($"Cari Aktarılırken Hata Oluştu. ArkmanId: #{result.ArkmanId}\n{error}");
                }
            }

            return result;
        }

        public ModelResult PostInvoice(ModelInvoice invoice)
        {
            Data data;

            if (invoice.Type == 7 ||
                invoice.Type == 8 ||
                invoice.Type == 3 ||
                invoice.Type == 2 ||
                invoice.Type == 9 ||
                invoice.Type == 10 ||
                invoice.Type == 14)
            {
                data = UnityManager._UnityApplication.NewDataObject(DataObjectType.doSalesInvoice);
            }
            else if (invoice.Type == 1 || invoice.Type == 4 || invoice.Type == 5 || invoice.Type == 6 || invoice.Type == 13 || invoice.Type == 26)
            {
                data = UnityManager._UnityApplication.NewDataObject(DataObjectType.doPurchInvoice);
            }
            else
            {
                var modelResult = new ModelResult
                {
                    Id = -1,
                    ArkmanId = invoice.ArkmanId
                };

                modelResult.ErrorMessage.Add("Fatura Tipi Belirtilenlerin Dışında. Tanımlama Yapılması Gerekiyor.");

                return modelResult;
            }

            data.New();

            data.DataFields.FieldByName("TYPE").Value = invoice.Type;

            data.DataFields.FieldByName("NUMBER").Value = invoice.Number;
            data.DataFields.FieldByName("DATE").Value = invoice.Date;

            data.DataFields.FieldByName("DOC_NUMBER").Value = invoice.DocNumber;
            data.DataFields.FieldByName("DOC_DATE").Value = invoice.DocDate;

            data.DataFields.FieldByName("ARP_CODE").Value = invoice.ArpCode;

            //data.DataFields.FieldByName("ARP_CODE_SHPM").Value = invoice.ArpCodeShpm;
            data.DataFields.FieldByName("NOTES1").Value = invoice.Note1;
            data.DataFields.FieldByName("NOTES2").Value = invoice.Note2;
            data.DataFields.FieldByName("NOTES3").Value = invoice.Note3;
            data.DataFields.FieldByName("NOTES4").Value = invoice.Note4;

            data.DataFields.FieldByName("EINVOICE").Value = invoice.EInvoice;
            data.DataFields.FieldByName("OHP_CODE").Value = invoice.OhpCode;

            //data.DataFields.FieldByName("PROJECT_CODE").Value = invoice.ProjectCode;
            data.DataFields.FieldByName("AUXIL_CODE").Value = invoice.AuxilCode;
            data.DataFields.FieldByName("AUTH_CODE").Value = invoice.AuthCode;
            data.DataFields.FieldByName("GL_CODE").Value = invoice.GlCode;
            data.DataFields.FieldByName("SOURCE_WH").Value = invoice.SourceWh;
            data.DataFields.FieldByName("SOURCE_COST_GRP").Value = invoice.SourceWh;
            data.DataFields.FieldByName("PAYMENT_CODE").Value = invoice.PaymentCode;
            data.DataFields.FieldByName("DIVISION").Value = invoice.Division;
            data.DataFields.FieldByName("DEPARTMENT").Value = invoice.Department;
            data.DataFields.FieldByName("TRADING_GRP").Value = invoice.TradingGrp;
            data.DataFields.FieldByName("FACTORY").Value = invoice.Factory;

            //data.DataFields.FieldByName("VAT_INCLUDED_GRS").Value = invoice.VatIncludedGrs;
            data.DataFields.FieldByName("SALESMAN_CODE").Value = invoice.SalesManCode;
            data.DataFields.FieldByName("VATEXCEPT_CODE").Value = invoice.VatExceptCode;

            data.DataFields.FieldByName("EINVOICE_TYPE").Value = invoice.EInvoiceType;
            data.DataFields.FieldByName("EINVOICE").Value = invoice.EInvoice;
            data.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTTYPE").Value = invoice.EArchiveDeTrIntPaymentType;
            data.DataFields.FieldByName("EDURATION_TYPE").Value = invoice.EDurationType;

            if (invoice.EInvoice == 1) // E-Fatura
            {
                data.DataFields.FieldByName("EINSTEAD_OF_DISPATCH").Value = invoice.EInsteadOfDispatch_EFatura;
                data.DataFields.FieldByName("ESTARTDATE").Value = invoice.EStartDate_EFatura;
                data.DataFields.FieldByName("EENDDATE").Value = invoice.EEndDate_EFatura;
                data.DataFields.FieldByName("EDESCRIPTION").Value = invoice.EDescription_EFatura;
                data.DataFields.FieldByName("EDURATION").Value = invoice.EDuration_EFatura;
            }
            else if (invoice.EInvoice == 2) // E-Arşiv
            {
                data.DataFields.FieldByName("ESTATUS").Value = invoice.EStatus_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_INSTALLMENTNUMBER").Value =
                    invoice.EArchiveDeTrInstallMentNumber_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_EARCHIVESTATUS").Value =
                    invoice.EArchiveDeTrEArchiveStatus_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_SENDMOD").Value = invoice.EArchiveDeTrSendMod_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTDESC").Value =
                    invoice.EArchiveDeTrIntPaymentDesc_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTAGENT").Value =
                    invoice.EArchiveDeTrIntPaymentAgent_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTDATE").Value =
                    invoice.EArchiveDeTrIntPaymentDate_EArsiv;
                data.DataFields.FieldByName("EARCHIVEDETR_INSTEADOFDESP").Value =
                    invoice.EArchiveDeTrInsteadOfDesp_EArsiv;
            }

            var date = Convert.ToDateTime(invoice.Date);

            object time = null;
            UnityManager._UnityApplication.PackTime(date.Hour, date.Minute, date.Second, ref time);
            int ofTime = 0;
            int.TryParse(time.ToString(), out ofTime);

            data.DataFields.FieldByName("TIME").Value = time;

            var dataLines = data.DataFields.FieldByName("TRANSACTIONS").Lines;

            foreach (var line in invoice.Lines)
            {
                if (line.Type == 0 || line.Type == 4)
                {
                    dataLines.AppendLine();

                    dataLines[dataLines.Count - 1].FieldByName("TYPE").Value = line.Type;
                    dataLines[dataLines.Count - 1].FieldByName("MASTER_CODE").Value = line.MasterCode;
                    dataLines[dataLines.Count - 1].FieldByName("DESCRIPTION").Value = line.Description;
                    dataLines[dataLines.Count - 1].FieldByName("VAT_RATE").Value = line.VatRate;
                    dataLines[dataLines.Count - 1].FieldByName("VAT_AMOUNT").Value = line.VatAmount;
                    dataLines[dataLines.Count - 1].FieldByName("VAT_BASE").Value = line.VatBase;
                    dataLines[dataLines.Count - 1].FieldByName("VAT_INCLUDED").Value = line.VatIncluded;
                    dataLines[dataLines.Count - 1].FieldByName("DISCOUNT_RATE").Value = line.DiscountRate;
                    dataLines[dataLines.Count - 1].FieldByName("QUANTITY").Value = line.Quantity;
                    dataLines[dataLines.Count - 1].FieldByName("PRICE").Value = line.Price;
                    dataLines[dataLines.Count - 1].FieldByName("TOTAL").Value = line.Total;
                    dataLines[dataLines.Count - 1].FieldByName("TOTAL_NET").Value = line.TotalNet;
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CODE").Value = line.UnitCode;
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UnitConv1;
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UnitConv2;
                    dataLines[dataLines.Count - 1].FieldByName("OHP_CODE1").Value = line.OhpCode1;
                    dataLines[dataLines.Count - 1].FieldByName("OHP_CODE2").Value = line.OhpCode2;
                    dataLines[dataLines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SourceIndex;
                    dataLines[dataLines.Count - 1].FieldByName("GL_CODE1").Value = line.GlCode1;
                    dataLines[dataLines.Count - 1].FieldByName("GL_CODE2").Value = line.GlCode2;
                    dataLines[dataLines.Count - 1].FieldByName("PURCH_GL_CODE").Value = line.PurchGlCode;
                    dataLines[dataLines.Count - 1].FieldByName("AUXIL_CODE").Value = line.AuxilCode;

                    if (line.PreeAccLines.Count > 0)
                    {
                        var dataAccLines = data.DataFields.FieldByName("TRANSACTIONS.PREACCLINES").Lines;

                        foreach (var preeAccLine in line.PreeAccLines)
                        {
                            dataAccLines.AppendLine();
                            dataAccLines[dataAccLines.Count - 1].FieldByName("LINENR").Value = preeAccLine.LineNr;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("DISTRATE").Value =
                                preeAccLine.DistRate;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("TSIGN").Value = preeAccLine.TSign;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("MODULNR").Value =
                                preeAccLine.ModuleNr;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("CENTERCODE").Value =
                                preeAccLine.CenterCode;
                        }
                    }
                }
                else if (line.Type == 2)
                {
                    dataLines.AppendLine();

                    dataLines[dataLines.Count - 1].FieldByName("TYPE").Value = line.Type;
                    dataLines[dataLines.Count - 1].FieldByName("MASTER_CODE").Value = "";
                    dataLines[dataLines.Count - 1].FieldByName("DISCOUNT_RATE").Value = line.DiscountRate;
                    dataLines[dataLines.Count - 1].FieldByName("QUANTITY").Value = 0;
                    dataLines[dataLines.Count - 1].FieldByName("TOTAL").Value = line.Total;
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CODE").Value = "";
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CONV1").Value = 0;
                    dataLines[dataLines.Count - 1].FieldByName("UNIT_CONV2").Value = 0;
                    dataLines[dataLines.Count - 1].FieldByName("OHP_CODE1").Value = line.OhpCode1;
                    dataLines[dataLines.Count - 1].FieldByName("OHP_CODE2").Value = line.OhpCode2;
                    dataLines[dataLines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SourceIndex;
                    dataLines[dataLines.Count - 1].FieldByName("GL_CODE1").Value = line.GlCode1;
                    dataLines[dataLines.Count - 1].FieldByName("GL_CODE2").Value = line.GlCode2;
                    dataLines[dataLines.Count - 1].FieldByName("PURCH_GL_CODE").Value = line.PurchGlCode;
                    dataLines[dataLines.Count - 1].FieldByName("AUXIL_CODE").Value = line.AuxilCode;

                    if (line.PreeAccLines.Count > 0)
                    {
                        var dataAccLines = data.DataFields.FieldByName("TRANSACTIONS.PREACCLINES").Lines;

                        foreach (var preeAccLine in line.PreeAccLines)
                        {
                            dataAccLines.AppendLine();
                            dataAccLines[dataAccLines.Count - 1].FieldByName("LINENR").Value = preeAccLine.LineNr;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("DISTRATE").Value =
                                preeAccLine.DistRate;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("TSIGN").Value = preeAccLine.TSign;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("MODULNR").Value =
                                preeAccLine.ModuleNr;
                            dataAccLines[dataAccLines.Count - 1].FieldByName("CENTERCODE").Value =
                                preeAccLine.CenterCode;
                        }
                    }
                }

                //dataLines[dataLines.Count - 1].FieldByName("PROJECT_CODE").Value = invoice.ProjectCode;
            }

            var dataPaymentLines = data.DataFields.FieldByName("PAYMENT_LIST").Lines;

            if (invoice.PaymentList.Count > 0)
            {
                foreach (var payment in invoice.PaymentList)
                {
                    dataPaymentLines.AppendLine();
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("DATE").Value = payment.Date;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("MODULENR").Value = payment.ModuleNr;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("TRCODE").Value = payment.TrCode;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("TOTAL").Value = payment.Total;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("DAYS").Value = payment.Days;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("PROCDATE").Value = payment.ProcDate;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("DISCOUNT_DUEDATE").Value =
                        payment.DiscountDueDate;
                    dataPaymentLines[dataPaymentLines.Count - 1].FieldByName("PAY_NO").Value = payment.PayNo;
                }
            }

            data.FillAccCodes();

            var result = Post(data, invoice.ArkmanId);

            if (result.ErrorMessage.Count == 0)
            {
                LogHelper.Logger.Info($"Fatura Aktarıldı. LOGICALREF: #{result.Id} ArkmanId: #{result.ArkmanId}");
            }
            else
            {
                foreach (var error in result.ErrorMessage)
                {
                    LogHelper.Logger.Info($"Fatura Aktarılırken Hata Oluştu. ArkmanId: #{result.ArkmanId}\n{error}");
                }
            }

            return result;
        }

        public ModelResult Post(Data data, int arkmanId)
        {
            var resultModel = new ModelResult();

            if (data.Post())
            {
                resultModel.Id = (int) data.DataFields.FieldByName("INTERNAL_REFERENCE").Value;
                resultModel.ArkmanId = arkmanId;
            }
            else
            {
                resultModel.Id = -1;
                resultModel.ArkmanId = arkmanId;

                if (data.ErrorCode != 0)
                    resultModel.ErrorMessage.Add("[" + data.ErrorCode + "] " + data.ErrorDesc + " " + data.DBErrorDesc);

                for (int i = 0; i < data.ValidateErrors.Count; i++)
                    resultModel.ErrorMessage.Add(
                        "XML ErrorList: (" +
                        data.ValidateErrors[i].ID +
                        ") - " +
                        data.ValidateErrors[i].Error);
            }

            return resultModel;
        }
    }
}