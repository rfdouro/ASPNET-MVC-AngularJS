using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp01.Models;
using System.Web.Helpers;

namespace MvcApp01.Controllers
{
    public class PessoaController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Pessoa/

        public ActionResult Index()
        {
            //https://msdn.microsoft.com/en-us/library/dn456843(v=vs.113).aspx
            /*System.Data.Common.DbTransaction trans = db.Database.Connection.BeginTransaction()
            trans.Commit();*/

            return View(db.Pessoas.ToList());
        }

        public JsonResult ListaJS(String s)
        {
            if (s != null)
            {
                List<Pessoa> l = db.Pessoas.ToList().FindAll(n => n.nome.StartsWith(s));
                return Json(l, JsonRequestBehavior.AllowGet);
            }
            return Json(db.Pessoas.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJS(long id = 0)
        {
            if (id != null)
            {
                List<Pessoa> l = db.Pessoas.ToList().FindAll(n => n.id==id);
                return Json(l, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Pessoa/Details/5

        public ActionResult Details(long id = 0)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pessoa/Create

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        //
        // GET: /Pessoa/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public String Excluir(long id = 0)
        {
            try
            {
                Pessoa pessoa = db.Pessoas.Find(id);
                db.Pessoas.Remove(pessoa);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
            }
            return "FAIL";
            //return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Pessoa/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}