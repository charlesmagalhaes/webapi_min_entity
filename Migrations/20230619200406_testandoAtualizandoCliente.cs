﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi_min_entity.Migrations
{
    /// <inheritdoc />
    public partial class testandoAtualizandoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cli_nome",
                table: "Fornecedores",
                type: "character varying(99)",
                maxLength: 99,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cli_nome",
                table: "Fornecedores",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(99)",
                oldMaxLength: 99);
        }
    }
}
