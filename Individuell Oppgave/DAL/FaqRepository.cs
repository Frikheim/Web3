using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Individuell_Oppgave.Model;
using Microsoft.EntityFrameworkCore;

namespace Individuell_Oppgave.DAL
{
        public class FaqRepository : IFaqRepository
    {
        private readonly FaqContext _db;

        public FaqRepository(FaqContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Spørsmål spørsmål)
        {
            try
            {
                var nyFaqRad = new SpørsmålSvar();
                nyFaqRad.Spørsmål = spørsmål.SpørsmålTekst;
                nyFaqRad.Svar = spørsmål.Svar;
                nyFaqRad.Kategori = spørsmål.Kategori;
                nyFaqRad.TommelOpp = spørsmål.TommelOpp;
                nyFaqRad.TommelNed = spørsmål.TommelNed;

                _db.Faq.Add(nyFaqRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Spørsmål>> HentAlle()
        {
            try
            {
                List<Spørsmål> alleSpørsmål = await _db.Faq.Select(k => new Spørsmål
                {
                    Id = k.Id,
                    SpørsmålTekst = k.Spørsmål,
                    Svar = k.Svar,
                    Kategori = k.Kategori,
                    TommelOpp = k.TommelOpp,
                    TommelNed = k.TommelNed
                }).ToListAsync();
                return alleSpørsmål;
            }
            catch
            {
                return null;
            }
        }
    }
}