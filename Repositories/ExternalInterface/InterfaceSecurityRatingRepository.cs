using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityRatingRepository : IRepository<ReqSecurityRatingList>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityRatingRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqSecurityRatingList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "GM_Security_Rating_Temp_810001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "assess_date", Value = model.assess_date });

            parameter.ResultModelNames.Add("RatingResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ReqSecurityRatingList> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ReqSecurityRatingList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ReqSecurityRatingList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ReqSecurityRatingList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ReqSecurityRatingList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ReqSecurityRatingList> models)
        {
            throw new NotImplementedException();
        }
    }
}
