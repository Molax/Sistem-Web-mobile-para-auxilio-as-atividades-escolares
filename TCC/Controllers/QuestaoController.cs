using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;

namespace TCC.Controllers
{
    public class QuestaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Visualizar()
        {
            var appQuestao = new QuestaoAplicacao();
            var listadeAtividades = appQuestao.ListarTodos();
            return View(listadeAtividades);
        }

        public ActionResult Cadastrar()
        {
            var appQuestao = new QuestaoAplicacao();
            var model = new ViewModelQuestao();

            return View(model);
        }



        public JsonResult Cadastro1(string descricao, string op1,string op2, string op3, string op4, string op5,string opcaoCorreta)
        {
            var appQuestao = new QuestaoAplicacao();
            var appOpcao = new OpcaoAplicacao();
            int OC =int.Parse( opcaoCorreta);
            Opcao _op1 = new Opcao();
            Opcao _op2 = new Opcao();
            Opcao _op3 = new Opcao();
            Opcao _op4 = new Opcao();
            Opcao _op5 = new Opcao();
            Questao _questao = new Questao();
            _questao.descricao = descricao;
            _questao.idAtividade = appQuestao.buscaAtividade("name") ;
            appQuestao.Salvar(_questao);

            _op1.descricao = op1;
            if (OC == 1)
                _op1.opcaoCorreta = 'S';
            else { _op1.opcaoCorreta = 'N'; }
            _op1.idQuestao = appOpcao.buscaQuestao("name");
            appOpcao.Salvar(_op1);

            _op2.descricao = op2;
            if (OC == 2)
                _op2.opcaoCorreta = 'S';
            else { _op2.opcaoCorreta = 'N'; }
            _op2.idQuestao = appOpcao.buscaQuestao("name");
            appOpcao.Salvar(_op2);

            _op3.descricao = op3;
            if (OC == 3)
                _op3.opcaoCorreta = 'S';
            else { _op3.opcaoCorreta = 'N'; }
            _op3.idQuestao = appOpcao.buscaQuestao("name");
            appOpcao.Salvar(_op3);

            _op4.descricao = op4;
            if (OC == 4)
                _op4.opcaoCorreta = 'S';
            else { _op4.opcaoCorreta = 'N'; }
            _op4.idQuestao = appOpcao.buscaQuestao("name");
            appOpcao.Salvar(_op4);

            _op5.descricao = op5;
            if (OC == 5)
                _op5.opcaoCorreta = 'S';
            else { _op5.opcaoCorreta = 'N'; }
            _op5.idQuestao = appOpcao.buscaQuestao("name");
            appOpcao.Salvar(_op5);

            string msg = "";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Excluir(int id)
        {
            var appQuestao = new QuestaoAplicacao();
            var questao = appQuestao.ListarPorId(id);

            if (questao == null)
                return HttpNotFound();

            return View(questao);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appQuestao = new QuestaoAplicacao();
            appQuestao.Excluir(id);
            return RedirectToAction("Visualizar");
        }

    }
}
