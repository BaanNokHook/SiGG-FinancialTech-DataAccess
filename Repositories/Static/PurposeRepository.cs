using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class PurposeRepository : IRepository<PurposeModel>
    {
        private readonly IUnitOfWork _uow;

        public PurposeRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(PurposeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Purpose_830007_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "Purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "Description", Value = model.description });
            parameter.Parameters.Add(new Field { Name = "Display_flag", Value = model.display_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PurposeResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<PurposeModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(PurposeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Purpose_830007_List_Proc";

            parameter.Parameters.Add(new Field { Name = "Purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PurposeResultModel");
            parameter.Paging = model.paging;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(PurposeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Purpose_830007_List_Proc";

            parameter.Parameters.Add(new Field { Name = "Purpose", Value = "%" + model.purpose + "%" });
            parameter.Parameters.Add(new Field { Name = "Description", Value = "%" + model.description + "%" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PurposeResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(PurposeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Purpose_830007_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "Purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "Description", Value = model.description });
            parameter.Parameters.Add(new Field { Name = "Display_flag", Value = model.display_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = 'D' });
            parameter.ResultModelNames.Add("PurposeResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(PurposeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Purpose_830007_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "Purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "Description", Value = model.description });
            parameter.Parameters.Add(new Field { Name = "Display_flag", Value = model.display_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PurposeResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<PurposeModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
