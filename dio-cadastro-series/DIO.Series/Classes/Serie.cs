using System;
using DIO.Series.Enums;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, string titulo, string descricao, int ano, Genero genero)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Genero = genero;
            Excluido = false;
            NotaGeral = new NotaGeral();
        }

        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private Genero Genero { get; set; }
        private NotaGeral NotaGeral { get; set; }


        public override string ToString()
        {
            var retorno = string.Empty;
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Nota Geral: " + NotaGeral.RetornarNotaGeral() + Environment.NewLine;
            retorno += "Disponível: " + (!Excluido ? "Disponível" : "Não disponível");
            return retorno;
        }

        public string RetornarTitulo() => Titulo;
        public int RetornarId() => Id;
        public void Excluir() => Excluido = true;
        public bool RetornarExcluido() => Excluido;

        public void AdicionarNota(int nota) => NotaGeral.AdicionarNota(nota);
        public decimal RetornarNotaDaSerie() => NotaGeral.RetornarNotaGeral();
    }
}