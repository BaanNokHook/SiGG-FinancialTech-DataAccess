using System;
using System.Collections.Generic;
using System.Text;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IExportUserProfileRepository
    {
        ResultWithModel GetUserProfileMonthly(ExportUserProfileMonthlyMailModel model);
    }
}
