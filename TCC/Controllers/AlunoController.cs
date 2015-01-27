using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;
using System.Web.Security;
using WebMatrix.WebData;

namespace TCC.Controllers
{
    public class AlunoController : Controller
    {
        //
        // GET: /Aluno/
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Visualizar()
        {
            
            var appAluno = new AlunoAplicacao();
            var listadeAlunos = appAluno.ListarTodos();
            return View(listadeAlunos);
        }

        public ActionResult Cadastrar()
        {
            var appAluno = new AlunoAplicacao();
            var model = new Aluno();
            model.Turma = appAluno.listaTurma();
          
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
              //  var x = ViewData["turma"];
                var appAluno = new AlunoAplicacao();
               // aluno.nascimentoAluno = DateTime.Parse(aluno.nascimentoAluno.ToString("yyyy-MM-dd"));
              
              //  appAluno.Salvar(aluno);
                return RedirectToAction("Visualizar");
            }
            return View(aluno);
        }


        public JsonResult Cadastro1(string turma, string  nome, string tel, string senha, string login, string sexo, string tipo, string datan, string cpf, string end)
        {
            var appAluno = new AlunoAplicacao();

            Aluno _aluno = new Aluno();
            _aluno.cpfAluno = cpf;
            _aluno.enderecoAluno = end;
            _aluno.login = login;
            _aluno.telAluno = tel;
            _aluno.tipo = Convert.ToInt16( tipo);
            _aluno.idTurma = appAluno.buscaTurma(turma);
            _aluno.Nome = nome;
            _aluno.senha = senha;
            _aluno.sexoAluno = sexo;
            _aluno.nascimentoAluno = Convert.ToDateTime(datan);
            _aluno.turma = turma;
          
            appAluno.Salvar(_aluno);
            Roles.AddUserToRole(_aluno.login, "aluno");
            string msg = "";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Editar(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Salvar(aluno);
                return RedirectToAction("Visualizar");
            }
            return View(aluno);
        }

        public ActionResult Detalhes(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        public ActionResult Excluir(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.ListarPorId(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appAluno = new AlunoAplicacao();
            appAluno.Excluir(id);
            return RedirectToAction("Visualizar");
        }

    }
}
