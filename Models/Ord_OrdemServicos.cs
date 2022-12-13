using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecGas.Models
{
    public class Ord_OrdemServicos
    {

        #region "Campos"
        [Key]
        public int Ord_OrdemId { get; set; }

        public int Ord_NumeroOrdem { get; set; }

        public DateTime Ord_DataAbertura { get; set; }

        public int CodigoClienteId { get; set; }

        public Cli_Clientes Cliente { get; set; }

        public string Ord_Modelo { get; set; }

        public string Ord_Detalhes { get; set; }

        public string Ord_Diagnostico { get; set; }

        public string Ord_Solucao { get; set; }

        public string Ord_PecasTrocadas { get; set; }

        public string Ord_ValorServico { get; set; }

        public string Ord_ValorPeca { get; set; }

        public string Ord_ValorTotal { get; set; }





        #endregion

    }
}
