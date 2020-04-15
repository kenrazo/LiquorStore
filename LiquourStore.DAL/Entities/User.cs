using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquourStore.DAL.Entities
{
    /// <summary>
    /// The user entities
    /// </summary>
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }


    }
}
