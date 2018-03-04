using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavoCalcLib;

namespace TestSavo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SavoCalc sc = new SavoCalc();

            Assert.AreEqual(sc.Width_cm,70, sc.Beaufort);
                



        }
    }
}
