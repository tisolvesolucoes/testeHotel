using SisHotel.Models;
using System;
using System.Collections.Generic;

namespace SisHotel.DAL
{
    public class HotelDal : IHotelDados
    {

        public void Incluir(Models.Hotel hotel)
        {
            DbHelper.ExecuteNonQuery("HotelIncluir",
                "@Nome",        hotel.Nome,
                "@Descricao",   hotel.Descricao,
                "@TipoComodidade",   hotel.TipoComodidade,
                "@avaliacao",   hotel.avaliacao,
                "@Logradouro", hotel.Logradouro,
                "@Numero", hotel.Numero,
                "@Complemento", hotel.Complemento,
                "@Estado", hotel.Estado,
                "@Cidade", hotel.Cidade
                );
        }

        public void Alterar(Models.Hotel hotel)
        {
            DbHelper.ExecuteNonQuery("HotelAtualizar",
            "@Id",                  hotel.id,
            "@Nome",                hotel.Nome,
            "@Descricao",           hotel.Descricao,
            "@TipoComodidade",      hotel.TipoComodidade,
            "@avaliacao",           hotel.avaliacao,
            "@Logradouro",          hotel.Logradouro,
            "@Numero",              hotel.Numero,
            "@Complemento",         hotel.Complemento,
            "@Estado",              hotel.Estado,
            "@Cidade",              hotel.Cidade);
        }

        public void Excluir(int Id)
        {
            DbHelper.ExecuteNonQuery("HotelDeletar", "@Id", Id);
        }


        public Models.Hotel ObterPorId(int Id)
        {
            Hotel hotel = null;
            using (var reader = DbHelper.ExecuteReader("HotelListarPorId", "@id", Id))
            {
                if (reader.Read()) {
                    hotel = ObterPorReader(reader);
                }
                return hotel;
            }
        }

        public List<Models.Hotel> Buscar(string nome)
        {
            var lista = new List<Hotel>();
            using (var reader = DbHelper.ExecuteReader("HotelListaPorNome", "@Nome", nome))
            {
                while (reader.Read())
                {
                    Hotel hotel = ObterPorReader(reader);

                    lista.Add(hotel);
                }
            }

            return lista;
        }

        public List<Models.Hotel> ObterTodos()
        {
            var lista = new List<Hotel>();

            using (var reader = DbHelper.ExecuteReader("HotelListar"))
            {
                while (reader.Read())
                {
                    Hotel hotel = ObterPorReader(reader);

                    lista.Add(hotel);
                }
            }

            return lista; 
        }

        private static Hotel ObterPorReader(System.Data.IDataReader reader)
        {
            var hotel = new Hotel();
            hotel.id = Convert.ToInt16(reader["id"]);
            hotel.Nome = reader["Nome"].ToString();
            hotel.Descricao = reader["Descricao"].ToString();
            hotel.TipoComodidade = reader["TipoComodidade"].ToString();
            hotel.avaliacao = Convert.ToInt16(reader["avaliacao"]);
            hotel.Logradouro= reader["Logradouro"].ToString();
            hotel.Numero= Convert.ToInt16(reader["Numero"]);
            hotel.Complemento= reader["Complemento"].ToString();
            hotel.Cidade= reader["Cidade"].ToString();
            
            return hotel;
        }
    }
}
