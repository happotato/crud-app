using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApp.Models
{
    public sealed class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PK_Estado { get; set; }

        [StringLength(2)]
        public string Sigla  { get; set; }

        [StringLength(100)]
        public string Nome   { get; set; }
    }
}
