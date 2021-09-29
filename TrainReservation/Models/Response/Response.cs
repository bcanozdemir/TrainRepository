using System.Collections.Generic;

namespace TrainReservation.Models.Response
{
    public class Response
    {
        public bool YerlesimYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}