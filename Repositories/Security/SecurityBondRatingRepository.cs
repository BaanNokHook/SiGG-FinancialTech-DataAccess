using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Security;

namespace GM.DataAccess.Repositories.Security
{
    public class SecurityBondRatingRepository:IRepository<SecurityBondRatingModel>
    {
        private readonly IUnitOfWork _uow;

        public SecurityBondRatingRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(SecurityBondRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Rating_810001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "assess_date", Value = model.assess_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<SecurityBondRatingModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(SecurityBondRatingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(SecurityBondRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Rating_810001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.ResultModelNames.Add("SecurityRatingResultModel");
            parameter.Paging = new PagingModel(){ PageNumber = 1, RecordPerPage = int.MaxValue};
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(SecurityBondRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Rating_810001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "assess_date", Value = model.assess_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(SecurityBondRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Rating_810001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "assess_date", Value = model.assess_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<SecurityBondRatingModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
