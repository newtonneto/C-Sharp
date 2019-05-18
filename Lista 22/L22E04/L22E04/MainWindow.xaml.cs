using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L21E04
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Jogo> jogos = new List<Jogo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCadastrarJogo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jogo novoJogo = new Jogo(textBoxNomeJogo.Text);
                jogos.Add(novoJogo);
            }
            catch (ArgumentNullException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                textBoxNomeJogo.Text = String.Empty;
                listBoxJogos.Items.Clear();
                foreach (Jogo j in jogos)
                {
                    listBoxJogos.Items.Add(j);
                }
            }
        }

        private void buttonTop1Jogos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*string selecionaJogo = listBoxJogos.SelectedItem.ToString();
                listBoxJogadores.Items.Add(selecionaJogo);*/
                /*listBoxJogos.SelectedIndex*/
                Jogo selecionaJogo = (Jogo)listBoxJogos.SelectedItem;
                listBoxJogadores.Items.Clear();

                try
                {
                    listBoxJogadores.Items.Add(selecionaJogo.Top1());
                }
                catch (IndexOutOfRangeException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void listBoxJogos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Jogo selecionaJogo = (Jogo)listBoxJogos.SelectedItem;
                List<Jogador> jogadoresDoJogo = new List<Jogador>();
                jogadoresDoJogo = selecionaJogo.Listar();

                listBoxJogadores.Items.Clear();
                foreach (Jogador j in jogadoresDoJogo)
                {
                    listBoxJogadores.Items.Add(j);
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void buttonCadastrarJogador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jogo selecionaJogo = (Jogo)listBoxJogos.SelectedItem;

                try
                {
                    Jogador novoJogador = new Jogador(textBoxNomeJogador.Text, textBoxEmailJogador.Text);
                    selecionaJogo.Inserir(novoJogador);
                }
                catch (ArgumentNullException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
                catch (EmailExistenteException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
            finally
            {
                textBoxNomeJogador.Text = String.Empty;
                textBoxEmailJogador.Text = String.Empty;
            }
        }

        private void buttonInserirJogador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jogador selecionaJogador = (Jogador)listBoxJogadores.SelectedItem;

                try
                {
                    selecionaJogador.SetPontos(int.Parse(textBoxPontosJogador.Text), DateTime.Parse(textBoxDataJogador.Text));
                }
                catch (NullReferenceException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
                catch (ArgumentOutOfRangeException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
                catch (PontuacaoInferiorException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
                finally
                {
                    textBoxPontosJogador.Text = String.Empty;
                    textBoxDataJogador.Text = String.Empty;
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }

        private void buttonTop10Jogos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Jogo selecionaJogo = (Jogo)listBoxJogos.SelectedItem;
                listBoxJogadores.Items.Clear();

                try
                {
                    List<Jogador> listaTop10 = selecionaJogo.Top10();

                    foreach (Jogador j in listaTop10)
                    {
                        listBoxJogadores.Items.Add(j);
                    }
                }
                catch (IndexOutOfRangeException erro)
                {
                    MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
                }
            }
            catch (NullReferenceException erro)
            {
                MessageBoxResult exibeErro = MessageBox.Show(erro.Message);
            }
        }
    }
}
