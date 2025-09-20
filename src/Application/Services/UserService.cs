using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<User> GetUser(int id) => _repository.GetByIdAsync(id);
    public Task<IEnumerable<User>> GetUsers() => _repository.GetAllAsync();
    public Task<User> CreateUser(User user) => _repository.AddAsync(user);
    public Task<User> UpdateUser(User user) => _repository.UpdateAsync(user);
    public Task DeleteUser(int id) => _repository.DeleteAsync(id);
}