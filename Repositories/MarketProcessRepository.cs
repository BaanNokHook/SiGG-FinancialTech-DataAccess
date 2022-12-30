using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.MarketProcess;
using GM.DataAccess.UnitOfWork;
using GM.Model.MarketProcess;

namespace GM.DataAccess.Repositories
{
    public class MarketProcessRepository
    {
        public IRepository<ExchangeRateModel> ExchangeRate { get; }
        public IRepository<FloatingIndexModel> FloatingIndex { get; }
        public IRepository<RPReferenceModel> RPReference { get; }

        public MarketProcessRepository(IUnitOfWork uow)
        {
            ExchangeRate = new ExchangeRateRepository(uow);
            FloatingIndex = new FloatingIndexRepository(uow);
            RPReference = new RPReferenceRepository(uow);
        }
    }
}
