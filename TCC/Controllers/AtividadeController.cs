using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;
using WebMatrix.WebData;
using PagedList;

namespace TCC.Controllers
{

    public class AtividadeController : Controller
    {
        //
        // GET: /Atividade/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Visualizar()
        {
            var appAtividade = new AtividadeAplicacao();
            var listadeAtividades = appAtividade.ListarTodos();
            return View(listadeAtividades);
        }
        public ActionResult VisualizaScore()
        {
            var appAtividade = new AtividadeAplicacao();
            var model = new Atividade();
            model.score = appAtividade.listascore();
            return View(model.score);
        }
        public ActionResult AtividadeAluno()
        {
            var userid = WebSecurity.CurrentUserId;
            var appAtividade = new AtividadeAplicacao();
            var listadeAtividades = appAtividade.listaporAluno(userid);
            return View(listadeAtividades);
        }

        public ActionResult Cadastrar()
        {
            var appAtividade = new AtividadeAplicacao();
            var model = new Atividade();
            model.Turma = appAtividade.listaTurma();

            return View(model);
        }


        public ActionResult CarregaAtividade(int? page, int id)
        {
            var appAtividade = new AtividadeAplicacao();

            List<Questao> listadaQuestoes;
            listadaQuestoes = appAtividade.listaQuestao(id);
            int pageSize = 1;
            int pageNumber = (page ?? 1);

            PagedList<Questao> model = new PagedList<Questao>(listadaQuestoes, pageNumber, pageSize);
            return View(model);
        }


        public JsonResult Cadastrar1(string descricao, string ano, string estado, string turma)
        {
            var appAtividade = new AtividadeAplicacao();

            Atividade _atividade = new Atividade();
            _atividade.descricao = descricao;
            _atividade.ano = DateTime.Parse(ano);
            _atividade.estado = char.Parse(estado);
            _atividade.idTurma = appAtividade.buscaTurma(turma);
            _atividade.turma = turma;
            appAtividade.Salvar(_atividade);
            string msg = "";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public JsonResult postResposta(string opc, string questao, string atividade, string aluno, string cont)
        {
            var appResposta = new RespostaAplicacao();
            RespostaAluno _resposta = new RespostaAluno();
            Score _score = new Score();
            _resposta.idAluno = WebSecurity.CurrentUserId;
            _resposta.idQuestao = int.Parse(questao);
            _resposta.idResposta = int.Parse(opc);
            _score.idAluno = WebSecurity.CurrentUserId;
            _score.idAtividade = int.Parse(atividade);
            var listopc = new Opcao();
            var x = appResposta.listaOpcao(_resposta.idQuestao);
            int qual = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i].opcaoCorreta == 'S')
                {
                    qual = i;
                }

            }


            //if (qual == _resposta.idResposta)
            //{

            //    _score.score = 1;

            //}
            //else
            //{
            //    _score.score = 0;
            //}


            appResposta.Salvar(_resposta);
            string msg = "";
            return Json(msg, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Editar(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListarPorId(id);

            if (atividade == null)
                return HttpNotFound();

            return View(atividade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                var appAtividade = new AtividadeAplicacao();
                appAtividade.Salvar(atividade);
                return RedirectToAction("Visualizar");
            }
            return View(atividade);
        }

        public ActionResult Detalhes(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListarPorId(id);

            if (atividade == null)
                return HttpNotFound();

            return View(atividade);
        }

        public ActionResult Excluir(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListarPorId(id);

            if (atividade == null)
                return HttpNotFound();

            return View(atividade);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            appAtividade.Excluir(id);
            return RedirectToAction("Visualizar");
        }

    }
}
