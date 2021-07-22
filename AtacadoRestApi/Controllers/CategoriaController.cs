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
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public List<CategoriaPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();

            List<CategoriaPoco> categoriasPoco = contexto.Categorias.Select(
                novo => new CategoriaPoco()
                {
                    catid = novo.catid,
                    descricao = novo.descricao,
                    dataInclusao = novo.datainsert
                }).ToList();

            return categoriasPoco;
        }

        // GET: api/Categoria/5
        public CategoriaPoco Get(int id)
        {
            AtacadoModel contexto = new AtacadoModel();

            CategoriaPoco categoriaPoco = (
                 from novo in contexto.Categorias
                 where novo.catid == id
                 select new CategoriaPoco()
                 {
                     catid = novo.catid,
                     descricao = novo.descricao,
                     dataInclusao = novo.datainsert
                 }).FirstOrDefault();

            return categoriaPoco;
        }

        // POST: api/Categoria
        public CategoriaPoco Post([FromBody] CategoriaPoco poco)
        {
            categoria categoria = new categoria();
            categoria.descricao = poco.descricao;
            categoria.datainsert = DateTime.Now;

            AtacadoModel contexto = new AtacadoModel();
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;

        }

        // PUT: api/Categoria/5
        public CategoriaPoco Put(int id, [FromBody] CategoriaPoco poco)
        {
            AtacadoModel contexto = new AtacadoModel();
            categoria categoria = contexto.Categorias.SingleOrDefault(reg => reg.catid == id);
            categoria.descricao = poco.descricao;
            contexto.Entry<categoria>(categoria).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;
        }

        // DELETE: api/Categoria/5
        public CategoriaPoco Delete(int id)
        {
            AtacadoModel contexto = new AtacadoModel();
            categoria categoria = contexto.Categorias.SingleOrDefault(reg => reg.catid == id);
            contexto.Entry<categoria>(categoria).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;


        }
    }
}
