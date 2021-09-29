using System.Text.Json.Serialization;

namespace TrainReservation.Models.Request
{
    public class Vagon
    {
        public string Ad { get; set; }
        public int Kapasite  { get; set; }
        public int DoluKoltukAdet { get; set; }
    }
}