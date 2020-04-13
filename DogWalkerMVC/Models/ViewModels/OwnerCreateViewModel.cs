using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogWalkerMVC.Models.ViewModels
{
    public class OwnerCreateViewModel
    {
        public int OwnerId { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        [MinLength(3, ErrorMessage = "Address should be at least 3 characters")]
        public string Address { get; set; }

        [Display(Name = "Neighborhood Name")]
        [Required]
        public int NeighborhoodId { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { get; set; }
        public List<SelectListItem> NeighborhoodOptions { get; set; }
    }
}
