using System;
using System.Collections.Generic;
using System.Text;
using GM.Model.Common;
using GM.Model.InterfaceEodReconcile;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceEodReconcileRepository
    {
        ResultWithModel AddPTI(DateTime asofDate, ReqEodReconcilePti model);
        ResultWithModel RemovePTI(DateTime asofDate, string recordedBy);
        ResultWithModel AddBahtnet(DateTime asofDate, ReqEodReconcileBahtnet model);
        ResultWithModel RemoveBahtnet(DateTime asofDate, string recordedBy);

        ResultWithModel Get(DateTime asofDate);
        ResultWithModel Add(RPEodReconcileModel model);
    }
}
