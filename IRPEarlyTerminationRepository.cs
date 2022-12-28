using System;
using System.Collections.Generic;
using System.Text;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPEarlyTerminationRepository
    {
        ResultWithModel Get(RPTransModel model);
        ResultWithModel GetDetail(RPTransModel model);
        ResultWithModel GetColl(RPTransModel model);
        ResultWithModel Update(RPTransModel model);
        ResultWithModel UpdateColl(DateTime? terminate_date, RPTransCollateralModel model);
        ResultWithModel Calculate(RPTransModel model);
        ResultWithModel Reject(RPTransModel model);
    }
}
