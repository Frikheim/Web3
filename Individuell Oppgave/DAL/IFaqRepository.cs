using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Individuell_Oppgave.Model;

namespace Individuell_Oppgave.DAL
{
    public interface IFaqRepository
    {
        Task<bool> Lagre(Spørsmål spørsmål);
        Task<List<Spørsmål>> HentAlle();
        
    }
}
