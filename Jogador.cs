namespace jogo_adivinha
{
    public struct Jogador
    //ainda não foi implementado
    {
        private string _apelido;
        private int _tentativas;
        private dificuldade _dif;
        private int _pts;


        public string apelido{
            get {return _apelido;}
            set {_apelido = value;}
        }
        public int tentativas{
            get {return _tentativas;}
            set {_tentativas = value;}
        }
        public dificuldade dif{
            get {return _dif;}
            set {_dif = value;}
        }
        public int pts{ //tentativas utilizada até o acerto
            get {return _pts;}
            set {_pts = value;}
        } 

        public Jogador (string apelido, int tentativas, dificuldade dif){
            this._apelido = apelido;
            this._tentativas = tentativas;
            this._dif = dif;
            _pts = 0;
        }



    }
}