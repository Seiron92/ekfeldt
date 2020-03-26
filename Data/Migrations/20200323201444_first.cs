using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    BrokerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(type: "ntext", nullable: true),
                    Title = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broker", x => x.BrokerId);
                });

            migrationBuilder.CreateTable(
                name: "Demonstration",
                columns: table => new
                {
                    DemonstrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTime = table.Column<DateTime>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    HomeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demonstration", x => x.DemonstrationId);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    AppartmentNumber = table.Column<string>(nullable: true),
                    Society = table.Column<string>(nullable: true),
                    Room = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Elevator = table.Column<string>(nullable: true),
                    Dop = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Bidding = table.Column<bool>(nullable: false),
                    HomeType = table.Column<string>(nullable: true),
                    Tow = table.Column<string>(nullable: true),
                    LivingArea = table.Column<int>(nullable: false),
                    BiArea = table.Column<int>(nullable: false),
                    GardenArea = table.Column<int>(nullable: false),
                    BuildningSystem = table.Column<string>(type: "ntext", nullable: true),
                    Renovations = table.Column<string>(type: "ntext", nullable: true),
                    OtherBuildnings = table.Column<string>(type: "ntext", nullable: true),
                    LivingSpaceComment = table.Column<string>(type: "ntext", nullable: true),
                    Parking = table.Column<string>(type: "ntext", nullable: true),
                    TvInternet = table.Column<string>(type: "ntext", nullable: true),
                    HeatVentilation = table.Column<string>(type: "ntext", nullable: true),
                    BuildningYear = table.Column<int>(nullable: false),
                    MounthlyFee = table.Column<int>(nullable: false),
                    PartOfSociety = table.Column<int>(nullable: false),
                    PawnBroking = table.Column<bool>(nullable: false),
                    AboutSociety = table.Column<string>(type: "ntext", nullable: true),
                    CommonAreas = table.Column<string>(type: "ntext", nullable: true),
                    TransactionFee = table.Column<int>(nullable: false),
                    TransactionFeePaidBy = table.Column<string>(nullable: true),
                    OperationCost = table.Column<int>(nullable: false),
                    TypeCode = table.Column<string>(nullable: true),
                    TaxValue = table.Column<int>(nullable: false),
                    TaxValueProperty = table.Column<int>(nullable: false),
                    TaxValueLand = table.Column<int>(nullable: false),
                    TaxYear = table.Column<int>(nullable: false),
                    PawnLetters = table.Column<string>(nullable: true),
                    Heating = table.Column<int>(nullable: false),
                    PowerComsumption = table.Column<int>(nullable: false),
                    EnergyCosts = table.Column<int>(nullable: false),
                    NumberOfOccupants = table.Column<int>(nullable: false),
                    WaterAndSewedge = table.Column<int>(nullable: false),
                    Cleaning = table.Column<int>(nullable: false),
                    Insurance = table.Column<int>(nullable: false),
                    InsuranceComment = table.Column<string>(nullable: true),
                    EnergyDeclaration = table.Column<bool>(nullable: false),
                    EnergyPerfomance = table.Column<int>(nullable: false),
                    EnergyClass = table.Column<string>(nullable: true),
                    SpecificEnergyUsage = table.Column<int>(nullable: false),
                    DeclarationDate = table.Column<DateTime>(nullable: true),
                    Inspector = table.Column<string>(nullable: true),
                    SummaryHeading = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(type: "ntext", nullable: true),
                    Information = table.Column<string>(type: "ntext", nullable: true),
                    OtherRightsAndLiabilities = table.Column<string>(type: "ntext", nullable: true),
                    BrokerId = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    ImageAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                });

            migrationBuilder.CreateTable(
                name: "Bidding",
                columns: table => new
                {
                    BiddingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeId = table.Column<int>(nullable: false),
                    HomesHomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidding", x => x.BiddingId);
                    table.ForeignKey(
                        name: "FK_Bidding_Homes_HomesHomeId",
                        column: x => x.HomesHomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageAdress = table.Column<string>(type: "ntext", nullable: true),
                    ImageText = table.Column<string>(type: "ntext", nullable: true),
                    HeroImage = table.Column<bool>(nullable: false),
                    FloorPlan = table.Column<string>(nullable: true),
                    HomeIds = table.Column<int>(nullable: false),
                    HomesHomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Homes_HomesHomeId",
                        column: x => x.HomesHomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Bidder = table.Column<bool>(nullable: false),
                    Viewer = table.Column<bool>(nullable: false),
                    PhoneNUmber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DemonstrationId = table.Column<int>(nullable: true),
                    BiddingIds = table.Column<int>(nullable: true),
                    HomeId = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    Alias = table.Column<int>(nullable: false),
                    HomesHomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Homes_HomesHomeId",
                        column: x => x.HomesHomeId,
                        principalTable: "Homes",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bidding_HomesHomeId",
                table: "Bidding",
                column: "HomesHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_HomesHomeId",
                table: "Image",
                column: "HomesHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_HomesHomeId",
                table: "Persons",
                column: "HomesHomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bidding");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "Demonstration");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
