using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.DAL.Entities
{
    public class Liquor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiquorId { get; set; }

        public string LiquorName { get; set; }
        public string LiquorType  { get; set; }

    }
}
