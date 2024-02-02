using FizzBuzzAPI.Model;
using FizzBuzzAPI.Utility;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IMathUtil _math;

        public FizzBuzzService(IMathUtil math)
        {
            this._math = math;
        }
        public List<string> GetFizzBuzzResult(string[] input)
        {
            List<string> result = new List<string>();
            int value;
            foreach(var item in input)
            {
                if (int.TryParse(item, out value))
                {
                    if (_math.Division(value,3) == 0 && _math.Division(value, 5) == 0)
                    {
                        result.Add(item + " - " + Constants.strFizzBuzz);
                    }
                    else
                    if (_math.Division(value, 3) == 0)
                    {
                        result.Add(item + " - " + Constants.strFizz);
                    }
                    else
                    if (_math.Division(value, 5) == 0)
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
