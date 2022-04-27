using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll_to_dbCinema;
using Microsoft.AspNetCore.Authorization;

namespace Web_Api_to_dbCinema.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        dbCinemaEditor Data = new dbCinemaEditor();

        // GET: <UserController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(Data.getAllMovies());
        }
        // GET <UserController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var movie = Data.getMovieByID(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("screening/{id}")]
        public IActionResult GetScreeningsByMovieId(int id)
        {
            return Ok(Data.getScreeningsByMovieID(id));
        }

        // GET: <UserController>
        [HttpGet]
        [Authorize(Policy = "Members1")]
        [Route("orders/{id}")]

        //all client's detailed orders (by Client ID)
        public IActionResult GetOrders(string id) 
        {
            List<DetailedOrder> ordersToShow = new List<DetailedOrder>();
            List<Order> orders = Data.getOrders(id);
            foreach (Order i in orders)
            {
                DetailedOrder details = new DetailedOrder();
                details.orderNumber = i.OrderId;
                details.tickets = i.NumberOfTickets;
                Screening s1 = Data.getSingleScreeningByMovieId(i.MovieId);
                details.orderDate = s1.Date.Day + "/" + s1.Date.Month + "/" + s1.Date.Year;
                details.orderTime = s1.Hour;
                details.movieTitle = Data.getMovieByID(i.MovieId).Title;
                ordersToShow.Add(details);
            }
            return Ok(ordersToShow);
        }

        [HttpGet]
        [Authorize(Policy = "Members1")]
        [Route("neworder/{id}")]

        //returns detailed order about the last order the client performed (by order ID)
        public IActionResult GetNewOrders(int id)
        {
            Order newOrder = Data.getSingleOrderByid(id);
            DetailedOrder details = new DetailedOrder();
            details.orderNumber = newOrder.OrderId;
            details.tickets = newOrder.NumberOfTickets;
            Screening s1 = Data.getSingleScreeningByMovieId(newOrder.MovieId);
            details.orderDate = s1.Date.Day + "/" + s1.Date.Month + "/" + s1.Date.Year;
            details.orderTime = s1.Hour;
            details.movieTitle = Data.getMovieByID(newOrder.MovieId).Title;
            return Ok(details);
        }


        [HttpGet]
        [Authorize(Policy = "Members1")]
        [Route("self/{id}")]
        public IActionResult GetSelfData(string id)
        {
            return Ok(Data.getClientById(id));
        }

        // POST <UserController>
        [HttpPost]
        [Authorize(Policy = "Members1")]
        public IActionResult PostNewOrder([FromBody] Order value)
        {
            int id = Data.addNewOrder(value);
            return Created($"user/{id}", value);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Members1")]
        public IActionResult Put(string id, [FromBody] Client value)
        {
            Data.updateClient(id, value);
            return Ok(value);
        }

        // DELETE <UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Members1")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                Data.cancelOrder(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
