using Application.Interface;
using Domain.Entidades;
using Infra.InfraRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Serivce
{
    public class SorteioService : ISorteio
    {
        private readonly ISorteioRepository _CadastroCliente;

        public SorteioService(ISorteioRepository cadastrocliente)
        {
            _CadastroCliente = cadastrocliente;
        }

        public async Task<List<Pessoas>> GetPeople()
        {
            var Pessoas = await _CadastroCliente.Get();

            Pessoas = ValidaRegras(Pessoas);

            return Pessoas;
        }


        public List<Pessoas> GetSorteio(List<Pessoas> pessoas)
        {
            Random random = new Random();
            List<Pessoas> pessoasSorteadas = new List<Pessoas>();
            List<string> idosos = new List<string>();
            List<string> deficientes = new List<string>();
            List<string> geral = new List<string>();


            foreach (var item in pessoas)
            {
                if (item.Cota.ToUpper() == "IDOSO")
                    idosos.Add(item.CPF);
                if (item.Cota.ToUpper() == "GERAL")
                    geral.Add(item.CPF);
                if (item.Cota.ToUpper() == "DEIFICENTE FÍSICO")
                    deficientes.Add(item.CPF);
            }

            string[] idosoArray = idosos.ToArray();
            string[] geralArray = geral.ToArray();
            string[] deficientesArray = deficientes.ToArray();

            var idosoVencedor = GerarIdosoVencedor(idosoArray);
            var geralVencedor = GerarGeralVencedor(geralArray);
            var derficienteVencedor = GerarDeficienteVencedor(deficientesArray);

            pessoasSorteadas.Add(pessoas.Where(x => x.CPF == idosoVencedor).FirstOrDefault());
            pessoasSorteadas.Add(pessoas.Where(x => x.CPF == derficienteVencedor).FirstOrDefault());

            foreach (var item in geralVencedor)
            {
                pessoasSorteadas.Add(pessoas.Where(x => x.CPF == item).FirstOrDefault());
            }

            return pessoasSorteadas;
        }

        private string GerarDeficienteVencedor(string[] deficientesArray)
        {
            string vencedor = "";
            Random random = new Random();
            for (int i = deficientesArray.Length; i > 1; i--)
            {
                int j = random.Next(i);
                vencedor = deficientesArray[j];
                deficientesArray[j] = deficientesArray[i - 1];
                deficientesArray[i - 1] = vencedor;
            }

            if (deficientesArray.Length == 1)
                vencedor = deficientesArray[0];

            return vencedor;
        }

        private List<string> GerarGeralVencedor(string[] geralArray)
        {
            List<string> vencedor = new List<string>();
            Random random = new Random();
            for (int i = 1; i < 3;)
            {
                int j = random.Next(geralArray.Length);
                if (!vencedor.Contains(geralArray[j]))
                {
                    vencedor.Add(geralArray[j]);
                }
                geralArray[j] = geralArray[i - 1];
                i = vencedor.Count;
            }

            if (geralArray.Length == 1)
                vencedor.Add(geralArray[0]);

            return vencedor;
        }

        private string GerarIdosoVencedor(string[] idosoArray)
        {
            string vencedor = "";
            Random random = new Random();
            for (int i = idosoArray.Length; i > 1; i--)
            {
                int j = random.Next(i);
                vencedor = idosoArray[j];
                idosoArray[j] = idosoArray[i - 1];
                idosoArray[i - 1] = vencedor;
            }


            if (idosoArray.Length == 1)
                vencedor = idosoArray[0];


            return vencedor;
        }

        private List<Pessoas> ValidaRegras(List<Pessoas> listaPessoas)
        {
            List<Pessoas> novaListaPessoas = new List<Pessoas>();

            foreach (var pessoa in listaPessoas)
            {             

                var rendaDecimal = decimal.Parse(pessoa.Renda.Replace(".", ","));
                var idade = DateTime.Now.Year - pessoa.Data_Nascimento.Year;
                var cpfModificado = Regex.Replace(pessoa.CPF, "[^0-9]", "");

                if (rendaDecimal >= 1045 && rendaDecimal <= 5225 && idade > 15 && cpfModificado.Length == 11)
                {
                    if (pessoa.Cota.ToUpper() == "IDOSO" && idade > 60)
                        novaListaPessoas.Add(pessoa);

                    if (pessoa.Cota.ToUpper() == "DEIFICENTE FÍSICO" && !string.IsNullOrEmpty(pessoa.CID))
                        novaListaPessoas.Add(pessoa);

                    if (pessoa.Cota.ToUpper() == "GERAL")
                        novaListaPessoas.Add(pessoa);
                }
            }
            foreach (var item in novaListaPessoas)
            {
                item.TotalParticipante = novaListaPessoas.Count;
            }

            return novaListaPessoas;
        }


    }
}
