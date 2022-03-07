using System;

namespace GestãoEquipamentoNovo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region equipamentos
            string[] nomeEquipamentos = new string[1000];
            decimal[] precoEquipamentos = new decimal[1000];
            int[] numeroSerieEquipamento = new int[1000];
            DateTime[] dataFAbricacao = new DateTime[1000];
            string[] nomeFabricante = new string[1000];
            #endregion

            // Deve ter Um equipamento : criar opcao de vincular chamo no cadaro de equipamento 
            string[] tituloChamado = new string[1000];
            DateTime[] dataChamado = new DateTime[1000];
            string[] DescricaoChamado = new string[1000];
            string[] nomeEquipamantoChamada = new string[1000];
            int[] numeroequipamentoChamado = new int[1000];


            string opcaoPrincipal;
            string opcaoEquipamento;
            string opcaoChamado;
            int id = 0, idChamada = 0;

            MenuInicial();
            opcaoPrincipal = opcaoMenu();
            bool condicao = 1 == 1;
            while (condicao)
            {

                if (opcaoPrincipal == "s")
                {
                    Console.WriteLine("\nPrograma esta sendo encerrado...");
                    break;
                }


                #region  equipamento
                if (opcaoPrincipal == "1")
                {
                    Console.Clear();
                    MenuEquipamentos();
                    opcaoEquipamento = opcaoMenu();

                    #region cadatrar

                    if (opcaoEquipamento == "1")
                    {
                        id = CadastroEquipamentos(nomeEquipamentos, precoEquipamentos, numeroSerieEquipamento, dataFAbricacao, nomeFabricante, id);
                    }

                    #endregion

                    #region visualizar
                    else if (opcaoEquipamento == "2")

                    {
                        VisualizarInventario(nomeEquipamentos, nomeFabricante, id);

                    }
                    #endregion

                    #region editar registro
                    else if (opcaoEquipamento == "3")

                    {

                        if (id == 0)
                        {
                            SemCadastro();
                        }
                        else
                        {
                            VisualizarEquipamentosparaEditar(nomeEquipamentos, precoEquipamentos, numeroSerieEquipamento, dataFAbricacao, nomeFabricante, id);
                            EditarEquipamento(nomeEquipamentos, precoEquipamentos, numeroSerieEquipamento, dataFAbricacao, nomeFabricante);

                            continue;
                        }


                    }
                    #endregion

                    #region excluir registro
                    else if (opcaoEquipamento == "4")
                    {
                        if (id == 0)
                        {
                            SemCadastro();
                        }
                        else
                        {
                            id = ExcluirRegistroEquipamentos(nomeEquipamentos, precoEquipamentos, numeroSerieEquipamento, dataFAbricacao, nomeFabricante, numeroequipamentoChamado, id, idChamada);

                            VisualizarInventario(nomeEquipamentos, nomeFabricante, id);
                            Console.ReadKey();
                            continue;
                        }
                    }

                    #endregion

                    #region sair equipamentos
                    else if (opcaoEquipamento == "s")
                    {
                        Console.Clear();
                        MenuInicial();
                        opcaoPrincipal = opcaoMenu();
                        continue;
                    }
                    #endregion

                }

                #endregion

                #region chamado

                else if (opcaoPrincipal == "2")
                {
                    Console.Clear();
                    MenuChamado();

                    opcaoChamado = opcaoMenu();

                    if (opcaoChamado == "1")
                    {
                        idChamada = cadrastrarChamado(nomeEquipamentos, numeroSerieEquipamento, tituloChamado, dataChamado, DescricaoChamado, nomeEquipamantoChamada, numeroequipamentoChamado, id, idChamada);
                    }

                    #endregion

                    #region visualizar
                    else if (opcaoChamado == "2")

                    {
                        visualizarChamado(tituloChamado, dataChamado, nomeEquipamantoChamada, idChamada);

                    }
                    #endregion

                    #region editar registro
                    else if (opcaoChamado == "3")

                    {

                        if (id == 0)
                        {
                            SemCadastro();
                        }
                        else
                        {
                            Console.ReadKey();
                            Console.WriteLine("\nInforme o Id do chadamado que deseja Editar: ");
                            int editarIDChamado = int.Parse(Console.ReadLine());

                            Console.WriteLine("Qual Informação do " + tituloChamado[editarIDChamado] + " deseja Editar?\n");
                            Console.WriteLine("\n1-Nome \n2- Preço\n3- Nº de Série\n4- Data de fabricação\n5- Fabricante");
                            int editarchamado = int.Parse(Console.ReadLine());

                            if (editarchamado == 1)
                            {
                                Console.WriteLine("\nDigite novo Titulo do chamado:");
                                string editarTituloChamado = Console.ReadLine();

                                nomeEquipamentos[editarIDChamado] = editarTituloChamado;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nInformação Editada com Sucesso!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else if (editarchamado == 2)
                            {
                                Console.WriteLine("\nDigite  a nova Drescrição do chamado:");
                                string editarDescricao = Console.ReadLine();

                                DescricaoChamado[editarIDChamado] = editarDescricao;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nInformação Editada com Sucesso!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }

                            else if (editarchamado == 3)
                            {
                                Console.WriteLine("\nDigite novo Nº de Série:");
                                int editarSerie = int.Parse(Console.ReadLine());

                                numeroSerieEquipamento[editarIDChamado] = editarSerie;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nInformação Editada com Sucesso!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else if (editarchamado == 4)
                            {
                                Console.WriteLine("\nDigite nova Data de do chamado:");
                                DateTime editarDataChamado = Convert.ToDateTime(Console.ReadLine());

                                dataChamado[editarIDChamado] = editarDataChamado;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nInformação Editada com Sucesso!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }


                        }
                    }
                    #endregion

                    #region excluir registro
                    else if (opcaoChamado == "4")
                    {

                        visualizarChamado(tituloChamado, dataChamado, nomeEquipamantoChamada, idChamada);
                        Console.WriteLine("\nDigite o Id do equipamneto que deseja excluir: ");
                        int excluirChamado = int.Parse(Console.ReadLine());
                        if (id == 0)
                        {
                            SemCadastro();
                        }
                        else
                        {
                            idChamada = ExcluirRegistroChamado(tituloChamado, dataChamado, DescricaoChamado, nomeEquipamantoChamada, numeroequipamentoChamado, idChamada, excluirChamado);
                        }
                    }
                    #endregion

                    #region sair equipamentos
                    else if (opcaoChamado == "s")
                    {
                        Console.Clear();
                        MenuInicial();
                        opcaoPrincipal = opcaoMenu();
                        continue;
                    }
                    #endregion

                }




            }


            static void VisualizarInventario(string[] nomeEquipamentos, string[] nomeFabricante, int id)
            {
                Console.Clear();
                Console.WriteLine("Equipamentos cadastrados\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID \t| Nome \t\t\t| Fabricante");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.ResetColor();
                for (int posicao = 0; posicao < id; posicao++)

                {
                    Console.WriteLine(posicao + " \t| " + nomeEquipamentos[posicao] + "  \t\t\t|" + nomeFabricante[posicao]);
                }

                Console.ReadKey();
            }

            static int CadastroEquipamentos(string[] nomeEquipamentos, decimal[] precoEquipamentos, int[] numeroSerieEquipamento, DateTime[] dataFAbricacao, string[] nomeFabricante, int id)
            {
                Console.Clear();
                Console.WriteLine(" Cadatro de Equipamentos\n");
                #region nome equipamento
                Console.Write("Informe o nome do equipamento: ");
                string nome = Console.ReadLine();
                nomeEquipamentos[id] = nome;
                #endregion

                #region Preço equipamento
                Console.Write("Informe o preço do equipamento: R$ ");
                decimal preco = decimal.Parse(Console.ReadLine());
                precoEquipamentos[id] = preco;
                #endregion

                #region Numero de serie
                Console.Write("Informe o numero de serie do equipamento: ");
                int numeroSerie = int.Parse(Console.ReadLine());
                numeroSerieEquipamento[id] = numeroSerie;
                #endregion

                #region Data de fabricaçao
                Console.Write("Informe o data de fabricação do equipamento: ");
                DateTime dataEquipamento = Convert.ToDateTime(Console.ReadLine());
                dataFAbricacao[id] = dataEquipamento;
                #endregion

                #region Preço equipamento
                Console.Write("Informe o nome do fabricante do equipamento: ");
                string fabricante = Console.ReadLine();
                nomeFabricante[id] = fabricante;
                #endregion

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Equipamento cadastrado com sucesso!");
                Console.ResetColor();
                id++;
                Console.ReadKey();
                return id;
            }

            static void SemCadastro()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Nenhum equipamento cadastrado!");
                Console.ResetColor();
                Console.ReadKey();
            }

            static void VisualizarEquipamentosparaEditar(string[] nomeEquipamentos, decimal[] precoEquipamentos, int[] numeroSerieEquipamento, DateTime[] dataFAbricacao, string[] nomeFabricante, int id)
            {
                Console.Clear();
                Console.WriteLine("Equipamentos cadastrados\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID \t| Nome \t\t\t| Preço\t\t| Nº de Sériet\t\t| Data de fabricaçãot\t\t| Fabricante");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                for (int posicao = 0; posicao < id; posicao++)

                {
                    Console.WriteLine(posicao + " \t| " + nomeEquipamentos[posicao] + "  \t\t|" + precoEquipamentos[posicao] + "  \t\t|" + numeroSerieEquipamento[posicao] + "  \t\t|" + dataFAbricacao[posicao] + "  \t\t|" + nomeFabricante[posicao]);
                }
            }

            static void MenuEquipamentos()
            {
                Console.WriteLine("     Controle de Equipamento\n");
                Console.WriteLine("1 - Registro de Equipamento\n2 - Visualizar inventario de equipamentos\n"
                                 + "3 - Editar Registro\n4 - Excluir registro\ns - sair");
            }

            static void MenuChamado()
            {
                Console.WriteLine("     Getão de Chamados\n");

                Console.WriteLine("1 - Registro de Chamado\n2 - Visualizar  registro de chamados\n"
                                 + "3 - Editar chamdos\n4 - Excluir chamdo\n5 - Menu Principal");
            }

            static void MenuInicial()
            {

                Console.WriteLine("     Gestão de Equipamentos\n");
                Console.WriteLine("1 - Controle de Equipamento\n2 - Controle de chamados\n3 - Sair");

            }

            static string opcaoMenu()
            {
                string opcao;
                Console.Write("\nInforme a opção desejada: ");
                opcao = Console.ReadLine();
                return opcao;
            }

            static void EditarEquipamento(string[] nomeEquipamentos, decimal[] precoEquipamentos, int[] numeroSerieEquipamento, DateTime[] dataFAbricacao, string[] nomeFabricante)
            {
                Console.ReadKey();
                Console.WriteLine("\nInforme o Id do equipamento que deseja Editar: ");
                int editarId = int.Parse(Console.ReadLine());

                Console.WriteLine("Qual Informação do " + nomeEquipamentos[editarId] + " deseja Editar?\n");
                Console.WriteLine("\n1-Nome \n2- Preço\n3- Nº de Série\n4- Data de fabricação\n5- Fabricante");
                int editarEquipamento = int.Parse(Console.ReadLine());

                if (editarEquipamento == 1)
                {
                    Console.WriteLine("\nDigite novo nome:");
                    string editarNome = Console.ReadLine();

                    nomeEquipamentos[editarId] = editarNome;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInformação Editada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (editarEquipamento == 2)
                {
                    Console.WriteLine("\nDigite novo Preço:");
                    decimal editarPreco = decimal.Parse(Console.ReadLine());

                    precoEquipamentos[editarId] = editarPreco;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInformação Editada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();


                }
                else if (editarEquipamento == 3)
                {
                    Console.WriteLine("\nDigite novo Nº de Série:");
                    int editarSerie = int.Parse(Console.ReadLine());

                    numeroSerieEquipamento[editarId] = editarSerie;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInformação Editada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (editarEquipamento == 4)
                {
                    Console.WriteLine("\nDigite nova Data de Fabricação:");
                    DateTime editarData = Convert.ToDateTime(Console.ReadLine());

                    dataFAbricacao[editarId] = editarData;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInformação Editada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (editarEquipamento == 5)
                {
                    Console.WriteLine("\nDigite novo nome do fabricante:");
                    string editarfabricante = Console.ReadLine();

                    nomeFabricante[editarId] = editarfabricante;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInformação Editada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            static int ExcluirRegistroEquipamentos(string[] nomeEquipamentos, decimal[] precoEquipamentos, int[] numeroSerieEquipamento, DateTime[] dataFAbricacao, string[] nomeFabricante, int[] numeroequipamentoChamado, int id, int idChamada)
            {
                VisualizarInventario(nomeEquipamentos, nomeFabricante, id);

                Console.WriteLine("\nDigite o Id do equipamneto que deseja excluir: ");
                int excluirEquipamento = int.Parse(Console.ReadLine());
                for (int j = 0; j < idChamada; j++)
                {
                    if (numeroequipamentoChamado[idChamada] == numeroSerieEquipamento[excluirEquipamento])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Equipamento nãopode ser excluido\n!");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else if (numeroequipamentoChamado[idChamada] != numeroSerieEquipamento[excluirEquipamento])
                    {
                        for (int i = excluirEquipamento; i < id - 1; i++)
                        {
                            nomeEquipamentos[i] = nomeEquipamentos[i + 1];
                            precoEquipamentos[i] = precoEquipamentos[i + 1];
                            numeroSerieEquipamento[i] = numeroSerieEquipamento[i + 1];
                            dataFAbricacao[i] = dataFAbricacao[i + 1];
                            nomeFabricante[i] = nomeFabricante[i + 1];

                        }
                        id--;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Equipamento excluido com sucesso\n!");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }

                return id;
            }

            static int cadrastrarChamado(string[] nomeEquipamentos, int[] numeroSerieEquipamento, string[] tituloChamado, DateTime[] dataChamado, string[] DescricaoChamado, string[] nomeEquipamantoChamada, int[] numeroequipamentoChamado, int id, int idChamada)
            {
                Console.Clear();

                Console.WriteLine("Cadastro de chamada\n");

                Console.WriteLine("\nInforme o titulo da chamada: ");
                string titulo = Console.ReadLine();
                tituloChamado[idChamada] = titulo;


                Console.WriteLine("\nInforme a descrição da chamda: ");
                string descriacao = Console.ReadLine();
                DescricaoChamado[idChamada] = descriacao;

                Console.WriteLine("informe o numero de Serie do equipamento que deseja vincular a chamda: ");
                int nSerieChamado = int.Parse(Console.ReadLine());

                for (int i = 0; i < id; i++)

                    if (nSerieChamado == numeroSerieEquipamento[id])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Equipamento encontrado");
                        Console.ResetColor();
                        numeroequipamentoChamado[id] = nSerieChamado;
                        Console.WriteLine("\nEquipamento " + nomeEquipamentos[id] + ", foi vinculado ao chamada");
                        nomeEquipamantoChamada[idChamada] = nomeEquipamentos[id];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Equipamento não encontrado");
                        Console.ResetColor();
                    }

                Console.WriteLine("\nInforme a data de abertura ddo chamado");
                DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());
                dataChamado[idChamada] = dataAbertura;

                idChamada++;
                return idChamada;
            }

            static void visualizarChamado(string[] tituloChamado, DateTime[] dataChamado, string[] nomeEquipamantoChamada, int idChamada)
            {
                Console.Clear();
                Console.WriteLine("Chamados cadastrados\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID \t| Titulo Chamado \t\t\t| Equipamento \t\t\t| Data Inicio chamada ");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.ResetColor();
                for (int posicao = 0; posicao < idChamada; posicao++)

                {
                    Console.WriteLine(posicao + " \t| " + tituloChamado[posicao] + "\t\t\t|" + nomeEquipamantoChamada[posicao] + "  \t\t\t|" + dataChamado[posicao] + " \t\t|");
                }

                Console.ReadKey();
            }

            static int ExcluirRegistroChamado(string[] tituloChamado, DateTime[] dataChamado, string[] DescricaoChamado, string[] nomeEquipamantoChamada, int[] numeroequipamentoChamado, int idChamada, int excluirChamado)
            {
                for (int i = excluirChamado; i < idChamada - 1; i++)
                {
                    nomeEquipamantoChamada[i] = nomeEquipamantoChamada[i + 1];
                    tituloChamado[i] = tituloChamado[i + 1];
                    DescricaoChamado[i] = DescricaoChamado[i + 1];
                    dataChamado[i] = dataChamado[i + 1];
                    numeroequipamentoChamado[i] = numeroequipamentoChamado[i + 1];

                }
                idChamada--;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Equipamento excluido com sucesso\n!");
                Console.ResetColor();
                Console.ReadKey();
                return idChamada;
            }





        }
    }

}
