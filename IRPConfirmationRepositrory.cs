using GM.Model.Common;
using GM.Model.PaymentProcess;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPConfirmationRepositrory : IRepository<RPConfirmationModel>
    {
        ResultWithModel Get(RPTransModel model);
    }
}
