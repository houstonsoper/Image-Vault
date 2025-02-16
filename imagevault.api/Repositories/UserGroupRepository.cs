using imagevault.api.Contexts;
using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Repositories;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly ImageVaultDbContext _context;

    public UserGroupRepository(ImageVaultDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UserGroup>> GetAllUserGroups()
    {
        return await _context.UserGroups.ToListAsync();
    }
}