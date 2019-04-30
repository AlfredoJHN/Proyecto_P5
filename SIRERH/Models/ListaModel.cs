using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIRERH.Models
{
    public partial class ListaModel
    {
        
        public List<USUARIO> uSUARIO { get; set; }
        public List<TECNOLOGIA> tECNOLOGIA { get; set; }
        public List<VACANTE> vACANTE { get; set; }
    }
}