using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
 
    public class  InterfaceConfirmationRepository : IInterfaceConfirmationRepository  
    {  
       private readonly IUnitOfWork _uow;  
       public InterfaceConfirmationRepository(IUnitOfWork uow)  
       {
            _uow = uow;
       }

       public ResultWithModel GetList(InterfaceCCMSearch model)   
       {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "RP-Interface_CCm_List_Proc";  
            parameter.ResultModelNames.Add("InterfaceConfirmationResultModel");
            parameter.Parameters.Add(new Field { Name = "search_date", Value = model.search_date });   
            parameter.Parameters.Add(new Field { Name = "search_trans_no", Value = model.search_trans_no });   
            parameter.Paging = model.paging;   
            return _uow.ExecDataProc(parameter);  
       }
ร
       public ResultWithModel AddLog(string refId, string transNo, string transTypeCode, string createBy)   
       {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "RP_Interface_CCM_LOg_Insert_Proc";   
            parameter.Parameters.Add(new Field { Name = "ref_id", Value = refId });   
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = transNo });       
            parameter.Parameters.Add(new Field { Name = "trans_type_code", Value = transTypeCode });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = createBy });
            parameter.ResultModelNames.Add("InterfaceConfirmationResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel GetSignName(string transNo, string createBy)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Confirmation_Sign_Name_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = transNo });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = createBy });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "T" });
            return _uow.ExecDataProc(parameter);
        }

    }
}