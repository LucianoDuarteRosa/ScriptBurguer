using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvc.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho minimo é de 1 caracter e o máximo é de 50 caracteres")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [Display(Name = "Nome do lanche")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "O tamanho minimo é de 1 caracter e o máximo é de 50 caracteres")]
        [Required(ErrorMessage = "Informe o descrição curta")]
        [Display(Name = "Descrição curta")]
        public string DescricaoCurta { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho minimo é de 1 caracter e o máximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe o descrição detalhada")]
        [Display(Name = "Descrição detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "preço")]
        public decimal Preco { get; set; }

        [StringLength(200, ErrorMessage = "Caminho da imagem normal")]
        [Display(Name = "Caminho da imagem normal")]
        public string ImagemUrl { get; set; }

        [StringLength(200, ErrorMessage = "Caminho da imagem miniatura")]
        [Display(Name = "Caminho da imagem miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Promoção")]
        public bool EmPromocao { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set;}
    }
}
