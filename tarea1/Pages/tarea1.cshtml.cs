using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tarea1.Pages
{
    public class tarea1Model : PageModel
    {
        [BindProperty]
        public double? Peso { get; set; }

        [BindProperty]
        public double? Altura { get; set; }

        public double? IMC { get; private set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (Peso.HasValue && Altura.HasValue && Altura > 0)
            {
                IMC = Peso / (Altura * Altura);
            }
            return Page();
        }
    }
}
