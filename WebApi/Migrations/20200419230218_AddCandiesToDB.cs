using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddCandiesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    idPage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.idPage);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    idPerson = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    telephone = table.Column<string>(maxLength: 10, nullable: true),
                    address = table.Column<string>(maxLength: 200, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.idPerson);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    idProductType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.idProductType);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    idProvider = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nameProvider = table.Column<string>(maxLength: 100, nullable: true),
                    reason = table.Column<string>(maxLength: 200, nullable: true),
                    nit = table.Column<string>(maxLength: 10, nullable: true),
                    address = table.Column<string>(maxLength: 200, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    typeProvider = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.idProvider);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    idRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "StatusMachine",
                columns: table => new
                {
                    idStatusMachine = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMachine", x => x.idStatusMachine);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    lastName = table.Column<string>(maxLength: 50, nullable: true),
                    userName = table.Column<string>(maxLength: 15, nullable: true),
                    passwordHash = table.Column<byte[]>(nullable: true),
                    passwordSalt = table.Column<byte[]>(nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    idClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(maxLength: 200, nullable: true),
                    coordinate = table.Column<string>(maxLength: 200, nullable: true),
                    nit = table.Column<string>(maxLength: 10, nullable: true),
                    wholesaler = table.Column<bool>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    idPerson = table.Column<int>(nullable: false),
                    urlPage = table.Column<string>(maxLength: 500, nullable: true),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.idClient);
                    table.ForeignKey(
                        name: "FK_Client_Person_idPerson",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    idProduct = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    cost = table.Column<float>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    idProvider = table.Column<int>(nullable: false),
                    existence = table.Column<int>(nullable: false),
                    idProductType = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.idProduct);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_idProductType",
                        column: x => x.idProductType,
                        principalTable: "ProductType",
                        principalColumn: "idProductType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Provider_idProvider",
                        column: x => x.idProvider,
                        principalTable: "Provider",
                        principalColumn: "idProvider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    idPurchaseOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    orderTitle = table.Column<string>(maxLength: 50, nullable: true),
                    datePurchaseOrder = table.Column<DateTime>(nullable: false),
                    purchaseOrderAmount = table.Column<float>(nullable: false),
                    statusOrder = table.Column<bool>(nullable: false),
                    idProvider = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.idPurchaseOrder);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Provider_idProvider",
                        column: x => x.idProvider,
                        principalTable: "Provider",
                        principalColumn: "idProvider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePage",
                columns: table => new
                {
                    idRolePage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idRole = table.Column<int>(nullable: false),
                    idPage = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePage", x => x.idRolePage);
                    table.ForeignKey(
                        name: "FK_RolePage_Page_idPage",
                        column: x => x.idPage,
                        principalTable: "Page",
                        principalColumn: "idPage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePage_Role_idRole",
                        column: x => x.idRole,
                        principalTable: "Role",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    idMachine = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idStatusMachine = table.Column<int>(nullable: false),
                    capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.idMachine);
                    table.ForeignKey(
                        name: "FK_Machine_StatusMachine_idStatusMachine",
                        column: x => x.idStatusMachine,
                        principalTable: "StatusMachine",
                        principalColumn: "idStatusMachine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    idUserRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idUser = table.Column<int>(nullable: false),
                    idRole = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.idUserRole);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_idRole",
                        column: x => x.idRole,
                        principalTable: "Role",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    idNotification = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idClient = table.Column<int>(nullable: false),
                    idUser = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    idStatusMachine = table.Column<int>(nullable: false),
                    totalSales = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.idNotification);
                    table.ForeignKey(
                        name: "FK_Notification_Client_idClient",
                        column: x => x.idClient,
                        principalTable: "Client",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_StatusMachine_idStatusMachine",
                        column: x => x.idStatusMachine,
                        principalTable: "StatusMachine",
                        principalColumn: "idStatusMachine",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationProductEntry",
                columns: table => new
                {
                    idOperationEntry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateOperation = table.Column<DateTime>(nullable: false),
                    dateOperationEntry = table.Column<DateTime>(nullable: false),
                    idProduct = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    unitValue = table.Column<float>(nullable: false),
                    idProvider = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationProductEntry", x => x.idOperationEntry);
                    table.ForeignKey(
                        name: "FK_OperationProductEntry_Product_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationProductEntry_Provider_idProvider",
                        column: x => x.idProvider,
                        principalTable: "Provider",
                        principalColumn: "idProvider",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                columns: table => new
                {
                    idPurchaseDetail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idProduct = table.Column<int>(nullable: false),
                    idPurchaseOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.idPurchaseDetail);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Product_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_PurchaseOrder_idPurchaseOrder",
                        column: x => x.idPurchaseOrder,
                        principalTable: "PurchaseOrder",
                        principalColumn: "idPurchaseOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientMachine",
                columns: table => new
                {
                    idClientMachine = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idClient = table.Column<int>(nullable: false),
                    idMachine = table.Column<int>(nullable: false),
                    dateAssignment = table.Column<DateTime>(nullable: false),
                    state = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMachine", x => x.idClientMachine);
                    table.ForeignKey(
                        name: "FK_ClientMachine_Client_idClient",
                        column: x => x.idClient,
                        principalTable: "Client",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientMachine_Machine_idMachine",
                        column: x => x.idMachine,
                        principalTable: "Machine",
                        principalColumn: "idMachine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationProductOutput",
                columns: table => new
                {
                    idOperationOutput = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateOperation = table.Column<DateTime>(nullable: false),
                    idProducto = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    unitValue = table.Column<float>(nullable: false),
                    idClient = table.Column<int>(nullable: false),
                    idNotification = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationProductOutput", x => x.idOperationOutput);
                    table.ForeignKey(
                        name: "FK_OperationProductOutput_Client_idClient",
                        column: x => x.idClient,
                        principalTable: "Client",
                        principalColumn: "idClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationProductOutput_Notification_idNotification",
                        column: x => x.idNotification,
                        principalTable: "Notification",
                        principalColumn: "idNotification",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperationProductOutput_Product_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Product",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_idPerson",
                table: "Client",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMachine_idClient",
                table: "ClientMachine",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMachine_idMachine",
                table: "ClientMachine",
                column: "idMachine");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_idStatusMachine",
                table: "Machine",
                column: "idStatusMachine");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_idClient",
                table: "Notification",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_idStatusMachine",
                table: "Notification",
                column: "idStatusMachine");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_idUser",
                table: "Notification",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProductEntry_idProduct",
                table: "OperationProductEntry",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProductEntry_idProvider",
                table: "OperationProductEntry",
                column: "idProvider");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProductOutput_idClient",
                table: "OperationProductOutput",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProductOutput_idNotification",
                table: "OperationProductOutput",
                column: "idNotification");

            migrationBuilder.CreateIndex(
                name: "IX_OperationProductOutput_idProducto",
                table: "OperationProductOutput",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idProductType",
                table: "Product",
                column: "idProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idProvider",
                table: "Product",
                column: "idProvider");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_idProduct",
                table: "PurchaseDetail",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_idPurchaseOrder",
                table: "PurchaseDetail",
                column: "idPurchaseOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_idProvider",
                table: "PurchaseOrder",
                column: "idProvider");

            migrationBuilder.CreateIndex(
                name: "IX_RolePage_idPage",
                table: "RolePage",
                column: "idPage");

            migrationBuilder.CreateIndex(
                name: "IX_RolePage_idRole",
                table: "RolePage",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_idRole",
                table: "UserRole",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_idUser",
                table: "UserRole",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMachine");

            migrationBuilder.DropTable(
                name: "OperationProductEntry");

            migrationBuilder.DropTable(
                name: "OperationProductOutput");

            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "RolePage");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "StatusMachine");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
