using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Core.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoDishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoDishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoDishes_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Saves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    infoDishId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saves_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saves_InfoDishes_infoDishId",
                        column: x => x.infoDishId,
                        principalTable: "InfoDishes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
<<<<<<<< HEAD:Recipes/Recipes.Core/Migrations/20221114224336_Init2.cs
                    { "4f8cc0e5-784e-4fa3-a9bc-e53dd21283c6", "1cb9f892-da2b-4cf2-ae0a-78027a526eb1", "Admin", "ADMIN" },
                    { "78cb791e-ab57-4213-9be4-d671a9bc8e7b", "31d3718c-4dcc-48bd-8b51-c217b4fe571c", "User", "USER" },
                    { "d8bfd126-a3f4-48d3-a115-1613c65f642e", "54114cfe-55d3-4188-ae35-991f7274160f", "Manager", "MANAGER" }
========
                    { "1b666487-0d48-4720-8bbd-ccf1304818df", "9d6236cb-14c2-4c5e-b4b9-1ad88bbc305b", "User", "USER" },
                    { "c3c1fb88-6b0e-4723-bac5-92ac7fe001de", "9aef1935-4826-4e97-9d5a-48899fce1aa5", "Manager", "MANAGER" },
                    { "d10b7dbb-0f2d-4357-b262-a5509ef16ed5", "88367436-7dfe-4542-aeac-aee3dce2fb59", "Admin", "ADMIN" }
>>>>>>>> Api:Recipes/Recipes.Core/Migrations/20221201120559_Init1.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:Recipes/Recipes.Core/Migrations/20221114224336_Init2.cs
                    { "2479730d-82f3-4dda-9d5c-28b7c19addd9", 0, "e77abf58-375f-4379-ba26-3248f91e7aea", "manager@recipes.com", true, null, null, false, null, "MANAGER@RECIPES.COM", "MANAGER@RECIPES.COM", "AQAAAAEAACcQAAAAEEOQ6GF82llmGRNVxdAHwvOMtcibN/0eZ/eSEcr9wXRrPLoG9GhDVleXi/kSXWEC1Q==", null, false, "633186f3-9c04-4e8e-8a53-ce7ea1369b63", false, "manager@recipes.com" },
                    { "270dffb2-bf58-4c58-bc35-2976002687c9", 0, "85443fd3-96d3-4695-accc-cdecfdcfd845", "user@recipes.com", true, null, null, false, null, "USER@RECIPES.COM", "USER@RECIPES.COM", "AQAAAAEAACcQAAAAEFcLkZPY/arBjZHW4eQDChfxrI1BLDAZb95dkvz5i3ATVp9WeaRsfiI+RXjtZ89npA==", null, false, "7afe5f16-1dcd-42ad-8d02-eea15d4a43e0", false, "user@recipes.com" },
                    { "ebb7f18e-d7f4-40e6-a94a-fb4be1d103ca", 0, "9212df5b-e5aa-4515-a061-9c91116ad3b8", "admin@recipes.com", true, null, null, false, null, "ADMIN@RECIPES.COM", "ADMIN@RECIPES.COM", "AQAAAAEAACcQAAAAEKqFb0JPXzsMe6/f/CuOGXmhimNNOt0CdFOe3bdavHB5futiONt2III6raCraKbamQ==", null, false, "b471db06-23be-4daf-9ef4-70b39cadea3b", false, "admin@recipes.com" }
========
                    { "1311914b-1e2c-4df5-a7e7-daa53c5d98fe", 0, "5439ad26-e42c-41d5-8bfe-8d1b3c6f7c7e", "manager@recipes.com", true, null, null, false, null, "MANAGER@RECIPES.COM", "MANAGER@RECIPES.COM", "AQAAAAEAACcQAAAAEIoOsBkRbKu6soWrpjUQWvzO5pKIP8f4Ok+P5i31qOR+osSWk2Wg9UdjK/3CCYQx2w==", null, false, "f6c42c15-3472-4d6d-95d4-0e650ce48acb", false, "manager@recipes.com" },
                    { "2a645d28-179a-4195-9221-327a5b4ef36d", 0, "f932953f-d581-4095-9ffd-522083692357", "user@recipes.com", true, null, null, false, null, "USER@RECIPES.COM", "USER@RECIPES.COM", "AQAAAAEAACcQAAAAEMOQLri4cEmKDSpNs70gMKkMS/vHrxE9LTY97TL0TR1gQwz5ZTQR8aZatIxJgrY1kA==", null, false, "7384dfd5-ee35-4dfc-b3b6-52c7259e2a6e", false, "user@recipes.com" },
                    { "de9b5988-7ef7-44ff-9d8a-085bd2a828bc", 0, "3dd45bf7-f4c5-45da-9478-5f00945dbcb2", "admin@recipes.com", true, null, null, false, null, "ADMIN@RECIPES.COM", "ADMIN@RECIPES.COM", "AQAAAAEAACcQAAAAEDlYyHBPOjRQWav6zLPP6NAHxeymYNmqQaV8jECp66nipNlR88/+sVd0Ahw6ti+RFQ==", null, false, "739fe965-bf33-4589-a81a-195b9fb7179a", false, "admin@recipes.com" }
>>>>>>>> Api:Recipes/Recipes.Core/Migrations/20221201120559_Init1.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:Recipes/Recipes.Core/Migrations/20221114224336_Init2.cs
                    { "78cb791e-ab57-4213-9be4-d671a9bc8e7b", "2479730d-82f3-4dda-9d5c-28b7c19addd9" },
                    { "d8bfd126-a3f4-48d3-a115-1613c65f642e", "2479730d-82f3-4dda-9d5c-28b7c19addd9" },
                    { "78cb791e-ab57-4213-9be4-d671a9bc8e7b", "270dffb2-bf58-4c58-bc35-2976002687c9" },
                    { "4f8cc0e5-784e-4fa3-a9bc-e53dd21283c6", "ebb7f18e-d7f4-40e6-a94a-fb4be1d103ca" },
                    { "78cb791e-ab57-4213-9be4-d671a9bc8e7b", "ebb7f18e-d7f4-40e6-a94a-fb4be1d103ca" },
                    { "d8bfd126-a3f4-48d3-a115-1613c65f642e", "ebb7f18e-d7f4-40e6-a94a-fb4be1d103ca" }
========
                    { "1b666487-0d48-4720-8bbd-ccf1304818df", "1311914b-1e2c-4df5-a7e7-daa53c5d98fe" },
                    { "c3c1fb88-6b0e-4723-bac5-92ac7fe001de", "1311914b-1e2c-4df5-a7e7-daa53c5d98fe" },
                    { "1b666487-0d48-4720-8bbd-ccf1304818df", "2a645d28-179a-4195-9221-327a5b4ef36d" },
                    { "1b666487-0d48-4720-8bbd-ccf1304818df", "de9b5988-7ef7-44ff-9d8a-085bd2a828bc" },
                    { "c3c1fb88-6b0e-4723-bac5-92ac7fe001de", "de9b5988-7ef7-44ff-9d8a-085bd2a828bc" },
                    { "d10b7dbb-0f2d-4357-b262-a5509ef16ed5", "de9b5988-7ef7-44ff-9d8a-085bd2a828bc" }
>>>>>>>> Api:Recipes/Recipes.Core/Migrations/20221201120559_Init1.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InfoDishes_CategoriesId",
                table: "InfoDishes",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_infoDishId",
                table: "Saves",
                column: "infoDishId");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_userId",
                table: "Saves",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Saves");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "InfoDishes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
