using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.TechChallenge.Fase1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "regiao",
                columns: new[] { "id", "ddd", "dt_alteracao", "dt_exclusao", "dt_registro", "estado", "excluido", "regiao" },
                values: new object[,]
                {
                    { new Guid("0fc6472f-a2f1-47f5-ac6c-dfe15fbdb689"), 75, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", false, "Nordeste" },
                    { new Guid("108dba40-7e13-4012-b068-223adf7d5fff"), 53, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RS", false, "Sul" },
                    { new Guid("17fb9598-789e-47df-9aea-e29825116e6f"), 45, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", false, "Sul" },
                    { new Guid("1dba5499-c79a-45d8-944f-2a31d44b2db4"), 24, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RJ", false, "Sudeste" },
                    { new Guid("227f09c0-c9b0-4579-808c-a077bb33e2ef"), 48, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", false, "Sul" },
                    { new Guid("25096d96-30c9-4770-bdc1-7de8c3183560"), 31, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("27fdd19d-9858-461c-8d2a-559b30e24065"), 51, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RS", false, "Sul" },
                    { new Guid("28f4fd3c-fb24-4c5f-bd7b-47751ae6848d"), 89, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PI", false, "Nordeste" },
                    { new Guid("291fa44c-1efb-40fa-a423-e63af1ae1588"), 15, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("34d45c85-714d-40ca-8adc-553ddc2359ab"), 92, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AM", false, "Norte" },
                    { new Guid("385cf7e5-f2ce-4803-afd5-ca627e35ffb8"), 79, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SE", false, "Nordeste" },
                    { new Guid("3cb5ab44-4203-4784-905b-f97636fe912b"), 95, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RR", false, "Norte" },
                    { new Guid("3cc34a5f-8fe2-4d29-837e-02f23404bf44"), 93, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PA", false, "Norte" },
                    { new Guid("440a243e-606f-435d-ba02-74b61309364b"), 42, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", false, "Sul" },
                    { new Guid("464348a3-cdc0-420c-a06b-5097c64e97e3"), 28, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ES", false, "Sudeste" },
                    { new Guid("4efb4b70-a1df-44d6-9476-dfb329e6415f"), 64, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GO", false, "Centro-Oeste" },
                    { new Guid("4ffdc9f3-2e5e-4aa6-9f5c-3df354a5b8aa"), 84, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RN", false, "Nordeste" },
                    { new Guid("513fc74f-b3e1-4630-802e-6007cdd3b0a5"), 54, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RS", false, "Sul" },
                    { new Guid("5ffcc6e2-82ab-49d4-bf77-8b18c24e0fa7"), 67, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MS", false, "Centro-Oeste" },
                    { new Guid("60ef67dd-8de6-4cd7-99ba-4ad3c1537933"), 98, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MA", false, "Nordeste" },
                    { new Guid("614de0d3-d4f2-4e80-aece-199361abda81"), 41, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", false, "Sul" },
                    { new Guid("657f655c-cf9a-4334-bf14-31e60a9c0823"), 71, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", false, "Nordeste" },
                    { new Guid("6f2334b8-c64a-4c7f-bccb-5368b7e07850"), 14, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("732cfc8d-e90d-4140-9486-6e188b1e9c9a"), 81, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PE", false, "Nordeste" },
                    { new Guid("74762c74-7817-4cb8-a2b9-59c67de4f8ee"), 27, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ES", false, "Sudeste" },
                    { new Guid("79d79914-9b6d-4b5d-9a9b-17cd65db305a"), 63, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TO", false, "Norte" },
                    { new Guid("7c649868-7606-49de-b563-ce8151e004ca"), 12, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("7cfbc556-05fc-4f59-979a-8de63fe6c7dd"), 88, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CE", false, "Nordeste" },
                    { new Guid("7e5e0638-d60f-4702-8886-4ddfe245fa27"), 69, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RO", false, "Norte" },
                    { new Guid("80313aa7-037e-41bd-aecd-6f221722546d"), 83, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PB", false, "Nordeste" },
                    { new Guid("87811452-13c0-4b59-96cd-6df082c7ee2c"), 35, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("8e974c0a-68ef-4d6d-b636-8c518bef4d68"), 44, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", false, "Sul" },
                    { new Guid("90040e40-4dc8-4dcb-84fc-f69558a8c392"), 97, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AM", false, "Norte" },
                    { new Guid("9341379d-f603-41aa-8420-929ea7dbd765"), 19, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("93ad63cf-e449-452b-b584-545d2243b72c"), 96, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AP", false, "Norte" },
                    { new Guid("9641bf0f-6537-4b88-bba7-6e14d23a1296"), 13, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("9e381f5d-4a59-422d-acb0-ab7e53f20904"), 68, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC", false, "Norte" },
                    { new Guid("a1c47334-75e7-4dc1-9330-b6d25feca275"), 21, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RJ", false, "Sudeste" },
                    { new Guid("a5499b54-cd1d-4ee7-a2fb-0ca1e6c4d382"), 66, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MT", false, "Centro-Oeste" },
                    { new Guid("a743f97a-f521-42ef-87d2-3008ea8f8ede"), 46, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", false, "Sul" },
                    { new Guid("a91de642-bf3d-4f2f-882a-9e573baf56ae"), 85, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CE", false, "Nordeste" },
                    { new Guid("ae9a3bd5-5ab5-44c1-a497-7e000cf7fa23"), 99, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MA", false, "Nordeste" },
                    { new Guid("aedad9ff-19b8-4521-9e8b-e9e4c38d9efa"), 17, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("b0a89fca-ac8a-4c01-9cda-3755630a4806"), 32, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("b9b56f96-638c-4fe0-910f-9d63169ec66f"), 16, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("baf94171-2dc4-4dfd-a20c-1169931a9ad3"), 82, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL", false, "Nordeste" },
                    { new Guid("bd733945-3426-45d9-a602-71f9631503e6"), 91, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PA", false, "Norte" },
                    { new Guid("c1cb9987-53b2-4c83-8a13-7b509a98e457"), 62, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GO", false, "Centro-Oeste" },
                    { new Guid("c6685d3e-79ea-414c-8769-f4324a2b3fc0"), 77, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", false, "Nordeste" },
                    { new Guid("c85b82e1-5a55-4bc7-81e2-3abab28a96b6"), 61, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DF", false, "Centro-Oeste" },
                    { new Guid("cb7524c1-a3cf-42c7-9cb0-23c7f8a410f0"), 87, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PE", false, "Nordeste" },
                    { new Guid("d0283ed7-deb4-4660-997b-0434a655f37e"), 11, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("d073f867-5a50-4d9d-a5e9-b24a9229e154"), 43, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", false, "Sul" },
                    { new Guid("d6657289-a2c9-4c99-ad47-7dee89134657"), 22, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RJ", false, "Sudeste" },
                    { new Guid("d80e3aef-254d-4503-9ea6-433758ff00e0"), 74, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", false, "Nordeste" },
                    { new Guid("d82eb6cb-dbb2-47dd-909a-d279c219bb80"), 34, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("d93c6f59-cb6e-42cb-a2ed-2992421dd816"), 49, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", false, "Sul" },
                    { new Guid("deb639d1-f214-40db-b33b-1244728edbf9"), 33, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("dedbb954-190d-443a-8e5c-6f18dce139df"), 65, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MT", false, "Centro-Oeste" },
                    { new Guid("e021f153-b6da-40e7-bdcb-c0c50d82e855"), 38, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("e1dec228-fc21-4d78-9833-ffa705dcc572"), 86, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PI", false, "Nordeste" },
                    { new Guid("ee10b9f8-accf-412c-acad-17f97df8a3fb"), 73, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", false, "Nordeste" },
                    { new Guid("ee9e419f-4f12-4419-ad77-72335f794cd4"), 37, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", false, "Sudeste" },
                    { new Guid("f16b043b-3435-47b2-91e6-1f62e92f79c4"), 94, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PA", false, "Norte" },
                    { new Guid("fa025bf5-72a1-4e42-9d62-74da8269faad"), 18, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", false, "Sudeste" },
                    { new Guid("fc438da4-ea1a-4749-8df3-21ec4f8de995"), 47, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", false, "Sul" },
                    { new Guid("fd608682-0516-452b-abe4-bfa84ecf7320"), 55, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RS", false, "Sul" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_alteracao", "dt_exclusao", "dt_registro", "email", "excluido", "nome", "role", "senha" },
                values: new object[] { new Guid("8e735ee9-b5d0-482a-9377-59c03b78ca98"), null, null, new DateTime(2024, 7, 25, 20, 20, 25, 378, DateTimeKind.Local).AddTicks(7627), "admin@gmail.com", false, "Administrador", (short)0, "$2b$12$/nj7LJgiUFp32SZ9A2A98e83JwjOtWPhOLTnplHMCRQqKfqGHAmVS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("0fc6472f-a2f1-47f5-ac6c-dfe15fbdb689"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("108dba40-7e13-4012-b068-223adf7d5fff"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("17fb9598-789e-47df-9aea-e29825116e6f"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("1dba5499-c79a-45d8-944f-2a31d44b2db4"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("227f09c0-c9b0-4579-808c-a077bb33e2ef"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("25096d96-30c9-4770-bdc1-7de8c3183560"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("27fdd19d-9858-461c-8d2a-559b30e24065"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("28f4fd3c-fb24-4c5f-bd7b-47751ae6848d"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("291fa44c-1efb-40fa-a423-e63af1ae1588"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("34d45c85-714d-40ca-8adc-553ddc2359ab"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("385cf7e5-f2ce-4803-afd5-ca627e35ffb8"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("3cb5ab44-4203-4784-905b-f97636fe912b"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("3cc34a5f-8fe2-4d29-837e-02f23404bf44"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("440a243e-606f-435d-ba02-74b61309364b"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("464348a3-cdc0-420c-a06b-5097c64e97e3"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("4efb4b70-a1df-44d6-9476-dfb329e6415f"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("4ffdc9f3-2e5e-4aa6-9f5c-3df354a5b8aa"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("513fc74f-b3e1-4630-802e-6007cdd3b0a5"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("5ffcc6e2-82ab-49d4-bf77-8b18c24e0fa7"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("60ef67dd-8de6-4cd7-99ba-4ad3c1537933"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("614de0d3-d4f2-4e80-aece-199361abda81"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("657f655c-cf9a-4334-bf14-31e60a9c0823"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("6f2334b8-c64a-4c7f-bccb-5368b7e07850"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("732cfc8d-e90d-4140-9486-6e188b1e9c9a"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("74762c74-7817-4cb8-a2b9-59c67de4f8ee"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("79d79914-9b6d-4b5d-9a9b-17cd65db305a"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("7c649868-7606-49de-b563-ce8151e004ca"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("7cfbc556-05fc-4f59-979a-8de63fe6c7dd"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("7e5e0638-d60f-4702-8886-4ddfe245fa27"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("80313aa7-037e-41bd-aecd-6f221722546d"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("87811452-13c0-4b59-96cd-6df082c7ee2c"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("8e974c0a-68ef-4d6d-b636-8c518bef4d68"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("90040e40-4dc8-4dcb-84fc-f69558a8c392"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("9341379d-f603-41aa-8420-929ea7dbd765"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("93ad63cf-e449-452b-b584-545d2243b72c"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("9641bf0f-6537-4b88-bba7-6e14d23a1296"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("9e381f5d-4a59-422d-acb0-ab7e53f20904"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("a1c47334-75e7-4dc1-9330-b6d25feca275"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("a5499b54-cd1d-4ee7-a2fb-0ca1e6c4d382"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("a743f97a-f521-42ef-87d2-3008ea8f8ede"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("a91de642-bf3d-4f2f-882a-9e573baf56ae"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("ae9a3bd5-5ab5-44c1-a497-7e000cf7fa23"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("aedad9ff-19b8-4521-9e8b-e9e4c38d9efa"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("b0a89fca-ac8a-4c01-9cda-3755630a4806"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("b9b56f96-638c-4fe0-910f-9d63169ec66f"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("baf94171-2dc4-4dfd-a20c-1169931a9ad3"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("bd733945-3426-45d9-a602-71f9631503e6"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("c1cb9987-53b2-4c83-8a13-7b509a98e457"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("c6685d3e-79ea-414c-8769-f4324a2b3fc0"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("c85b82e1-5a55-4bc7-81e2-3abab28a96b6"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("cb7524c1-a3cf-42c7-9cb0-23c7f8a410f0"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d0283ed7-deb4-4660-997b-0434a655f37e"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d073f867-5a50-4d9d-a5e9-b24a9229e154"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d6657289-a2c9-4c99-ad47-7dee89134657"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d80e3aef-254d-4503-9ea6-433758ff00e0"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d82eb6cb-dbb2-47dd-909a-d279c219bb80"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("d93c6f59-cb6e-42cb-a2ed-2992421dd816"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("deb639d1-f214-40db-b33b-1244728edbf9"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("dedbb954-190d-443a-8e5c-6f18dce139df"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("e021f153-b6da-40e7-bdcb-c0c50d82e855"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("e1dec228-fc21-4d78-9833-ffa705dcc572"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("ee10b9f8-accf-412c-acad-17f97df8a3fb"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("ee9e419f-4f12-4419-ad77-72335f794cd4"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("f16b043b-3435-47b2-91e6-1f62e92f79c4"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("fa025bf5-72a1-4e42-9d62-74da8269faad"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("fc438da4-ea1a-4749-8df3-21ec4f8de995"));

            migrationBuilder.DeleteData(
                table: "regiao",
                keyColumn: "id",
                keyValue: new Guid("fd608682-0516-452b-abe4-bfa84ecf7320"));

            migrationBuilder.DeleteData(
                table: "usuario",
                keyColumn: "id",
                keyValue: new Guid("8e735ee9-b5d0-482a-9377-59c03b78ca98"));
        }
    }
}
