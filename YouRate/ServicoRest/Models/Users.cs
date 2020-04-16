using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicoRest
{
    public class Users
    {
        public int Users_Id { get; set; }
        public string Users_FirstName { get; set; }
        public string Users_LastName { get; set; }
        public string Users_Email { get; set; }
        public string Users_Password { get; set; }
    }
}