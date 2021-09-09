using System;

namespace Cadastrodeseries
{
    public class Series : CadastroBase
    {
        public Genero Genero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string nome, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano;
            return retorno;
        }
        public string retornaNome()
        {
            return this.Nome;
        }
        public int returnId()
        {
            return this.Id;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
        public bool returnStatus()
        {
            return this.Excluido;
        }
    }
}   
