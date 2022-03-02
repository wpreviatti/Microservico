using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosWPSShopping.ProductApi.Data.ValueObjects;
using MicrosWPSShopping.ProductApi.Repository.Interface;

namespace MicrosWPSShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVo>> Get(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVo>>> GetAll()
        {
            var product = await _repository.FindAll();
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductVo>> Create(ProductVo vo)
        {
            if (vo == null)
                return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);
        }
        [HttpPut]
        public async Task<ActionResult<ProductVo>> Update(ProductVo vo)
        {
            if (vo == null)
                return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
        }
    }
}
