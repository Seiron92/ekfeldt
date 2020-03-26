using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Homes
    {
        [Key]

        public int HomeId { get; set; }
        public DateTime PublishDate { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Gata")]
        public string Street { get; set; }
        [DisplayName("Stad")]
        public string City { get; set; }
        [DisplayName("Kommun")]
        public string County { get; set; }
        [DisplayName("Postnummer")]
        public string PostalCode { get; set; }
        [DisplayName("Område")]
        public string District { get; set; }
        [DisplayName("Lägenhetsnummer")]
        public string AppartmentNumber { get; set; }
        [DisplayName("Förening")]
        public string Society { get; set; }
        [DisplayName("Antal rum")]
        public int Room { get; set; }
        [DisplayName("Våning")]
        public int Floor { get; set; }
        [DisplayName("Hiss")]
        public string Elevator { get; set; }
        [DisplayName("Fastighetbeteckning")]
        public string Dop { get; set; }
        [DisplayName("Pris")]
        public int Price { get; set; }
        [DisplayName("Budgivning")]
        public bool Bidding { get; set; }
        [DisplayName("Bostadstyp")]
        public string HomeType { get; set; }
        [DisplayName("Upplåtelseform")]
        public string Tow { get; set; }
        [DisplayName("Boarea")]
        public int LivingArea { get; set; }
        [DisplayName("Biarea")]
        public int BiArea { get; set; }
        [DisplayName("Tomtarea")]
        public int GardenArea { get; set; }
        [DisplayName("Byggnadssätt")]
        [Column(TypeName = "ntext")]
        public string BuildningSystem { get; set; }
        [DisplayName("Renoveringar")]
        [Column(TypeName = "ntext")]
        public string Renovations { get; set; }
        [DisplayName("Andra byggnader")]
        [Column(TypeName = "ntext")]
        public string OtherBuildnings { get; set; }
        [DisplayName("Boarea kommentarer")]
        [Column(TypeName = "ntext")]

        public string LivingSpaceComment { get; set; }
        [DisplayName("Parkering")]
        [Column(TypeName = "ntext")]
        public string Parking { get; set; }

        [DisplayName("TV och Internet")]
        [Column(TypeName = "ntext")]
        public string TvInternet { get; set; }
        [DisplayName("Värme och ventilation")]
        [Column(TypeName = "ntext")]
        public string HeatVentilation { get; set; }
        [DisplayName("Byggnadsår")]

        public int BuildningYear { get; set; }
        [DisplayName("Månadsavgift")]

        public int MounthlyFee { get; set; }
        [DisplayName("Andel av föreningen")]
        public int PartOfSociety { get; set; }
        [DisplayName("Pantsättning")]
        public bool PawnBroking { get; set; }
        [DisplayName("Om föreningen")]
        [Column(TypeName = "ntext")]
        public string AboutSociety { get; set; }
        [DisplayName("Gemensamma utrymmen")]
        [Column(TypeName = "ntext")]
        public string CommonAreas { get; set; }
        [DisplayName("Överlåtelseavgift")]
        public int TransactionFee { get; set; }
        [DisplayName("Överlåtelseavgift betalas av")]
        public string TransactionFeePaidBy { get; set; }
        [DisplayName("Driftskostnad (per år)")]
        public int OperationCost { get; set; }
        [DisplayName("Typkod")]
        public string TypeCode { get; set; }
        [DisplayName("Taxeringsvärde")]
        public int TaxValue { get; set; }
        [DisplayName("Taxeringsvärde byggnad")]
        public int TaxValueProperty { get; set; }
        [DisplayName("Taxeringsvärde mark")]
        public int TaxValueLand { get; set; }
        [DisplayName("Taxeringsår")]
        public int TaxYear { get; set; }
        [DisplayName("Pantbrev")]
        public string PawnLetters { get; set; }
        [DisplayName("Uppvärmningskostand (per år)")]
        public int Heating { get; set; }
        [DisplayName("Elförbrukning (per år)")]
        public int PowerComsumption { get; set; }
        [DisplayName("Elkostnad (per år)")]
        public int EnergyCosts { get; set; }
        [DisplayName("Personer i hushållet")]
        public int NumberOfOccupants { get; set; }
        [DisplayName("Kostnad för vatten och avlopp (per år)")]
        public int WaterAndSewedge { get; set; }
        [DisplayName("Kostnad för renhållning (per år)")]
        public int Cleaning { get; set; }
        [DisplayName("Försäkringskostnad")]
        public int Insurance { get; set; }
        [DisplayName("Kommerntar om försäkring (ex. försäkringsbolag)")]
        public string InsuranceComment { get; set; }
        [DisplayName("Energideklaration utförd")]
        public bool EnergyDeclaration { get; set; }
        [DisplayName("Energiprestanda (kWh/kvm/år)")]
        public int EnergyPerfomance { get; set; }
        [DisplayName("Energiklass")]
        public string EnergyClass { get; set; }
        [DisplayName("Specifik energianvändning (kWh/kvm/år)")]
        public int SpecificEnergyUsage { get; set; }
        [DisplayName("Deklarationsdatum")]
        public DateTime? DeclarationDate { get; set; }
        [DisplayName("Deklaration utförd av")]
        public string Inspector { get; set; }
        [DisplayName("Samanfattande rubrik")]
        public string SummaryHeading { get; set; }
        [DisplayName("Sammanfattning")]
        [Column(TypeName = "ntext")]
        public string Summary { get; set; }
        [DisplayName("Information")]
        [Column(TypeName = "ntext")]
        public string Information { get; set; }
        [DisplayName("Övriga rättigheter och belastningar")]
        [Column(TypeName = "ntext")]
        public string OtherRightsAndLiabilities { get; set; }
        [NotMapped]
        public ICollection<Broker> Brokers { get; set; }

        public int BrokerId { get; set; }
        public bool deleted { get; set; }
        [NotMapped]
        public Image Image { get; }
        public string ImageAddress { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        [NotMapped]
        public string FullAddress { get { return this.Street + " " + this.City; } }
    }

    public class Image
    {
        [Key]
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
        [NotMapped]
        public IFormFile Photo { get; set; }
    }


    public class Bidding
    {
        [Key]
        public int BiddingId { get; set; }

        public int HomeId { get; set; }
        public Homes Homes { get; set; }

    }
    public class Demonstration
    {
        [Key]
        public int DemonstrationId { get; set; }
        [DisplayName("Tid")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime BookingTime { get; set; }
        [DisplayName("Datum")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }
        [DisplayName("Objekt")]
        public int HomeId { get; set; }

        [NotMapped]
        public string DateNTime { get { return "Datum: " + this.BookingDate + " kl " + this.BookingTime; } }

    }
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Gata")]
        public string Street { get; set; }
        [DisplayName("Stad")]
        public string City { get; set; }
        [DisplayName("Postnummer")]
        public string PostalCode { get; set; }
        [DisplayName("Budgivare")]
        public bool Bidder { get; set; }
        [DisplayName("Ska på visning")]
        public bool Viewer { get; set; }
        [DisplayName("Telefonnummer")]
        public string PhoneNUmber { get; set; }
        public string Email { get; set; }
        [DisplayName("Visnings Id")]
        public int? DemonstrationId { get; set; }
        [DisplayName("Budgivnings Id")]
        public int? BiddingIds { get; set; }
        [DisplayName("Objekt Id")]
        public int HomeId { get; set; }
        public bool deleted { get; set; }
        [DisplayName("Summa")]
        public int? Amount { get; set; }
        [DisplayName("Datum")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [DisplayName("Tid")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Time { get; set; }

        public int Alias { get; set; }

        public Homes Homes { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

    }


    public class Broker
    {
        [Key]
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

    public class ContactFormModel
    {
        [Required(ErrorMessage = "Du måste fylla i ett förnamn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Du måste fylla i en E-postadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Du måste fylla i en gata")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Du måste fylla i en stad")]
        public string City { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett postnummer")]
        public string PostalCode { get; set; }
        [Required]
        public string Subject { get; set; }

        [BindProperty]
        public ContactFormModel Contact { get; set; }
    }
}
