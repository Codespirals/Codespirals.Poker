using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codespirls.Poker.Web.Pages
{
    public class BlackjackModel : PageModel
    {
        public Deck Deck { get; set; } = new Deck();
        public void OnGet()
        {

        }
    }
}
