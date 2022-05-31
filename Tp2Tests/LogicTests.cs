using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tp2;
using Tp2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void TriggerTest()
        {
            Logic logica = new Logic();
            logica.Trigger();
        }

        [TestMethod()]
        [ExpectedException(typeof(ExceptionPersonalizada))]
        public void CustomTriggerTest()
        {
            Logic logica = new Logic();
            logica.CustomTrigger();
        }
    }
}