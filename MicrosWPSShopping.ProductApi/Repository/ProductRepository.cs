using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicrosWPSShopping.ProductApi.Data.ValueObjects;
using MicrosWPSShopping.ProductApi.Model;
using MicrosWPSShopping.ProductApi.Model.Context;
using MicrosWPSShopping.ProductApi.Repository.Interface;

namespace MicrosWPSShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLContext _context;
        private IMapper _mapper;
        public ProductRepository(SQLContext sQLContext, IMapper mapper)
        {
            _context = sQLContext;
            _mapper = mapper;
        }
        public async Task<ProductVo> Create(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(w => w.Id == id)
                .FirstAsync();
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVo>> FindAll()
        {
            List<Product> list = new List<Product>();
            list = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVo>>(list);
        }

        public async Task<ProductVo> FindById(long id)
        {

            Product product = await _context.Products.Where(w=>w.Id == id)
                .FirstAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<ProductVo> Update(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }
    }
}
