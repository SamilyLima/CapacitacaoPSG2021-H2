using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro26Listas.Model
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInsert { get; set; }

        public Categoria() { }

        public List<SubCategoria> SubCategorias { get; set; }
    }
}
