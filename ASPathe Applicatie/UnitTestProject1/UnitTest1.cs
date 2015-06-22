using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPathe_Applicatie;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        DatabaseKoppeling dbKoppeling;
        [TestMethod]
        public void TestMethod1()
        {
            dbKoppeling = new DatabaseKoppeling();            
            bool connectie = false;
            connectie = dbKoppeling.TestConnectie();
            
            bool actual = connectie;
            bool expected = true;

            Assert.AreEqual(expected, actual, "Connectie kan niet geopend worden");
        }
    }
}
