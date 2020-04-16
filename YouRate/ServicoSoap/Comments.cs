using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicoSoap
{
    public class Comments
    {
        public int Comments_Id { get; set; }
        public DateTime Comments_Date { get; set; }
        public string Comments_Comments { get; set; }
        public int Comments__Video_Id { get; set; }
    }
}