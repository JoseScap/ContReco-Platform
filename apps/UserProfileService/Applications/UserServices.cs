using Libs.SK.Domain.Dtos.Reponses;
using Libs.SK.Domain.Dtos.Requests;
using UPS.Domain.IServices;
using UPS.Infrastructure.Persistence;

namespace UPS.Applications
{
    public class UserServices : IUserServices
    {
        private readonly UpsDbContext _context;

        public UserServices(UpsDbContext context)
        {
            _context = context;
        }

        public async Task<UserCreationResponse> CreateUserAsync(UserCreationRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var userToAdd = request.AsUserEntity();
            var createdUser = await _context.Users.AddAsync(userToAdd);
            await _context.SaveChangesAsync();
            return userToAdd.AsCreationResponse();
        }
    }
}
