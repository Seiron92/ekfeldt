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
    public class HomesCreateViewModel
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
        [DisplayName("Driftskostnad")]
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
        [DisplayName("Uppvärmningskostand")]
        public int Heating { get; set; }
        [DisplayName("Elförbrukning")]
        public int PowerComsumption { get; set; }
        [DisplayName("Elkostnad")]
        public int EnergyCosts { get; set; }
        [DisplayName("Personer i hushållet")]
        public int NumberOfOccupants { get; set; }
        [DisplayName("Vatten och avlopp")]
        public int WaterAndSewedge { get; set; }
        [DisplayName("Renhållning")]
        public int Cleaning { get; set; }
        [DisplayName("Försäkring")]
        public int Insurance { get; set; }
        [DisplayName("Kommerntar om försäkring")]
        public string InsuranceComment { get; set; }
        [DisplayName("Energideklaration utförd")]
        public bool EnergyDeclaration { get; set; }
        [DisplayName("Energiprestanda")]
        public int EnergyPerfomance { get; set; }
        [DisplayName("Energiklass")]
        public string EnergyClass { get; set; }
        [DisplayName("Specifik energianvändning")]
        public int SpecificEnergyUsage { get; set; }
        [DisplayName("Deklarationsdatum")]
        public DateTime DeclarationDate { get; set; }
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
        public ICollection<Image> Images { get; set; }
        public ICollection<Bidding> Biddings { get; set; }
        public ICollection<Demonstration> Demonstrations { get; set; }
        public ICollection<Broker> Brokers { get; set; }

        // [Required(ErrorMessage = "Du måste ha en hero-bild")]
        public string ImageAddress { get; set; }
        public IFormFile Photo { get; set; }
  
        public List<IFormFile> Photos { get; set; }
    
    }
}
