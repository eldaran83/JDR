using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JDR.Data.Migrations
{
    public partial class FKCatPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Aventures",
                columns: table => new
                {
                    AventureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aventures", x => x.AventureID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieEquipements",
                columns: table => new
                {
                    CategorieEquipementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitreCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEquipements", x => x.CategorieEquipementID);
                });

            migrationBuilder.CreateTable(
                name: "CategoriePersonnes",
                columns: table => new
                {
                    CategoriePersonneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriePersonnes", x => x.CategoriePersonneId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AventureID = table.Column<int>(nullable: true),
                    Contenu = table.Column<string>(nullable: true),
                    Titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Aventures_AventureID",
                        column: x => x.AventureID,
                        principalTable: "Aventures",
                        principalColumn: "AventureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    EquipementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AventureID = table.Column<int>(nullable: true),
                    CategorieEquipementID = table.Column<int>(nullable: true),
                    Dommage = table.Column<int>(nullable: true),
                    Durete = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prix = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.EquipementID);
                    table.ForeignKey(
                        name: "FK_Equipements_Aventures_AventureID",
                        column: x => x.AventureID,
                        principalTable: "Aventures",
                        principalColumn: "AventureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipements_CategorieEquipements_CategorieEquipementID",
                        column: x => x.CategorieEquipementID,
                        principalTable: "CategorieEquipements",
                        principalColumn: "CategorieEquipementID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    PersonneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AventureID = table.Column<int>(nullable: true),
                    CategoriePersonneID = table.Column<int>(nullable: false),
                    Dexterite = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Force = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Niveau = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Vie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.PersonneID);
                    table.ForeignKey(
                        name: "FK_Personnes_Aventures_AventureID",
                        column: x => x.AventureID,
                        principalTable: "Aventures",
                        principalColumn: "AventureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnes_CategoriePersonnes_CategoriePersonneID",
                        column: x => x.CategoriePersonneID,
                        principalTable: "CategoriePersonnes",
                        principalColumn: "CategoriePersonneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_AventureID",
                table: "Equipements",
                column: "AventureID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_CategorieEquipementID",
                table: "Equipements",
                column: "CategorieEquipementID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AventureID",
                table: "Messages",
                column: "AventureID");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_AventureID",
                table: "Personnes",
                column: "AventureID");

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_CategoriePersonneID",
                table: "Personnes",
                column: "CategoriePersonneID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "CategorieEquipements");

            migrationBuilder.DropTable(
                name: "Aventures");

            migrationBuilder.DropTable(
                name: "CategoriePersonnes");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
