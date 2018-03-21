using Microsoft.AspNetCore.Mvc;

namespace firstApp.Controllers
{
    // [Route("About")]
    // [Route("[controller]")]
    [Route("[controller]/[action]")]
    // [Route("company/[controller]/[action]")]
    public class AboutController
    {
        // [Route("")]
        public string Phone()
        {
            return "987654321";
        }

        // [Route("Address")]
        // [Route("[action]]")]
        public string Address()
        {
            return "India";
        }
    }
}
