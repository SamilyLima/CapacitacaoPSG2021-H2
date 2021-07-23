using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços para a tabela UnidadesFederação.
    /// </summary>
    public class UnidadesFederacaoController : ApiController
    {
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<UnidadesFederacaoPoco>))]
        public List<UnidadesFederacaoPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();

            List<UnidadesFederacaoPoco> unidadesPoco = contexto.Estados.Select(
               novo => new UnidadesFederacaoPoco()
               {
                   UFID = novo.UFID,
                   Descricao = novo.Descricao,
                   SiglaUF = novo.SiglaUF,
                   RegiaoID = novo.RegiaoID,
                   DataInclusao = novo.datainsert
               }).ToList();

            return unidadesPoco;
        }

        /// <summary>
        /// Obter registro baseado na chave primária.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public UnidadesFederacaoPoco Get(int id)
        {

            AtacadoModel contexto = new AtacadoModel();

            UnidadesFederacaoPoco unidadePoco = (
                from novo in contexto.Estados
                where novo.UFID == id
                select new UnidadesFederacaoPoco()
                {
                    UFID = novo.UFID,
                    Descricao = novo.Descricao,
                    SiglaUF = novo.SiglaUF,
                    RegiaoID = novo.RegiaoID,
                    DataInclusao = novo.datainsert
                }).FirstOrDefault();


            return unidadePoco;

        }

        /// <summary>
        /// Criar um novo registro na tabela.
        /// </summary>
        /// <param name="poco">Registro a ser criado.</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public UnidadesFederacaoPoco Post([FromBody] UnidadesFederacaoPoco poco)
        {
            UnidadesFederacao unidadeFederacao = new UnidadesFederacao();
            unidadeFederacao.Descricao = poco.Descricao;
            unidadeFederacao.SiglaUF = poco.SiglaUF;
            unidadeFederacao.RegiaoID = poco.RegiaoID;
            unidadeFederacao.datainsert = DateTime.Now;

            AtacadoModel contexto = new AtacadoModel();
            contexto.Estados.Add(unidadeFederacao);
            contexto.SaveChanges();

            UnidadesFederacaoPoco novoPoco = new UnidadesFederacaoPoco();

            novoPoco.UFID = unidadeFederacao.UFID;
            novoPoco.Descricao = unidadeFederacao.Descricao;
            novoPoco.SiglaUF = unidadeFederacao.SiglaUF;
            novoPoco.RegiaoID = unidadeFederacao.RegiaoID;
            novoPoco.DataInclusao = unidadeFederacao.datainsert;

            return novoPoco;

         }

        /// <summary>
        /// Alterar um registro da tabela.
        /// </summary>
        /// <param name="id">Chave primária do registro.</param>
        /// <param name="poco">Registro a ser alterado.</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public UnidadesFederacaoPoco Put(int id, [FromBody] UnidadesFederacaoPoco poco)
        {

            AtacadoModel contexto = new AtacadoModel();
            UnidadesFederacao unidadeFederacao = contexto.Estados.SingleOrDefault(reg => reg.UFID == id);
            unidadeFederacao.Descricao = poco.Descricao;
            unidadeFederacao.SiglaUF = poco.SiglaUF;
            contexto.Entry<UnidadesFederacao>(unidadeFederacao).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            UnidadesFederacaoPoco novoPoco = new UnidadesFederacaoPoco();
            novoPoco.UFID = unidadeFederacao.UFID;
            novoPoco.Descricao = unidadeFederacao.Descricao;
            novoPoco.RegiaoID = unidadeFederacao.RegiaoID;
            novoPoco.DataInclusao = unidadeFederacao.datainsert;

            return novoPoco;

        }

        /// <summary>
        /// Excluir um reistro de uma tabela.
        /// </summary>
        /// <param name="id">Chave primária do registro.</param>
        [HttpDelete]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public void Delete(int id)
        {


        }
    }
}
