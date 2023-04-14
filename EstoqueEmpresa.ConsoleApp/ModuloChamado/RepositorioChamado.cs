using EstoqueEmpresa.ConsoleApp.ModuloEquipamento;
using System.Collections;

namespace EstoqueEmpresa.ConsoleApp.ModuloChamado
{
    internal class RepositorioChamado
    {
        private static int id = 1;
        static ArrayList _listaChamados = new ArrayList();

        public static void Criar(Chamado chamado)
        {
            chamado.Id = id;

            _listaChamados.Add(chamado);

            Program.IncrementarId();
        }

        internal static ArrayList ObterLista()
        {
            return _listaChamados;
        }
        public static Chamado ObterPorId(int id)
        {
            Chamado chamado = null;

            foreach (Chamado _chamado in _listaChamados)
            {
                if (_chamado.Id == id)
                {
                    chamado = _chamado;
                    break;
                }
            }

            return chamado;
        }

        internal static void Editar(int id, Chamado chamadoAtualizado)
        {
            Chamado chamado = ObterPorId(id);
            chamado.Titulo = chamadoAtualizado.Titulo;
            chamado.Descricao = chamadoAtualizado.Descricao;
            chamado.DataAbertura = chamadoAtualizado.DataAbertura;
            chamado.Equipamento = chamadoAtualizado.Equipamento;
        }

        internal static void Excluir(int idChamadoEditar)
        {
            Chamado chamado = ObterPorId(idChamadoEditar);
            _listaChamados.Remove(chamado);
        }
        public static void CadastrarAlgunsChamadosAutomaticamente()
        {
            int Id = id;
            string titulo = "Impressão fraca";
            string descricao = "Mesmo trocando o toner, impressão continua fraca";
            string dataAbertura = "04/04/2023";
            Equipamento equipamento = RepositorioEquipamento.ObterPorId(1);
            Chamado chamado = new Chamado(Id, titulo, descricao, dataAbertura, equipamento);
            _listaChamados.Add(chamado);
            Program.IncrementarId();
        }
    }
}
