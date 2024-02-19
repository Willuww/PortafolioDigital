namespace PortafolioJBR.Servicios
{
    public class ServicioUnico
    {
        public Guid ObtenerGuid { get; set; } 
        public ServicioUnico() 
        { 
        ObtenerGuid = Guid.NewGuid();
        }  
    }
    public class ServicioDelimitado
    {
        public Guid ObtenerGuid { get; set; }
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid();
        }
    }
    public class ServicioTransitorio
    {
        public Guid ObtenerGuid { get; set; }
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid();
        }
    }
}
