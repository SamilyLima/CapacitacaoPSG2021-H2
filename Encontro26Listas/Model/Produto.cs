using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro26Listas.Model
{
   public class Produto
    {
        public int ProdutoID { get; set; }

        public int SubCategoriaID { get; set; }

        public int CategoriaID { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInsert { get; set; }

        public Produto() { }
    }
}
