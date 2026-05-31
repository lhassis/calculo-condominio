using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CondominioApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apartamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    bloco = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    metragem = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    fracao_ideal = table.Column<decimal>(type: "numeric(10,6)", precision: 10, scale: 6, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "calculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    periodo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    total_apartamentos = table.Column<int>(type: "integer", nullable: false),
                    finalizado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calculos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "despesas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    valor = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rateio_por_fracao_ideal_id = table.Column<int>(type: "integer", nullable: false),
                    ativa = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_despesas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ajustes_apartamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apartamento_id = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    periodo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ajustes_apartamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_ajustes_apartamento_apartamentos_apartamento_id",
                        column: x => x.apartamento_id,
                        principalTable: "apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "creditos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apartamento_id = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    data_credito = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    utilizado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditos", x => x.id);
                    table.ForeignKey(
                        name: "FK_creditos_apartamentos_apartamento_id",
                        column: x => x.apartamento_id,
                        principalTable: "apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dados_cobranca",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apartamento_id = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    contato = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dados_cobranca", x => x.id);
                    table.ForeignKey(
                        name: "FK_dados_cobranca_apartamentos_apartamento_id",
                        column: x => x.apartamento_id,
                        principalTable: "apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "envios_email",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calculo_id = table.Column<int>(type: "integer", nullable: false),
                    apartamento_id = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    assunto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    enviado_com_sucesso = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    mensagem_erro = table.Column<string>(type: "text", nullable: true),
                    data_envio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_envios_email", x => x.id);
                    table.ForeignKey(
                        name: "FK_envios_email_apartamentos_apartamento_id",
                        column: x => x.apartamento_id,
                        principalTable: "apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_envios_email_calculos_calculo_id",
                        column: x => x.calculo_id,
                        principalTable: "calculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resultados_calculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    calculo_id = table.Column<int>(type: "integer", nullable: false),
                    apartamento_id = table.Column<int>(type: "integer", nullable: false),
                    valor_despesas = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    valor_creditos_aplicados = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    valor_ajustes = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    valor_final = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    detalhamento = table.Column<string>(type: "text", nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultados_calculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_resultados_calculo_apartamentos_apartamento_id",
                        column: x => x.apartamento_id,
                        principalTable: "apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resultados_calculo_calculos_calculo_id",
                        column: x => x.calculo_id,
                        principalTable: "calculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parametros_despesa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    despesa_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_rateio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    percentual = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW() AT TIME ZONE 'UTC'"),
                    atualizado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametros_despesa", x => x.id);
                    table.ForeignKey(
                        name: "FK_parametros_despesa_despesas_despesa_id",
                        column: x => x.despesa_id,
                        principalTable: "despesas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ajustes_apartamento_apartamento_id_periodo",
                table: "ajustes_apartamento",
                columns: new[] { "apartamento_id", "periodo" });

            migrationBuilder.CreateIndex(
                name: "IX_apartamentos_bloco_numero",
                table: "apartamentos",
                columns: new[] { "bloco", "numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_calculos_periodo",
                table: "calculos",
                column: "periodo");

            migrationBuilder.CreateIndex(
                name: "IX_creditos_apartamento_id",
                table: "creditos",
                column: "apartamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_dados_cobranca_apartamento_id",
                table: "dados_cobranca",
                column: "apartamento_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dados_cobranca_email",
                table: "dados_cobranca",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_despesas_ativa",
                table: "despesas",
                column: "ativa");

            migrationBuilder.CreateIndex(
                name: "IX_envios_email_apartamento_id",
                table: "envios_email",
                column: "apartamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_envios_email_calculo_id",
                table: "envios_email",
                column: "calculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_parametros_despesa_despesa_id",
                table: "parametros_despesa",
                column: "despesa_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_resultados_calculo_apartamento_id",
                table: "resultados_calculo",
                column: "apartamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_resultados_calculo_calculo_id_apartamento_id",
                table: "resultados_calculo",
                columns: new[] { "calculo_id", "apartamento_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ajustes_apartamento");

            migrationBuilder.DropTable(
                name: "creditos");

            migrationBuilder.DropTable(
                name: "dados_cobranca");

            migrationBuilder.DropTable(
                name: "envios_email");

            migrationBuilder.DropTable(
                name: "parametros_despesa");

            migrationBuilder.DropTable(
                name: "resultados_calculo");

            migrationBuilder.DropTable(
                name: "despesas");

            migrationBuilder.DropTable(
                name: "apartamentos");

            migrationBuilder.DropTable(
                name: "calculos");
        }
    }
}
