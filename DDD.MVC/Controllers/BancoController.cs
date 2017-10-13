using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DDD.Aplicacion.Interface;
using DDD.Dominio.Entidad;
using DDD.MVC.ViewModels;

namespace DDD.MVC.Controllers
{
    public class BancoController : Controller
    {
        //private readonly BancoRepository _bancoRepository = new BancoRepository();

        // GET: Banco
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        var bancoViewModel = Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoViewModel>>(_bancoRepository.GetAll());
        //        return View(bancoViewModel);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("In Main catch block. Caught: {0}", e.Message);
        //        Console.WriteLine("Inner Exception is {0}", e.InnerException);
        //    }
        //    return RedirectToAction("Index");
        //}

        //// GET: Banco/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Banco/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Banco/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BancoViewModel banco)
        //{
        //   if(ModelState.IsValid)
        //   {
        //       var bancoDomain = Mapper.Map<BancoViewModel, Banco>(banco);
        //        _bancoRepository.Add(bancoDomain);
        //       return RedirectToAction("Index");
        //   }
        //    return View(banco);
        //}
        private readonly ITipoBancoAppService _tipoBancoApp;
        private readonly IBancoAppService _bancoApp;

        public BancoController(ITipoBancoAppService tipoBancoAppService, IBancoAppService bancoAppService)
        {
            _tipoBancoApp = tipoBancoAppService;
            _bancoApp = bancoAppService;
        }

        public ActionResult Index()
        {
            try
            {
                var bancoViewModel = Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoViewModel>>(_bancoApp.GetAll());
                return View(bancoViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine("In Main catch block. Caught: {0}", e.Message);
                Console.WriteLine("Inner Exception is {0}", e.InnerException);
            }
            return RedirectToAction("Index");
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            var banco = _bancoApp.GetById(id);
            var bancoViewModel = Mapper.Map<Banco, BancoViewModel>(banco);
            return View(bancoViewModel);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            ViewBag.TipoBancoId =new SelectList(_tipoBancoApp.GetAll(),"Id","Name");
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BancoViewModel banco)
        {
            if (ModelState.IsValid)
            {
                var bancoDomain = Mapper.Map<BancoViewModel, Banco>(banco);
                _bancoApp.Add(bancoDomain);
                return RedirectToAction("Index");
            }
            ViewBag.TipoBancoId = new SelectList(_tipoBancoApp.GetAll(), "Id", "Name", banco.TipoBancoId);
            return View(banco);
        }





        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            var banco = _bancoApp.GetById(id);
            var bancoViewModel = Mapper.Map<Banco, BancoViewModel>(banco);

            ViewBag.TipoBancoId = new SelectList(_tipoBancoApp.GetAll(), "ID", "NAME", selectedValue: banco.TipoBancoId);
            return View(bancoViewModel);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(BancoViewModel banco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bancoDomain = Mapper.Map<BancoViewModel, Banco>(banco);
                    _bancoApp.Update(bancoDomain);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {

                    TempData["MessageToClient"] = String.Format("Otro usuario con los mismos permisos ha modificado el registro {0} desde que lo has cargado.  Tus cambios no han sido aplicados.", banco.Name);
                    return RedirectToAction("Index");
                }

            }
            ViewBag.TipoBancoId = new SelectList(_tipoBancoApp.GetAll(), "ID", "NAME", selectedValue: banco.TipoBancoId);
            return View(banco);
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    [Serializable]
    internal class DbUpdateConcurrencyException : Exception
    {
        public DbUpdateConcurrencyException()
        {
        }

        public DbUpdateConcurrencyException(string message) : base(message)
        {
        }

        public DbUpdateConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbUpdateConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
