using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L21E04
{
    class Jogador : IComparable
    {
        private string nome;
        private string email;
        private int pontuacaoMaxima;
        private DateTime data;

        public Jogador(string n, string e)
        {
            if (n == "" || e == "")
            {
                throw new ArgumentNullException("Nome ou email inválido");
            }
            nome = n;
            email = e;
        }

        public string GetEmail()
        {
            return email;
        }

        public int GetPontuacaoMaxima()
        {
            return pontuacaoMaxima;
        }

        public DateTime GetData()
        {
            return data;
        }

        public void SetPontos(int p, DateTime d)
        {
            if (p < 0 || d > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Pontuação ou data inválida");
            }
            else if (p < pontuacaoMaxima)
            {
                throw new PontuacaoInferiorException("Pontuação informada inferior a pontuação cadastrada");
            }
            pontuacaoMaxima = p;
            data = d;
        }

        public override string ToString()
        {
            return $"Nome: {nome}\n" +
                $"Email: {email}\n" +
                $"Pontuação: {pontuacaoMaxima}\n" +
                $"Data: {data}\n";
        }

        public int CompareTo(object obj)
        {
            Jogador j = obj as Jogador;
            if (pontuacaoMaxima > j.pontuacaoMaxima) return -1;
            if (pontuacaoMaxima < j.pontuacaoMaxima) return 1;
            return data.CompareTo(j.data);
        }
    }
}
