using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace programa4.Pages
{
    public class tarea1Model : PageModel
    {
        public int[] Numeros { get; private set; }
        public int Suma { get; private set; }
        public double Promedio { get; private set; }
        public List<int> Moda { get; private set; }
        public double Mediana { get; private set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            Random random = new Random();
            Numeros = new int[20];

            for (int i = 0; i < Numeros.Length; i++)
            {
                Numeros[i] = random.Next(0, 101);
            }

            Suma = Numeros.Sum();
            Promedio = Numeros.Average();
            Moda = CalcularModa(Numeros);
            Mediana = CalcularMediana(Numeros);
        }

        private List<int> CalcularModa(int[] numeros)
        {
            var diccionarioFrecuencia = new Dictionary<int, int>();

            foreach (var numero in numeros)
            {
                if (diccionarioFrecuencia.ContainsKey(numero))
                {
                    diccionarioFrecuencia[numero]++;
                }
                else
                {
                    diccionarioFrecuencia[numero] = 1;
                }
            }

            int maximaFrecuencia = diccionarioFrecuencia.Values.Max();
            return diccionarioFrecuencia.Where(par => par.Value == maximaFrecuencia)
                                        .Select(par => par.Key)
                                        .ToList();
        }

        private double CalcularMediana(int[] numeros)
        {
            Array.Sort(numeros);
            int n = numeros.Length;
            if (n % 2 == 0)
            {
                return (numeros[n / 2 - 1] + numeros[n / 2]) / 2.0;
            }
            else
            {
                return numeros[n / 2];
            }
        }
    }
}
