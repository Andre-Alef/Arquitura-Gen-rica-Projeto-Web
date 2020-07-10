using ArquiteturaTeste.Domain.Models;
using ArquiteturaTeste.Domain.Services;
using ArquiteturaTeste.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArquiteturaTeste.Infrastructure.Repositories
{

    public class RepositorioChamados : INovoChamado
    {
        private ContextChamadosTeste1 _context; 

        public RepositorioChamados(ContextChamadosTeste1 context)
        {
            this._context = context;  
        }

        public void CadastrarChamado(NovoChamado chamado)
        {
            _context.chamados.Add(chamado);
            _context.SaveChanges();
        }

        public void CancelarChamado(NovoChamado chamado)
        {
            _context.chamados.Remove(chamado);
            _context.SaveChanges();
        }

        public void EditarStatus(NovoChamado chamado)
        {
            _context.Entry<NovoChamado>(chamado).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<NovoChamado> ListarChamados()
        {
            return _context.chamados.ToList();
        }

        public NovoChamado ListarPorId(int id)
        {
            return _context.chamados.Where(x => x.IdChamado == id).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
