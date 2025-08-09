using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleAcces.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalleAffectee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: true),
                    SalleNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    SessionNom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarteRFID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpreinteHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPromotion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Promotions_IdPromotion",
                        column: x => x.IdPromotion,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Identifiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    EtudiantMatricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarteRFID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpreinteDigitale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpreinteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarteCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiants_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstPaye = table.Column<bool>(type: "bit", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePaiement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiements_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccesExamens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    HoraireExamenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesExamens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccesExamens_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccesExamens_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccesExamens_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoraireExamens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Matiere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: true),
                    IdPromotion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraireExamens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraireExamens_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoraireExamens_Promotions_Id",
                        column: x => x.Id,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoraireExamens_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JournalPresences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    AccesExamenId = table.Column<int>(type: "int", nullable: false),
                    HeureEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureSortie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    HoraireExamenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalPresences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalPresences_AccesExamens_AccesExamenId",
                        column: x => x.AccesExamenId,
                        principalTable: "AccesExamens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JournalPresences_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JournalPresences_HoraireExamens_HoraireExamenId",
                        column: x => x.HoraireExamenId,
                        principalTable: "HoraireExamens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JournalPresences_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnneeAcademique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraireExamenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_HoraireExamens_HoraireExamenId",
                        column: x => x.HoraireExamenId,
                        principalTable: "HoraireExamens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccesExamens_EtudiantId",
                table: "AccesExamens",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccesExamens_HoraireExamenId",
                table: "AccesExamens",
                column: "HoraireExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_AccesExamens_ModuleId",
                table: "AccesExamens",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccesExamens_SalleId",
                table: "AccesExamens",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_IdPromotion",
                table: "Etudiants",
                column: "IdPromotion");

            migrationBuilder.CreateIndex(
                name: "IX_HoraireExamens_ModuleId",
                table: "HoraireExamens",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraireExamens_SalleId",
                table: "HoraireExamens",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraireExamens_SessionId",
                table: "HoraireExamens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiants_CarteRFID",
                table: "Identifiants",
                column: "CarteRFID");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiants_EmpreinteDigitale",
                table: "Identifiants",
                column: "EmpreinteDigitale");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiants_EtudiantId",
                table: "Identifiants",
                column: "EtudiantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalPresences_AccesExamenId",
                table: "JournalPresences",
                column: "AccesExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalPresences_EtudiantId",
                table: "JournalPresences",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalPresences_HoraireExamenId",
                table: "JournalPresences",
                column: "HoraireExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalPresences_SalleId",
                table: "JournalPresences",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_EtudiantId",
                table: "Paiements",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_HoraireExamenId",
                table: "Sessions",
                column: "HoraireExamenId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccesExamens_HoraireExamens_HoraireExamenId",
                table: "AccesExamens",
                column: "HoraireExamenId",
                principalTable: "HoraireExamens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoraireExamens_Sessions_SessionId",
                table: "HoraireExamens",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_HoraireExamens_HoraireExamenId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Identifiants");

            migrationBuilder.DropTable(
                name: "JournalPresences");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "AccesExamens");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "HoraireExamens");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
