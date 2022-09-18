using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IProjectRepository
    {
        List<ProjectDTO> GetProjects();
    }
    public class ProjectRepository : IProjectRepository
    {
        public List<ProjectDTO> GetProjects()
        {
            return new List<ProjectDTO>()
            {
                new ProjectDTO
                {
                    Title = "Capacítate",
                    Description = "Sistema de Gestión de Aprendizaje (LMS) desarrollado en Laravel",
                    Link = "https://capacitate.mt.gob.do",
                    ImageUrl = "/images/capacitate.png"
                },
                new ProjectDTO
                {
                    Title = "Plantilla Institucional",
                    Description = "Plantilla institucional del Ministerio de Trabajo desarrollada en WordPress",
                    Link = "https://mt.gob.do",
                    ImageUrl = "/images/plantilla-institucional-mt.png"
                },
                new ProjectDTO
                {
                    Title = "ACSD Services",
                    Description = "Plantilla para el Sitio Web de la compañia ACSD Services desarrollada en WordPress",
                    Link = "https://acsdservices.com/",
                    ImageUrl = "/images/acsd-services.png"
                },
                new ProjectDTO
                {
                    Title = "i-BETCHA",
                    Description = "Plantilla para el Sitio Web de apuestas i-BETCHA desarrollada en WordPress",
                    Link = "https://ibetcha.com/",
                    ImageUrl = "/images/ibetcha.png"
                },
            };
        }
    }
}
