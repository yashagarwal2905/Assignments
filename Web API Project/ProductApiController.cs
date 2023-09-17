using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiServiceRepositorySecurityDatabase.Services;
using WebApiServiceRepositorySecurityDatabase.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiServiceRepositorySecurityDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ProductApiController : ControllerBase
    {
        IServices _service;
        public ProductApiController(IServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_service.Details());
        }

        [HttpGet("DetailsById/{id}")]
        public IActionResult DetailsById(int id) {
            Product obj = _service.DetailsById(id);
            if (obj == null)
            {
                return NotFound(new { result = "Product Id not found." });
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet("DetailsByCategory/{category}")]
        public IActionResult DetailsByCategory(string category)
        {
            List<Product> obj = _service.DetailsByCategory(category);
            if (obj == null)
            {
                return NotFound(new { result = "Product category not found." });
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet("outofstock")]
        public IActionResult OutOfStock()
        {
            List<Product> obj = _service.OutOfStock();
            if (obj == null)
            {
                return NotFound(new { result = "No product is out of stock." });
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet("range/{l}&{r}")]
        public IActionResult RangeDetails(int l, int r)
        {
            List<Product> obj = _service.RangeDetails(l,r);
            if (obj == null)
            {
                return NotFound(new { result = "No product available in this range." });
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet("category")]
        public IActionResult CategoryNames()
        {
            List<string> obj = _service.CategoryNames();
            if (obj == null)
            {
                return NotFound(new { result = "No categories available." });
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product obj)
        {
            _service.Create(obj);
            return Ok(new { result = "Product details added to database." });
        }
        [HttpPut]
        public IActionResult Edit([FromBody] int id)
        {
            _service.Edit(id);
            return Ok(new { result = "Product details changed." });
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            _service.Delete(id);
            return Ok(new { result = "Product details changed." });
        }


    }
}
