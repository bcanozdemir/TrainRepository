using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservation.Models.Request;
using TrainReservation.Models.Response;

namespace TrainReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpPost("checkReservation")]
        public Response Check(Request req)
        {
            var YerlesimAyrintiListesi = new List<YerlesimAyrinti>();
            if (req.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                var isAdded = false;
                var kisiSayisi = req.RezervasyonYapilacakKisiSayisi;
                foreach (var vagon in req.Tren.Vagonlar)
                {
                    var bosYer = Convert.ToInt32((vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet);
                    if (kisiSayisi > 0)
                    {
                        for (int i = kisiSayisi; i > 0; i--)
                        {
                            if (bosYer > i)
                            {
                                YerlesimAyrintiListesi.Add(new YerlesimAyrinti()
                                {
                                    VagonAdi = vagon.Ad,
                                    KisiSayisi = i
                                });
                                kisiSayisi = kisiSayisi - i;
                                isAdded = true;
                                break;
                            }
                            
                        }
                    }
                   
                }
                return new Response()
                {
                    YerlesimYapilabilir = isAdded,
                    YerlesimAyrinti = YerlesimAyrintiListesi
                };
                
            }
            else
            {
                var isAdded = false;
                foreach (var vagon in req.Tren.Vagonlar)
                {
                    var kisiSayisi = req.RezervasyonYapilacakKisiSayisi;
                    var isChecked = vagon.Kapasite * 0.7 > vagon.DoluKoltukAdet + req.RezervasyonYapilacakKisiSayisi;
                    if (isChecked)
                    {

                        YerlesimAyrintiListesi.Add(new YerlesimAyrinti()
                        {
                            VagonAdi = vagon.Ad,
                            KisiSayisi = req.RezervasyonYapilacakKisiSayisi
                        });
                        kisiSayisi = 0;
                        isAdded = true;
                    }

                    if (kisiSayisi == 0)
                    {
                        break;
                    }

                }

                return new Response()
                {
                    YerlesimYapilabilir = isAdded,
                    YerlesimAyrinti = YerlesimAyrintiListesi
                };
            }
        }


    }
}
