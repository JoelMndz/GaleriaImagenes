using Aplicacion.Dominio;
using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Caracteristicas
{
    public class GetImages
    {
        public Contexto contexto { get; set; }
        public GetImages(Contexto contexto) {
            this.contexto = contexto;
        }

        public async Task<IReadOnlyCollection<Image>> Run()
        {
            return await contexto.Images.ToArrayAsync();
        }
    }
}
