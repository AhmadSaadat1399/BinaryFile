using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Files
{
     public class Files
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int DocumentId { get; set; }
          [MaxLength(100)]
          public string Name { get; set; }
          [MaxLength(100)]
          public string FileType { get; set; }
          [MaxLength]
          public Byte[] DataFiles { get; set; }
          public DateTime? CreatedOn { get; set; }

     }
}