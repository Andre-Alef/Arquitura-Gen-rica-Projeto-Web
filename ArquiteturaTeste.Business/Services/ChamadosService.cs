using ArquiteturaTeste.Domain.Models;
using ArquiteturaTeste.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaTeste.Business.Services
{
    public class ChamadosService : IChamadosService
    {
        private IChamadosService _repositorio;
        public ChamadosService(IChamadosService repo)
        {
            this._repositorio = repo;
        }
        public void CancelarChamado(NovoChamado chamado)
        {
            _repositorio.CancelarChamado(chamado);
        }

        public void EditarStatus(NovoChamado chamado)
        {
            _repositorio.EditarStatus(chamado);
        }

        public List<NovoChamado> ListarChamados()
        {
           return _repositorio.ListarChamados();
        }

        public NovoChamado ListarPorId(string id)
        {

            return _repositorio.ListarPorId(id);
        }

        public void NovoChamado(NovoChamado chamado)
        {
            _repositorio.NovoChamado(chamado);
        }
    }
}
