namespace ApiExercicio.Models
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public string EnderecoEntrega { get; set;}
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
