using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAutotalli
{
    public class Garage
    {
        public static List<Auto> GetTestAutos()
        {
            //UI testaamista varten palautetaan muutama auto
            List<Auto> autos = new List<Auto>();

            autos.Add(new Auto() { Brand = "Audi", KM = 120000, Model = "R8", Price = 76000F, URL = "AudiA4.png", YearModel = 2018 });
            autos.Add(new Auto() { Brand = "Volvo", KM = 240000, Model = "V70", Price = 15000F, URL = "VolvoV70.png", YearModel = 2010 });
            autos.Add(new Auto() { Brand = "Volvo", KM = 200000, Model = "V40", Price = 12000F, URL = "VolvoV40.png", YearModel = 2012 });
            autos.Add(new Auto() { Brand = "BMW", KM = 200000, Model = "320", Price = 12000F, URL = "VolvoV40.png", YearModel = 2012 });
            autos.Add(new Auto() { Brand = "Renault", KM = 200000, Model = "Clio", Price = 12000F, URL = "VolvoV40.png", YearModel = 2012 });

            return autos;
        }
    }
    public class Auto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public int KM { get; set; }
        public float Price { get; set; }
        public string URL { get; set; }
    }
}
