using Microsoft.AspNetCore.Mvc;
namespace asp_lab12.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserService _userService;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserService userService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _userService = userService;
    }
    public IActionResult Index()
    {
        _dbContext.Users.Add(new User("Bob", "Bob@gmail.com", 22));
        return View();
    }
    public async Task<IActionResult> AddUsers()
    {
        await _userService.CreateUserAsync("Alice", "alice@example.com", 30);
        await _userService.CreateUserAsync("John", "john@example.com", 28);
        await _userService.CreateUserAsync("Emma", "emma@example.com", 35);
        await _userService.CreateUserAsync("David", "david@example.com", 40);
        await _userService.CreateUserAsync("Sophia", "sophia@example.com", 26);

        return View();
    }
    public IActionResult ShowUsers()
    {
        var users = _dbContext.Users.ToList();
        
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, First Name: {user.FirstName}, Second Name: {user.SecondName}, Age: {user.Age}");
        }
        
        return View(users);
    }
    public IActionResult ShowCompanies()
    {
        var companies = _dbContext.Companies.ToList();
        return View(companies);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
}