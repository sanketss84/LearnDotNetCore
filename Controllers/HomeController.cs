using Microsoft.AspNetCore.Mvc;
using firstApp.Models;
using firstApp.Repository;
using firstApp.ViewModels;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _restaurantRepository;

        private IGreetings _greetings;

        public HomeController (IRestaurantRepository restaurantRepository,
                                IGreetings greetings)
        {
            _restaurantRepository = restaurantRepository;
            _greetings = greetings;
        }

        //Return a View i.e. some view .cshtml instead of just a string or objectresult
        public IActionResult Index()
        {
            // var model = new Restaurant { 
            //     Id = 1 , Name = "Over Story"
            // };
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantRepository.GetAll();
            model.CurrentMessage = _greetings.GetGreetings();

            return View(model); //Looks for Index.cshtml in Views folder
            // return View("Home"); // you can have different view name by default its the name of the Action
        }

        #region Sample Example Code

        // public string Index()
        // {
        //     return "HomeController called :) ";
        // }

        // public ContentResult Index()
        // {
        //     return Content("HomeController ContentResult called :) ");
        // }

        //ObjectResult is like RES API returning a JSON or XML or CSV or PDF or anything which you tell the MVC framework to return.
        // public IActionResult Index()
        // {
        //     var model = new Restaurant { Id = 1 , Name = "Over Story"};

        //     // return Content("HomeController IActionResult called :) ");
        //     // ObjectResult can give a response in XMl or JSON 
        //     // its upto to the controller to decide on what sort of response it wants to give
        //     // When checked in chrome it gave a JSON response
        //     return new ObjectResult (model);
        // }

        // Note all the various result types ContentResult,FileContentResult,NoContentResult etc.
        // are inherited from IActionResult

        public string ControllerContextExample()
        {

            // When you inherit from Controller it opens a whole new world
            // check all the this. options that you unlock after you inherit from Controller class

            // ControllerContext
            // var ActionName = this.ControllerContext.ActionDescriptor.ActionName;
            // var ControllerName = this.ControllerContext.ActionDescriptor.ControllerName;
            return "ControllerContextExample called :) ";
        }

        public string HttpContextExample()
        {
            
            // HttpContext , this allows you to manipulate the response object and look at the request header
            // Please note even if HttpContext is available here there are much cleaner ways 
            // of accessing it and which also makes it unit testable
            // this.HttpContext.Request
            // this.HttpContext.Request.Headers;
            // this.HttpContext.Request.Body;
            // this.HttpContext.Request.Cookies;

            // this.HttpContext.Response
            // this.HttpContext.RequestAborted
            return "HttpContextExample called :) ";
        }
        public IActionResult SomeAction()
        {
            // There are other methods also that are available 
            // Majority of the methods are used to produce something that implements IActionResult
            // BadRequest allows us to send error 400 to the client 
            // and we are telling the client that they have passed some invalid data
            return this.BadRequest();
        }

        public IActionResult FileExample()
        {
            //send back a file
            // return this.File();
            // return "FileExample called :) ";
            return Content("FileExample called :) ");
        }

        public ContentResult SendContentInStructuredWayExample()
        {
            return Content("HomeController called :) ");
        }

        #endregion

    }
}
