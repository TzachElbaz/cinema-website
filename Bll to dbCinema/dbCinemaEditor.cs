using System;
using System.Linq;
using System.Collections.Generic;



namespace Bll_to_dbCinema
{
    public class dbCinemaEditor
    {
        dbCinemaContext dataBaseCinema = new dbCinemaContext();

        //gets user details(email and password) and compare to data in database
        public Client login(string email, string password)
        {
            //password is case sensitive, email is not.
            var clients = dataBaseCinema.Clients.Where(c => c.Email == email).ToList();
            Client authorizedClient = clients.FirstOrDefault(c => c.Password == password);
            if (authorizedClient != null)
            {
                return authorizedClient;
            }
            return null;
        }

        //Adding a new client to the Clients table
        public void signUp(Client newClient)
        {
            dataBaseCinema.Clients.Add(newClient);
            dataBaseCinema.SaveChanges();
        }

        //Gets all the movies from Movies table
        public List<Movie> getAllMovies()
        {
            return dataBaseCinema.Movies.ToList();
        }

        //Gets a single movies from Movies table by its movieId property
        public Movie getMovieByID(int id) 
        {
            return dataBaseCinema.Movies.FirstOrDefault(m => m.MovieId == id);
        }

        //Gets a single user data from Clients table by its ID
        public Client getClientById(string id)
        {
            return dataBaseCinema.Clients.FirstOrDefault(c =>
            c.ClientId == id);
        }

        //All screenings of a single movie (by movie id)
        public object getScreeningsByMovieID(int movieID) 
        {
            var screenings = from Screening in dataBaseCinema.Screenings
                             where Screening.MovieId == movieID
                             select Screening;
            return screenings.OrderBy(s => s.Date).ToList();
        }
        
        public Screening getSingleScreeningByMovieId(int movieId)
        {
            Screening s1 = dataBaseCinema.Screenings.FirstOrDefault(s => s.MovieId == movieId);
            return s1;
        }

        public List<Screening> getAllScreenings()
        {
            return dataBaseCinema.Screenings.ToList();
        }
        public List<Order> getOrders(string userID)
        {
            return (from Order in dataBaseCinema.Orders
                    where Order.ClientId == userID
                    select Order).ToList();
        }

        public Order getSingleOrderByid(int orderId)
        {
            return dataBaseCinema.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
        public int addNewMovie(Movie newMovie)
        {
            dataBaseCinema.Movies.Add(newMovie);
            dataBaseCinema.SaveChanges();
            return (dataBaseCinema.Movies.FirstOrDefault(
                m => m.Title == newMovie.Title)).MovieId;
        }

        public void addNewScreening(Screening newScreening)
        {
            dataBaseCinema.Screenings.Add(newScreening);
            Movie m1 = dataBaseCinema.Movies.FirstOrDefault(m => m.MovieId == newScreening.MovieId);
            m1.NumberOfScreenings++;
            dataBaseCinema.SaveChanges();
        }
        public int addNewOrder(Order newOrder)
        {
            dataBaseCinema.Orders.Add(newOrder);
            dataBaseCinema.SaveChanges();
            return (dataBaseCinema.Orders.FirstOrDefault(
                o => o.ClientId == newOrder.ClientId &&
                o.MovieId == newOrder.MovieId)).OrderId;
        }
        public void deleteMovie(int id)
        {
            Movie movieToRemove = dataBaseCinema.Movies.FirstOrDefault(
                m => m.MovieId == id);
            if (movieToRemove == null)
            {
                throw new Exception();
            }
            dataBaseCinema.Movies.Remove(movieToRemove);
            dataBaseCinema.SaveChanges();
        }

        public void deleteScreening(int id)
        {
            Screening screeningToRemove = dataBaseCinema.Screenings.FirstOrDefault(
                s => s.ScreeningId == id);
            if (screeningToRemove == null)
            {
                throw new Exception();
            }
            dataBaseCinema.Screenings.Remove(screeningToRemove);
            Movie m1 = dataBaseCinema.Movies.FirstOrDefault(m => m.MovieId == screeningToRemove.MovieId);
            m1.NumberOfScreenings--;
            dataBaseCinema.SaveChanges();
        }

        public void cancelOrder(int id)
        {
            Order orderToCancel = dataBaseCinema.Orders.FirstOrDefault(
                o => o.OrderId == id);
            if (orderToCancel == null)
            {
                throw new Exception();
            }
            dataBaseCinema.Orders.Remove(orderToCancel);
            dataBaseCinema.SaveChanges();
        }

        public void updateClient(string id, Client newData)
        {
            Client oldData = dataBaseCinema.Clients.FirstOrDefault(c => c.ClientId == id);
            oldData.Email = newData.Email;
            oldData.Password = newData.Password;
            oldData.Phone = newData.Phone;
            oldData.CreditCardNumber = newData.CreditCardNumber;

            dataBaseCinema.SaveChanges();
        }

    }
}
