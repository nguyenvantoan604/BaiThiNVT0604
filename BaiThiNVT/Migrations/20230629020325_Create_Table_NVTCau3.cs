using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiThiNVT.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_NVTCau3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVTCau3",
                columns: table => new
                {
                    IDNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    TuoiNhanVien = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVTCau3", x => x.IDNhanVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVTCau3");
        }
    }
}
