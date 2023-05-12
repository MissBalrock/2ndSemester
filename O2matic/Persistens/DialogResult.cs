using System.Runtime.Serialization;

namespace O2matic.Persistens
{
    public class DialogResult
    {
        private object DialogResults { get; set; }
        private string Result { get; set; }

        public object dialogResults { get; set; }
        public string result
        { 
            get Result;
            set;
        }
        public DialogResult(string result) 
        {
            this.result = result;
        }

        If(string result == Yes)
        {

        }

    }
}