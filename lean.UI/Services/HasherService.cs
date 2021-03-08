using lean.UI.Helpers.Methods;

namespace lean.UI.Services
{
    public class HasherService 
    {
        public string ComputeSha256Hash(string data)
        {
            return HasherHelper.ComputeSha256Hash(data);
        }
    }
}
