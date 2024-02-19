using PortafolioJBR.Models;

namespace PortafolioJBR.Infraestructura
{
    public interface IServiceEmailSendGrid
    {
        Task Enviar(ContactoVM contactoVM);
    }
}
