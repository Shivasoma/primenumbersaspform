using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class PrimeNumbersModel : PageModel
{
    [BindProperty]
    public int FromNumber { get; set; }

    [BindProperty]
    public int ToNumber { get; set; }

    public List<int> PrimeNumbers { get; set; }

    public void OnPost()
    {
        PrimeNumbers = GetPrimeNumbers(FromNumber, ToNumber);
    }

    private List<int> GetPrimeNumbers(int from, int to)
    {
        List<int> primes = new List<int>();
        for (int i = from; i <= to; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
    }

    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
