namespace consoleapp.Models
{
    public class Balk : IKleur, IVeelhoek
    {
        private double _breedte;
        private double _hoogte;

        public double Breedte { get { return _breedte; } set { _breedte = value; } }
        public double Hoogte { get { return _hoogte; } set { _hoogte = value; } }

        public string BepaalKleur()
        {
            return "groen";
        }

        public double BerekenOppervlakte()
        {
            return this.Breedte * this.Hoogte;
        }
    }
}
