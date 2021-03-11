using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarMarket.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }  
        public string Info { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Img { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public bool Abs { get; set; }
        public bool ElectricWindowLift { get; set; }
        public bool Bluetooth { get; set; }
        public bool Hatch { get; set; }
        public bool Alarm { get; set; }
        public bool ParkingControl { get; set; }
        public bool Navigation { get; set; }
        public bool OnBoardComputer { get; set; }
        public bool MultiWheel { get; set; }
    }
}
