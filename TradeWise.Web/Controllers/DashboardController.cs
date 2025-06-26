using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeWise.Web.Data;
using TradeWise.Web.Models;

namespace TradeWise.Web.Controllers
{
    [Authorize] // ← PROTEÇÃO: Todo o controller precisa de login
    public class DashboardController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(
            UserManager<User> userManager,
            ApplicationDbContext context,
            ILogger<DashboardController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        // GET: /Dashboard
        public async Task<IActionResult> Index()
        {
            // Pegar usuário logado
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Pegar dados do usuário
            var portfolios = await _context.Portfolios
                .Include(p => p.Asset)
                .Where(p => p.UserId == user.Id)
                .ToListAsync();

            var recentOrders = await _context.Orders
                .Include(o => o.Asset)
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .ToListAsync();

            var assets = await _context.Assets
                .Where(a => a.IsActive)
                .ToListAsync();

            var model = new
            {
                User = new
                {
                    FullName = user.FullName,
                    Balance = user.Balance,
                    Email = user.Email,
                    MemberSince = user.CreatedAt
                },
                Portfolios = portfolios,
                RecentOrders = recentOrders,
                Assets = assets,
                TotalPortfolioValue = portfolios.Sum(p => p.CurrentValue),
                TotalProfitLoss = portfolios.Sum(p => p.ProfitLoss)
            };

            return View(model);
        }

        // GET: /Dashboard/Portfolio
        public async Task<IActionResult> Portfolio()
        {
            var userId = _userManager.GetUserId(User); // ← Pegar ID do usuário logado
            
            var portfolios = await _context.Portfolios
                .Include(p => p.Asset)
                .Where(p => p.UserId == userId)
                .ToListAsync();

            return View(portfolios);
        }

        // GET: /Dashboard/Orders
        public async Task<IActionResult> Orders()
        {
            var userId = _userManager.GetUserId(User);
            
            var orders = await _context.Orders
                .Include(o => o.Asset)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return View(orders);
        }

        // GET: /Dashboard/Profile
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
} 