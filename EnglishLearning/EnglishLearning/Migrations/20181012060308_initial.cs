using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishLearning.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_date_time_utc = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(maxLength: 64, nullable: false),
                    updated_date_time_utc = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(maxLength: 64, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    normalized_email = table.Column<string>(maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_administrators", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "related_words",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_date_time_utc = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(maxLength: 64, nullable: false),
                    updated_date_time_utc = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(maxLength: 64, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    root_id = table.Column<long>(nullable: false),
                    word = table.Column<string>(maxLength: 100, nullable: false),
                    chinese_meaning = table.Column<string>(maxLength: 300, nullable: false),
                    remember_logic = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_related_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "word_roots",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    created_date_time_utc = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(maxLength: 64, nullable: false),
                    updated_date_time_utc = table.Column<DateTime>(nullable: false),
                    updated_by = table.Column<string>(maxLength: 64, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    word = table.Column<string>(maxLength: 100, nullable: false),
                    chinese_meaning = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_roots", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "related_words");

            migrationBuilder.DropTable(
                name: "word_roots");
        }
    }
}
