using System;
using System.Collections.Generic;
using System.Text;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.GLProcess;

namespace GM.DataAccess.Repositories.GLProcess
{
   
    public class GLAdjustRepository : IRepository<GLAdjustModel>   
    {
        private readonly IUnitOfWork _uow;   

        public GLAdjustRepository(IUnitOfWork uow)     
        {
            _uow = uow;   
        }   

        public ResultWithModel Add(GLAdjustModel model)    
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "RP_GL_Adjust_540000_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "adjust_num", Value = model.adjust_num });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_port", Value = model.trans_port });
            parameter.Parameters.Add(new Field { Name = "posting_date", Value = model.posting_date });
            parameter.Parameters.Add(new Field { Name = "value_date", Value = model.value_date });
            parameter.Parameters.Add(new Field { Name = "entry_cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "adjust_type", Value = model.adjust_type });
            parameter.Parameters.Add(new Field { Name = "account_no", Value = model.account_no });
            parameter.Parameters.Add(new Field { Name = "dr_cr", Value = model.dr_cr });
            parameter.Parameters.Add(new Field { Name = "base_amount", Value = model.amount });
            parameter.Parameters.Add(new Field { Name = "cost_center", Value = model.cost_center });
            parameter.Parameters.Add(new Field { Name = "note", Value = model.note });
            parameter.Parameters.Add(new Field { Name = "sub_seq_num", Value = model.sub_seq_num });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("GLAdjustResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<GLAdjustModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(GLAdjustModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Adjust_540000_Detail_Proc";
            parameter.Parameters.Add(new Field { Name = "adjust_num", Value = model.adjust_num });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("GLAdjustResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(GLAdjustModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Adjust_540000_List_Proc";
            parameter.Parameters.Add(new Field { Name = "adjust_num", Value = model.adjust_num });
            parameter.Parameters.Add(new Field { Name = "trans_port ", Value = model.trans_port });
            parameter.Parameters.Add(new Field { Name = "entry_cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "posting_date", Value = model.posting_date });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("GLAdjustResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(GLAdjustModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Adjust_540000_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "adjust_num", Value = model.adjust_num });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("GLAdjustResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(GLAdjustModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<GLAdjustModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
