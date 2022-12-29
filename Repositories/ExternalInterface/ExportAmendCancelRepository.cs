using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{

   public class ExportAmendCancelRepository : IExportAmendCancelRepository   
   {
      private readonly IUnitOfWork _uow;  
      public ExportAmendCancelRepository(IUnitOfWork uow)     
      {
           _uow = uow;  
      }  

      public ResultWithModel GetAmendCancelDaily(ExportAmendCancelDailyMailModel model)   
      {
            BaseParameterModel parameter = new BaseParameterModel();  

            parameter.ProcedureName = "RP_Report_AmendCancel_100003_Proc";    

            parameter.Parameters.Add(new Field { Name = "asofDate", Value = model.AsofDate });   
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = DBNull.Value });   
            parameter.Parameters.Add(new Field { Name = "cust_type", Value = DBNull.Value });   
            parameter.Parameters.Add(new Field { Name = "report_type", Value = DBNull.Value });      

            parameter.ResultModelNames.Add("AmendCancelDailyResultModel");   
            parameter.Paging = new PagingModel() { PageNumber = 1 , RecordPerPage = 999999 };    
            parameter.Orders = new List<OrderByModel>();   

            return _uow.ExecDataProc(parameter;=)
      }

      public ResultWithModel GetAmendCancelMonthly(ExportAmendCancelDailyMailModel model)  
      {
            BaseParameterModel parameter = new BaseParameterModel();   

            parameter.ProcedureName = "RP_Report_AmendCancel_Monthly_100003_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });   
            parameter.Parameters.Add(new Field { Name = "trans_monthly", Value = model.Monthly });   

            parameter.ResultModelNames.Add("AmendCancelMonthlyResultModel");  
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };   
            parameters.Orders = new List<OrderByModel>();   

            return _uow.ExecDataProc(parameter);   
      }

   }
}