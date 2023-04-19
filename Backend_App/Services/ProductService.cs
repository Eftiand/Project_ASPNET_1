using Backend_App.Factory;
using Backend_App.Models.DTO.Product;
using Backend_App.Models.Entities;
using Backend_App.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Backend_App.Services;

public class ProductService  
{
    private readonly ProductRepository _productRepository;
    
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return ConvertToResponse(products);
    } 
    
    public async Task<ProductResponse> GetProductAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }
    
    public async Task<IEnumerable<ProductResponse>> GetByStatusAsync(string status)
    {
        var products = await _productRepository.GetAllAsync();
        var responseEntities = products
            .Where(x => x.Status.ToString().ToLower() == status.ToLower()).ToList();
        
        return ConvertToResponse(responseEntities);
    }
    
    public async Task<ProductResponse> CreateAsync(ProductRequest productRequest)
    {
        var result = await _productRepository.AddAsync(productRequest);
        return result;
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await _productRepository.DeleteAsync(product);
    }
    
    public async Task<IEnumerable<ProductResponse>> SearchAsync(string search)
    {
        var products = await _productRepository.GetAllAsync();
        var responseEntities = products
            .Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
        
        return ConvertToResponse(responseEntities);
    }
    private IEnumerable<ProductResponse> ConvertToResponse(IEnumerable<ProductEntity> productEntities)
    {
        var response = productEntities.Select(ProductFactory.CreateProductResponse).ToList();
        return response;
    }
}