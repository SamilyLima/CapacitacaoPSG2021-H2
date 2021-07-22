using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtacadoRestApi.Controllers
{
    public class UnidadesFederacaoController : ApiController
    {
        // GET: api/UnidadesFederacao
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

        // GET: api/UnidadesFederacao/5
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

        // POST: api/UnidadesFederacao
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

        // PUT: api/UnidadesFederacao/5
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

        // DELETE: api/UnidadesFederacao/5
        public void Delete(int id)
        {


        }
    }
}
