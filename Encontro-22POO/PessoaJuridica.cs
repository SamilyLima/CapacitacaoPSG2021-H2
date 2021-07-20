using System;
using System.Collections.Generic;
using System.Text;

namespace Encontro_22POO
{
    public class PessoaJuridica : Cliente
    {
       
            private string razaoSocial;

            private string endereco;

            private string cnpj;

            public string RazaoSocial { get => this.razaoSocial; set => this.razaoSocial = value; }
            public string Endereco { get => this.endereco; set => this.endereco = value; }
            public string CNPJ { get => this.cnpj; set => this.cnpj = value; }

            public PessoaJuridica() : base()
            { }

            public PessoaJuridica(
                int codigoCliente,
                string razaoSocial,
                string endereco,
                string cnpj,
                DateTime dataInclusao)
                : base(codigoCliente, dataInclusao)
            {
                this.razaoSocial = razaoSocial;
                this.endereco = endereco;
                this.cnpj = cnpj;
            }

        }
    }

