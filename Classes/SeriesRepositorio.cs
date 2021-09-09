using System.Collections.Generic;
using Cadastrodeseries.Interface;

namespace Cadastrodeseries
{
    class SeriesRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            listaSerie[id] = entidade;
        }
        public void Excluir(int id)
        {
            listaSerie[id].excluir();
        }
        public void Insere(Series entidade)
        {
            listaSerie.Add(entidade);
        }
        public List<Series> Lista()
        {
            return listaSerie;
        }
        public int ProximaID()
        {
            return listaSerie.Count;
        }
        public Series RetornaPorID(int id)
        {
            return listaSerie[id];
        }
    }
}
