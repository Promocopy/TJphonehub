using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TJphonehub.Data;
using TJphonehub.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace TJphonehub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public SalesController (ProductContext productContext)
        {
            _productContext=productContext;
        }





        //public ProductController (ProductContext ProductContext)
        //{
        //    _productContext = ProductContext;
        //}
        [HttpGet("ListSalesMade")]
        public ActionResult<IEnumerable<ProductSales>> GetSalesList()
        {
            
            //var User = _productContext.ProductSales.ToList();
            //if (User.Count == 0)
            //{
            //    return StatusCode (500 , "No User Found");
            //}
            try
            {
                var User = _productContext.ProductSales.ToList();
                return User;
            }
            catch 
            {
                return StatusCode(500, "No User Found");
            }

            //return User;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductSales> GetSales(int id)
        {
            //var User = _productContext.ProductSales.Find(id);
            //if (User == null)
            //{
            //    return NotFound("500, No User Found");
            //}
            try
            {
                var User = _productContext.ProductSales.Find(id);
                return Ok(User);
            }
            catch (Exception ex)
            {
                return NotFound("500, No User Found");
            }
            //return User;
        }

        [HttpPost("AddSales")]
        public ActionResult Addsales(ProductSales sales)
        {
           

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Field not filled");
            //}
            try
            {
                _productContext.ProductSales.Add(sales);
                _productContext.SaveChanges();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return BadRequest("Field not filled");
            }


            //return Ok(sales);
        }
    }
}
