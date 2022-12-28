using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPCyberPayRepository
    {
        ResultWithModel Add(string transDate, string cur);
    }
}
