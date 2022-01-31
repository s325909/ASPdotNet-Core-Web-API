using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFranchiseWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFranchiseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieFranchiseController : ControllerBase
    {
        private IMovieFranchiseRepo _movieFranchise;
        public MovieFranchiseController(IMovieFranchiseRepo movieFranchise)
        {
            _movieFranchise = movieFranchise;
        }

        [HttpGet]
        // [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            //return Ok(_movieFranchise.GetMovies());
            return Ok();
        }
    }
}
