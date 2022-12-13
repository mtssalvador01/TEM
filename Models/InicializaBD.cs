using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEM.Models;

namespace TecGas.Models
{
    public class InicializaBD
    {
        public static void Initialize( Context context)
        {

            context.Database.EnsureCreated();

            #region "Cli_Cliente 
            if (context.Cli_Clientes.Any())
            {
                return;
            }

            var Cli_Clientes = new Cli_Clientes[]
            {
                new Cli_Clientes{Cli_Nome ="MAAP Hotel", Cli_CNPJ="052.321.654/0001-02", Cli_Endereco="Avenida Julio Prestes, 81", Cli_Telefone="(12)99198-8765", Cli_Email="maaphotel@gmail.com"},

            };

            foreach (var item in Cli_Clientes)
            {
                context.Cli_Clientes.Add(item);
            }

            context.SaveChanges();
            #endregion

            #region Ord_OrdemServicos

            if (context.Ord_OrdemServicos.Any())
            {
                return;
            }

            var Ord_OrdemServicos = new Ord_OrdemServicos[]
            {
                new Ord_OrdemServicos{Ord_NumeroOrdem =1, CodigoClienteId = 1 },

            };

            foreach (var item in Ord_OrdemServicos)
            {
                context.Ord_OrdemServicos.Add(item);
            }

            context.SaveChanges();
            #endregion

            #region Usu_Usuarios

            if (context.Usu_Usuarios.Any())
            {
                return;
            }

            var Usu_Usuarios = new Usu_Usuarios[]
            {
                new Usu_Usuarios{Usu_Nome="Matheus", Usu_Email="matheus.salvador@gmail.com", Usu_Senha="123" },

            };

            foreach (var item in Usu_Usuarios)
            {
                context.Usu_Usuarios.Add(item);
            }

            context.SaveChanges();
            #endregion
        }
    }
}   
