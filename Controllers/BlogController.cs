using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mysqlconnector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public AppDb Db { get; }
        public BlogController(AppDb db)
        {
            Db = db;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            Db.Connection.Open();
            var query = new BlogPostQuery(Db);
            var result = query.LatestPostsAsync();
            return new OkObjectResult(result);
        }
    }
}
