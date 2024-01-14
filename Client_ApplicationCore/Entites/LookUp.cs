using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace Client_Infrustructure
{
    [Table("LookUp")]
    public partial class LookUp
    {
        public LookUp()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }

        [InverseProperty(nameof(Client.MaritalStatusNavigation))]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
