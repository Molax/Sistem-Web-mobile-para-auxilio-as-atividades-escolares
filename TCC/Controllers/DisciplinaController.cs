using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;

namespace TCC.Controllers
{
    public class DisciplinaController : Controller
    {
        //
        // GET: /Disciplina/

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
        public ActionResult Cadastrar(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                var appDisciplina = new DisciplinaAplicacao();
                appDisciplina.Salvar(disciplina);
                return RedirectToAction("Visualizar");
            }
            return View(disciplina);
        }
        public ActionResult Visualizar()
        {
            var appDisciplina = new DisciplinaAplicacao();
            var listadeDisciplina = appDisciplina.ListarTodos();
            return View(listadeDisciplina);
        }
        public ActionResult Editar(int id)
        {
            var appDisciplina = new DisciplinaAplicacao();
            var disciplina = appDisciplina.ListarPorId(id);

            if (disciplina == null)
                return HttpNotFound();

            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                var appDisciplina = new DisciplinaAplicacao();
                appDisciplina.Salvar(disciplina);
                return RedirectToAction("Visualizar");
            }
            return View(disciplina);
        }

        public ActionResult Detalhes(int id)
        {
            var appDisciplina = new DisciplinaAplicacao();
            var disciplina = appDisciplina.ListarPorId(id);

            if (disciplina == null)
                return HttpNotFound();

            return View(disciplina);
        }

        public ActionResult Excluir(int id)
        {
            var appDisciplina = new DisciplinaAplicacao();
            var disciplina = appDisciplina.ListarPorId(id);

            if (disciplina == null)
                return HttpNotFound();

            return View(disciplina);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appDisciplina = new DisciplinaAplicacao();
            appDisciplina.Excluir(id);
            return RedirectToAction("Visualizar");
        }

    }
}
