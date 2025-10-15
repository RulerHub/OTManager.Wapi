using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsConfigsUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Clients_ClientId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Orders_OrderId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCosts_Orders_OrderId",
                table: "MaterialCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCosts_Orders_OrderId",
                table: "ServiceCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerCosts_Orders_OrderId",
                table: "WorkerCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_Code",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCosts",
                table: "MaterialCosts");

            migrationBuilder.DropIndex(
                name: "IX_MaterialCosts_Code",
                table: "MaterialCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Features",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_Code",
                table: "Features");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Code",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "MaterialCosts",
                newName: "MaterialCost");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "Facture");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CreatedAt",
                table: "Order",
                newName: "IX_Order_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_Name",
                table: "Material",
                newName: "IX_Material_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CreatedAt",
                table: "Material",
                newName: "IX_Material_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_OrderId",
                table: "MaterialCost",
                newName: "IX_MaterialCost_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_Name",
                table: "MaterialCost",
                newName: "IX_MaterialCost_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCosts_CreatedAt",
                table: "MaterialCost",
                newName: "IX_MaterialCost_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Features_OrderId",
                table: "Facture",
                newName: "IX_Facture_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Features_CreatedAt",
                table: "Facture",
                newName: "IX_Facture_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Features_ClientId",
                table: "Facture",
                newName: "IX_Facture_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_Name",
                table: "Client",
                newName: "IX_Client_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CreatedAt",
                table: "Client",
                newName: "IX_Client_CreatedAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourlyRate",
                table: "Workers",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "HourlyRate",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Material",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Material",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MaterialCost",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MaterialCost",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Facture",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Facture",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCost",
                table: "MaterialCost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facture",
                table: "Facture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderNumber",
                table: "Order",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_Code",
                table: "Material",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCost_Code",
                table: "MaterialCost",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facture_Code",
                table: "Facture",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_Code",
                table: "Client",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Client_ClientId",
                table: "Facture",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_Order_OrderId",
                table: "Facture",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCost_Order_OrderId",
                table: "MaterialCost",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCosts_Order_OrderId",
                table: "ServiceCosts",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerCosts_Order_OrderId",
                table: "WorkerCosts",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Client_ClientId",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_Facture_Order_OrderId",
                table: "Facture");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialCost_Order_OrderId",
                table: "MaterialCost");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCosts_Order_OrderId",
                table: "ServiceCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerCosts_Order_OrderId",
                table: "WorkerCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderNumber",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCost",
                table: "MaterialCost");

            migrationBuilder.DropIndex(
                name: "IX_MaterialCost_Code",
                table: "MaterialCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_Code",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facture",
                table: "Facture");

            migrationBuilder.DropIndex(
                name: "IX_Facture_Code",
                table: "Facture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_Code",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "MaterialCost",
                newName: "MaterialCosts");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "Facture",
                newName: "Features");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CreatedAt",
                table: "Orders",
                newName: "IX_Orders_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_OrderId",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_Name",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialCost_CreatedAt",
                table: "MaterialCosts",
                newName: "IX_MaterialCosts_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Material_Name",
                table: "Materials",
                newName: "IX_Materials_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Material_CreatedAt",
                table: "Materials",
                newName: "IX_Materials_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Facture_OrderId",
                table: "Features",
                newName: "IX_Features_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Facture_CreatedAt",
                table: "Features",
                newName: "IX_Features_CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Facture_ClientId",
                table: "Features",
                newName: "IX_Features_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Client_Name",
                table: "Clients",
                newName: "IX_Clients_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Client_CreatedAt",
                table: "Clients",
                newName: "IX_Clients_CreatedAt");

            migrationBuilder.AlterColumn<decimal>(
                name: "HourlyRate",
                table: "Workers",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "HourlyRate",
                table: "WorkerCosts",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MaterialCosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MaterialCosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCosts",
                table: "MaterialCosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Features",
                table: "Features",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialCosts_Code",
                table: "MaterialCosts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Code",
                table: "Materials",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Code",
                table: "Features",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Code",
                table: "Clients",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Clients_ClientId",
                table: "Features",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Orders_OrderId",
                table: "Features",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialCosts_Orders_OrderId",
                table: "MaterialCosts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCosts_Orders_OrderId",
                table: "ServiceCosts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerCosts_Orders_OrderId",
                table: "WorkerCosts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
