using Codespirals.Poker;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codespirls.Poker.Web.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public Deck Deck { get; set; } = new Deck();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
