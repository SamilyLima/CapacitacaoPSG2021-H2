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
    public class RegiaoController : ApiController
    {
        // GET: api/Regiao
        public List<RegiaoPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();

            //List<RegiaoPoco> regioesPoco = (
            //    from novo in contexto.Regioes
            //    select new RegiaoPoco()
            //    {
            //        RegiaoID = novo.RegiaoID,
            //        Descricao = novo.Descricao,
            //        SiglaRegiao = novo.SiglaRegiao,
            //        DataInclusao = novo.datainsert
            //    }).ToList();



            //Versão LINQ to Entities.
            List<RegiaoPoco> regioesPoco = contexto.Regioes.Select(
                novo => new RegiaoPoco()
                {
                    RegiaoID = novo.RegiaoID,
                    Descricao = novo.Descricao,
                    SiglaRegiao = novo.SiglaRegiao,
                    DataInclusao = novo.datainsert
                }).ToList();


            //MODO ESPARTANO
            // List<Regiao> regioes = contexto.Regioes.ToList();
            //List<RegiaoPoco> regioesPoco = new List<RegiaoPoco>();
            //foreach (var item in regioes)
            //{
            //    RegiaoPoco novo = new RegiaoPoco();
            //    novo.RegiaoID = item.RegiaoID;
            //    novo.Descricao = item.Descricao;
            //    novo.SiglaRegiao = item.SiglaRegiao;
            //    novo.DataInclusao = item.datainsert;
            //    regioesPoco.Add(novo);
            // }


            return regioesPoco;
        }

        // GET: api/Regiao/5
        public RegiaoPoco Get(int id)
        {
            AtacadoModel contexto = new AtacadoModel();

            RegiaoPoco regiaoPoco = (
                from novo in contexto.Regioes
                where novo.RegiaoID == id
                select new RegiaoPoco()
                {
                    RegiaoID = novo.RegiaoID,
                    Descricao = novo.Descricao,
                    SiglaRegiao = novo.SiglaRegiao,
                    DataInclusao = novo.datainsert
                }).FirstOrDefault();



            //RegiaoPoco regiaoPoco = contexto.Regioes
            //    .Where(reg => reg.RegiaoID == id)
            //    .Select(novo => new RegiaoPoco()
            //    {
            //        RegiaoID = novo.RegiaoID,
            //        Descricao = novo.Descricao,
            //        SiglaRegiao = novo.SiglaRegiao,
            //        DataInclusao = novo.datainsert
            //    }).FirstOrDefault();



            //Modo Espartano, porém prático.
            //Regiao regiao = contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);
            //RegiaoPoco regiaoPoco = new RegiaoPoco()
            //{
            //    RegiaoID = regiao.RegiaoID,
            //    Descricao = regiao.Descricao,
            //    SiglaRegiao = regiao.SiglaRegiao,
            //    DataInclusao = regiao.datainsert
            //};
            return regiaoPoco;
        }

        // POST: api/Regiao
        public RegiaoPoco Post([FromBody] RegiaoPoco poco)
        {
            Regiao regiao = new Regiao();
            regiao.Descricao = poco.Descricao;
            regiao.SiglaRegiao = poco.SiglaRegiao;
            regiao.datainsert = DateTime.Now;

            AtacadoModel contexto = new AtacadoModel();
            contexto.Regioes.Add(regiao);
            contexto.SaveChanges();

            RegiaoPoco novoPoco = new RegiaoPoco();
            novoPoco.RegiaoID = regiao.RegiaoID;
            novoPoco.Descricao = regiao.Descricao;
            novoPoco.SiglaRegiao = regiao.SiglaRegiao;
            novoPoco.DataInclusao = regiao.datainsert;

            return novoPoco;

        }

        // PUT: api/Regiao/5
        public RegiaoPoco Put(int id, [FromBody] RegiaoPoco poco)
        {
            AtacadoModel contexto = new AtacadoModel();
            Regiao regiao = contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);
            regiao.Descricao = poco.Descricao;
            regiao.SiglaRegiao = poco.SiglaRegiao;
            contexto.Entry<Regiao>(regiao).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            RegiaoPoco novoPoco = new RegiaoPoco();
            novoPoco.RegiaoID = regiao.RegiaoID;
            novoPoco.Descricao = regiao.Descricao;
            novoPoco.SiglaRegiao = regiao.SiglaRegiao;
            novoPoco.DataInclusao = regiao.datainsert;

            return novoPoco;
        }

        // DELETE: api/Regiao/5
        public RegiaoPoco Delete(int id)
        {
            AtacadoModel contexto = new AtacadoModel();
            Regiao regiao = contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);
            contexto.Entry<Regiao>(regiao).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();

            RegiaoPoco novoPoco = new RegiaoPoco();
            novoPoco.RegiaoID = regiao.RegiaoID;
            novoPoco.Descricao = regiao.Descricao;
            novoPoco.SiglaRegiao = regiao.SiglaRegiao;
            novoPoco.DataInclusao = regiao.datainsert;

            return novoPoco;
        }
    }
}
