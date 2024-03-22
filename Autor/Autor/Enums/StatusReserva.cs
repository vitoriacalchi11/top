using System.ComponentModel;

namespace Autor.Enums
{
    public enum StatusReserva
    {
        [Description("Disponível")]
        Disponível = 1,
        [Description("Reservado")]
        Reservado = 2
    }
}
