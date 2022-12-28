using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceEquitySymbol;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceEquitySymbolRepository
    {
        ResultWithModel Add(ReqEquitySymbolList model);
        ResultWithModel Remove(ReqEquitySymbol model);
        ResultWithModel Import(ReqEquitySymbol model);
    }
}
