using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
    }
}
