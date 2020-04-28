using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiquorStore.DAL.Entities.DatabaseEntities
{
    public class Liquor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiquorId { get; set; }

        public string LiquorName { get; set; }
        public int LiquorTypeId  { get; set; }
        public LiquorType LiquorType { get; set; }

    }
}
