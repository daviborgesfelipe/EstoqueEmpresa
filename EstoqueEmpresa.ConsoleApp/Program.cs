using EstoqueEmpresa.ConsoleApp.ModuloChamado;
using EstoqueEmpresa.ConsoleApp.ModuloEquipamento;
using System.Collections;

namespace EstoqueEmpresa.ConsoleApp
{
    public class Program
    {
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
                listaChamados.Add(new string[] { "1", "Falha", "Apresenta falha na esfera que orienta o cursor", "3", "10/11/2021" });
                listaChamados.Add(new string[] { "2", "Botao Quebrado", "Antena do aparelho quebrou teclado fisico", "2", "10/04/2022" });
                listaChamados.Add(new string[] { "3", "Erro SO", "Windowns Vista apresenta intensa lentidao", "1", "10/08/2022" });
                #endregion
                Console.Clear();
                ImprimirMenuInicial();
            }
        }
        static ArrayList listaChamados = new ArrayList();
        static string[] equipamento = new string[6];
        static string[] chamado = new string[5];
        static int idEquipamento = 4;
        static int idChamado = 4;
        static int id;
        public static void ImprimirCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine(subtitulo);
            Console.WriteLine("---------------------------------------------");
        }
        public static void ImprimirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        public static void ImprimirMensagemSaidaMenu(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }
        public static int InteragirComMenuInicial()
        {
            Console.WriteLine("Menu Inicial");
            Console.WriteLine("Selecione a opcao desejada: ");
            Console.WriteLine();
            Console.WriteLine("[1] Equipamentos: ");
            Console.WriteLine("[2] Chamados: ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[Ctrl + 'C'] Sair");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Digite a opcao: ");
            int opcaoMenuInicial = Convert.ToInt32(Console.ReadLine());
            return opcaoMenuInicial;
        }
        public static void ImprimirMenuInicial()
        {
            int opcaoMenuInicial = InteragirComMenuInicial();
            switch (opcaoMenuInicial)
            {
                #region MenuEquipamentos
                case 1:
                    {
                        TelaEquipamento.ImprimirMenuEquipamentos();
                    }
                    break;
                #endregion

                #region MenuChamados
                case 2:
                    {
                        TelaChamado.ImprimirMenuChamados();
                    }
                    break;
                #endregion

                #region Sair da aplicacao
                case 0:
                    break;
                #endregion
            }
        }
        public static void IncrementarId()
        {
            id++;
        }

    }
}