using Animals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public List<AnimalModel> AnimalList { get; set; } = new List<AnimalModel>()
        {
            new AnimalModel()
            {
              Name = "Lion",
                Age=41
            },
             new AnimalModel()
            {
                Name = "Tiger",
                Age=15
            },
              new AnimalModel()
            {
                Name = "Elephant",
                Age=14
            },
               new AnimalModel()
            {
                Name = "Giraffe",
                Age=24
            },
                new AnimalModel()
            {
                Name = "Hippo",
                Age=12
            },
        };

        [Route("{name}")]
        public IActionResult GetById(string name)
        {
            if (name == "Giraffe")
            {
                return Redirect("smile");
            }
            if (AnimalList.Exists(x => x.Name == name))
            {
                return Ok(name);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("special/{name}")]
        public ActionResult getbyid(string name)
        {
            if (name == "Giraffe")
            {
                return RedirectToAction("smile");
            }
            if (AnimalList.Exists(x => x.Name == name))
            {
                return CreatedAtAction("~api/animal/special" + name, new { name = name });
            }
            else
            {
                return NotFound();
            }

        }

        [Route("smile")]
        public IActionResult Smile()
        {
            return Ok("smile");
        }

    }
}
