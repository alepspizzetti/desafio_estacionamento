namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            
            string placa = "";
            placa = Console.ReadLine().ToUpper();
            ValidarPlaca(placa);
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("Digite a posição do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            int posicaoVeiculo = 0;
            posicaoVeiculo = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            int horas = 0; 
            horas = Convert.ToInt16(Console.ReadLine());
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            // TODO: Remover a placa digitada da lista de veículos
            string placa = "";
            placa = veiculos[posicaoVeiculo].ToUpper();
            veiculos.RemoveAt(posicaoVeiculo);

            Console.WriteLine("Preço Inicial    |   Horas   |   Preço por hora");
            Console.WriteLine($"     {precoInicial}                {horas}                  {precoPorHora}");
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                for (int index = 0; index < veiculos.Count; index++)
                {
                    Console.WriteLine($"{index + 1} - {veiculos[index]}");
                }
                Console.WriteLine($"Totalizando {veiculos.Count} veículos");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine($"A placa está em branco ou com espaços, verifique a placa e tente novamente.");
                return false;
            }

            placa = placa.ToUpper().Trim();

            // Padrão antigo: 3 letras + 4 números (ex: ABC1234)
            // Padrão Mercosul: 3 letras + 1 número + 1 letra + 2 números (ex: ABC1D23)
            var padraoAntigo = @"^[A-Z]{3}[0-9]{4}$";
            var padraoMercosul = @"^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$";

            bool placaValida = System.Text.RegularExpressions.Regex.IsMatch(placa, padraoAntigo) ||
                System.Text.RegularExpressions.Regex.IsMatch(placa, padraoMercosul);

            if (!placaValida)
            {
                Console.WriteLine($"A placa {placa} está em um formato inválido.\nVerifique a placa e tente novamente.");
                return false;
            }

            return true;
        }
    }
}
