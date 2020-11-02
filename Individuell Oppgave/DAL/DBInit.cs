using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell_Oppgave.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            
            var db = serviceScope.ServiceProvider.GetService<FaqContext>();

            // må slette og opprette databasen hver gang når den skal initieres (seed`es)
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var spørsmål1 = new SpørsmålSvar
            {
                Spørsmål = "Hva betyr % tallene ved noen av billettypene? ",
                Svar = "Det er rabatten disse bilettypene får i forhold til standardprisen på voksenbillett",
                Kategori = "Billett",
                TommelOpp = 2,
                TommelNed = 5
            };

            var spørsmål2 = new SpørsmålSvar
            {
                Spørsmål = "Jeg får ikke laget bruker for å logge inn",
                Svar = "Innlogging er desverre kun for administratoer, innlogging for kunder kommer snart",
                Kategori = "Innlogging",
                TommelOpp = 0,
                TommelNed = 30
            };

            var spørsmål3 = new SpørsmålSvar
            {
                Spørsmål = "Hvorfor vises ikke returvarianten av rutene?",
                Svar = "Rutene er begge retninger slik at en egen returrute ikke trenges",
                Kategori = "Rute",
                TommelOpp = 10,
                TommelNed = 1
            };

            var spørsmål4 = new SpørsmålSvar
            {
                Spørsmål = "Hvorfor kommer man ikke tilbake til bilettbestillingen fra faqsiden",
                Svar = "faqsiden ble laget i et annet prosjekt enn billettbestillingen",
                Kategori = "Annet",
                TommelOpp = 0,
                TommelNed = 0
            };

            db.Faq.Add(spørsmål1);
            db.Faq.Add(spørsmål2);
            db.Faq.Add(spørsmål3);
            db.Faq.Add(spørsmål4);

            db.SaveChanges();
        }
    }  
}
