using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.CounterParty;
using GM.DataAccess.Repositories.CounterPartyFund;
using GM.DataAccess.Repositories.Issuer;
using GM.DataAccess.UnitOfWork;
using GM.Model.CounterParty;

namespace GM.DataAccess.Repositories
{
    public class CounterPartyGroupRepository
    {
        public IRepository<CounterPartyExchRateModel> CounterPartyExchRate { get; }
        public IRepository<CounterPartyHaircutModel> CounterPartyHaircut { get; }
        public IRepository<CounterPartyIdentifyModel> CounterPartyIdentify { get; }
        public IRepository<CounterPartyMarginModel> CounterPartyMargin { get; }
        public IRepository<CounterPartyPaymentModel> CounterPartyPayment { get; }
        public IRepository<CounterPartyRatingModel> CounterPartyRating { get; }
        public IRepository<CounterPartyModel> CounterParty { get; }


        public IRepository<CounterPartyFundIdentifyModel> CounterPartyFundIdentify { get; }
        public IRepository<CounterPartyFundMarginModel> CounterPartyFundMargin { get; }
        public IRepository<CounterPartyFundPaymentModel> CounterPartyFundPayment { get; }
        public IRepository<CounterPartyFundModel> CounterPartyFund { get; }


        public IRepository<IssuerIdentifyModel> IssuerIdentify { get; }
        public IRepository<IssuerRatingModel> IssuerRating { get; }
        public IRepository<IssuerModel> Issuer { get; }


        public CounterPartyGroupRepository(IUnitOfWork uow)
        {
            CounterPartyExchRate = new CounterPartyExchangeRepository(uow);
            CounterPartyHaircut = new CounterPartyHaircutRepository(uow);
            CounterPartyIdentify = new CounterPartyIdentifyRepository(uow);
            CounterPartyMargin = new CounterPartyMarginRepository(uow);
            CounterPartyPayment = new CounterPartyPaymentRepository(uow);
            CounterPartyRating = new CounterPartyRatingRepository(uow);
            CounterParty = new CounterPartyRepository(uow);

            CounterPartyFundIdentify = new CounterPartyFundIdentifyRepository(uow);
            CounterPartyFundMargin = new CounterPartyFundMarginRepository(uow);
            CounterPartyFundPayment = new CounterPartyFundPaymentRepository(uow);
            CounterPartyFund = new CounterPartyFundRepository(uow);

            IssuerIdentify = new IssuerIdentifyRepository(uow);
            IssuerRating = new IssuerRatingRepository(uow);
            Issuer = new IssuerRepository(uow);
        }
    }
}
