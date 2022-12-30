using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.UserAndScreen;
using GM.DataAccess.UnitOfWork;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories
{
    public class UserAndScreenRepository
    {
        public ILoginRepository<LoginModel> Login { get; }
        public IRepository<BookModel> Book { get; }
        public IRepository<DeskGroupModel> DeskGroup { get; }
        public IRepository<PagePermissionModel> PagePermission { get; }
        public IRepository<PolicyRateModel> PolicyRate { get; }
        public IRepository<RoleModel> Role { get; }
        public IRepository<RoleTaskModel> RoleTask { get; }
        public IRoleScreenRepository RoleScreen { get; }
        public IRepository<ScreenModel> Screen { get; }
        public IRepository<TraderModel> Trader { get; }
        public IRepository<TraderLimitModel> TraderLimit { get; }
        public IRepository<UserModel> User { get; }
        public IRepository<TraderLimitConfigModel> TraderLimitConfig { get; }

        public IRepository<UserModel> UserActive { get; }

        public IRepository<ActivityLogModel> UserActivityLog { get; }

        public UserAndScreenRepository(IUnitOfWork uow)
        {
            Login = new LoginRepository(uow);
            Book = new BookRepository(uow);
            DeskGroup = new DeskGroupRepository(uow);
            PagePermission = new PagePermissionRepository(uow);
            PolicyRate = new PolicyRateRepository(uow);
            Role = new RoleRepository(uow);
            RoleTask = new RoleTaskRepository(uow);
            RoleScreen = new RoleScreenRepository(uow);
            Screen = new ScreenRepository(uow);
            Trader = new TraderRepository(uow);
            TraderLimit = new TraderLimitRepository(uow);
            User = new UserRepository(uow);
            TraderLimitConfig = new TraderLimitConfigRepository(uow);
            UserActive = new UserActiveRepository(uow);
            UserActivityLog = new UserActivityLogRepository(uow);
        }
    }
}
