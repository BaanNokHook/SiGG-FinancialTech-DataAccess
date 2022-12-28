using System;
using GM.Model.Common;
using GM.Model.InterfaceNavPrice;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceNavPriceRepository
    {
        ResultWithModel Add(ReqNavPriceList model);
        ResultWithModel Remove(ReqNavPrice model);
        ResultWithModel Import(ReqNavPrice model);
    }
}
