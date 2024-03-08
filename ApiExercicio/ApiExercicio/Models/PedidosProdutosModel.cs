namespace ApiExercicio.Models
{
    public class PedidosProdutosModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int? ProdutoId { get; set; }
        public virtual ProdutosModel? Produtos { get; set; }
        public int? CategoriaId { get; set; }
        public virtual CategoriasModel? Categorias { get; set; }
    }
}
