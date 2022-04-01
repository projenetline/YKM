using System.Collections.Generic;

namespace YKM.Transfer.ILibrary
{
    public class ModelResult
    {
        //public Data Data { get; set; }

        public int Id { get; set; }

        //public string Code { get; set; }

        public int ArkmanId { get; set; }

        public List<string> ErrorMessage { get; set; }

        public ModelResult()
        {
            ErrorMessage = new List<string>();
        }
    }
}