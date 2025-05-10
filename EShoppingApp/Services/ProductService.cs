using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using EShoppingApp.Services.Interfaces;

namespace EShoppingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductDocument> _productDocumentRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductDocument> productDocumentRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productDocumentRepository = productDocumentRepository;
            _mapper = mapper;
        }
        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            if (data != null)
            {
                return null;
            }
            

            var productVM = _mapper.Map<ProductViewModel>(data);
            return productVM;


        }
        public Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ProductViewModel> AddAsync(ProductViewModel viewModel)
        {
            var product =  _mapper.Map<Product>(viewModel);
           var entity = await _productRepository.AddAsync(product);
            if (entity != null)
            {
                return null;
            }
            var productVM = _mapper.Map<ProductViewModel>(entity);
            return productVM;

        }
        public Task<ProductViewModel> UpdateAsync(ProductViewModel entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }   
    
    
}
