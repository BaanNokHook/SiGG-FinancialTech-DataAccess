using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Issuer
{
    public class IssuerRatingRepository : IRepository<IssuerRatingModel>
    {
        private readonly IUnitOfWork _uow;
        public IssuerRatingRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(IssuerRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Rating_820002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<IssuerRatingModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(IssuerRatingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(IssuerRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Rating_820002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.ResultModelNames.Add("IssuerRatingResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(IssuerRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Rating_820002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(IssuerRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Rating_820002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<IssuerRatingModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
