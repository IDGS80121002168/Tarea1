using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace programa3.Pages
{
    public class tarea1Model : PageModel
    {
        [BindProperty]
        [Required]
        public double A { get; set; }

        [BindProperty]
        [Required]
        public double B { get; set; }

        [BindProperty]
        [Required]
        public double X { get; set; }

        [BindProperty]
        [Required]
        public double Y { get; set; }

        [BindProperty]
        [Required]
        public int N { get; set; }

        public double Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Result = Calcular(A, B, X, Y, N);
            }
        }

        private double Calcular(double a, double b, double x, double y, int n)
        {
            double result = 0;
            for (int k = 0; k <= n; k++)
            {
                result += Coeficiente(n, k) * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return result;
        }
        private double Factorial(int number)
        {
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        private double Coeficiente(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

       
    }
}
