using asp_lab12;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(string firstName, string secondName, int age)
    {
        var user = new User(firstName, secondName, age);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> UpdateUserAsync(int id, string firstName, string secondName, int age)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            user.FirstName = firstName;
            user.SecondName = secondName;
            user.Age = age;
            await _context.SaveChangesAsync();
        }
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}