using Microsoft.AspNetCore.Mvc;
using Fiap.Persistencia.Final.Core.Data;
using Fiap.Persistencia.Final.Core.Models;
using Fiap.Persistencia.Final.Web.Model;
using AutoMapper;
using System;

namespace Fiap.Persistencia.Final.Web.Controllers
{
    public class EventosController : Controller
    {
        Core.Repository.Eventos context = new Core.Repository.Eventos(new Context());
        Core.Repository.Versao contextVersion = new Core.Repository.Versao(new Context());

        // GET: Eventos
        public ActionResult Index()
        {
            var result = context.Listar();

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
            var listaVersao = contextVersion.Listar();
            
            EventosViewModel model = new EventosViewModel()
            {
                ListaVersoes = listaVersao
            };

            return View(model);
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Eventos entity)
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<EventosViewModel, Eventos>();
                    cfg.CreateMap<Eventos, EventosViewModel>();
                });

                var entidade = Mapper.Map<Eventos>(entity);
                context.Incluir(entidade);                

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
            var listaVersao = contextVersion.Listar();
            var evento = context.Buscar(id);
            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EventosViewModel, Eventos>();
                cfg.CreateMap<Eventos, EventosViewModel>();
            });

            var entidade = Mapper.Map<EventosViewModel>(evento);
            entidade.ListaVersoes = listaVersao;

            return View(entidade);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventosViewModel entity)
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<EventosViewModel, Eventos>();
                    cfg.CreateMap<Eventos, EventosViewModel>();
                });

                var entidade = Mapper.Map<Eventos>(entity);
                context.Atualizar(entidade);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int id)
        {
            var result = context.Buscar(id);

            return View(result);
        }

        // POST: Eventos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Eventos entity)
        {
            var result = context.Buscar(id);
            try
            {

                context.Remover(result);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.message = "Há eventos para esta versão e a mesma não pode ser excluída";
                return View(result);
            }
            return View();
        }
    }
}