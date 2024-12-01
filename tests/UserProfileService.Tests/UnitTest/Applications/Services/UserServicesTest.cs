using Libs.SK.Domain.Dtos.Requests;
using Libs.SK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedTesting.Extensions;
using UPS.Applications;
using UPS.Domain.IServices;
using UPS.Infrastructure.Persistence;

namespace UserProfileService.Tests.UnitTest.Applications.Services;

[TestFixture]
public class UserServices__CreateUserAsync__Tests
{
    private UpsDbContext _dbContext;
    private IUserServices _userServices;

    [SetUp]
    public void SetUp()
    {
        IServiceCollection collection = new ServiceCollection();
        collection.AddInMemoryDbContext<UpsDbContext>();
        collection.AddScoped<IUserServices, UserServices>();
        IServiceProvider provider = collection.BuildServiceProvider();
        _dbContext = provider.GetService<UpsDbContext>() ?? throw new Exception($"Something went wrong setting up testing services.");
        _userServices = provider.GetService<IUserServices>() ?? throw new Exception($"Something went wrong setting up testing services.");
    }

    [Test]
    public void CreateUserAsync__ShouldThrowException__IfEntityIsNull()
    {
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _userServices.CreateUserAsync(null));
    }

    [Test]
    public async Task CreateUserAsync__ShouldGoOk__WhenItIsCalledWithValidArgument()
    {
        var request = new UserCreationRequest(
            firstName: "Jane",
            lastName: "Doe",
            userName: "JaneDoeIsReal",
            email: "JaneDoe@exist.com",
            password: "SomethingSecret",
            birthday: DateTime.UtcNow
            );

        var createdUser = await _userServices.CreateUserAsync( request );

        var trackedUser = _dbContext.ChangeTracker.Entries<User>()
            .FirstOrDefault(x => x.Entity.UserName == request.UserName && x.Entity.Email == request.Email);

        Assert.NotNull(trackedUser);
        Assert.That(trackedUser.State, Is.EqualTo(EntityState.Unchanged));
    }
}
