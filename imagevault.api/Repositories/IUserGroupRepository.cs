using imagevault.api.Models;

namespace imagevault.api.Repositories;

public interface IUserGroupRepository
{
    Task<IEnumerable<UserGroup>> GetAllUserGroups();
}