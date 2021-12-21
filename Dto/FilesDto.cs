using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BinaryFile.Dto
{
    public class FilesDto
    {
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