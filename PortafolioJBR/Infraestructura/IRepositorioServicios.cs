using PortafolioJBR.Models;

namespace PortafolioJBR.Infraestructura
{
    public interface IRepositorioServicios
    {
        List<Proyecto> GetPtoyectos();
    }
}
