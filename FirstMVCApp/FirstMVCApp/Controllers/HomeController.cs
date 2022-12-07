using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    /*
    The HomeController inherits from the Controller and has one public method Index.

    When we run this code your broswer should display hello from the Index method of the HomeController,
    if you append to the localhost url /Home or /Home/Index. 
    
    It looks for the Index method and invokes it.

    If you try to append /Home/DoSomething it will not work because we do not have a DoSomething method.
   
    Let us comment out DoSomething and see what happens! 
    
    This is known as routing.
    
    The URL/ or /Home also works because MVC Configured to serve /Home/Index when nothing is specified in the URL.

    But I thought the controller was not supposed to work without a view!!!

    That is correct, this is just an example let us add the view now.

    */
    public class HomeController : Controller
    {

        
 
       public IActionResult Index()
       {
           FirstModel message = new FirstModel();
           return View(message);
       }

       public IActionResult DoSomething()
       {

           return View();
       }

        public IActionResult somethingDone()
        {


            return View();
        }

        
            
       

        /*
        public string DoSomething()
        {
            return "Hello from the DoSomething method of the HomeController";

        }
        











        /*
        
        //Implementing our own Index method that simply returns a string (Step 1).
        
        
        public string Index()
        {
            return "hello from the Index method of the HomeController";
        }

        */

        /* Adding view (Step 2)
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult DoSomething()
        {

            return View();
        }

        */


        /*
         * Adding model and view (Step 3).
        public IActionResult Index()
        {
            FirstModel message = new FirstModel();
            return View(message);
        }

        public IActionResult DoSomething()
        {

            return View();
        }
        */

        /*
        public string DoSomething()
        {
            return "Hello from the DoSomething method of the HomeController";

        }
        */

        /*
         * This was the default Index method, we commented out to test what it looks like to create our own index method.
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}


/*EXERCISE
 * 
 * 
 * Using the homecontroller, add a new model and view with a unique twist to it (make it display an image (from a link) or something of that nature.
*/