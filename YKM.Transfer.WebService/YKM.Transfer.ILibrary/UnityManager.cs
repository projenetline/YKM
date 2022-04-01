using UnityObjects;

namespace YKM.Transfer.ILibrary
{
    public class UnityManager
    {
        // ReSharper disable once InconsistentNaming
        public static UnityApplication _UnityApplication;

        private const string HashMap = "n€tL!n@";

        public static bool LogIn(string userName, string password, int firmNr, int firmPer)
        {
            userName = CryptHelper.Decrypt(userName, HashMap);
            password = CryptHelper.Decrypt(password, HashMap);

            if (_UnityApplication == null)
                _UnityApplication = new UnityApplication();

            //LogHelper.Logger.Info(
            //    $"LogoUserName: {userName}, LogoUserPassword: {password}, LogoFirmNr: {firmNr}, LogoFirmPer: {firmPer}");

            return _UnityApplication.Login(userName, password, firmNr, firmPer);
        }

        public static ModelResult CompanyLogIn(int firmNr)
        {
            var resultModel = new ModelResult();

            if (firmNr > 0)
            {
                if (_UnityApplication.CompanyLoggedIn)
                    _UnityApplication.CompanyLogout();

                if (_UnityApplication.CompanyLogin(firmNr))
                {
                    return resultModel;
                }

                resultModel.ErrorMessage.Add(
                    _UnityApplication.GetLastError() +
                    ":" +
                    _UnityApplication.GetLastErrorString());

                return resultModel;
            }

            resultModel.ErrorMessage.Add("Geçersiz Firma Numarası");

            return resultModel;
        }

        protected UnityManager()
        {
        }
    }
}