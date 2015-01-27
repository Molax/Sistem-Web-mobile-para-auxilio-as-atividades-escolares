using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;
using System.Web.Security;
namespace TCC.Controllers
{
    public class ProfessorController : Controller
    {
        //
        // GET: /Professor/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Professor prof)
        {
            if (ModelState.IsValid)
            {
                var appProf = new ProfessorAplicacao();
                appProf.Salvar(prof);
                Roles.AddUserToRole(prof.login, "professor");
                return RedirectToAction("Visualizar");
            }
            return View(prof);
        }
        public ActionResult Visualizar()
        {
            var appProf = new ProfessorAplicacao();
            var listadeProf = appProf.ListarTodos();
            return View(listadeProf);
        }
        public ActionResult Editar(int id)
        {
            var appProf = new ProfessorAplicacao();
            var prof  = appProf.ListarPorId(id);

            if (prof == null)
                return HttpNotFound();

            return View(prof);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Professor prof)
        {
            if (ModelState.IsValid)
            {
                var appProf = new ProfessorAplicacao();
                appProf.Salvar(prof);
                return RedirectToAction("Visualizar");
            }
            return View(prof);
        }

        public ActionResult Detalhes(int id)
        {
            var appProf = new ProfessorAplicacao();
            var prof = appProf.ListarPorId(id);

            if (prof == null)
                return HttpNotFound();

            return View(prof);
        }

        public ActionResult Excluir(int id)
        {
            var appProf = new ProfessorAplicacao();
            var prof = appProf.ListarPorId(id);

            if (prof == null)
                return HttpNotFound();

            return View(prof);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appProf = new ProfessorAplicacao();
            appProf.Excluir(id);
            return RedirectToAction("Visualizar");
        }

    }
}
