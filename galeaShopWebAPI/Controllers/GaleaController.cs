using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using galeaShopWebAPI.Models;


namespace galeaShopWebAPI.Controllers
{
    [RoutePrefix("api/Prodcut")]
    public class GaleaController : ApiController
    {
        GaleaShopeEntities1 GsContext = new GaleaShopeEntities1();

        [HttpGet]
        [Route("products")]
        public IQueryable<Product> GetProducts()
        {
            try
            {
                return GsContext.Products;
            }
            catch (Exception m)
            {
                throw m;
            }
        }
        [HttpGet]
        [Route("GetProductDetailsById/{id:int}")]
        public IHttpActionResult GetProductDetails(int id)
        {
            Product tblObj = new Product();

            try
            {
                tblObj = GsContext.Products.Find(id);
                if (tblObj == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(tblObj);
        }

        [HttpPost]
        [Route("insertProductDetails")]

        public IHttpActionResult PostProduct(Product data)
        {
            // ModelSate review for next lesson 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                GsContext.Products.Add(data);
                GsContext.SaveChanges();
            }
            catch (Exception m)
            {
                throw m;
            }
            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateProductDetails")]
        public IHttpActionResult PutProduct(Product pr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Product tblObj = new Product();
                tblObj = GsContext.Products.Find(tblObj.Id);
                if (tblObj != null)
                {
                    tblObj.Name = pr.Name;
                    tblObj.Price = pr.Price;
                    tblObj.Quantity = pr.Quantity;
                    tblObj.Image = pr.Image;
                    tblObj.Details = pr.Details;
                    tblObj.Quantity = pr.Quantity;

                }
                 GsContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(pr);

        }
        [HttpDelete]
        [Route("DeleteProductDetails/{id:int}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Product myObj = GsContext.Products.Find(id);
            if (myObj == null)
            {
                return NotFound();
            }
            GsContext.Products.Remove(myObj);
            GsContext.SaveChanges();
            return Ok(myObj);
        }
    }
}
/////Test kljsakljlska