using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecGas.Models
{
    public class Cli_Clientes
    {
        #region "Campos"

        [Key]
        public int CodigoClienteId { get; set; }

        public string Cli_Nome { get; set; }

        public string Cli_CNPJ { get; set; }

        public string Cli_Endereco { get; set; }

        public string Cli_Telefone { get; set; }

        public string Cli_Email { get; set; }
        
        public ICollection<Ord_OrdemServicos> Ord_OrdemServicos { get; set; }

        #endregion
    }
}
