using FizzBuzzAPI.Model;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<string> GetFizzBuzzResult(string[] input)
        {
            List<string> result = new List<string>();
            int value;
            foreach(var item in input)
            {
                if (int.TryParse(item, out value))
                {
                    if (value % 3 == 0 && value % 5 == 0)
                    {
                        result.Add(item + " - " + Constants.strFizzBuzz);
                    }
                    else
                    if (value % 3 == 0)
                    {
                        result.Add(item + " - " + Constants.strFizz);
                    }
                    else
                    if (value % 5 == 0)
                    {
                        result.Add(item + " - " + Constants.strBuzz);
                    }
                    else
                        result.Add("Divided " + item + " by 3 & Divided " + item + " by 5");
                }
                else
                    result.Add(item + " - " + Constants.strInvalidItem);
            }
            
            return result;
        }
    }
}
