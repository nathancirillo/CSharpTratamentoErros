namespace TratamentoErros
{
    static class Program
    {
        static void Main(string[]args)
        {
            // Mostrar erros ao usuário é algo bem ruim. Por exemplo, acessar uma posição errada do array.
            // Outro exemplo é tentar acessar a propriedade de um objeto nulo. 
            // Todos os erros em .NET são tratados como exceções (exceptions).
            // Uma exceção é algo que não deveria acontecer, ou seja, não previsto.
            // Toda vez que uma exceção ocorre para a execução do programa.
            // Uma forma de resolver/amenizar isso é através do try/catch.
            // Evite fazer toda a lógica dentro de um único try..catch. Use blocos.
            // Ao acontecer um erro no catch duas propriedades que podemos usar são: Message e InnerException (captura através do ex).
            // Definir a exception no catch é opcional. Porém acaba sendo interessante para facilitar a identificação do problema.
            // Dentro do tratamento de erros podemos ter N catch's, pois podem haver vários erros.
            // Podemos usar também o finally e ele sempre irá acontecer, independente de ter ocorrido algum erro.

            // Exemplo: código abaixo irá gerar um IndexOutOfRangeException.
            //GeraException();

            // Tratando o código mostrado acima. Se fosse um cadastro, por exemplo, 
            // poderiamos enviar um e-mail.  
            try
            {
                //GeraException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ops...algo deu errado!");
                Console.WriteLine($"Exceção: {ex.Message}");
            }     

            // No exemplo abaixo estamos usando o try..catch com mais de um catch (multicatch).
            // A indicação é sempre buscar tratar os erros do mais específico para o mais genérico.
            try 
            {
                //var num = 0; 
                //GeraException(); 
                //System.Console.WriteLine($"Divisão por zero: " + 150/num);
            }
            catch(IndexOutOfRangeException)
            {
               System.Console.WriteLine("Exceção: trata de uma forma");     
            }
            catch(DivideByZeroException)
            {
                System.Console.WriteLine("Exceção: trata de outra forma");
            }
            catch(Exception)
            {
                System.Console.WriteLine("Exceção mais genérica de todas");
            }

            // Uma outra possibilidade que temos é levantar a nossa própria exceção.
            // Podemos criar/levantar qualquer tipo de exceção desejada.   
            // A primeira exceção é já usada uma existente: ArgumentNullException.
            // A segunda exceção é a personalizada. Criada a partir de uma classe que herda de Exception.
            // Tratamento sendo da mais específica para a mais genérica.   
            // Interessante usar o finally, por exemplo, em leitura de arquivo. 
            // Dessa forma conseguimos sempre fechar o recurso após uma Exception ocorrida.       
            try
            {
                Salvar(string.Empty); 
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message); 
            }
            catch(MinhaException ex) // Exceção personalizada que é uma classe que herda de Exception.  
            {
                Console.WriteLine(ex.Mensagem);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            finally
            {
                Console.WriteLine("Finally: sempre será executado...");
            }         
                    
        }

        //Método criado par gerar a exceção de IndexOutOfRangeException.
        static void GeraException()
        {
            var meuArray = new int[4];
            for(int i=0;i<=meuArray.Length;i++)            
                Console.WriteLine(meuArray[i]); 
        }


        // Sempre que o parâmetro for nulo ou vazio será levantada uma exceção.
        // Se o valor passado for nulo será a exceção existente ArgumentNullException.
        // Se o valor passado for vazio será a exceção personalizada MinhaException.
        static void Salvar(string valor)
        {
            if(valor == null)
                throw new ArgumentNullException("valor não pode ser nulo!");
            
            if(valor == string.Empty)           
                throw new MinhaException("O valor não pode ser vazio!"); 
        }
    }
}