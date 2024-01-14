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
    public static class LookUpExtensions
    {


        public static VmLookUp ToModel(this LookUp target)
        {
            var model = new VmLookUp();
            model.Id = target.Id;
            model.Status = target.Status;
           

            return model;
        }
    }
    public class VmLookUp
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        public string? Status { get; set; }

       
    }
}
