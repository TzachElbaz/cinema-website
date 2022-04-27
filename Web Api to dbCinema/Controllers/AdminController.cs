using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll_to_dbCinema;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api_to_dbCinema.Controllers
{
    [Route("[controller]")] [Authorize(Policy = "Admin1")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        dbCinemaEditor Data = new dbCinemaEditor();

        // GET: <AdminController>
        //get all the information about all the movies
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.getAllMovies());
        }

        // GET api/<AdminController>/MovieID
        // get information about a specific movie (by its MovieID)
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = Data.getMovieByID(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("screening")]
        public IActionResult GetScreenings()
        {
            return Ok(Data.getAllScreenings());
        }

        // GET <AdminController>/screening/
        [HttpGet]
        [Route("screening/{id}")]
        public IActionResult GetScreeningsByMovieId(int id)
        {
            return Ok(Data.getScreeningsByMovieID(id));
            //not found?
        }

        // POST <AdminController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie value)
        {
            int id = Data.addNewMovie(value);
            return Created($"admin/{id}", value);
        }

        // POST <AdminController>
        [HttpPost]
        [Route("screening/{id}")]
        public IActionResult postNewScreening([FromBody] Screening value)
        {
            Data.addNewScreening(value);
            return Ok();
        }

        // PUT <AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Data.deleteMovie(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE api/<AdminController>/5
        [HttpDelete]
        [Route("screening/{id}")]
        public IActionResult DeleteScreening([FromBody] int screeningId)
        {
            try
            {
                Data.deleteScreening(screeningId);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
