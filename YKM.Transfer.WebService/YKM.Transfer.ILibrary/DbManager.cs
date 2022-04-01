using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Dapper;

// ReSharper disable SpecifyACultureInStringConversionExplicitly
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace YKM.Transfer.ILibrary
{
    public class DbManager
    {
        private readonly string _connectionString;
        System.Globalization.CultureInfo cultureInfo = new CultureInfo("tr-TR");
        private const string HashMap = "n€tL!n@";

        public DbManager()
        {
            _connectionString = CryptHelper.Decrypt(ConfigHelper.Get<string>("ConnectionString"), HashMap);
            //_connectionString = ConfigHelper.Get<string>("ConnectionString");

            //_connectionString = ConfigHelper.Get<string>("ConnectionString");
            //_connectionString = @"Server=DESKTOP-G6TSHAR\BURAK;Database=TIGER;User Id=sa;Password=net_123;";
        }

        public void LogInvoice(List<ModelInvoice> invoiceList)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                foreach (var invoice in invoiceList)
                {
                    invoice.Date = DateTime.Parse(invoice.Date.ToString(), cultureInfo);
                    invoice.DocDate = DateTime.Parse(invoice.DocDate.ToString(), cultureInfo);
                    invoice.EArchiveDeTrIntPaymentDate_EArsiv = DateTime.Parse(invoice.EArchiveDeTrIntPaymentDate_EArsiv.ToString(), cultureInfo);
                    invoice.EStartDate_EFatura = DateTime.Parse(invoice.EStartDate_EFatura.ToString(), cultureInfo);
                    invoice.EEndDate_EFatura = DateTime.Parse(invoice.EEndDate_EFatura.ToString(), cultureInfo);

                    string docDate;
                    string eArchiveDeTrIntPaymentDateEArsiv;
                    string eStartDateEFatura;
                    string eEndDateEFatura;

                    var date = invoice.Date.ToString("yyyy-MM-dd HH:mm:ss");

                    if (invoice.DocDate.ToString() == "1.01.0001 00:00:00" || invoice.DocDate.ToString() == "0001-01-01 00:00:00")
                        docDate = "1900-01-01";
                    else
                        docDate = invoice.DocDate.ToString("yyyy-MM-dd HH:mm:ss");

                    if (invoice.EArchiveDeTrIntPaymentDate_EArsiv.ToString() == "1.01.0001 00:00:00" ||
                        invoice.EArchiveDeTrIntPaymentDate_EArsiv.ToString() == "0001-01-01 00:00:00")
                        eArchiveDeTrIntPaymentDateEArsiv = "1900-01-01";
                    else
                        eArchiveDeTrIntPaymentDateEArsiv = invoice.DocDate.ToString("yyyy-MM-dd HH:mm:ss");

                    if (invoice.EStartDate_EFatura.ToString() == "1.01.0001 00:00:00" ||
                        invoice.EStartDate_EFatura.ToString() == "0001-01-01 00:00:00")
                        eStartDateEFatura = "1900-01-01";
                    else
                        eStartDateEFatura = invoice.DocDate.ToString("yyyy-MM-dd HH:mm:ss");

                    if (invoice.EEndDate_EFatura.ToString() == "1.01.0001 00:00:00" || invoice.EEndDate_EFatura.ToString() == "0001-01-01 00:00:00")
                        eEndDateEFatura = "1900-01-01";
                    else
                        eEndDateEFatura = invoice.DocDate.ToString("yyyy-MM-dd HH:mm:ss");

                    #region Query

                    var clearQuery = $@"
DELETE  FROM dbo.Net_Log_Invoice
WHERE   ArkmanId = {invoice.ArkmanId} AND EntId = 0";

                    sqlConnection.Execute(clearQuery);

                    var insertQuery = $@"
INSERT INTO dbo.Net_Log_Invoice
        ( ArkmanId ,
          Id ,
          Type ,
          Number ,
          Date ,
          Time ,
          ArpCode ,
          GlCode ,
          DocDate ,
          DocNumber ,
          DocTrackNr ,
          Note1 ,
          Note2 ,
          Note3 ,
          Note4 ,
          OhpCode ,
          AuxilCode ,
          AuthCode ,
          PaymentCode ,
          SalesManCode ,
          TradingGrp ,
          SourceWh ,
          SourceCostGrp ,
          Division ,
          Department ,
          Factory ,
          VatExceptCode ,
          EInvoiceType ,
          EInvoice ,
          EArchiveDeTrIntPaymentType ,
          EDurationType ,
          EStatus_EArsiv ,
          EArchiveDeTrInstallMentNumber_EArsiv ,
          EArchiveDeTrEArchiveStatus_EArsiv ,
          EArchiveDeTrSendMod_EArsiv ,
          EArchiveDeTrIntPaymentDesc_EArsiv ,
          EArchiveDeTrIntPaymentAgent_EArsiv ,
          EArchiveDeTrIntPaymentDate_EArsiv ,
          EArchiveDeTrInsteadOfDesp_EArsiv ,
          EInsteadOfDispatch_EFatura ,
          EStartDate_EFatura ,
          EEndDate_EFatura ,
          EDescription_EFatura ,
          EDuration_EFatura
        )
VALUES  ( {invoice.ArkmanId} , -- ArkmanId - int
          {invoice.Id} , -- Id - int
          {invoice.Type} , -- Type - int
          N'{invoice.Number}' , -- Number - nvarchar(50)
          '{date}' , -- Date - datetime
          {invoice.Time} , -- Time - int
          N'{invoice.ArpCode}' , -- ArpCode - nvarchar(50)
          N'{invoice.GlCode}' , -- GlCode - nvarchar(50)
          CASE WHEN '{docDate}' = '0001-01-01 00:00:00' OR '{docDate}' = '1.01.0001 00:00:00' THEN NULL ELSE '{docDate}' END , -- DocDate - datetime
          N'{invoice.DocNumber}' , -- DocNumber - nvarchar(50)
          N'{invoice.DocTrackNr}' , -- DocTrackNr - nvarchar(50)
          N'{invoice.Note1}' , -- Note1 - nvarchar(250)
          N'{invoice.Note2}' , -- Note2 - nvarchar(250)
          N'{invoice.Note3}' , -- Note3 - nvarchar(250)
          N'{invoice.Note4}' , -- Note4 - nvarchar(250)
          N'{invoice.OhpCode}' , -- OhpCode - nvarchar(50)
          N'{invoice.AuxilCode}' , -- AuxilCode - nvarchar(50)
          N'{invoice.AuthCode}' , -- AuthCode - nvarchar(50)
          N'{invoice.PaymentCode}' , -- PaymentCode - nvarchar(50)
          N'{invoice.SalesManCode}' , -- SalesManCode - nvarchar(50)
          N'{invoice.TradingGrp}' , -- TradingGrp - nvarchar(50)
          {invoice.SourceWh} , -- SourceWh - int
          {invoice.SourceCostGrp} , -- SourceCostGrp - int
          {invoice.Division} , -- Division - int
          {invoice.Department} , -- Department - int
          {invoice.Factory} , -- Factory - int
          N'{invoice.VatExceptCode}' , -- VatExceptCode - nvarchar(50)
          {invoice.EInvoiceType} , -- EInvoiceType - int
          {invoice.EInvoice} , -- EInvoice - int
          {invoice.EArchiveDeTrIntPaymentType} , -- EArchiveDeTrIntPaymentType - int
          {invoice.EDurationType} , -- EDurationType - int
          {invoice.EStatus_EArsiv} , -- EStatus_EArsiv - int
          N'{invoice.EArchiveDeTrInstallMentNumber_EArsiv}' , -- EArchiveDeTrInstallMentNumber_EArsiv - nvarchar(250)
          {invoice.EArchiveDeTrEArchiveStatus_EArsiv} , -- EArchiveDeTrEArchiveStatus_EArsiv - int
          {invoice.EArchiveDeTrSendMod_EArsiv} , -- EArchiveDeTrSendMod_EArsiv - int
          N'{invoice.EArchiveDeTrIntPaymentDesc_EArsiv}' , -- EArchiveDeTrIntPaymentDesc_EArsiv - nvarchar(50)
          N'{invoice.EArchiveDeTrIntPaymentAgent_EArsiv}' , -- EArchiveDeTrIntPaymentAgent_EArsiv - nvarchar(50)
          CASE WHEN '{eArchiveDeTrIntPaymentDateEArsiv}' = '0001-01-01 00:00:00' OR '{
                            eArchiveDeTrIntPaymentDateEArsiv
                        }' = '1.01.0001 00:00:00' THEN NULL ELSE '{
                            eArchiveDeTrIntPaymentDateEArsiv
                        }' END, -- EArchiveDeTrIntPaymentDate_EArsiv - datetime
          {invoice.EArchiveDeTrInsteadOfDesp_EArsiv} , -- EArchiveDeTrInsteadOfDesp_EArsiv - int
          {invoice.EInsteadOfDispatch_EFatura} , -- EInsteadOfDispatch_EFatura - int
          CASE WHEN '{eStartDateEFatura}' = '0001-01-01 00:00:00' OR '{eStartDateEFatura}' = '1.01.0001 00:00:00' THEN NULL ELSE '{
                            eStartDateEFatura
                        }' END, -- EStartDate_EFatura - datetime
          CASE WHEN '{eEndDateEFatura}' = '0001-01-01 00:00:00' OR '{eEndDateEFatura}' = '1.01.0001 00:00:00' THEN NULL ELSE '{
                            eEndDateEFatura
                        }' END, -- EEndDate_EFatura - datetime
          N'{invoice.EDescription_EFatura}' , -- EDescription_EFatura - nvarchar(250)
          {invoice.EDuration_EFatura}  -- EDuration_EFatura - int
        )";

                    #endregion

                    LogHelper.Logger.Info(insertQuery);

                    sqlConnection.Execute(insertQuery);
                }
            }
        }

        public void LogClCard(List<ModelClCard> clCardList)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                foreach (var clCard in clCardList)
                {
                    #region Query

                    var clearQuery = $@"
DELETE  FROM dbo.Net_Log_ClCard
WHERE   ArkmanId = {clCard.ArkmanId}  AND EntId = 0";

                    sqlConnection.Execute(clearQuery);

                    var insertQuery = $@"
                    INSERT INTO dbo.Net_Log_ClCard
                            ( Id ,
                              ArkmanId ,
                              Code ,
                              Title ,
                              Title2 ,
                              AuxilCode ,
                              AuxilCode2 ,
                              AuxilCode3 ,
                              AuxilCode4 ,
                              AuxilCode5 ,
                              Address1 ,
                              Address2 ,
                              Town ,
                              City ,
                              CityCode ,
                              Country ,
                              CountryCode ,
                              PostalCode ,
                              Telephone1Code ,
                              Telephone1 ,
                              Telephone2Code ,
                              Telephone2 ,
                              FaxCode ,
                              Fax ,
                              TaxId ,
                              TaxOffice ,
                              Contact ,
                              Contact2 ,
                              Contact3 ,
                              EMail ,
                              EMail2 ,
                              EMail3 ,
                              TradingGrp ,
                              GlCode ,
                              OhpCode ,
                              PersCompany ,
                              TCKNO ,
                              WebUrl ,
                              PurchBrws ,
                              SalesBrws ,
                              ImpBrws ,
                              ExpBrws ,
                              FinBrws
                            )
                    VALUES  ( {clCard.Id} , -- Id - int
                              {clCard.ArkmanId} , -- ArkmanId - int
                              N'{clCard.Code}' , -- Code - nvarchar(50)
                              N'{clCard.Title}' , -- Title - nvarchar(200)
                              N'{clCard.Title2}' , -- Title2 - nvarchar(200)
                              N'{clCard.AuxilCode}' , -- AuxilCode - nvarchar(50)
                              N'{clCard.AuxilCode2}' , -- AuxilCode2 - nvarchar(50)
                              N'{clCard.AuxilCode3}' , -- AuxilCode3 - nvarchar(50)
                              N'{clCard.AuxilCode4}' , -- AuxilCode4 - nvarchar(50)
                              N'{clCard.AuxilCode5}' , -- AuxilCode5 - nvarchar(50)
                              N'{clCard.Address1}' , -- Address1 - nvarchar(300)
                              N'{clCard.Address2}' , -- Address2 - nvarchar(300)
                              N'{clCard.Town}' , -- Town - nvarchar(100)
                              N'{clCard.City}' , -- City - nvarchar(100)
                              N'{clCard.CityCode}' , -- CityCode - nvarchar(10)
                              N'{clCard.Country}' , -- Country - nvarchar(100)
                              N'{clCard.CountryCode}' , -- CountryCode - nvarchar(10)
                              N'{clCard.PostalCode}' , -- PostalCode - nvarchar(10)
                              N'{clCard.Telephone1Code}' , -- Telephone1Code - nvarchar(10)
                              N'{clCard.Telephone1}' , -- Telephone1 - nvarchar(20)
                              N'{clCard.Telephone2Code}' , -- Telephone2Code - nvarchar(10)
                              N'{clCard.Telephone2}' , -- Telephone2 - nvarchar(20)
                              N'{clCard.FaxCode}' , -- FaxCode - nvarchar(10)
                              N'{clCard.Fax}' , -- Fax - nvarchar(20)
                              N'{clCard.TaxId}' , -- TaxId - nvarchar(20)
                              N'{clCard.TaxOffice}' , -- TaxOffice - nvarchar(100)
                              N'{clCard.Contact}' , -- Contact - nvarchar(100)
                              N'{clCard.Contact2}' , -- Contact2 - nvarchar(100)
                              N'{clCard.Contact3}' , -- Contact3 - nvarchar(100)
                              N'{clCard.EMail}' , -- EMail - nvarchar(250)
                              N'{clCard.EMail2}' , -- EMail2 - nvarchar(250)
                              N'{clCard.EMail3}' , -- EMail3 - nvarchar(250)
                              N'{clCard.TradingGrp}' , -- TradingGrp - nvarchar(50)
                              N'{clCard.GlCode}' , -- GlCode - nvarchar(50)
                              N'{clCard.OhpCode}' , -- OhpCode - nvarchar(50)
                              {clCard.PersCompany} , -- PersCompany - bit
                              N'{clCard.TCKNO}' , -- TCKNO - nvarchar(20)
                              N'{clCard.WebUrl}' , -- WebUrl - nvarchar(250)
                              {clCard.PurchBrws} , -- PurchBrws - int
                              {clCard.SalesBrws} , -- SalesBrws - int
                              {clCard.ImpBrws} , -- ImpBrws - int
                              {clCard.ExpBrws} , -- ExpBrws - int
                              {clCard.FinBrws}  -- FinBrws - int
                            )";

                    #endregion

                    sqlConnection.Execute(insertQuery);
                }
            }
        }

        public void LogInvoiceResult(ModelResult result)
        {
            var updateQuery = "";

            if (result.ErrorMessage.Count > 0)
            {
                var errors = result.ErrorMessage.Aggregate("", (current, error) => current + error + ". ");

                updateQuery = $@"
UPDATE  dbo.Net_Log_Invoice
SET     Success = 0 ,
        EntId = 0 ,
        ErrorString = '{errors.Replace("'", "''")}'
WHERE   ArkmanId = {result.ArkmanId}";
            }
            else
            {
                updateQuery = $@"
UPDATE  dbo.Net_Log_Invoice
SET     Success = 1 ,
        EntId = {result.Id} ,
        Id = {result.Id} ,
        ErrorString = ''
WHERE   ArkmanId = {result.ArkmanId}";
            }

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(updateQuery);
            }
        }

        public void LogClCardResult(ModelResult result)
        {
            var updateQuery = "";

            if (result.ErrorMessage.Count > 0)
            {
                var errors = result.ErrorMessage.Aggregate("", (current, error) => current + error + ". ");

                updateQuery = $@"
UPDATE  dbo.Net_Log_ClCard
SET     Success = 0 ,
        EntId = 0 ,
        ErrorString = '{errors.Replace("'", "''")}'
WHERE   ArkmanId = {result.ArkmanId}";
            }
            else
            {
                updateQuery = $@"
UPDATE  dbo.Net_Log_ClCard
SET     Success = 1 ,
        EntId = {result.Id} ,
        Id = {result.Id} ,
        ErrorString = ''
WHERE   ArkmanId = {result.ArkmanId}";
            }

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Execute(updateQuery);
            }
        }

        public int ControlClCard(int clCardArkmanId)
        {
            var query = $@"
SELECT  EntId
FROM    dbo.Net_Log_ClCard
WHERE   ArkmanId = {clCardArkmanId}";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var recordCount = sqlConnection.Query<int>(query).FirstOrDefault();

                if (recordCount > 0)
                {
                    var deleteQuery = $@"
DELETE  FROM dbo.Net_Log_ClCard
WHERE   ArkmanId = {clCardArkmanId}
        AND EntId = 0";

                    sqlConnection.Execute(deleteQuery);
                }

                return recordCount;
            }
        }

        public int ControlInvoice(int invoiceArkmanId)
        {
            var query = $@"
SELECT  EntId
FROM    dbo.Net_Log_Invoice
WHERE   ArkmanId = {invoiceArkmanId}";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var recordCount = sqlConnection.Query<int>(query).FirstOrDefault();

                if (recordCount > 0)
                {
                    var deleteQuery = $@"
DELETE  FROM dbo.Net_Log_Invoice
WHERE   ArkmanId = {invoiceArkmanId}
        AND EntId = 0";

                    sqlConnection.Execute(deleteQuery);
                }

                return recordCount;
            }
        }
    }
}