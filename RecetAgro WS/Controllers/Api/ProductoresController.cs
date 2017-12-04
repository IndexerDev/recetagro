using RecetAgro_WS.Dtos;
using RecetAgro_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;


namespace RecetAgro_WS.Controllers.Api
{
    public class ProductoresController : ApiController
    {

        private ApplicationDbContext _context;

        public ProductoresController()
        {
            _context = new ApplicationDbContext();
        }


        // GET   /api/productores
        public IEnumerable<ProductorDto> GetProductores()
        {
            return _context.Productores.ToList().Select(Mapper.Map<Productor, ProductorDto>);
        }


        // GET /api/productores/1
        public IHttpActionResult GetProductor(int id)
        {
            var productor = _context.Productores.SingleOrDefault(c => c.Id == id);

            if (productor == null)
                return NotFound();

            return Ok(Mapper.Map<Productor, ProductorDto>(productor));            
        }


        // POST /api/productores
        [HttpPost]
        public IHttpActionResult CreateProductor(ProductorDto productorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productor = Mapper.Map<ProductorDto, Productor>(productorDto);

            _context.Productores.Add(productor);
            _context.SaveChanges();

            // returns the new id to the client

            productorDto.Id = productor.Id;

            return Created(new Uri(Request.RequestUri + "/" + productor.Id),productorDto);

        }


        // PUT /api/productores/1
        [HttpPut]
        public IHttpActionResult UpdateProductor(int id, ProductorDto productorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productorInDb = _context.Productores.SingleOrDefault(p => p.Id == id);

            if (productorInDb == null)
                return NotFound();

            Mapper.Map(productorDto, productorInDb);
            
            _context.SaveChanges();

            return Ok();
        }
    

        // DELETE /api/productores/1
        [HttpDelete]
        public IHttpActionResult DeleteProductor(int id)
        {
            var productorInDb = _context.Productores.SingleOrDefault(p => p.Id == id);

            if (productorInDb == null)
                return NotFound();

            _context.Productores.Remove(productorInDb);
            _context.SaveChanges();

            return Ok();
        }



    }
}
