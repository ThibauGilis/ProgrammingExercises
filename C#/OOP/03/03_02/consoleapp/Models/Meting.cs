using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Meting
    {
        private DateTime _tijdstip;
        private double _gradenFahrenheit;
        private double _gradenCelsius;

        public DateTime Tijdstip
        {
            get { return _tijdstip;}
            set { _tijdstip = value;}
        }
        public double GradenFahrenheit
        {
            get { return _gradenFahrenheit; }
            set { _gradenFahrenheit = value; }
        }
        public double GradenCelsius
        {
            get { return _gradenCelsius; }
            set { _gradenCelsius = value; }
        }

        public Meting(double gradenCelsius)
        {
            this.Tijdstip = DateTime.Now;
            this.GradenCelsius = gradenCelsius;
            this.GradenFahrenheit = TemperatuurConversies.ConverteerNaarGradenFahrenheit(gradenCelsius);
        }
        public Meting(DateTime tijdstip, double gradenCelsius)
        {
            this.Tijdstip = tijdstip;
            this.GradenCelsius = gradenCelsius;
            this.GradenFahrenheit = TemperatuurConversies.ConverteerNaarGradenFahrenheit(gradenCelsius);
        }
        public Meting(DateTime tijdstip, double gradenFahrenheit, double gradenCelsius)
        {
            this.Tijdstip = tijdstip;
            this.GradenFahrenheit = gradenFahrenheit;
            this.GradenCelsius = gradenCelsius;
        }

        public string ToonGegevens()
        {
            return $"Op {this.Tijdstip} werd er {this.GradenCelsius} graden Celsius en {this.GradenFahrenheit} graden Fahrenheit gemeten.";
        }
    }
}
