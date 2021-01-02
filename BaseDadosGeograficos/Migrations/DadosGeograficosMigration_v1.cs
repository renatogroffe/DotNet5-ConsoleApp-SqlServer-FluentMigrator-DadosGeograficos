using FluentMigrator;

namespace BaseDadosGeograficos.Migrations
{
    [Migration(1)]
    public class DadosGeograficosMigration_v1 : Migration
    {
        public override void Up()
        {
    		Create.Table("Regioes")
	    		.WithColumn("IdRegiao").AsInt32().NotNullable().PrimaryKey()
		    	.WithColumn("NomeRegiao").AsAnsiString(20).NotNullable();

    		Create.Table("Estados")
	    		.WithColumn("SiglaEstado").AsFixedLengthAnsiString(2).NotNullable().PrimaryKey()
                .WithColumn("NomeEstado").AsAnsiString(20).NotNullable()
                .WithColumn("NomeCapital").AsAnsiString(20).NotNullable()
                .WithColumn("IdRegiao").AsInt32().NotNullable();

            Create.ForeignKey("FK_Estado_Regiao")
                .FromTable("Estados").ForeignColumn("IdRegiao")
                .ToTable("Regioes").PrimaryColumn("IdRegiao");
            
            InsertDadosGeograficos();
        }

        public override void Down()
        {
            Delete.Table("Regioes");
        }

        private void InsertDadosGeograficos()
        {
            // Inclusao de Regioes
            InsertRegiao(1, "Centro-Oeste");
            InsertRegiao(2, "Nordeste");
            InsertRegiao(3, "Norte");
            InsertRegiao(4, "Sudeste");
            InsertRegiao(5, "Sul");

            // Inclusao de Estados
            InsertEstado("AC", "Acre", "Rio Branco", 3);
            InsertEstado("AL", "Alagoas", "Maceio", 2);
            InsertEstado("AP", "Amapa", "Macapa", 3);
            InsertEstado("AM", "Amazonas", "Manaus", 3);
            InsertEstado("BA", "Bahia", "Salvador", 2);
            InsertEstado("CE", "Ceara", "Fortaleza", 2);
            InsertEstado("DF", "Distrito Federal", "Brasilia", 1);
            InsertEstado("ES", "Espirito Santo", "Vitoria", 4);
            InsertEstado("GO", "Goias", "Goiania", 1);
            InsertEstado("MA", "Maranhao", "Sao Luis", 2);
            InsertEstado("MT", "Mato Grosso", "Cuiaba", 1);
            InsertEstado("MS", "Mato Grosso do Sul", "Campo Grande", 1);
            InsertEstado("MG", "Minas Gerais", "Belo Horizonte", 4);
            InsertEstado("PA", "Para", "Belem", 3);
            InsertEstado("PB", "Paraiba", "Joao Pessoa", 2);
            InsertEstado("PR", "Parana", "Curitiba", 5);
            InsertEstado("PE", "Pernambuco", "Recife", 2);
            InsertEstado("PI", "Piaui", "Teresina", 2);
            InsertEstado("RJ", "Rio de Janeiro", "Rio de Janeiro", 4);
            InsertEstado("RN", "Rio Grande do Norte", "Natal", 2);
            InsertEstado("RS", "Rio Grande do Sul", "Porto Alegre", 5);
            InsertEstado("RO", "Rondônia", "Porto Velho", 3);
            InsertEstado("RR", "Roraima", "Boa Vista", 3);
            InsertEstado("SC", "Santa Catarina", "Florianopolis", 5);
            InsertEstado("SP", "Sao Paulo", "Sao Paulo", 4);
            InsertEstado("SE", "Sergipe", "Aracaju", 2);
            InsertEstado("TO", "Tocantins", "Palmas", 3);
        }
        
        private void InsertRegiao(
            int idRegiao, string nomeRegiao)
        {
            Insert.IntoTable("Regioes").Row(new
            {
                IdRegiao = idRegiao,
                NomeRegiao = nomeRegiao
            });
        }        

        private void InsertEstado(
            string siglaEstado, string nomeEstado,
            string nomeCapital, int idRegiao)
        {
            Insert.IntoTable("Estados").Row(new
            {
                SiglaEstado = siglaEstado,
                NomeEstado = nomeEstado,
                IdRegiao = idRegiao,
                NomeCapital = nomeCapital
            });
        }        
    }
}