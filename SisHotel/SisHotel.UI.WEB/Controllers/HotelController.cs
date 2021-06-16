using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SisHotel.Models;
using SisHotel.BLL;
using SisHotel.DAL;
using Microsoft.AspNetCore.Http;


namespace SisHotel.UI.WEB.Controllers
{
    public class HotelController : Controller
    {

        private HotelBLL bll;

        public HotelController()
        {
            var dal = new HotelDal();
            this.bll = new HotelBLL(dal);
            //this.bll = new HotelBLL();
        }

       

        public IActionResult Incluir()
        {
            var hot = new Hotel();
            return View(hot);
        }

        [HttpPost]
        public IActionResult Incluir(Hotel hotel)
        {

            try
            {
                bll.Incluir(hotel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(hotel);
            }
        }

        public ActionResult Alterar(int Id)
        {
            var hotel = bll.ObterPorId(Id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult Alterar(Hotel hotel)
        {
           
            try
            { 
                bll.Alterar(hotel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(hotel);
            }
        }


        public ActionResult Excluir(int Id)
        {
            var hotel = bll.ObterPorId(Id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult Excluir(Hotel hotel)
        {
            int Id = hotel.id;
            try
            {
                bll.Excluir(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var hot = bll.ObterPorId(Id);
                return View(hot);
            }
        }

        public IActionResult Detalhes(int Id)
        {
            var hotel = bll.ObterPorId(Id);
            return View(hotel);
        }

        public IActionResult Buscar(string nome)
        {
            var lista = bll.Buscar(nome);
            return View(lista);
        }
       
        public IActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);


        }
    }
}
