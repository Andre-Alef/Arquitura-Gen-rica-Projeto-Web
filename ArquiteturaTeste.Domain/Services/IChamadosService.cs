using ArquiteturaTeste.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaTeste.Domain.Services
{
   public interface IChamadosService
    {
        void NovoChamado(NovoChamado chamado);
        void EditarStatus(NovoChamado chamado);
        void CancelarChamado(NovoChamado chamado);

        List<NovoChamado> ListarChamados();
        NovoChamado ListarPorId(string id);
    }
}
