using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XmlExampleProject.Models;

namespace XmlExampleProject.Controllers { 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace XmlBookList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Book> books = ReadBooksFromXml();

            return View(books);
        }

        private List<Book> ReadBooksFromXml()
        {
            List<Book> books = new List<Book>();

            string xmlFilePath = "wwwroot/books.xml";

            XDocument xDocument = XDocument.Load(xmlFilePath);

            foreach (var element in xDocument.Root.Elements("Book"))
            {
                Book book = new Book
                {
                    Id = int.Parse(element.Attribute("Id").Value),
                    Title = element.Element("Title").Value,
                    Author = element.Element("Author").Value,
                    Year = int.Parse(element.Element("Year").Value)
                };

                books.Add(book);
            }

            return books;
        }
    }
} }
