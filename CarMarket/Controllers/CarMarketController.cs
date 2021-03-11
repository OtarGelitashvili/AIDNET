using CarMarket.Data;
using CarMarket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarMarket.Controllers
{
    public class CarMarketController : Controller
    {
        private readonly DataContext _context;
        private readonly IFreeCurrencyConverterService _IFreeCurrencyConverterService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CarMarketController( DataContext context,IWebHostEnvironment hostEnvironment, IFreeCurrencyConverterService IFreeCurrencyConverterService)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _IFreeCurrencyConverterService = IFreeCurrencyConverterService;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> cars = _context.Cars;
            return View(cars);
        }    
        public IActionResult Create()
        { 
            ViewBag.Models = new List<string>() { "BMW", "TOYOTA", "AUDI", "MERCEDES", "MITSUBISHI" };
            ViewBag.Currency = new List<string>() { "USD", "EUR","GEL" };
        
            return View();
        }

      [HttpPost]
        public IActionResult Create( Car car)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(car.ImageFile.FileName);
            string extension = Path.GetExtension(car.ImageFile.FileName);
            car.Img = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/image/", fileName);
            using (var fileStream =new FileStream(path, FileMode.Create))
            {
                car.ImageFile.CopyTo(fileStream);
            }
            if (car.Currency == "USD")
            {
                decimal UsdToGel = (decimal)_IFreeCurrencyConverterService.GetCurrencyExchange("USD", "GEL");
                car.Price = car.Price * UsdToGel;
                car.Currency = "GEL";
            }

            if(car.Currency == "EUR")
            {
                decimal EurToGel = (decimal)_IFreeCurrencyConverterService.GetCurrencyExchange("EUR", "GEL");
                car.Price = car.Price * EurToGel;
                car.Currency = "GEL";
            }
            
            _context.Cars.Add(car); 
           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int? id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if( car==null) {
                return NotFound();
             }
            return View(car);
        }
        public IActionResult Edit (int? id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if( car==null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
         
                _context.Entry(car).State = EntityState.Modified;
            _context.Entry(car).Property(x => x.Model).IsModified = false;
            _context.Entry(car).Property(x => x.Year).IsModified = false;
            _context.Entry(car).Property(x => x.Price).IsModified = false;
            _context.Entry(car).Property(x => x.Info).IsModified = false;
            _context.Entry(car).Property(x => x.Img).IsModified = false;
            _context.SaveChanges();
                return RedirectToAction("Index");
   
        }
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            _context.Entry(car).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
