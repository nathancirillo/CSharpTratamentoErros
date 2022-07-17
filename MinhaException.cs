namespace TratamentoErros
{
    public class MinhaException : Exception 
    {       
        public string Mensagem { get; set; }        
        
        public MinhaException(string msg)
        {
            Mensagem = $"Exceção: {msg}. Ocorreu: {DateTime.Now}";
        }     
    }
}