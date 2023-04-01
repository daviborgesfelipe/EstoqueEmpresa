using System.Collections;

namespace EstoqueEmpresa.ConsoleApp
{
    internal class Program
    {
        static ArrayList listaEquipamentos = new ArrayList();
        static ArrayList listaChamados = new ArrayList();
        static string[] equipamento = new string[6];
        static string[] chamado = new string[5];
        static int idEquipamento = 4;
        static int idChamado = 4;
        static void ImprimirMenuInicial()
        {
            Console.WriteLine("Menu Inicial");
            Console.WriteLine("Selecione a opcao desejada: ");
            Console.WriteLine();
            Console.WriteLine("[1] Equipamentos: ");
            Console.WriteLine("[2] Chamados: ");
            Console.WriteLine();
            Console.WriteLine("[0] Sair: ");
            Console.WriteLine();
            Console.Write("Digite a opcao: ");
            int opcaoMenuInicial = Convert.ToInt32(Console.ReadLine());
            switch (opcaoMenuInicial)
            {
                #region MenuEquipamentos
                case 1:
                    {
                        ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region MenuChamados
                case 2:
                    {
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region Sair da aplicacao
                case 0:
                    break;
                    #endregion
            }
        }
        static void ImprimirMenuChamados()
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
                        Console.Clear();
                        Console.WriteLine("Registro de Chamados");
                        Console.WriteLine();
                        Console.WriteLine("Digite o titulo do chamado");
                        string tituloChamado = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Digite a descricao do chamado");
                        string descricaoChamado = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Digite o id do equipamento");
                        string equipamentoChamado = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Digite a data de abertura do chamado");
                        string dataAberturaChamado = Console.ReadLine();



                        chamado[0] = Convert.ToString(idChamado);
                        chamado[1] = tituloChamado;
                        chamado[2] = descricaoChamado;
                        chamado[3] = equipamentoChamado;
                        chamado[4] = dataAberturaChamado;
                        listaChamados.Add(chamado);
                        idChamado++;
                        Console.WriteLine();
                        Console.WriteLine("Chamado cadastrado com sucesso!");
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu Chamados...");
                        Console.ReadKey();
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion
                
                #region ListarChamados
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Lista de Chamados");
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------");

                        if (listaChamados.Count == 0)
                        {
                            Console.WriteLine("Não há chamados cadastrados.");
                        }
                        else
                        {
                            foreach (string[] chamado in listaChamados)
                            {
                                DateTime dataAbertura = DateTime.ParseExact(chamado[4], "dd/MM/yyyy", null);
                                string dataAberturaFormatada = dataAbertura.ToString("dd/MM/yyyy");
                                TimeSpan diferenca = DateTime.Now.Subtract(dataAbertura);
                                int diasAberto = (int)diferenca.TotalDays;
                                
                                Console.WriteLine($"ID: {chamado[0]}");
                                Console.WriteLine($"Titulo: {chamado[1]}");
                                Console.WriteLine($"Descricao: {chamado[2]}");
                                Console.WriteLine($"Id do equipamento: {chamado[3] }");
                                foreach (string[] equi in listaEquipamentos)
                                {
                                    if (chamado[3] == equi[0])
                                    {
                                        Console.WriteLine($"Nome do equipamento: {equi[1]}");
                                    }
                                }
                                Console.WriteLine($"Data abertura: {dataAberturaFormatada}");
                                Console.WriteLine($"O chamado esta aberto a {diasAberto} dias");
                                Console.WriteLine("---------------------------------------------");
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu Chamados...");
                        Console.ReadKey();
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion
                
                #region EditarChamado
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Edição de Equipamento");
                        Console.WriteLine();
                        Console.WriteLine("Digite o ID do equipamento que deseja editar: ");
                        int idChamadoEditar = Convert.ToInt32(Console.ReadLine());
                        bool chamadoEncontrado = false;
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
                                Console.WriteLine("Digite os novos dados do chamado: ");
                                Console.WriteLine("Digite o novo titulo do chamado: ");
                                string novoTituloCadastro = Console.ReadLine();

                                Console.WriteLine("Atualize a descricao: ");
                                string novoDescricaoCadastro = Console.ReadLine();

                                Console.WriteLine("Atualize equipamento: ");
                                string novoEquipamentoChamado = Console.ReadLine();

                                Console.WriteLine("Atualize a data de abertura: ");
                                string novaDataAberturaChamado = Console.ReadLine();

                                chamado[1] = novoTituloCadastro;
                                chamado[2] = novaDataAberturaChamado;
                                chamado[3] = novoEquipamentoChamado;
                                chamado[4] = novaDataAberturaChamado;

                                Console.WriteLine();
                                Console.WriteLine("Chamado editado com sucesso!");
                                chamadoEncontrado = true;
                                break;
                            }
                        }

                        if (!chamadoEncontrado)
                        {
                            Console.WriteLine("Chamado não encontrado.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de chamados.");
                        Console.ReadKey();
                        ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region ExcluirChamado
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Exclusão de Chamado");
                        Console.WriteLine();

                        Console.WriteLine("Digite o ID do chamado que deseja excluir: ");
                        int idChamadoExcluir = Convert.ToInt32(Console.ReadLine()) - 1;

                        bool chamadoEncontrado = false;


                        foreach (string[] chamd in listaChamados)
                        {
                            int idFor = Convert.ToInt32(chamd[0]);
                            if (idFor == idChamadoExcluir)
                            {
                                chamadoEncontrado = true;
                                listaEquipamentos.RemoveAt(idChamadoExcluir);
                                Console.WriteLine("Chamado excluído com sucesso!");
                                Console.WriteLine();
                                break;
                            }
                        }


                        if (!chamadoEncontrado)
                        {
                            Console.WriteLine("Chamado não encontrado!");
                            Console.WriteLine();
                        }

                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        ImprimirMenuChamados();

                    }
                    break;
                #endregion

                #region ImprimirMenuInicial
                case 0:
                    {
                        Console.Clear();
                        ImprimirMenuInicial();
                    }
                    break;
                #endregion
            }
        }
        static void ImprimirMenuEquipamentos()
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
                        Console.Clear();
                        Console.WriteLine("Cadastro de Equipamento");
                        Console.WriteLine();
                        Console.WriteLine("Digite o nome do equipamento com no maximo 6 caracteres");
                        string nomeEquipamento = Console.ReadLine();
                        while (nomeEquipamento.Length > 6)
                        {
                            Console.WriteLine("Nome maior que 6 caracteres.");
                            Console.WriteLine("Digite o nome novamente: ");
                            nomeEquipamento = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Digite o preco da aquisicao");
                        double precoAquisicao = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Digite o numero de serie");
                        string numeroSerie = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Digite a data de fabricacao");
                        string dataFabricacao = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Digite a nome do fabricante");
                        string nomeFabricante = Console.ReadLine();

                        equipamento[0] = Convert.ToString(idEquipamento);
                        equipamento[1] = nomeEquipamento;
                        equipamento[2] = Convert.ToString(precoAquisicao);
                        equipamento[3] = numeroSerie;
                        equipamento[4] = dataFabricacao;
                        equipamento[5] = nomeFabricante;
                        listaEquipamentos.Add(equipamento);
                        idEquipamento++;
                        Console.WriteLine();
                        Console.WriteLine("Equipamento cadastrado com sucesso!");
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu Equipamentos...");
                        Console.ReadKey();
                        ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region ListarEquipamentos
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Lista de Equipamentos");
                        Console.WriteLine();
                        Console.WriteLine("---------------------------------------------");

                        if (listaEquipamentos.Count == 0)
                        {
                            Console.WriteLine("Não há equipamentos cadastrados.");
                        }
                        else
                        {
                            foreach (string[] equipamento in listaEquipamentos)
                            {
                                Console.WriteLine($"ID: {equipamento[0]}");
                                Console.WriteLine($"Nome: {equipamento[1]}");
                                Console.WriteLine($"Preço de aquisição: {equipamento[2]}");
                                Console.WriteLine($"Número de série: {equipamento[3]}");
                                Console.WriteLine($"Data de fabricação: {equipamento[4]}");
                                Console.WriteLine($"Nome do fabricante: {equipamento[5]}");
                                Console.WriteLine("---------------------------------------------");
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu Equipamentos...");
                        Console.ReadKey();
                        ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region EditarEquipamento
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Edição de Equipamento");
                        Console.WriteLine();
                        Console.WriteLine("Digite o ID do equipamento que deseja editar: ");
                        int idEquipamentoEditar = Convert.ToInt32(Console.ReadLine());
                        bool equipamentoEncontrado = false;
                        foreach (string[] equipamento in listaEquipamentos)
                        {
                            if (Convert.ToInt32(equipamento[0]) == idEquipamentoEditar)
                            {
                                Console.WriteLine("Equipamento encontrado!");
                                Console.WriteLine();
                                Console.WriteLine($"ID: {equipamento[0]}");
                                Console.WriteLine($"Nome: {equipamento[1]}");
                                Console.WriteLine($"Preço de aquisição: {equipamento[2]}");
                                Console.WriteLine($"Número de série: {equipamento[3]}");
                                Console.WriteLine($"Data de fabricação: {equipamento[4]}");
                                Console.WriteLine($"Nome do fabricante: {equipamento[5]}");
                                Console.WriteLine();
                                Console.WriteLine("Digite os novos dados do equipamento: ");
                                Console.WriteLine("Digite o novo nome do equipamento com no máximo 6 caracteres: ");
                                string novoNomeEquipamento = Console.ReadLine();
                                while (novoNomeEquipamento.Length > 6)
                                {
                                    Console.WriteLine("Nome maior que 6 caracteres.");
                                    Console.WriteLine("Digite o nome novamente: ");
                                    novoNomeEquipamento = Console.ReadLine();
                                }

                                Console.WriteLine("Digite o novo preço da aquisição: ");
                                double novoPrecoAquisicao = Convert.ToDouble(Console.ReadLine());

                                Console.WriteLine("Digite o novo número de série: ");
                                string novoNumeroSerie = Console.ReadLine();

                                Console.WriteLine("Digite a nova data de fabricação: ");
                                string novaDataFabricacao = Console.ReadLine();

                                Console.WriteLine("Digite o novo nome do fabricante: ");
                                string novoNomeFabricante = Console.ReadLine();

                                equipamento[1] = novoNomeEquipamento;
                                equipamento[2] = Convert.ToString(novoPrecoAquisicao);
                                equipamento[3] = novoNumeroSerie;
                                equipamento[4] = novaDataFabricacao;
                                equipamento[5] = novoNomeFabricante;

                                Console.WriteLine();
                                Console.WriteLine("Equipamento editado com sucesso!");
                                equipamentoEncontrado = true;
                                break;
                            }
                        }

                        if (!equipamentoEncontrado)
                        {
                            Console.WriteLine("Equipamento não encontrado.");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu de equipamentos.");
                        Console.ReadKey();
                        ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region ExcluirEquipamento
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Exclusão de Equipamento");
                        Console.WriteLine();

                        Console.WriteLine("Digite o ID do equipamento que deseja excluir: ");
                        int idEquipamentoExcluir = Convert.ToInt32(Console.ReadLine()) - 1;

                        bool equipamentoEncontrado = false;


                        foreach (string[] equip in listaEquipamentos)
                        {
                            int idFor = Convert.ToInt32(equip[0]);
                            if (idFor == idEquipamentoExcluir)
                            {
                                equipamentoEncontrado = true;
                                listaEquipamentos.RemoveAt(idEquipamentoExcluir);
                                Console.WriteLine("Equipamento excluído com sucesso!");
                                Console.WriteLine();
                                break;
                            }
                        }
                     

                        if (!equipamentoEncontrado)
                        {
                            Console.WriteLine("Equipamento não encontrado!");
                            Console.WriteLine();
                        }
                        
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region ImprimirMenuInicial
                case 0:
                    {
                        Console.Clear();
                        ImprimirMenuInicial();
                    }
                    break;
                #endregion
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                #region EncheListaEquipamentos
                listaEquipamentos.Add(new string[] { "1", "Laptop", "2000.00", "ABC123", "01/01/2021", "Apple" });
                listaEquipamentos.Add(new string[] { "2", "Phone", "1000.00", "XYZ789", "01/01/2021", "BlackBarry" });
                listaEquipamentos.Add(new string[] { "3", "Mouse", "50.00", "JKL456", "01/01/2021", "ATuring" });
                #endregion

                #region EncheListaChamados
                listaChamados.Add(new string[] { "1", "Falha", "Apresenta falha na esfera que orienta o cursor", "3", "10/11/2021"});
                listaChamados.Add(new string[] { "2", "Bota Quebrado", "Antena do aparelho quebrou teclado fisico", "2", "10/04/2022" });
                listaChamados.Add(new string[] { "3", "Erro SO", "Windowns Vista apresenta intensa lentidao", "1", "10/08/2022" });
                #endregion
                Console.Clear();
                ImprimirMenuInicial();
            }
        }
    }
}