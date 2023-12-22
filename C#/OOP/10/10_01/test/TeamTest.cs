namespace test
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void TeamTest_AantalSpelers()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();

            for (int i = 0; i < 15; i++)
            {
                teamSpelers.Add(spelers[i]);
            }

            Team team = new Team(trainers[0],teamSpelers);

            Assert.AreEqual(15, team.AantalSpelers);
        }

        [TestMethod]
        public void TeamTest_AantalVerdedigers()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();

            for (int i = 0; i < 15; i++)
            {
                teamSpelers.Add(spelers[i]);
            }

            Team team = new Team(trainers[0], teamSpelers);

            Assert.AreEqual(4, team.AantalVerdedigers);
        }

        [TestMethod]
        public void TeamTest_AantalMiddenvelders()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();

            for (int i = 0; i < 15; i++)
            {
                teamSpelers.Add(spelers[i]);
            }

            Team team = new Team(trainers[0], teamSpelers);

            Assert.AreEqual(4, team.AantalMiddenvelders);
        }

        [TestMethod]
        public void TeamTest_AantalAanvallers()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();

            for (int i = 0; i < 15; i++)
            {
                teamSpelers.Add(spelers[i]);
            }

            Team team = new Team(trainers[0], teamSpelers);

            Assert.AreEqual(6, team.AantalAanvallers);
        }

        [TestMethod]
        public void TeamTest_AantalKeeppers()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();

            for (int i = 0; i < 15; i++)
            {
                teamSpelers.Add(spelers[i]);
            }

            Team team = new Team(trainers[0], teamSpelers);

            Assert.AreEqual(1, team.AantalKeeppers);
        }

        [TestMethod]
        public void TeamTest_VoegSpelerToe()
        {
            List<Trainer> trainers = FileOperations.LeesTrainers();
            List<Voetbalspeler> spelers = FileOperations.LeesSpelers();
            List<Voetbalspeler> teamSpelers = new List<Voetbalspeler>();
            Team team = new Team(trainers[0], teamSpelers);

            team.VoegSpelerToe(spelers[0]);
            team.VoegSpelerToe(spelers[4]);

            string persoonInfo = team.Spelers[0].ToString();
            StringAssert.Contains("Lionel Messi speelt op positie Aanvaller", persoonInfo);

            persoonInfo = team.Spelers[1].ToString();
            StringAssert.Contains("Mohamed Salah speelt op positie Aanvaller", persoonInfo);
        }
    }
}