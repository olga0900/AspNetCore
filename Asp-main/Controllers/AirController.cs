using ASPAirport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPAirport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirController : ControllerBase
    {
        private static readonly IList<Reisi> Reisi = new List<Reisi>();

        [HttpGet]
        public IEnumerable<Reisi> All()
        {
            return Reisi;
        }


        [HttpPost]
        public Reisi Add(AirModel model)
        {
            var reis = new Reisi
            {
                Id = Guid.NewGuid(),
                nomer_reisa = model.nomer_reisa,
                type = model.type,
                prib_time = model.prib_time,
                passagiers_count = model.passagiers_count,
                ppassagiers__price = model.ppassagiers__price,
                ek_count = model.ek_count,
                ek_price = model.ek_price,
                procent = model.procent,
                allmoney = model.passagiers_count * model.ppassagiers__price + model.ek_count * model.ek_price + model.procent
            };
            Reisi.Add(reis);
            return reis;
        }


        [HttpDelete("{id:guid}")]
        public bool Remove(Guid id)
        {
            var taggetreis = Reisi.FirstOrDefault(x => x.Id == id);
            if (taggetreis != null)
            {
                return Reisi.Remove(taggetreis);
            }
            return false;
        }


        [HttpPut("{id:guid}")]
        public Reisi Update([FromRoute] Guid id, [FromBody] AirModel model)
        {
            var targetreis = Reisi.FirstOrDefault(x => x.Id == id);
            if (targetreis != null)
            {
                targetreis.nomer_reisa = model.nomer_reisa;
                targetreis.type = model.type;
                targetreis.prib_time = model.prib_time;
                targetreis.passagiers_count = model.passagiers_count;
                targetreis.ppassagiers__price = model.ppassagiers__price;
                targetreis.ek_count = model.ek_count;
                targetreis.ek_price = model.ek_price;
                targetreis.procent = model.procent;
                targetreis.allmoney = model.passagiers_count * model.ppassagiers__price + model.ek_count * model.ek_price + model.procent;
            }
            return targetreis;
        }


        [HttpGet("statictic")]
        public Statictic GetStats()
        {
            var statictic = new Statictic()
            {
                kolvo = Reisi.Count,
                kolvoPassengers = Reisi.Sum(x => x.passagiers_count),
                kolvoСrew = Reisi.Sum(x => x.ek_count),
                vsegoSum = Reisi.Sum(x => x.allmoney)
            };
            return statictic;
        }
    }
}
