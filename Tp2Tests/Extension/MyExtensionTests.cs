using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tp2.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Extension.Tests
{
    [TestClass()]
    public class MyExtensionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException), "Attempted to divide by zero.")]
        public void DividirTest()
        {
            int numero = 5;

            int resultado = numero / 0;

            
        }

        [TestMethod()]
        public void DividirDosNumerosTest()
        {
            //Arrange
            int numero1 = 15;
            int numero2 = 5;
            int resultadoEsperado = 3;

            double division = numero1 / numero2;

            Assert.AreEqual(division, resultadoEsperado);
        }
    }
}