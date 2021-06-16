using System;
using System.Collections.Generic;
using System.Text;

namespace SisHotel.Models
{
    public interface IHotelDados
    {
        void Incluir(Hotel hotel);
        void Alterar(Hotel hotel);
        void Excluir(int Id);
        List<Hotel> ObterTodos();
        Hotel ObterPorId(int Id);
        List<Hotel> Buscar(string nome);
    }
}
