﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2.Migrations
{
    public partial class Dodanotabeleorazichwartosci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musican",
                columns: table => new
                {
                    IdMusican = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musican", x => x.IdMusican);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabel",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabel", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_MusicLabel_IdMusicLabel",
                        column: x => x.IdMusicLabel,
                        principalTable: "MusicLabel",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdMusicAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Track_Album_IdMusicAlbum",
                        column: x => x.IdMusicAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicanTrack",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false),
                    IdMusican = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicanTrack", x => new { x.IdMusican, x.IdTrack });
                    table.ForeignKey(
                        name: "FK_MusicanTrack_Musican_IdMusican",
                        column: x => x.IdMusican,
                        principalTable: "Musican",
                        principalColumn: "IdMusican",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicanTrack_Track_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Track",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "Garage" });

            migrationBuilder.InsertData(
                table: "Musican",
                columns: new[] { "IdMusican", "FirstName", "LastName", "Nickname" },
                values: new object[] { 1, "Krzysztof", "Krawczyk", "KKraw" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "Night", 1, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 30f, 1, "Sky" });

            migrationBuilder.InsertData(
                table: "MusicanTrack",
                columns: new[] { "IdMusican", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdMusicLabel",
                table: "Album",
                column: "IdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicanTrack_IdTrack",
                table: "MusicanTrack",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicanTrack");

            migrationBuilder.DropTable(
                name: "Musican");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "MusicLabel");
        }
    }
}
