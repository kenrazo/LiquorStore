using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquorStore.DAL.Entities.DatabaseEntities
{
    public class LiquorType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LiquorTypeId { get; set; }
        [MaxLength(50)]
        public string LiquorTypeName { get; set; }
    }
}
