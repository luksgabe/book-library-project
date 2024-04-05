using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SQLScript_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("../../scripts/books_inserts.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
