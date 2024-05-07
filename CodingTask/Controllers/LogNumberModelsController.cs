using Microsoft.AspNetCore.Mvc;
using CodingTask.DataCon;
using CodingTask.Models;

namespace CodingTask.Controllers
{
    public class LogNumberModelsController : Controller
    {
        private readonly LogNumberDbContext _context;

        public LogNumberModelsController(LogNumberDbContext context, NumberTextUtility numberTextUtility)
        {
            _context = context;
        }
        public IActionResult Index(int startNumber = 1, int endNumber = 100)
        {
            //server-side validations
            if (startNumber < 0)
            {
                ModelState.AddModelError(string.Empty, "The starting number should fall within the range of 0 to 100");
            }
            else if (endNumber > 100)
            {
                ModelState.AddModelError(string.Empty, "The ending number should fall within the range of 0 to 100");
            }
            else if (startNumber > endNumber)
            {
                ModelState.AddModelError(string.Empty, "Start number cannot be greater than end number.");
            }

            if (!ModelState.IsValid)
            {
                // If there are validation errors, return the view with errors
                return View(new LogNumberViewModel { Numbers = new List<string>(), ErrorMessage = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage });
            }

            var temp = new LogNumberModel
            {
                StartNumber = startNumber,
                EndNumber = endNumber,
                DateTime = DateTime.Now
            };
            _context.LogNumberEntries.Add(temp);
            _context.SaveChanges();
            return View(GetNumberViewModel(startNumber, endNumber));

        }
        private LogNumberViewModel GetNumberViewModel(int startNumber, int endNumber)
        {
            var viewModel = new LogNumberViewModel();
            for (int i = startNumber; i <= endNumber; i++)
            {
                viewModel.Numbers.Add(NumberTextUtility.GetTextForNumber(i));
            }
            return viewModel;
        }

    }


}
