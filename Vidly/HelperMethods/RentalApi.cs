using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Vidly.Dtos;

namespace Vidly.HelperMethods
{
    public class RentalApi
    {
        public IEnumerable<RentalDto> GetRentalDtos(int customerId)
        {
            IEnumerable<RentalDto> rentals = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/api/rentals");
                var responseTask = client.GetAsync("?CustomerId=" + customerId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsAsync<IList<RentalDto>>();
                    model.Wait();

                    rentals = model.Result;
                }

                return rentals;
            }
        }

        public void CreateRental(RentalDto rentalDto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/api/rentals");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RentalDto>("rentals", rentalDto);
                postTask.Wait();
                var result = postTask.Result;
            }
        }
    }
}