using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace programa2.Pages
{
    public class tarea1Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int recorrer { get; set; }

        [BindProperty]
        public string aplicar { get; set; }

        public string resultado { get; private set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(Mensaje) || recorrer < 0)
            {
                resultado = "Por favor, ingrese un mensaje válido y un desplazamiento positivo.";
                return;
            }

            switch (aplicar)
            {
                case "encode":
                    resultado = Encode(Mensaje, recorrer);
                    break;
                case "decode":
                    resultado = Decode(Mensaje, recorrer);
                    break;
                default:
                    resultado = "Acción no válida.";
                    break;
            }
        }

        private string Encode(string input, int recorrer)
        {
            return ProcessMessage(input, recorrer);
        }

        private string Decode(string input, int recorrer)
        {
            return ProcessMessage(input, 26 - (recorrer % 26));
        }

        private string ProcessMessage(string input, int recorrer)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (char c in input.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    char d = (char)((c - 'A' + recorrer) % 26 + 'A');
                    resultado.Append(d);
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }
    }
}
