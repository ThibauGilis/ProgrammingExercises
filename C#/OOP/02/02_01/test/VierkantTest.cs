namespace test
{
    [TestClass]
    public class VierkantTest
    {
        [TestMethod]
        public void TestPropertyZijdeKleinerDan0()
        {
            Vierkant vierkant = new Vierkant(-5);

            Assert.AreEqual(0, vierkant.Zijde);
        }

        [TestMethod]
        public void TestPropertyZijdeGroterDan25()
        {
            Vierkant vierkant = new Vierkant(30);

            Assert.AreEqual(25, vierkant.Zijde);
        }

        [TestMethod]
        public void TestPropertyZijdeOk()
        {
            Vierkant vierkant = new Vierkant(15);

            Assert.AreEqual(15, vierkant.Zijde);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Vierkant vierkant = new Vierkant(12);

            Assert.AreEqual(12, vierkant.Zijde);
        }

        [TestMethod]
        public void TestDiagonaal()
        {
            Vierkant vierkant = new Vierkant(5);

            double diagonaal = vierkant.Diagonaal();
            Assert.AreEqual(Math.Round(Math.Sqrt(50),2),diagonaal);
        }

        [TestMethod]
        public void TestOmtrek()
        {
            Vierkant vierkant = new Vierkant(5);

            int omtrek = vierkant.Omtrek();
            Assert.AreEqual(20, omtrek);
        }

        [TestMethod]
        public void TestOppervlakte()
        {
            Vierkant vierkant = new Vierkant(5);

            int oppervlakte = vierkant.Oppervlakte();
            Assert.AreEqual(25, oppervlakte);
        }

        [TestMethod]
        public void TestTeken()
        {
            Vierkant vierkant = new Vierkant(5);

            string teken = vierkant.Teken();
            StringAssert.Contains(teken, "* * * * *\n" +
                                         "* * * * *\n" +
                                         "* * * * *\n" +
                                         "* * * * *\n" +
                                         "* * * * *");
        }
    }
}