using ArquiteturaTeste.Domain.Models;
using System.Collections.Generic;

namespace ArquiteturaTeste.Domain.Services
{
    public interface INovoChamado
    {
        void CadastrarChamado(NovoChamado chamado);

        void EditarStatus(NovoChamado chamado);

        void CancelarChamado(NovoChamado chamado);

        List<NovoChamado> ListarChamados();

        NovoChamado ListarPorId(int id);


    }
}
