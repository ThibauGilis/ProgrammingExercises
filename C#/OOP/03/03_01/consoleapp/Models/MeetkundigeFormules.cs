using System.Runtime.CompilerServices;

namespace consoleapp.Models;

static public class MeetkundigeFormules
{
    static public double OppervlakteRechthoek(double lengte, double breedte)
    {
        return lengte * breedte;
    }
    static public double OppervlakteCirkel(double straal)
    {
        return Math.Pow(straal, 2) * Math.PI;
    }
    static public double VolumeBalk(double lengte, double breedte, double hoogte)
    {
        return lengte * breedte * hoogte;
    }
    static public double VolumeCilinder(double straal, double hoogte)
    {
        return Math.Pow(straal, 2) * Math.PI * hoogte;
    }

}
