using ArquiteturaTeste.Domain.Models;
using ArquiteturaTeste.Domain.Services;
using ArquiteturaTeste.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArquiteturaTeste.Infrastructure.Repositories
{
    public class ChamadosRepositorio : IChamadosService
    {
        private ContextChamadosTeste1 _context;
        public ChamadosRepositorio()
        {
            _context = new ContextChamadosTeste1();
        }

        public void NovoChamado(NovoChamado chamado)
        {
            _context.chamados.Add(chamado);
            _context.SaveChanges();
        }

        public void EditarStatus(NovoChamado chamado)
        {
            //    _context.Entry<NovoChamado>(chamado).State = System.Data.Entity.EntityState.Modified;
            //  _context.SaveChanges();

            var ChamadoAlterar = _context.chamados.First(x => x.Id == chamado.Id);
            ChamadoAlterar.Assunto = chamado.Assunto;         
            _context.SaveChanges();
        }

        public void CancelarChamado(NovoChamado chamado)
        {
            var ChamadoExcluir = _context.chamados.First(x => x.Id == chamado.Id);
            _context.chamados.Remove(chamado);
            _context.Set<NovoChamado>().Remove(ChamadoExcluir);
            _context.SaveChanges();
        }

        public List<NovoChamado> ListarChamados()
        {
            return _context.chamados.ToList();
        }

        public NovoChamado ListarPorId(string id)
        {

            int idInt;
            Int32.TryParse(id, out idInt);
            return _context.chamados.First(x => x.Id == idInt);
        
        }

        public void Dispose()
        {
            _context.Dispose();
        }
     
    }
}
