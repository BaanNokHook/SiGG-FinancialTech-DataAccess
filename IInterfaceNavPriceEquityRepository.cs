using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceNavPrice;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceNavPriceEquityRepository
    {
        ResultWithModel Add(InterfaceReqNavPriceModel reqModel, InterfaceResNavPriceListModel model);
        ResultWithModel Remove(InterfaceReqNavPriceModel model);
        ResultWithModel Import(InterfaceReqNavPriceModel model);
        ResultWithModel Check(InterfaceReqNavPriceModel model);
    }
}
