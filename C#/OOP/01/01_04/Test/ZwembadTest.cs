namespace Test
{
    [TestClass]
    public class ZwembadTest
    {
        [TestMethod]
        public void RandafstandTestKleinerDanNul()
        {
            Zwembad zwembad = new Zwembad(20,5,10,-2);

            Assert.AreEqual(0, zwembad.Randafstand);
        }

        [TestMethod]
        public void RandafstandTestGroterDanDiepte()
        {
            Zwembad zwembad = new Zwembad(20, 5, 10, 15);

            Assert.AreEqual(0, zwembad.Randafstand);
        }

        [TestMethod]
        public void RandafstandTestOk()
        {
            Zwembad zwembad = new Zwembad(20, 5, 10, 2);

            Assert.AreEqual(2, zwembad.Randafstand);
        }

        [TestMethod]
        public void ConstructorOk()
        {
            Zwembad zwembad = new Zwembad(20,5,10,2);

            Assert.AreEqual(zwembad.Breedte, 20);
            Assert.AreEqual(zwembad.Lengte, 5);
            Assert.AreEqual(zwembad.Diepte, 10);
            Assert.AreEqual(zwembad.Randafstand, 2);
        }

        [TestMethod]
        public void TestLiterWater()
        {
            Zwembad zwembad = new Zwembad(2, 1.8, 11, 0.3);

            double LiterWater = zwembad.LiterWater();
            Assert.AreEqual(LiterWater, 33000);
        }
    }
}