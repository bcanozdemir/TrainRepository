using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainReservation.Models.Request
{
    
    public class Tren
    {
        public string Ad { get; set; }
        public List<Vagon> Vagonlar { get; set; }
    }
}