
namespace Intex_Defaults.Models
{
    public class EF_Repository : I_Repository
    {
        private Default_Context _defaultContext;
        public EF_Repository(Default_Context temp)
        {
            _defaultContext = temp;
        }

        public IEnumerable<Product> Products => _defaultContext.Products;
    }
}