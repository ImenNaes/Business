using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SuggestedCount = table.Column<int>(nullable: false),
                    Value1 = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    LabelEn = table.Column<string>(nullable: true),
                    FromPrice = table.Column<decimal>(nullable: true),
                    Discount = table.Column<decimal>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    CitiesID = table.Column<Guid>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    PreOrder = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ProductSmallImagesID = table.Column<Guid>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
