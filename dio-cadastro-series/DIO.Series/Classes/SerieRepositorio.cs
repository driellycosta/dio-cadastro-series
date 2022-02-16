using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private IList<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entidade) => listaSerie[id] = entidade;
        public void Excluir(int id) => listaSerie[id].Excluir();
        public void Inserir(Serie entidade) => listaSerie.Add(entidade);
        public IList<Serie> Listar() => listaSerie;
        public int ProximoId() => listaSerie.Count;
        public Serie RetornarPorId(int id) => listaSerie[id];
    }
}