using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L21E04
{
    class Jogo
    {
        private string nome;
        private List<Jogador> jogs = new List<Jogador>();

        public Jogo(string n)
        {
            if (n == "")
            {
                throw new ArgumentNullException("Nome inválido");
            }
            nome = n;
        }

        public void Inserir(Jogador j)
        {
            foreach (Jogador jog in jogs)
            {
                if (jog.GetEmail() == j.GetEmail())
                {
                    throw new EmailExistenteException("Email já cadastrado");
                }
            }
            jogs.Add(j);
        }

        public List<Jogador> Listar()
        {
            return jogs;
        }

        public Jogador Top1()
        {
            /*Jogador jogadorTop1 = jogs[0];

            foreach(Jogador j in jogs)
            {
                if (j.GetPontuacaoMaxima() > jogadorTop1.GetPontuacaoMaxima())
                {
                    jogadorTop1 = j;
                }
                else if (j.GetPontuacaoMaxima() == jogadorTop1.GetPontuacaoMaxima())
                {
                    if (DateTime.Compare(j.GetData(), jogadorTop1.GetData()) == 0)
                    {
                        jogadorTop1 = j;
                    }
                }
            }*/
            if (jogs.Count == 0)
            {
                throw new IndexOutOfRangeException("Nenhum jogador cadastrado");
            }

            jogs.Sort();
            return jogs[0];
        }

        public List<Jogador> Top10()
        {
            /*for (int i = 0; i < 10; i++)
            {
                top10[i] = jogs[i];
            }

            return top10;*/

            List<Jogador> top10 = new List<Jogador>();
            jogs.Sort();

            if (jogs.Count == 0)
            {
                throw new IndexOutOfRangeException("Nenhum jogador cadastrado");
            }

            top10.AddRange(jogs.Take(10));

            return top10;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
