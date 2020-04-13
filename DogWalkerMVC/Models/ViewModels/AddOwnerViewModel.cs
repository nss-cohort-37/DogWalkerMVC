using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogWalkerMVC.Models.ViewModels
{
    public class AddOwnerViewModel
    {

        public int OwnerId { get; set; }
        [Display (Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        [Display(Name = "Neighborhood")]
        public int NeighborhoodId { get; set; }

        public List<SelectListItem> NeighborhoodOptions { get; set; }
    }
}
