using EstoqueEmpresa.ConsoleApp.ModuloEquipamento;

namespace EstoqueEmpresa.ConsoleApp.ModuloChamado
{
    internal class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DataAbertura { get; set; }
        public Equipamento Equipamento { get; set; }

        public Chamado(Chamado chamado)
        {
            this.Id = chamado.Id;
            this.Titulo = chamado.Titulo;
            this.Descricao = chamado.Descricao;
            this.DataAbertura = chamado.DataAbertura;
            this.Equipamento = chamado.Equipamento;
        }
        public Chamado(int id, string titulo, string descricao, string dataAbertura, Equipamento equipamento)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.DataAbertura = dataAbertura;
            this.Equipamento = equipamento;
        }
        public Chamado(string titulo, string descricao, string dataAbertura, Equipamento equipamento)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.DataAbertura = dataAbertura;
            this.Equipamento = equipamento;
        }
    }
}
