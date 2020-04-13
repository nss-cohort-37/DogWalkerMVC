using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogWalkerMVC.Models.ViewModels
{
    public class NeighborhoodOwnersViewModel
    {
        public string NeighborhoodName { get; set; }

        public int OwnerCount { get; }

        public List<OwnerViewModel> OwnerViewModels { get; set; }

        public List<WalkerViewModel> WalkerViewModels { get; set; }
    }
}
