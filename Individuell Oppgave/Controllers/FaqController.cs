using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Individuell_Oppgave.DAL;
using Individuell_Oppgave.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KundeApp2.Controllers
{
    [ApiController]
   
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private IFaqRepository _db;

        private ILogger<FaqController> _log;

        public FaqController(IFaqRepository db, ILogger<FaqController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpPost]
        public async Task<ActionResult> Lagre(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Lagre(innKunde);
                if (!returOK)
                {
                    _log.LogInformation("Kunden kunne ikke lagres!");
                    return BadRequest();
                }
                return Ok(); // kan ikke returnere noe tekst da klient prøver å konvertere deene som en Json-streng
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> HentAlle()
        {
            List<Kunde> alleKunder = await _db.HentAlle();
            return Ok(alleKunder); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Slett(int id)
        {
            bool returOK = await _db.Slett(id);
            if (!returOK)
            {
                _log.LogInformation("Sletting av Kunden ble ikke utført");
                return NotFound();
            }
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> HentEn(int id)
        {
            if (ModelState.IsValid)
            {
                Kunde kunden = await _db.HentEn(id);
                if (kunden == null)
                {
                    _log.LogInformation("Fant ikke kunden");
                    return NotFound();
                }
                return Ok(kunden);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Endre(Kunde endreKunde)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Endre(endreKunde);
                if (!returOK)
                {
                    _log.LogInformation("Endringen kunne ikke utføres");
                    return NotFound();
                }
                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }
    }
}
