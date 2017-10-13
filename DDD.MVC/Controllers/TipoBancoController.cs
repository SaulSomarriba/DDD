using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DDD.Aplicacion.Interface;
using DDD.Dominio.Entidad;
using DDD.MVC.ViewModels;
using DDD.Infra.Data.Repositorios;

namespace DDD.MVC.Controllers
{
    public class TipoBancoController : Controller
    {
        //private readonly TipoBancoRepository _tipoBancoRepository = new TipoBancoRepository();
        //// GET: TipoBanco
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        var tipoBancoViewModel = Mapper.Map<IEnumerable<TipoBanco>, IEnumerable<TipoBancoViewModel>>(_tipoBancoRepository.GetAll());
        //        return View(tipoBancoViewModel);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("In Main catch block. Caught: {0}", e.Message);
        //        Console.WriteLine("Inner Exception is {0}", e.InnerException);
        //    }
        //    return RedirectToAction("Index");
        //}

        //// GET: TipoBanco/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TipoBanco/Create
        //[HttpPost]
        //public ActionResult Create(TipoBancoViewModel tipoBanco)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var tipoBancoDomain = Mapper.Map<TipoBancoViewModel, TipoBanco>(tipoBanco);
        //        _tipoBancoRepository.Add(tipoBancoDomain);
        //        return RedirectToAction("Index");
        //    }
        //    return View(tipoBanco);
        //}



        private readonly ITipoBancoAppService _tipoBancoApp;

        public TipoBancoController(ITipoBancoAppService tipoBancoAppService)
        {
            _tipoBancoApp = tipoBancoAppService;
        }




        // GET: TipoBanco
        public ActionResult Index()
        {
            var tipoBancoViewModel = Mapper.Map<IEnumerable<TipoBanco>, IEnumerable<TipoBancoViewModel>>(_tipoBancoApp.GetAll());
            return View(tipoBancoViewModel);
        }

        //CON LAS MODIFICACIONES DEL CONTROLADOR
        // GET: TipoBanco/Details/5
        public ActionResult Details(int id)
        {
            var tipoBanco = _tipoBancoApp.GetById(id);
            var tipoBancoViewModel = Mapper.Map<TipoBanco, TipoBancoViewModel>(tipoBanco);

            return View(tipoBancoViewModel);
        }


        //GET: TipoBanco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoBanco/Create
        [HttpPost]
        public ActionResult Create(TipoBancoViewModel tipoBanco)
        {
            if (ModelState.IsValid)
            {
                var tipoBancoDomain = Mapper.Map<TipoBancoViewModel, TipoBanco>(tipoBanco);
                _tipoBancoApp.Add(tipoBancoDomain);
                return RedirectToAction("Index");
            }
            return View(tipoBanco);
        }


        // GET: TipoBanco/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoBanco = _tipoBancoApp.GetById(id);
            var tipoBancoViewModel = Mapper.Map<TipoBanco, TipoBancoViewModel>(tipoBanco);

            return View(tipoBancoViewModel);
        }

        // POST: TipoBanco/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoBancoViewModel tipoBanco)
        {
            if (ModelState.IsValid)
            {
                var tipoBancoDominio = Mapper.Map<TipoBancoViewModel, TipoBanco>(tipoBanco);
                _tipoBancoApp.Update(tipoBancoDominio);

                return RedirectToAction("Index");
            }
            return View(tipoBanco);
        }

        // GET: TipoBanco/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoBanco = _tipoBancoApp.GetById(id);
            var tipoBancoViewModel = Mapper.Map<TipoBanco, TipoBancoViewModel>(tipoBanco);
            return View(tipoBancoViewModel);
        }

        // POST: TipoBanco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var tipoBanco = _tipoBancoApp.GetById(id);
            _tipoBancoApp.Remove(tipoBanco);

            return RedirectToAction("Index");
        }
    }
}
