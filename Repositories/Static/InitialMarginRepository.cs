using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class InitialMarginRepository : IRepository<InitialMarginModel>
    {
        private readonly IUnitOfWork _uow;
        public InitialMarginRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InitialMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_InitialMargin_830006_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "DESCRIPTION", Value = model.DESCRIPTION });
            parameter.Parameters.Add(new Field { Name = "DESCRIPTION2", Value = model.DESCRIPTION2 });
            parameter.Parameters.Add(new Field { Name = "HAIRCUTMARGIN", Value = model.HAIRCUTMARGIN });
            parameter.Parameters.Add(new Field { Name = "VARIATIONMARGIN", Value = model.VARIATIONMARGIN });
            parameter.Parameters.Add(new Field { Name = "COUPONTYPE", Value = model.COUPONTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "SECURITYTYPE", Value = model.SECURITYTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "YearStart", Value = model.YearStart });
            parameter.Parameters.Add(new Field { Name = "YearEnd", Value = model.YearEnd });

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<InitialMarginModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InitialMarginModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InitialMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_InitialMargin_830006_List_Proc";

            parameter.Parameters.Add(new Field { Name = "ID", Value = model.ID });
            parameter.Parameters.Add(new Field { Name = "COUPONTYPE", Value = model.COUPONTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "SECURITYTYPE", Value = model.SECURITYTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "DESCRIPTION", Value = model.DESCRIPTION });

            parameter.ResultModelNames.Add("InitialMarginResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InitialMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_InitialMargin_830006_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "ID", Value = model.ID });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(InitialMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_InitialMargin_830006_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "ID", Value = model.ID });
            parameter.Parameters.Add(new Field { Name = "DESCRIPTION", Value = model.DESCRIPTION });
            parameter.Parameters.Add(new Field { Name = "DESCRIPTION2", Value = model.DESCRIPTION2 });
            parameter.Parameters.Add(new Field { Name = "HAIRCUTMARGIN", Value = model.HAIRCUTMARGIN });
            parameter.Parameters.Add(new Field { Name = "VARIATIONMARGIN", Value = model.VARIATIONMARGIN });
            parameter.Parameters.Add(new Field { Name = "COUPONTYPE", Value = model.COUPONTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "SECURITYTYPE", Value = model.SECURITYTYPE_ID });
            parameter.Parameters.Add(new Field { Name = "YearStart", Value = model.YearStart });
            parameter.Parameters.Add(new Field { Name = "YearEnd", Value = model.YearEnd });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("InitialMarginResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<InitialMarginModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
