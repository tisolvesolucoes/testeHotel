using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisHotel.DAL;
namespace SisHotelTestProject
{
    [TestClass]
    public class HotelDalTeste
    {
        [DataTestMethod]
        public void ObterPorNomeTeste()
        {
            string v = "2";
            var dal = new HotelDal();
            var hotel = dal.Buscar(v);
            Assert.IsTrue(hotel == null, "Deveria ter trazido os hoteis");
        }
    }
}
