using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_min_entity.Entidades;

public record Fornecedor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(name: "cli_id")]
    public int Id {get;set;}

    [Required]
    [MaxLength(99)]
    [Column(name: "cli_nome")]
    public string Nome {get;set;} = default!;

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [MaxLength(20)]
    [Column(name: "cli_telefone")]
    public string Telefone {get;set;} = default!;

    [Column(TypeName = "text")]
    public string Observacao { get; set; } = default!;
    
}