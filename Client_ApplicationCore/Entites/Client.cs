using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

namespace Client_Infrustructure
{
    [Table("Client")]
    public partial class Client
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateofBirth { get; set; }
        public int? MaritalStatus { get; set; }
        [StringLength(50)]
        public string? MobileNumber { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public string? Image { get; set; }

        [ForeignKey(nameof(MaritalStatus))]
        [InverseProperty(nameof(LookUp.Clients))]
        public virtual LookUp? MaritalStatusNavigation { get; set; }
    }
}
