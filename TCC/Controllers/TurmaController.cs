using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;

namespace TCC.Controllers
{
    public class TurmaController : Controller
    {
        //
        // GET: /Turma/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            var appTurma = new TurmaAplicacao();
            var model1 = new Turma();
            model1.Disciplina = appTurma.listaDisciplina();
            model1.Professor = appTurma.listaProfessor();
            return View(model1);
        }

        public JsonResult Cadastrar1(string disc, string prof, string nome, string ano)
        {
            var appTurma = new TurmaAplicacao();

            Turma _turma = new Turma();
            _turma.nome = nome;
            _turma.idProf = appTurma.buscaProf(prof);
            _turma.idDisciplina = appTurma.buscaDisciplina(disc);
            _turma.ano = Convert.ToDateTime(ano);

            appTurma.Salvar(_turma);
            string msg = "";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Visualizar()
        {
            var appTurma = new TurmaAplicacao();
            var listaTurma = appTurma.ListarTodos();
            return View(listaTurma);
        }
        public ActionResult Editar(int id)
        {
            var appTurma = new TurmaAplicacao();
            var turma = appTurma.ListarPorId(id);

            if (turma == null)
                return HttpNotFound();

            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Turma turma)
        {
            if (ModelState.IsValid)
            {
                var appTurma = new TurmaAplicacao();
                appTurma.Salvar(turma);
                return RedirectToAction("Visualizar");
            }
            return View(turma);
        }

        public ActionResult Detalhes(int id)
        {
            var appTurma = new TurmaAplicacao();
            var turma = appTurma.ListarPorId(id);

            if (turma == null)
                return HttpNotFound();

            return View(turma);
        }

        public ActionResult Excluir(int id)
        {
            var appTurma = new TurmaAplicacao();
            var turma = appTurma.ListarPorId(id);

            if (turma == null)
                return HttpNotFound();

            return View(turma);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appTurma = new TurmaAplicacao();
            appTurma.Excluir(id);
            return RedirectToAction("Visualizar");
        }
    }
}
