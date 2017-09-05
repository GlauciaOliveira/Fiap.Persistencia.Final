using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Persistencia.Final.Core.Data;
using Fiap.Persistencia.Final.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Persistencia.Final.Web.Controllers
{
    public class VersaoController : Controller
    {
        //Context db = new Context();
        Core.Repository.Versao contextVersion = new Core.Repository.Versao(new Context());

        // GET: Versao
        public ActionResult Index()
        {
            var result = contextVersion.Listar();

            return View(result);
        }

        // GET: Versao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Versao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Versao entity)
        {
            try
            {
                contextVersion.Incluir(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Versao/Edit/5
        public ActionResult Edit(int id)
        {
            var result = contextVersion.Buscar(id);
            return View(result);
        }

        // POST: Versao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Versao entity)
        {
            try
            {
                contextVersion.Atualizar(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Versao/Delete/5
        public ActionResult Delete(int id)
        {
            var result = contextVersion.Buscar(id);
            return View(result);
        }

        // POST: Versao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Versao entity)
        {
            var result = contextVersion.Buscar(id);
            try
            {
                // TODO: Add delete logic here

                contextVersion.Remover(result);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.message = "Há eventos para esta versão e a mesma não pode ser excluída";
                return View(result);
            }
        }
    }
}