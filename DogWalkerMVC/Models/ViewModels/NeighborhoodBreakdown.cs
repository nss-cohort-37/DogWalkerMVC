using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogWalkerMVC.Models.ViewModels
{
    public class NeighborhoodBreakdown
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Walkers")]
        public int WalkerCount { get; set; }
    }
}
