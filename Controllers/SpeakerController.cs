using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.Models;
using exam.context;

namespace Exam.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly EXAMContext _context;

        public SpeakerController(EXAMContext context)
        {
            _context = context;
        }

        // GET: SpeakerController1
         public async Task<IActionResult> Speaker()
        {
            var _speakers = await _context.ViewListOfSpeakers.ToListAsync();
            return View(_speakers);
        }

    }
}
