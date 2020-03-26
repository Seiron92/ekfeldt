using Microsoft.AspNetCore.Http;
using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project.ViewModels
{
    public class ImagesViewModel
    {
        public int ImageId { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Bildadress")]
        public string ImageAdress { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Bildtext")]
        public string ImageText { get; set; }
        [DisplayName("Herobild")]
        public bool HeroImage { get; set; }
        [DisplayName("Planlösning")]
        public string FloorPlan { get; set; }
        public int HomeIds { get; set; }
        public Homes Homes { get; set; }

        public IFormFile Photo { get; set; }
    }
}
