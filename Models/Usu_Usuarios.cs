using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecGas.Models
{
    public class Usu_Usuarios
    {

        #region "Campos"

            [Key]
            public int Usu_Id { get; set; }

            public string Usu_Nome { get; set; }

            public string Usu_Email { get; set; }

            public string Usu_Senha { get; set; }

        #endregion

    }
}
