namespace EstoqueEmpresa.ConsoleApp.ModuloEquipamento
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string NumeroSerie { get; set; }
        public string DataFabricante { get; set; }
        public string Fabricante { get; set; }
        public Equipamento(Equipamento equipamento)
        {
            this.Id = equipamento.Id;
            this.Nome = equipamento.Nome;
            this.Preco = equipamento.Preco;
            this.NumeroSerie = equipamento.NumeroSerie;
            this.DataFabricante = equipamento.DataFabricante;
            this.Fabricante = equipamento.Fabricante;
        }
        public Equipamento(int id, string nome, double preco, string numeroSerie, string dataFabricante, string fabricante)
        {
            this.Id = id;
            this.Nome= nome;
            this.Preco = preco;
            this.NumeroSerie = numeroSerie;
            this.DataFabricante = dataFabricante;
            this.Fabricante = fabricante;
        }
        public Equipamento(string nome, double preco, string numeroSerie, string dataFabricante, string fabricante)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.NumeroSerie = numeroSerie;
            this.DataFabricante = dataFabricante;
            this.Fabricante = fabricante;
        }
    }
}
