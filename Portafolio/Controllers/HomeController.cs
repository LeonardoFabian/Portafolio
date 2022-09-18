using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepository projectRepository;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository, IEmailService emailService)
        {
            _logger = logger;
            this.projectRepository = projectRepository;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Este es un mensaje de log");
            var projects = projectRepository.GetProjects().Take(3).ToList();
            var model = new HomeIndexViewModel() { Projects = projects };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = projectRepository.GetProjects();
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
        {
            await emailService.Send(contactViewModel);
            return RedirectToAction("Confirm");
        }

        public IActionResult Confirm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}