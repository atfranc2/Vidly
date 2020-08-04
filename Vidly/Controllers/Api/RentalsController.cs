using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using System.Web.Http.Results;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult getRentals()
        {
            var rentals = _context.Rentals
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentals); 
        }

        public IHttpActionResult getCustomerRentals(int customerId)
        {
            var rentals = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentals); 
        }

/*        [HttpPut]
        public IHttpActionResult UpdateRental(RentalDto rentalDto)
        {

        }*/

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            rentalDto.Id = rental.Id;

            return Created(new Uri(Request.RequestUri + "/" + rental.Id), rentalDto);
        }

        [HttpDelete]
        public void DeleteRental(int Id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == Id);

            if (rentalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }
    }
}
