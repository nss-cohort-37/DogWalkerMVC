using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWalkerMVC.Models.ViewModels
{
    public class HomepageViewModel
    {
        public List<TopWalkerViewModel> TopWalkers { get; set; }
        public string TotalWalkTime { get; set; }
        public List<Dog> Dogs { get; set; }
        public DateTime Today { get; set; }
    }
}
