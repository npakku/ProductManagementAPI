using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystemApi.Controllers;
using ProductManagementSystemApi.Dto;
using ProductManagementSystemApi.Models;
using ProductManagementSystemApi.Repository;
using ProductManagementSystemApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystemAPITest.Controller
{
    //<summary>
    //
    //ProductController - Tests
    //
    //</summary>
    public class ProductControllerTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductController _productController;
        public ProductControllerTests()
        {
            //set up dependencies
            _productRepository = A.Fake<IProductRepository>();
            _mapper = A.Fake<IMapper>();

            //SUT 
            _productController = new ProductController(_productRepository, _mapper);
        }


        //<summary>
        // Test whether retrieving all products returns ok  - status code 200
        //</summary>
        [Fact]
        public void ProductController_GetAllProducts_ReturnsOk()
        {

            //Arrange - create fake products and productdtos
            var fakeProducts = new List<Product> { new Product { Id = 1, Name = "Bicycle" } };
            var fakeProductDtos = new List<ProductDto> { new ProductDto { Id = 2, Name = "Bicycle" } };

            A.CallTo(() => _productRepository.GetAllProducts()).Returns(fakeProducts);
            A.CallTo(() => _mapper.Map<List<ProductDto>>(fakeProducts)).Returns(fakeProductDtos);

            //Act
            var result = _productController.GetAllProducts();


            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

   
        //<Summary>
        //
        //Test whether creating a product returns created action result
        //</Summary>
        [Fact]
        public void ProductController_CreateProduct_ReturnsOk()
        {
            //arrnage
            var productCreateDto = new ProductDto { Id = 1, Name = "Test" };
            var product = new Product { Id = 1, Name = "Test" };
            var productDto = new ProductDto { Id = 1, Name = "Test" };

            A.CallTo(() => _mapper.Map<ProductDto>(product)).Returns(productDto);
            A.CallTo(() => _mapper.Map<Product>(productDto)).Returns(product);

            //Act - execute 
            var result = _productController.CreateProduct(productCreateDto);

            //Assert
            var createdActionResult = Assert.IsType<CreatedAtActionResult>(result);

            var productDTO = Assert.IsType<ProductDto>(createdActionResult.Value);
            Assert.Equal(productCreateDto.Name, productDTO.Name);
        }
    }
}
