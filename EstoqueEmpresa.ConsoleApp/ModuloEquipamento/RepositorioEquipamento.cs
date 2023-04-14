using System.Collections;

namespace EstoqueEmpresa.ConsoleApp.ModuloEquipamento
{
    public class RepositorioEquipamento
    {
        private static int id = 1;
        static ArrayList _listaEquipamentos = new ArrayList();
        public static void Criar(Equipamento equipamento)
        {
            equipamento.Id = id;

            _listaEquipamentos.Add(equipamento);

            Program.IncrementarId();
        }
        public static void Editar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamento = ObterPorId(id);

            equipamento.Nome = equipamentoAtualizado.Nome;
            equipamento.Preco = equipamentoAtualizado.Preco;
            equipamento.NumeroSerie = equipamentoAtualizado.NumeroSerie;
            equipamento.DataFabricante = equipamentoAtualizado.DataFabricante;
            equipamento.Fabricante = equipamentoAtualizado.Fabricante;
        }
        public static void Excluir(int id)
        {
            Equipamento equipamento = ObterPorId(id);

            _listaEquipamentos.Remove(equipamento);
        }
        public static ArrayList ObterLista()
        {
            return _listaEquipamentos;
        }
        public static Equipamento ObterPorId(int id)
        {
            Equipamento equipamento = null;

            foreach (Equipamento _equip in _listaEquipamentos)
            {
                if (_equip.Id == id)
                {
                    equipamento = _equip;
                    break;
                }
            }

            return equipamento;
        }

    }
}
