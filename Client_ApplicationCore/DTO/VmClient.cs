using Client_Infrustructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_ApplicationCore.DTO
{
    public static class ClientExtensions
    {


        public static VmClient ToModel(this Client target)
        {
            var model = new VmClient();
            model.Id = target.Id;
            model.FirstName = target.FirstName;
            model.LastName = target.LastName;
            model.DateofBirth = target.DateofBirth;
            model.MaritalStatus = target.MaritalStatus;
            model.MobileNumber = target.MobileNumber;
            model.Email = target.Email;
            model.Image = target.Image;
            return model;
        }
    }
    public class VmClient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string? LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateofBirth { get; set; }
        public int? MaritalStatus { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11)]
        public string? MobileNumber { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string? Email { get; set; }
        public string? Image { get; set; }
        public List<LookUp> MaritalStatusList { get; set; }
       // public LookUp LookUp { get; set; }

    }
}
