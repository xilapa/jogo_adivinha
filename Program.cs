using System;


            // TODO
            // main
            //      - log de erros
            // logger
            // BD
            //      - registar pontuação no fim da partida
            //      - buscar e retornar top 10


namespace jogo_adivinha
{
    class Program
    {
        public static void Main()
        {
            int? executar = 1;
            Jogador jogador = new Jogador("",10,dificuldade.medio);

            Console.WriteLine("\n\n************************ JOGO DA ADIVINHAÇÃO ************************");
            do{
                try{
                    executar = menu();
                    switch (executar){
                        case 1:
                            //jogar
                            jogador.pts = jogar(jogador.tentativas);
                            jogador.apelido = inputApelido(jogador.apelido);
                            //TODO: salvar e confirmar que a pontuação foi salva
                            break;
                        case 2:
                            //Preencher apelido
                            jogador.apelido = inputApelido(jogador.apelido);
                            break;
                        case 3: 
                            //Ver pontuações
                            break;
                        case 4:
                            //Configurar dificuldade
                            int _tentativas = jogador.tentativas;
                            jogador.dif = confDificuldade(jogador.dif, ref _tentativas);
                            jogador.tentativas = _tentativas;

                            break;
                        case 5:
                            //Sair
                            Console.WriteLine("\n\n\tJogo Finalizado");
                            break;
                        default:
                            //Opção Inválida
                            Console.WriteLine("Digite uma opção válida");
                            break;
                    }
                }catch{
                       //escrever no logger 
                }
            }while (executar!=5);
        }

        private static int menu(){
            Console.WriteLine("\n\nEscolha uma opção:\n\n\t1 - Jogar\n\t2 - Informe seu apelido\n\t3 - Ver maiores pontuações\n\t4 - Configurar dificuldade\n\t5 - Sair");
            int opcao = inputInteiro();
            return opcao;
        }
        private static int jogar(int tentativas){
            int _tentativas = tentativas;
            int _pts;
            var rand = new Random();
            int segredo = rand.Next(0,101);
            Console.WriteLine(segredo);
            Console.WriteLine("\n*** JOGO INICIADO ***\n\nDê um chute entre [0 e 100]");
            while (true){
                int chute = inputInteiro();
                _tentativas -= 1;
                if (chute==segredo & _tentativas !=0){
                    Console.Write("\nParabéns você ganhou");
                    _pts = tentativas - _tentativas;
                    return _pts;
                }else if (chute < segredo & _tentativas !=0){
                        Console.Write("\nO número secreto é maior\nTente novamente: ");
                }else if (chute > segredo & _tentativas !=0){
                        Console.Write("\nO número secreto é menor\nTente novamente: ");
                }else{
                    Console.Write($"\nVocê perdeu, o segredo era {segredo}");
                    _pts = tentativas - _tentativas;
                    return _pts;
                }
            } 
        }      
        private static dificuldade confDificuldade(dificuldade _dif, ref int _tentativas){

                    //strings do menu de opções
                    string facil, medio, dificil, personalizado;
                    facil = medio = dificil = personalizado = String.Empty;
                    switch(_dif){
                        case dificuldade.facil:
                            facil = "    **SELECIONADA**";
                            medio = dificil = personalizado = String.Empty;
                            break;                                    
                        case dificuldade.medio:
                            medio = "    **SELECIONADA**";
                            facil = dificil = personalizado = String.Empty;
                            break;        
                        case dificuldade.dificil:
                            dificil = "    **SELECIONADA**";
                            medio = facil = personalizado = String.Empty;
                            break;
                        case dificuldade.personalizado:
                            string _t = Convert.ToString(_tentativas);
                            personalizado = "("+_t+" tentativas)"+ "    **SELECIONADA**";
                            medio = dificil = facil = String.Empty;
                            break;
                    }
                    Console.WriteLine($"\n*** ESCOLHA A DIFICULDADE ***\n\nEscolha uma opção:\n\n\t1 - Fácil (20 tentativas) {facil}\n\t2 - Médio (10 tentativas) {medio}\n\t3 - Díficil (5 tentativas) {dificil}\n\t4 - Personalizado {personalizado}\n\t5 - Voltar");
                    
                    int escolha;
                    do{
                       escolha = inputInteiro();
                       dificuldade _difNova = (dificuldade)escolha;
                       switch (_difNova){
                            case dificuldade.facil:
                                _tentativas = 20;
                                return _difNova;
                            case dificuldade.medio:
                                _tentativas = 10;
                                return _difNova;
                            case dificuldade.dificil:
                                _tentativas = 5;
                                return _difNova;
                            case dificuldade.personalizado:
                                Console.WriteLine("Digite um número de tentativas");
                                _tentativas = inputInteiro();
                                return _difNova;
                            default:
                                Console.WriteLine("Digite uma opção válida");
                                return _dif;
                       } 
                    }while(escolha!=5);
        }
        private static int inputInteiro(){
                int entrada;
                while(!int.TryParse(Console.ReadLine(),out entrada)){
                    Console.Write("Você deve digitar um número, tente novamente: "); 
                }
                return entrada;                
            }        
        private static string inputApelido(string _apelido){     
            //checa se apelido esta preenchido    
            if (String.IsNullOrEmpty(_apelido)){
                while(true){
                    Console.Write("O apelido não foi informado\nDigite seu apelido: ");     
                    _apelido = Console.ReadLine();
                    if (String.IsNullOrEmpty(_apelido)){
                    Console.Write("\nO apelido não pode ser vazio, digite novamente: ");
                    }else{
                        break;
                    }                  
                }  
            }else{
                Console.WriteLine($"O apelido atual é: {_apelido}, deseja alterar? Digite S ou N");
                string _alterar = Console.ReadLine().ToUpper();
                while(_alterar !="S"&&_alterar!="N"){
                    Console.WriteLine("Opção inválida, digite novamente");
                    _alterar = Console.ReadLine().ToUpper();
                }
                if (_alterar =="S"){
                    Console.WriteLine("Digite o novo apelido");
                    _apelido = Console.ReadLine();
                }else{
                    return _apelido;
                }
            }      
            return _apelido;    
        }    


    
    }
}


