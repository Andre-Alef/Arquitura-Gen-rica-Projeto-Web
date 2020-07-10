using ArquiteturaTeste.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaTeste.Business.Services
{
   public class ConstrutorChamados
    {
        public static ChamadosService ChamadosBusiness()
        {
            return new ChamadosService(new ChamadosRepositorio());
        }
    }
}
