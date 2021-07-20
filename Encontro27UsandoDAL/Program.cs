using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro27UsandoDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            AtacadoModel crud = new AtacadoModel();

            List<Municipio> municipios = crud.Municipios.ToList();

            Console.WriteLine("Lista de Regiões:");

            foreach (var item in municipios)
            {
                Console.WriteLine("ID: {0} - Descrição: {1}", item.MunicipioID, item.Descricao);
            }
            Console.ReadKey();

        }
    }
}
