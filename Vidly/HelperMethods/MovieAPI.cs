using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Vidly.Dtos;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Vidly.HelperMethods
{
    public class MovieAPI
    {
        public MovieDto GetMovieDto(int movieId)
        {
            MovieDto movie = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/api/movies");
                var responseTask = client.GetAsync("?id=" + movieId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsAsync<MovieDto>();
                    model.Wait();
                    movie = model.Result;
                }

                return movie;
            }
        }

        public void decrementMovieStock(int movieId)
        {
            var movieDto = GetMovieDto(movieId);
            movieDto.NumberInStock = movieDto.NumberInStock - 1;
            var json = new JavaScriptSerializer().Serialize(movieDto);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/api/movies"); 

                //HTTP POST
                var putTask = client.PutAsJsonAsync("movies", json);
                putTask.Wait();

                var result = putTask.Result;
            }

        }
        
    }
}