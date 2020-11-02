using System;

namespace Individuell_Oppgave.Model
{
    public class Spørsmål
    {
        public int Id { get; set; }
        public String SpørsmålTekst { get; set; }
        public String Svar { get; set; }
        public String Kategori { get; set; }
        public int TommelOpp { get; set; }
        public int TommelNed { get; set; }
        
    }
}
