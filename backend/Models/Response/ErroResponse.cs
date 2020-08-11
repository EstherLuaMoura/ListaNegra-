namespace backend.Models.Response
{
    public class ErroReponse
    {
        public int erro {get; set;}
        public string mensagem {get; set;}

        public ErroReponse(int erro,string mensagem)
        {
            this.erro=erro;
            this.mensagem=mensagem;

        }
    }
}