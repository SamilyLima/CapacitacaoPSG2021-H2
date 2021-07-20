using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtacadoServicos
{
    public class RegiaoController : ApiController
    {
        // GET api/<controller>
        public List<Regiao> Get()
        {
            AtacadoModel contexto = new AtacadoModel();
            List<Regiao> regioes = contexto.Regioes.ToList();
            return regioes;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}