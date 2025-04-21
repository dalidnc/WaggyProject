using Microsoft.AspNetCore.Mvc;
using WaggyProject.Context;
using WaggyProject.Entities;

namespace WaggyProject.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly WaggyContext _context;

        public TestimonialController(WaggyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var values = _context.Testimonials.ToList();
            return View(values);
        }


        public IActionResult AddTestimonial()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {

          var values = _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {

            var values = _context.Testimonials.Find(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {

            var values = _context.Testimonials.Find(testimonial.TestimonialId);
            values.Comment = testimonial.Comment;
            values.Name = testimonial.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public IActionResult DeleteTestimonial(int id)
        {

            var values = _context.Testimonials.Find(id);
            _context.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }










    }
}
