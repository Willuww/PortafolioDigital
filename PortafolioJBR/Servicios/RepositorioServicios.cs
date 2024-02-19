using PortafolioJBR.Infraestructura;
using PortafolioJBR.Models;

namespace PortafolioJBR.Servicios
{
    public class RepositorioServicios : IRepositorioServicios
    {
        
        public List<Proyecto> GetPtoyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto{ Titulo = "Amazon", Descripcion="E-Commerce desarrollado en Net Core", Link="https://amazon.com", ImagenUrl="/img/Amazon.png"},
                new Proyecto{ Titulo="Reddit", Descripcion="Administracion y Desarrollo de Envio de Mails", Link="https://reddit.com", ImagenUrl="/img/reddit.png"},
                new Proyecto{ Titulo="Mercado Libre", Descripcion="E-Commerce con implementacion de JavaScript", Link="https://mercadolibre.com.mx", ImagenUrl="/img/mercadolibre.jpg"},
                new Proyecto{ Titulo="Microsof", Descripcion="Plataforma de aprendizaje Big-Learn", Link="https://microsoft.com", ImagenUrl="/img/microsoft.jpg"},
            };
        }
        
    }
}
