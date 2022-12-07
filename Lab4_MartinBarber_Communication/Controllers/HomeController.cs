/*
 * Name:            Martin Barber
 * Student ID:      100368442
 * Date:            November 20th
 * Description:     Create a web page, appraising a book given by students to sell.
 * File Name:       Lab4_MartinBarber
 */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_MartinBarber.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Lab4_MartinBarber.Controllers
{

    public class HomeController : Controller
    {
        List<Textbook> books = new List<Textbook>();

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Textbook book)
        {
            

            int errors = 0;
            // Extra validation to take user to error page
            // Validate book title has words in it
            if (book.title == null)
            {
                errors++;
                ViewData["ErrorTitle"] = "Error - Enter a Book Title";
            }

            // If ISBN is not 6 numbers
            if (book.isbn < 100000 || book.isbn >= 1000000)
            {
                errors++;
                ViewData["ErrorISBN"] = "Error - Book ISBN. Must be 6 numbers";
            }

            // Book version between 1 and 20
            if (book.version <= 0 || book.version > 20)
            {
                errors++;
                ViewData["ErrorVersion"] = "Error - Book Version (1 - 20)";
            }

            // Original price must be less than 1000 but higher than 0
            if (book.originalPrice <= 0 || book.originalPrice >= 1000)
            {
                errors++;
                ViewData["ErrorPrice"] = "Error - Book Original Price. ($1 - $1000)";
            }

            if (errors == 0)
            {
                // If the state of the model meets all expectations, then set the message and appraise message to get the value of the book
                if (ModelState.IsValid)
                {
                    
                    // This will display all the information on a seperate line for easier readability.
                    ViewData["BookName"] = "Book Title:     " + book.title;
                    ViewData["ISBN"] = "ISBN:           " + book.isbn;
                    ViewData["Version"] = "Book Version:   " + book.version;
                    ViewData["OriginalPrice"] = "Original Price: $" + book.originalPrice;
                    ViewData["Condition"] = "Condition:      " + book.condition;
                    book.appraisal = book.calcAppraise(book.originalPrice, book.condition);
                    ViewData["Appraise"] = "This book is valued at: $" + book.appraisal;


                    books.Add(new Textbook
                    {
                        title = book.title,
                        isbn = book.isbn,
                        version = book.version,
                        originalPrice = book.originalPrice,
                        condition = book.condition,
                        appraisal = book.appraisal
                    });
                    

                    ViewData["list"] = "Items in list: " + books.Count;

                    return View("Registered", book); // This passes the information to the next page.
                }
                else
                {
                    return View("Error", book);
                }
            }
            // If the state of the model meets all expectations, then set the message and appraise message to get the value of the book
            else
            {
                return View("Error", book);
            }

        }


        public IActionResult ViewAppraisals(Text books)
        {
            List<Textbook> displaybooks = new List<Textbook>();

            foreach (var book in books)
            {
                displaybooks.Add(new Textbook(book.title, book.isbn, book.version, book.originalPrice, book.condition, book.appraisal));
            }

            displaybooks.Add(new Textbook("testing", books.Count, 4,111, "Like new", 50));
            displaybooks.Add(new Textbook("testing2", books.Count, 1, 222, "Like new", 111));

            ViewData["books"] = displaybooks;
            return View("ViewAppraisals", displaybooks);
        }
    }
}
