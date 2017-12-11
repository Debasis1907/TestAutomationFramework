using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework
{
    [TestClass]
    public class UserData
    {        
        public string Key { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
