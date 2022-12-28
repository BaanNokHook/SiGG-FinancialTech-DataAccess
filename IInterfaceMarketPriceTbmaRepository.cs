using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceMarketPriceTbmaRepository
    {
        ResultWithModel Add(InterfaceMarketPriceTbmaDetailModel model);
        ResultWithModel Remove(InterfaceMarketPriceTbmaModel model);
        ResultWithModel Import(InterfaceMarketPriceTbmaModel model);
        ResultWithModel Check(InterfaceMarketPriceTbmaModel model);
    }
}
