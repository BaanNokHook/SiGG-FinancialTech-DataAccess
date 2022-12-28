using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceMarketPriceRepository
    {
        ResultWithModel Get(InterfaceMarketPriceModel model);
        ResultWithModel Add(InterfaceMarketPriceDetailModel model);
        ResultWithModel Remove(InterfaceMarketPriceModel model);
        ResultWithModel Import(InterfaceMarketPriceModel model);
    }
}
