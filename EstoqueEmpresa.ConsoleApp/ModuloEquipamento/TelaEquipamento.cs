using System.Collections;

namespace EstoqueEmpresa.ConsoleApp.ModuloEquipamento
{
    internal class TelaEquipamento
    {
        public static void ImprimirMenuEquipamentos()
        {
            #region MenuEquipamentos
            Console.Clear();
            Console.WriteLine("Menu Equipamentos");
            Console.WriteLine("Selecione a opcao desejada: ");
            Console.WriteLine();
            Console.WriteLine("[1] Cadastrar um equipamento: ");
            Console.WriteLine("[2] Listar todos os equipamentos: ");
            Console.WriteLine("[3] Editar um equipamento: ");
            Console.WriteLine("[4] Excluir um equipamento: ");
            Console.WriteLine();
            Console.WriteLine("[0] Voltar menu inicial: ");
            Console.WriteLine();
            #endregion
            Console.Write("Digite a opcao: ");
            int opcaoMenuEquipamento = Convert.ToInt32(Console.ReadLine());
            switch (opcaoMenuEquipamento)
            {
                #region CadastrarEquipamento
                case 1:
                    {
                        CadastrarEquipamento();
                    }
                    break;
                #endregion

                #region ListarEquipamentos
                case 2:
                    {
                        ListarEquipamentos();
                    }
                    break;
                #endregion

                #region EditarEquipamento
                case 3:
                    {
                        EditarEquipamento();
                    }
                    break;
                #endregion

                #region ExcluirEquipamento
                case 4:
                    {
                        ExcluirEquipamento();
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
        private static void ExcluirEquipamento()
        {
            Program.ImprimirCabecalho("Cadastro Equipamento", "Exclusão de Equipamento");
            ImprimirListaEquipamentos();
            int idEquipamentoExcluir = EncontrarIdEquipamento();
            RepositorioEquipamento.Excluir(idEquipamentoExcluir);
            Program.ImprimirMensagem("Equipamento excluído com sucesso!", ConsoleColor.DarkGreen);
            Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu de equipamentos.", ConsoleColor.DarkYellow);
            ImprimirMenuEquipamentos();
        }
        private static void EditarEquipamento()
        {
            Program.ImprimirCabecalho("Cadastro Equipamento", "Edição de Equipamento");
            ImprimirListaEquipamentos();
            int idEquipamentoEditar = EncontrarIdEquipamento();
            Equipamento equipamentoAtualizado = CriarPropriedadesEquipamento();
            RepositorioEquipamento.Editar(idEquipamentoEditar, equipamentoAtualizado);
            Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu de equipamentos.", ConsoleColor.DarkYellow);
            ImprimirMenuEquipamentos();
        }
        private static void ListarEquipamentos()
        {
            Program.ImprimirCabecalho("Cadastro Equipamento", "Lista de Equipamentos");
            ImprimirListaEquipamentos();
            Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu Equipamentos...", ConsoleColor.DarkYellow);
            ImprimirMenuEquipamentos();
        }
        private static void CadastrarEquipamento()
        {
            Program.ImprimirCabecalho("Menu Equipamento", "Cadastro de Equipamento");
            Equipamento novoEquipamento = CriarPropriedadesEquipamento();
            RepositorioEquipamento.Criar(novoEquipamento);
            Program.ImprimirMensagem("Equipamento cadastrado com sucesso!", ConsoleColor.DarkGreen);
            Program.ImprimirMensagemSaidaMenu("Pressione qualquer tecla para voltar ao menu Equipamentos...", ConsoleColor.DarkYellow);
            ImprimirMenuEquipamentos();
        }
        public static int EncontrarIdEquipamento()
        {
            int idEquipamentoEditar;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o ID do equipamento desejado: ");
                idEquipamentoEditar = Convert.ToInt32(Console.ReadLine());
                idInvalido = RepositorioEquipamento.ObterPorId(idEquipamentoEditar) == null;
                if (idInvalido)
                {
                    Program.ImprimirMensagem("Id inválido, tente novamente", ConsoleColor.Red);
                }
            }
            while (idInvalido);
            Console.WriteLine($"Equipamento selecionado com o ID {idEquipamentoEditar}");
            return idEquipamentoEditar;
        }
        public static void ImprimirListaEquipamentos()
        {
            ArrayList listaEquipamentos = RepositorioEquipamento.ObterLista();
            if (listaEquipamentos.Count == 0)
            {
                Program.ImprimirMensagem("Não há equipamentos cadastrados.", ConsoleColor.DarkRed);
            }
            else
            {
                foreach (Equipamento equipamento in listaEquipamentos)
                {
                    Console.WriteLine($"ID: {equipamento.Id}");
                    Console.WriteLine($"Nome: {equipamento.Nome}");
                    Console.WriteLine($"Preço de aquisição: {equipamento.Preco}");
                    Console.WriteLine($"Número de série: {equipamento.NumeroSerie}");
                    Console.WriteLine($"Data de fabricação: {equipamento.DataFabricante}");
                    Console.WriteLine($"Nome do fabricante: {equipamento.Fabricante}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
        private static Equipamento CriarPropriedadesEquipamento()
        {
            Console.WriteLine("Digite o nome do equipamento com no maximo 6 caracteres");
            string nome = Console.ReadLine();
            while (nome.Length > 6)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nome maior que 6 caracteres.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Digite o nome novamente: ");
                Console.ResetColor();
                nome = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Digite o preco da aquisicao");
            double preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite o numero de serie");
            string numeroSerie = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite a data de fabricacao");
            string dataFabricante = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite a nome do fabricante");
            string fabricante = Console.ReadLine();
            Equipamento equipamento = new Equipamento(nome, preco, numeroSerie, dataFabricante, fabricante);

            return equipamento;
        }
    }
}
