using System;
using SisHotel.DAL;
using SisHotel.Models;
using System.Collections.Generic;
using System.Collections;

namespace SisHotel.BLL
{
    public class HotelBLL : IHotelDados
    {

        private IHotelDados dal;
        
        public HotelBLL(IHotelDados hotelDados) {
            this.dal = hotelDados;
        }


        public void Incluir(Hotel hotel)
        {
            Validar(hotel);
            
            var dal = new HotelDal();
            dal.Incluir(hotel);

        }

        public void Alterar(Hotel hotel)
        {
            Validar(hotel);

            dal.Alterar(hotel);
        }


        public void Excluir(int Id)
        {
            dal.Excluir(Id);
        }


        public Hotel ObterPorId(int Id)
        {            
            var lista = dal.ObterPorId(Id);
            return lista;
        }

        public List<Hotel> Buscar(string nome)
        {
            var lista = dal.Buscar(nome);
            ValidaBusca(lista);
            return lista;
        }

        public List<Hotel> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;

        }

        private static void Validar(Hotel hotel)
        {
            if (string.IsNullOrEmpty(hotel.Nome))
            {
                throw new ApplicationException("O nome do hotel deve ser informado!");
            }
            if (string.IsNullOrEmpty(hotel.Descricao))
            {
                throw new ApplicationException("Descrição do hotel deve ser informado!");

            }
            if (string.IsNullOrEmpty(hotel.TipoComodidade))
            {
                throw new ApplicationException("Tipo Comodidade do hotel deve ser informado!");
            }
        }
        
        private static void ValidaBusca(IList lista)
        {
            if (lista.Count < 1)
            {
                throw new ApplicationException("O Nenhum dado encontrado :( !");
            }
            
        }
    }
}
