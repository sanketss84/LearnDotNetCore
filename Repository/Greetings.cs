using Microsoft.Extensions.Configuration;

namespace firstApp.Repository
{
  public interface IGreetings
  {
    string GetGreetings();

  }

  public class Greetings : IGreetings
  {
    private IConfiguration _configuration;

    public Greetings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetGreetings()
    {
      return _configuration["Greeting"];
    }
  }

}

