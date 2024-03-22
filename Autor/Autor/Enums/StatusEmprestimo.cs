using System.ComponentModel;

namespace Autor.Enums
{
   
        public enum StatusEmprestimo
        {
            [Description("Disponível")]
            Disponível = 1,
            [Description("Aguardando Retirada")]
            AguardandoRetirada = 2,
            [Description("Emprestado")]
            Emprestado = 3
        }
    
}
