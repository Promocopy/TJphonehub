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
    public class ProductController : ControllerBase
    {
        private readonly ProductContext Product;
        public ProductController(ProductContext Droduct)
        {
            Product = Droduct;
        }

        [HttpGet("Alistitem")]
        public ActionResult<IEnumerable<ProductUser>> GetListItem()
        {
            var productuser = Product.ProductUsers.ToList();
            if (productuser.Count==0)
            {
                return NotFound("No Users Found");
            }

            return Ok(productuser);
        }


        [HttpGet("{id}")]
        public ActionResult<ProductUser> GetNProduct(int id)
        {
            var productuser = Product.ProductUsers.Find(id);
            if (productuser == null)
            {
                return BadRequest("User not found");
            }

            return Ok(productuser);
        }

        [HttpGet("ProductInfo")]
        public ActionResult<ProductUser> GetNProduct(string name) 
        {
            var productuser = Product.ProductUsers.Find(name);
            if(productuser == null)
            {
                return BadRequest ("User not found");
            }

                return Ok(productuser);
        }

        [HttpGet("ProductIfo")]
        public ActionResult<ProductUser> GetSProduct(string specification)
        {
            var productuser = Product.ProductUsers.Find(specification);

            if (productuser == null)
            {
                return BadRequest("500,User not found");    
            }

            return Ok(productuser);


            //try
            //{
            //    var productuser = Product.ProductUsers.Find(specification);
            //    return productuser;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500, "User not found");
            //}

           
        }


        [HttpPost("addItem")]
        public async Task <ActionResult> AddItem(ProductUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Field not filled");
            }
            if(user == null)
            {
                return BadRequest("Field not filled");
            }
            Product.ProductUsers.Add(user);
            Product.SaveChanges();
            
           
            
           

            // try
            // {
            //    Product.ProductUsers.Add(user);
            //    Product.SaveChanges();
            // }
            //catch (Exception ex)
            // {
            //     return BadRequest("Field not filled");
            // }

            return Ok(user);
        } 
    }
}
 