using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.AspNetCore.Http;
using project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project.ViewModels
{
    public class BrokersViewModel
    {

        public int BrokerId { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Telefonnummer")]
        public string Phonenumber { get; set; }
        [Column(TypeName = "ntext")]
        public string Image { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Arbetstitel")]
        public string Title { get; set; }
        [NotMapped]
        public virtual IEnumerable<Broker> Brokers { get; set; }
        [NotMapped]
        public string fullname { get { return this.FirstName + " " + this.LastName; } }
        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
