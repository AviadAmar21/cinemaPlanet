using CinemaPlanet.Dal;
using CinemaPlanet.Models;
using CinemaPlanet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaPlanet.Controllers
{
    public class HallController : Controller
    {
        // GET: Hall
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddHall()
        {

            HallDal dal = new HallDal();
            HallViewModel vm = new HallViewModel();
            List<Hall> Halls = dal.Halls.ToList<Hall>();
            vm.Hall = new Hall();
            vm.Halls = Halls;
            return View(vm);
        }

        //[HttpPost]
        //public ActionResult Submit()
        //{
        //    MovieViewModel mvm = new MovieViewModel();
        //    Movie MyMovie = new Movie()
        //    {

        //        ID = int.Parse(Request.Form["Movie.ID"]).ToString(),
        //        mName = Request.Form["Movie.mName"],
        //        mDate = //DateTime.ParseExact(Request.Form["Movie.mDate"], @"MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
        //        DateTime.Parse(Request.Form["Movie.mDate"]),
        //        Price = int.Parse(Request.Form["Movie.Price"]),
        //        HallName = Request.Form["Movie.HallName"],
        //        Age = int.Parse(Request.Form["Movie.Age"]),
        //        Category = Request.Form["Movie.Category"],

        //    };

        //    MovieDal dal = new MovieDal();

        //    if (ModelState.IsValid)
        //    {

        //        dal.Movies.Add(MyMovie);
        //        dal.SaveChanges();
        //        mvm.Movie = new Movie();
        //    }


        //    else
        //    {
        //        mvm.Movie = MyMovie;
        //    }


        //    mvm.Movies = dal.Movies.ToList<Movie>();
        //    return View("EnterMovie", mvm);

        //}

        [HttpPost]
        public ActionResult SubmitHall()
        {
            HallViewModel vm = new HallViewModel();
            Hall MyHall = new Hall()
            {

                ID = Request.Form["Hall.ID"],
                HallName = Request.Form["Hall.HallName"],
                SeatsNumber = int.Parse(Request.Form["Hall.SeatsNumber"])

            };

            HallDal dal = new HallDal();

            if (ModelState.IsValid)
            {
                dal.Halls.Add(MyHall);
                dal.SaveChanges();
                vm.Hall = new Hall();
            }

            else
            {
                vm.Hall = MyHall;
            }

            vm.Halls = dal.Halls.ToList<Hall>();
            return View("AddHall", vm);

        }

        public ActionResult ChangeSeatsNumber()
        {
            HallViewModel vm = new HallViewModel();
            vm.Hall = new Hall();
            HallDal dal = new HallDal();
            string HallNameValue = Request.Form["txtHallName"];
            int _SeatsNumber = 0;

            if (Request.Form["HallSeatsNumber"] != null)
                _SeatsNumber = int.Parse(Request.Form["HallSeatsNumber"]);

            if (HallNameValue != null)
            {

                Hall addHall = dal.Halls.First(h => h.HallName == HallNameValue);
                addHall.SeatsNumber = _SeatsNumber;
                dal.SaveChanges();
                vm.Halls = dal.Halls.ToList<Hall>();
                return View(vm);

            }

            vm.Halls = dal.Halls.ToList<Hall>();
            return View(vm);
        }

        public bool MovieExist(string search)
        {
            HallDal dal = new HallDal();
            List<Hall> Halls = (from x in dal.Halls where x.HallName.Contains(search) select x).ToList<Hall>();

            if (Halls.Count >= 1)
                return true;

            return false;
        }

        //public ActionResult ChangePrice()
        //{
        //    MovieViewModel mvm = new MovieViewModel();
        //    mvm.Movie = new Movie();
        //    MovieDal dal = new MovieDal();
        //    string nameValue = Request.Form["txtMovieName"];
        //    int price = 0;

        //    if (Request.Form["MoviePrice"] != null)
        //        price = int.Parse(Request.Form["MoviePrice"]);

        //    if (MovieExist(nameValue))
        //    {
        //        Movie addMovie = dal.Movies.First(a => a.mName == nameValue);
        //        addMovie.Price = price;
        //        dal.SaveChanges();
        //        mvm.Movies = dal.Movies.ToList<Movie>();
        //        return View(mvm);
        //    }

        //    mvm.Movies = dal.Movies.ToList<Movie>();
        //    return View(mvm);

        //}
    }
}