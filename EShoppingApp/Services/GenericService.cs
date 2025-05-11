using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using EShoppingApp.Services.Interfaces;

namespace EShoppingApp.Services
{
    public class GenericService<TVM, TEntity> : IGenericService<TVM, TEntity> where TVM : class where TEntity : BaseEntity, new()
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IMapper mapper, IGenericRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TVM> AddAsync(TVM entity)
        {
            var data = _mapper.Map<TEntity>(entity);
            var result = await _repository.AddAsync(data);
            if (result == null)
            {
                return null;
            }
            var entityVM = _mapper.Map<TVM>(data);
            return entityVM;

        }

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);





        public async Task<IEnumerable<TVM>> GetAllAsync()
        {
            var datas = await _repository.GetAllAsync();
            if (datas == null)
            {
                return null;
            }
            var entityVM = _mapper.Map<IEnumerable<TVM>>(datas);
            return entityVM;
        }

        public async Task<TVM> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return null;
            }
            var entityVM = _mapper.Map<TVM>(data);
            return entityVM;
        }

        public async Task<TVM> UpdateAsync(TVM entity)
        {
            var data = _mapper.Map<TEntity>(entity);
            var result = await _repository.UpdateAsync(data);
            if (result == null)
            {
                return null;
            }
            var entityVM = _mapper.Map<TVM>(data);
            return entityVM;
        }


    }


}
