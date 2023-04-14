using EstoqueEmpresa.ConsoleApp.ModuloEquipamento;
using System.Collections;

namespace EstoqueEmpresa.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        public static void ImprimirMenuChamados()
        {
            #region MenuChamado
            Console.Clear();
            Console.WriteLine("Menu Chamados");
            Console.WriteLine("Selecione a opcao desejada: ");
            Console.WriteLine();
            Console.WriteLine("[1] Registar um chamado: ");
            Console.WriteLine("[2] Listar todos os chamados: ");
            Console.WriteLine("[3] Editar um chamado: ");
            Console.WriteLine("[4] Excluir um chamado: ");
            Console.WriteLine();
            Console.WriteLine("[0] Voltar menu inicial: ");
            Console.WriteLine();
            #endregion
            Console.Write("Digite a opcao: ");
            int opcaoMenuChamados = Convert.ToInt32(Console.ReadLine());
            switch (opcaoMenuChamados)
            {
                #region RegistrarChamado
                case 1:
                    {
                        Program.ImprimirCabecalho("Menu Chamados", "Registro de Chamados");
                        Chamado novoChamado = CriarPropriedadesChamado();
                        RepositorioChamado.Criar(novoChamado);
                        Program.ImprimirMensagem("Chamado cadastrado com sucesso!", ConsoleColor.DarkGreen);
                        Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu Chamados...", ConsoleColor.DarkYellow);
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region ListarChamados
                case 2:
                    {
                        Program.ImprimirCabecalho("Cadastro Chamados", "Lista de Chamados");
                        ImprimirListaChamados();
                        Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu Equipamentos...", ConsoleColor.DarkYellow);
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region EditarChamado
                case 3:
                    {
                        ArrayList listaChamados = RepositorioChamado.ObterLista();
                        Program.ImprimirCabecalho("Cadastro Chamado", "Edição de Chamado");
                        ImprimirListaChamados();
                        int idChamadoEditar = EncontrarIdChamado();

                        foreach (string[] chamado in listaChamados)
                        {
                            if (Convert.ToInt32(chamado[0]) == idChamadoEditar)
                            {
                                Console.WriteLine("Chamado encontrado!");
                                Console.WriteLine();
                                Console.WriteLine($"Titulo: {chamado[1]}");
                                Console.WriteLine($"Descricao: {chamado[2]}");
                                Console.WriteLine($"Equipamento: {chamado[3]}");
                                Console.WriteLine($"Data abertura: {chamado[4]}");
                                Console.WriteLine();
                                Chamado chamadoAtualizado = CriarPropriedadesChamado();
                                RepositorioChamado.Editar(idChamadoEditar, chamadoAtualizado);
                                Program.ImprimirMensagem("Chamado editado com sucesso!", ConsoleColor.DarkGreen);
                                break;
                            }
                        }
                        Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu de chamados.", ConsoleColor.DarkYellow);
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region ExcluirChamado
                case 4:
                    {
                        Program.ImprimirCabecalho("Cadastro Chamado", "Exclusão de Chamado");
                        ImprimirListaChamados();
                        int idChamadoEditar = EncontrarIdChamado();
                        RepositorioChamado.Excluir(idChamadoEditar);
                        Program.ImprimirMensagem("Chamado excluído com sucesso!", ConsoleColor.DarkGreen);
                        Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu de chamados.", ConsoleColor.DarkYellow);
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region ImprimirMenuInicial
                case 0:
                    {
                        Console.Clear();
                        Program.ImprimirMenuInicial();
                    }
                    break;
                    #endregion
            }
        }

        private static int EncontrarIdChamado()
        {
            int idChamadoEditar;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o ID do chamado desejado: ");
                idChamadoEditar = Convert.ToInt32(Console.ReadLine());
                idInvalido = RepositorioChamado.ObterPorId(idChamadoEditar) == null;
                if (idInvalido)
                {
                    Program.ImprimirMensagem("Id inválido, tente novamente", ConsoleColor.Red);
                }
            }
            while (idInvalido);
            Console.WriteLine($"Chamado selecionado com o ID {idChamadoEditar}");
            return idChamadoEditar;
        }

        private static Chamado CriarPropriedadesChamado()
        {
            Program.ImprimirCabecalho("Menu Chamados", "Registro de Chamados");
            Chamado novoChamado = CriarPropriedadesChamado();
            Console.WriteLine("Digite o titulo do chamado");
            string tituloChamado = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite a descricao do chamado");
            string descricaoChamado = Console.ReadLine();
            Console.WriteLine();
            int idEquipamento = TelaEquipamento.EncontrarIdEquipamento();
            Equipamento equipamento = RepositorioEquipamento.ObterPorId(idEquipamento);
            Console.WriteLine();
            Console.WriteLine("Digite a data de abertura do chamado");
            string dataAberturaChamado = Console.ReadLine();
            Chamado chamado = new Chamado(tituloChamado, descricaoChamado, dataAberturaChamado, equipamento);
            return chamado;
        }
        public static void ImprimirListaChamados()
        {
            ArrayList listaChamados = RepositorioChamado.ObterLista();
            if (listaChamados.Count == 0)
            {
                Program.ImprimirMensagem("Não há chamados cadastrados.", ConsoleColor.DarkRed);
            }
            else
            {
                foreach (Chamado chamados in listaChamados)
                {
                    Console.WriteLine($"ID: {chamados.Id}");
                    Console.WriteLine($"Titulo: {chamados.Titulo}");
                    Console.WriteLine($"Descricao: {chamados.Descricao}");
                    Console.WriteLine($"Data Abertura: {chamados.DataAbertura}");
                    Console.WriteLine($"Equipamento nome: {chamados.Equipamento.Nome}");
                    Console.WriteLine($"Numero de Serie: {chamados.Equipamento.NumeroSerie}");
                    Console.WriteLine("---------------------------------------------");
                    DateTime dataAbertura = DateTime.ParseExact(chamados.DataAbertura, "dd/MM/yyyy", null);
                    string dataAberturaFormatada = dataAbertura.ToString("dd/MM/yyyy");
                    TimeSpan diferenca = DateTime.Now.Subtract(dataAbertura);
                    int diasAberto = (int)diferenca.TotalDays;
                    Console.WriteLine($"Data abertura: {dataAberturaFormatada}");
                    Console.WriteLine($"O chamado esta aberto a {diasAberto} dias");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
    }
}
