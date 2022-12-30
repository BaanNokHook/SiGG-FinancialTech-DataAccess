using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.Security;
using GM.DataAccess.Repositories.Static;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Security;
using GM.Model.Static;

namespace GM.DataAccess.Repositories
{
    public class StaticRepository
    {
        public IRepository<HolidayModel> Holiday { get; }
        public IRepository<PaymentMethodModel> PaymentMethod { get; }
        public ITestConnectRepository<TestConnectModel> TestConnect { get; }
        public IRepository<TestPageModel> TestPage { get; }
        public IRepository<TransLeqModel> TransLeq { get; }
        public IRepository<DMSModel> DMS { get; }
        public IRepository<DWHModel> DWH { get; }
        public IBusinessDateRepository BusinessDate { get; }
        public IRepository<ConfigParameterModel> Config { get; }
        public IRepository<CountryModel> Country { get; }
        public IRepository<CurrencyModel> Currency { get; }
        public IRepository<CustodianModel> Custodian { get; }
        public IRepository<LogInOutModel> LogInOut { get; }
        public IRepository<SecurityModel> Security { get; }
        public IRepository<SecurityGuarantorModel> SecurityGuarantor { get; }
        public IRepository<SecurityBondRatingModel> SecurityBondRating { get; }
        public IRepository<SecurityEventModel> SecurityEvent { get; }
        public IRepository<SecurityAdditionalCodeModel> SecurityAdditionalCode { get; }
        public IRepository<InitialMarginModel> InitialMargin { get; }
        public IRepository<PurposeModel> Purpose { get; }
        public IRepository<UserSignNameModel> UserSignName { get; }

        public StaticRepository(IUnitOfWork uow)
        {
            Holiday = new HolidayRepository(uow);
            PaymentMethod = new PaymentMethodRepository(uow);
            TestConnect = new TestConnectRepository(uow);
            TestPage = new TestPageRepository(uow);
            TransLeq = new TransLeqRepository(uow);
            DMS = new ViewDMSRepository(uow);
            DWH = new ViewDWHRepository(uow);
            BusinessDate = new BusinessDateRepository(uow);
            Config = new ConfigRepository(uow);
            Country = new CountryRepository(uow);
            Currency = new CurrencyRepository(uow);
            Custodian = new CustodianRepository(uow);
            LogInOut = new LogInOutRepository(uow);
            Security = new SecurityRepository(uow);
            SecurityGuarantor = new SecurityGuarantorRepository(uow);
            SecurityBondRating = new SecurityBondRatingRepository(uow);
            SecurityEvent = new SecurityEventRepository(uow);
            SecurityAdditionalCode = new SecurityAdditionalCodeRepository(uow);
            InitialMargin = new InitialMarginRepository(uow);
            Purpose = new PurposeRepository(uow);
            UserSignName = new UserSignNameRepository(uow);
        }
    }
}
