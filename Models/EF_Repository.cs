
namespace IntexLego.Models
{
    public class EF_Repository : I_Repository
    {
        private IntexDataContext _defaultContext;
        public EF_Repository(IntexDataContext temp)
        {
            _defaultContext = temp;
        }

        public IEnumerable<Product> Products => _defaultContext.Products;
    }
}