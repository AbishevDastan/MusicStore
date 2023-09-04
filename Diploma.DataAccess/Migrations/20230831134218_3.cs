using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam id sodales nunc. Duis ut sapien tincidunt, tempor felis in, imperdiet diam. Vivamus eu justo sit amet nibh feugiat congue. ", "Martin 000-28" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nam tempor, diam quis porta sagittis, dolor erat auctor nisi, eu pulvinar lacus massa in velit. Nam et aliquet felis.", "Ibanez AW54OPN" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nullam auctor vitae velit a iaculis. Proin sed urna sit amet ante tincidunt imperdiet. Curabitur ac condimentum elit.", "Ibanez Talman TCY10E" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nam ac diam lacinia, porta velit et, venenatis quam. In a quam sit amet est aliquet convallis nec vel ligula.", "Jackson JS32" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Sed dapibus tristique lacinia. Cras laoreet dictum elit id rutrum.", "Jackson JS22" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nullam rutrum velit nulla, a mattis quam consequat eu. Nunc sagittis quam eget orci faucibus mattis.", "Jackson Bass JS2" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nulla vulputate viverra nisl in tincidunt. Mauris id tincidunt libero, a venenatis mauris. Morbi aliquam hendrerit sem id elementum.", "Ibanez SR" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Mauris vitae maximus ante. Nunc vitae lorem eros. Duis vulputate pharetra eros at tincidunt.", "Donner DED-100" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quisque bibendum lacinia ante, rhoncus facilisis enim facilisis sit amet. Vivamus condimentum nunc nec maximus porttitor.", "Vangoa Drum Kit" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Interdum et malesuada fames ac ante ipsum primis in faucibus. Etiam lacinia accumsan urna, vel cursus nisl maximus pellentesque.");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Mauris eget sodales dolor. Maecenas rutrum ultricies mauris et finibus.");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nullam ac arcu a metus maximus aliquet eget vel dolor. Nulla ac volutpat mauris, quis pulvinar nulla.", "Cecilio MV500+92D" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Vestibulum accumsan lorem erat, sit amet congue ligula facilisis eget. Mauris mattis eget velit vitae molestie.");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nullam convallis tempor gravida. Suspendisse non est vitae tellus pretium fringilla et at eros. Nam venenatis elit quis faucibus porta.", "FingerBallet Piano" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Aenean id blandit libero. Curabitur nec enim aliquet, placerat arcu et, pellentesque est. Fusce condimentum tincidunt nulla, sit amet hendrerit diam mollis fringilla.", "Magicon BX2 Piano" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Praesent viverra ipsum id sem hendrerit sagittis. Praesent molestie faucibus elementum.", "Behringer DeepMind 6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Martin 000-28 Eric Clapton Signature Auditorium Acoustic Guitar" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Ibanez AW54OPN Artwood Dreadnought Acoustic Guitar" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Ibanez Talman TCY10E Acoustic-electric Guitar" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Jackson JS Series Kelly JS32" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Jackson JS Series Dinky Arch Top JS22" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Jackson JS Series Spectra Bass JS2" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Ibanez SR Standard 5-String Electric Bass Guitar" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Donner DED-100 Electric Drum Set" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Vangoa Acoustic Drum Kit" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Mendini By Cecilio Violin - MV500+92D" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "FingerBallet Portable Piano Keyboard" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "MAGICON BX2 88-Key Foldable Electronic Piano" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Behringer DeepMind 6 37-Key 6-Voice Analog Synthesizer" });
        }
    }
}
