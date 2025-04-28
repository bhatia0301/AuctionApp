using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "279e30e5-426d-449e-86c8-c2a89ffc1ada",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c59466c3-82bc-413e-8eb9-5ea17b2158c0", "AQAAAAIAAYagAAAAEH02dCYr7JXeyLZiPuruNTw6lDYk/II882HVzbwHSYgTx8GwER05BKhmlzqtX6XrxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41377029-b399-409c-8da2-7a4bcf802978",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91d1b7de-4ef2-4465-b174-b78b11fd05ac", "AQAAAAIAAYagAAAAEGfvV+Pt4UAoXFm8PHCPTHiZ6/7PkuIOjnsH425yduTRYDnjtWb623JhLj0r9MH3DA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4732b433-fd9c-48d3-8cb3-eccee797cb0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ea97cef-c014-4f48-be80-7fc4cd7d0f7e", "AQAAAAIAAYagAAAAEGwdUwLtLHk8AxUKFMicoxk48VIIAH4oqR3lUu4CjemgYvMBzew3mBci+RJLNRja9Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e3fccd2-60fb-4090-b281-33f0405d6a45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f1a51ff-3c9f-42bf-a98b-162adb3bb289", "AQAAAAIAAYagAAAAEFJf7/prvIBKtKSKeEyXzn5qAGQw3VNSqeQINoSIlh41cCGUiiFw7H4100qmXT13JQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77311c10-f548-4e65-8bd5-5df2dd774c1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fec2cc0-082e-4c9f-af39-4e9d9c499b27", "AQAAAAIAAYagAAAAEN1SGQtrUfpVS9U0gxOWG0uvyJl7fC8C5LmaW3I0aJLucfx7xdrWmY87XoMKL7h9tA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bba7a43-19df-46d5-97ad-b1cf29053c02",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21c436da-fd1e-4a22-ae21-098a121f9eea", "AQAAAAIAAYagAAAAEO6YaafQvXxqy96oZMiDYmUw71c6dxNUdWQTBPJ9F12dOTWTnTN5UYSnFN8zYg7yLA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c8c7ba1-9f91-4ee4-8d47-fac0125dc74c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f9b62d6-9f2e-4456-98ad-70d9008ddc23", "AQAAAAIAAYagAAAAEHlDW1N5rJWex/fAJHdTNmqOX/sQZlqgiXI8zg99RAgoa2B6tWusfAbXI5qz2qMw6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad014415-a368-4a32-9351-a8abf2485393",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acde56ca-7b25-45d9-8f05-1fbb3937ea90", "AQAAAAIAAYagAAAAEBxfehcJGbsnzekGdYICxKFxqc5o80HMPcTBaBEuoINsjP/e2zJRVsb00WLUFyYidg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "279e30e5-426d-449e-86c8-c2a89ffc1ada",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "094bfe96-4011-4b64-828a-1b8dab47b65f", "AQAAAAIAAYagAAAAEN2ekXXkVMbbS4TzFVPb4DNwc7uwx/oC4S+bbRoeogMsk6wEbpvmG2ANG1gQdgqo5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41377029-b399-409c-8da2-7a4bcf802978",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "242b9571-6f4b-4cff-a10b-bbc9cd335f2d", "AQAAAAIAAYagAAAAEFY0rO92Y0MrcP7hgbO5XEpw5u1iSqXV/bSaKLVm/JkVkh9Geqa28hQW+xw8Axy0Sw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4732b433-fd9c-48d3-8cb3-eccee797cb0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b191400a-dc90-45ee-8b94-7caf5dd77731", "AQAAAAIAAYagAAAAECIT0SeV1XKaWTB6PZP535L4SODC/+CGGmLMsIT8KgaFSXTB80buawYAJ++C5dTXxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e3fccd2-60fb-4090-b281-33f0405d6a45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa9e922a-7811-4c6b-95f8-e1d176a1dafe", "AQAAAAIAAYagAAAAEN3mQPs3TFY1SU/DkdeeJYUbrZIRqDTvcpMDaTSYXvvxrRxL0sOB7hWRPNrznfC2Fg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77311c10-f548-4e65-8bd5-5df2dd774c1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10722e5c-5d95-4134-88eb-d5e0e2c49ef2", "AQAAAAIAAYagAAAAEFKp6S8ge97tem7QUYfAkSEW2wtsmRACHVO84bDbtWdlnqjY2uAimbch5OaNnxTRGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bba7a43-19df-46d5-97ad-b1cf29053c02",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0509b5fb-b87b-4670-8c9a-9ac90ade760c", "AQAAAAIAAYagAAAAEPaW2YH3GZzJRRfb1QLYiaFL7gDLu6DaHLQfmaFXNj3TNt8PM3X9SLgeCBdgcyGXkg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c8c7ba1-9f91-4ee4-8d47-fac0125dc74c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b18b4165-ab04-4680-9d4f-8db1705d4e52", "AQAAAAIAAYagAAAAEOtFBC4nwFmKcZWpheK/E57xOUi8ihvblksx6bP0q+rMMFPIy9KUv/pLoGkx0f/iKw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad014415-a368-4a32-9351-a8abf2485393",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ade9fbc-e6ba-4a77-be16-3d7356204c6e", "AQAAAAIAAYagAAAAEH1Dl2R2UyD51C+gYrt4I5b+bpmDBYS0pIlp2nTphzPDFZg6YQAxdStxAha0ofYCgQ==" });
        }
    }
}
