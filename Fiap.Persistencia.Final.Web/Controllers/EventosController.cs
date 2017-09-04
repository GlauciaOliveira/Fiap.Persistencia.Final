using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fiap.Persistencia.Final.Core.Data;
using Microsoft.EntityFrameworkCore;
using Fiap.Persistencia.Final.Core.Models;

namespace Fiap.Persistencia.Final.Web.Controllers
{
    public class EventosController : Controller
    {
        Context db = new Context();
        // GET: Eventos
        public ActionResult Index()
        {
            var result = db.Eventos.Include("Versao").ToList();
            return View(result);
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Eventos entity)
        {
            try
            {
                // TODO: Add insert logic here
                db.Eventos.Add(entity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int id)
        {
            var versoes = db.Versao.ToList();
            ViewBag.ListaVersao = versoes;

            var result = db.Eventos.Where(x => x.IdEvento == id).Include("Versao").FirstOrDefault();
            return View(result);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Eventos entity)
        {
            try
            {
                var teste = ViewBag.ListaVersao;
                // TODO: Add update logic here
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int id)
        {
            var result = db.Eventos.Find(id);
            return View(result);
        }

        // POST: Eventos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Eventos entity)
        {
            var result = db.Eventos.Find(id);
            try
            {
                // TODO: Add delete logic here

                db.Entry(result).State = EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = "Há eventos para esta versão e a mesma não pode ser excluída";
                return View(result);
            }
        }
    }
}