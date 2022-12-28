using System;
using GM.Model.Common;
using GM.Model.InterfaceRpReference;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceRpReferenceRepository
    {
        ResultWithModel Add(ReqRpReferenceList model);
        ResultWithModel Remove(DateTime asofDate, string settlementDay);
        ResultWithModel Import(DateTime asofDate, string settlementDay);
    }
}
