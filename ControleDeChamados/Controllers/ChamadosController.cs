using ArquiteturaTeste.Business.Services;
using ArquiteturaTeste.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeChamados.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly ChamadosService appChamados;
        public ChamadosController()
        {
            appChamados = ConstrutorChamados.ChamadosBusiness();
        }

        // GET: Chamados
        public ActionResult Index()
        {
            var Listar = appChamados.ListarChamados();
            return View(Listar);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(NovoChamado chamado)
        {
            if (ModelState.IsValid)
            {
                appChamados.NovoChamado(chamado);
                return RedirectToAction("Index");
            }
            return View(chamado);
        }

        public ActionResult Editar(string id)
        {
            var chamado = appChamados.ListarPorId(id);
            if (chamado == null)
                return HttpNotFound();

            return View(chamado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(NovoChamado chamado)
        {
            if (ModelState.IsValid)
            {
                appChamados.EditarStatus(chamado);
                return RedirectToAction("Index");
            }
            return View(chamado);
        }

        public ActionResult Detalhes(string id)
        {
            var chamados = appChamados.ListarPorId(id);
            if (chamados == null)
                return HttpNotFound();

            return View(chamados);
        }

        public ActionResult Excluir(string id)
        {
            var chamados = appChamados.ListarPorId(id);
            if (chamados == null)
                return HttpNotFound();

            return View(chamados);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var chamados = appChamados.ListarPorId(id);
            appChamados.CancelarChamado(chamados);
            return RedirectToAction("Index");
        }


    }
}