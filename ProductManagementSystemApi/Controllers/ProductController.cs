using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystemApi.Dto;
using ProductManagementSystemApi.Models;
using ProductManagementSystemApi.Repository.IRepository;

namespace ProductManagementSystemApi.Controllers
{
    //<summary>

    //Controller for Products management

    //</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        //<summary>
        // Get all products
        //<summary>
        //<returns> A list of products </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetAllProducts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetAllProducts()); 
            return Ok(products);    
        }

        //<summary>
        //Get a product
        //<param name = "prodcutId"> The Id of the product to retrieve </param>
        //<returns> Returns the product with specified productId </returns>
        //</summary>
        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult GetProductById(int productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        //<summary>
        //Get a product
        //<param name = "prodcutName"> The name of the product to retrieve </param>
        //<returns> Returns the product with specified produc name </returns>
        //</summary>
        [HttpGet("products/{productName}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        public IActionResult GetProductByName( string productName)
        {
            if (!_productRepository.ProductExists(productName))
            {
                return NotFound();
            }

            var product = _productRepository.GetAllProducts().Where(p=> p.Name == productName).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        //<summary>
        //Create a product
        //<param name = "productName">Name of product to create </param>
        //<returns> returns the created product </returns?
        [HttpPost]
        [ProducesResponseType(202, Type = typeof(ProductDto))]
        public IActionResult CreateProduct([FromBody] ProductDto productCreate) 
        {
            if (productCreate == null)
            {
                return BadRequest();
            }

            //compare the product to existing data in the database to see if there is a match
            var product = _productRepository.GetAllProducts()
                .Where(c => c.Name.Trim().ToUpper() == productCreate.Name.Trim().ToUpper()).FirstOrDefault();

            if (product != null)
            {
                ModelState.AddModelError("", "Product already exist");
                return StatusCode(422);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productMap = _mapper.Map<Product>(productCreate);

            if (!_productRepository.CreateProduct(productMap))
            {
                ModelState.AddModelError("", "Error adding new product");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created!");
        }

        //<summary>
        //Update a product
        //<param name = "productId">Id of product to update </param>
        //<returns> updated product  - noContent StatusCode </returns?
        [HttpPut("{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateProductById(int productId, [FromBody]ProductDto updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest();
            }

            if (productId != updatedProduct.Id)
            {
                return BadRequest();
            }

            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productMap = _mapper.Map<Product>(updatedProduct);

            if (!_productRepository.UpdateProductById(productMap))
            {
                ModelState.AddModelError("", "Error updating Product");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //<summary>
        //Update a product by name
        //<param name = "productName">Name of product to update </param>
        //<returns> returns the updated product - NoContent StatusCode </returns?
        [HttpPut("/product/{productName}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateProductById(string productName, [FromBody]ProductDto updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest();
            }

            if (productName == updatedProduct.Name)
            {
                return BadRequest();
            }

            if (!_productRepository.ProductExists(productName))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productMap = _mapper.Map<Product>(updatedProduct);

            if (!_productRepository.UpdateProductById(productMap))
            {
                ModelState.AddModelError("", "Error updating Product");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //<summary>
        //Delete a product
        //<param name = "productId">Name of product to delete </param>
        //<returns> return NoContent </returns?
        [HttpDelete("{productId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(202)]
        public IActionResult DeleteProducById(int productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var productToDelete = _productRepository.GetProductById(productId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_productRepository.DeleteProduct(productToDelete))
            {
                ModelState.AddModelError("", "Error - Cannot delete product");
               
            }

            return NoContent();
        }

        //<summary>
        //Delete a product
        //<param name = "productId">Name of product to delete </param>
        //<returns> return NoContent </returns?
        [HttpDelete("/product/{productName}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(202)]
        public IActionResult DeleteProducByName(string productName)
        {
            if (!_productRepository.ProductExists(productName))
            {
                return NotFound();
            }

            var productToDelete = _productRepository.GetProductByName(productName);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_productRepository.DeleteProduct(productToDelete))
            {
                ModelState.AddModelError("", "Error - Cannot delete product");
               
            }

            return NoContent();
        }
    }
}
