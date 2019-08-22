using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.Services;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.UI.Site.Models;

namespace EP.CursoMVC.UI.Site.Controllers
{
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : Controller
    {
        protected IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }
        
        [Route("listar-ativos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }
        
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {            
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }
        
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }
                
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
