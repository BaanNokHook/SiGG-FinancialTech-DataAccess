using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class BookRepository : IRepository<BookModel>
    {
        private readonly IUnitOfWork _uow;

        public BookRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(BookModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Book_910005_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "book_name_en", Value = model.book_name_en });
            parameter.Parameters.Add(new Field { Name = "book_name_th", Value = model.book_name_th });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("BookResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<BookModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(BookModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Book_910005_List_Proc";
            parameter.Parameters.Add(new Field { Name = "book_id", Value = model.book_id });
            parameter.ResultModelNames.Add("BookResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(BookModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Book_910005_List_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "book_name_en", Value = model.book_name_en });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("BookResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(BookModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Book_910005_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "book_id", Value = model.book_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("BookResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(BookModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Book_910005_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "book_id", Value = model.book_id });
            parameter.Parameters.Add(new Field { Name = "book_name_en", Value = model.book_name_en });
            parameter.Parameters.Add(new Field { Name = "book_name_th", Value = model.book_name_th });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("BookResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<BookModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
