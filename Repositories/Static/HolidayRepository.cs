using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class HolidayRepository : IRepository<HolidayModel>
    {
        private readonly IUnitOfWork _uow;

        public HolidayRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(HolidayModel entity)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<HolidayModel> models)
        {
            ResultWithModel rwm = new ResultWithModel();
            try
            {
                _uow.BeginTransaction();
                foreach (HolidayModel Holiday in models)
                {
                    BaseParameterModel parameter = new BaseParameterModel();
                    parameter.ProcedureName = "GM_Holiday_830004_Insert_Proc";
                    parameter.Parameters.Add(new Field { Name = "cur", Value = Holiday.cur });
                    parameter.Parameters.Add(new Field { Name = "holiday_date", Value = Holiday.holiday_date });
                    parameter.Parameters.Add(new Field { Name = "holiday_desc", Value = Holiday.holiday_desc });
                    parameter.Parameters.Add(new Field { Name = "recorded_by", Value = Holiday.create_by });
                    parameter.ResultModelNames.Add("HolidayResultModel");
                    rwm = _uow.ExecNonQueryProc(parameter);

                    if (!rwm.Success)
                    {
                        _uow.Rollback();
                        return rwm;
                    }
                }
                _uow.Commit();
            }
            catch (Exception ex)
            {
                rwm.Message = ex.Message;
                rwm.RefCode = 500;
            }
            return rwm;
        }

        public ResultWithModel Find(HolidayModel model)
        {
            BaseParameterModel parameter  = new BaseParameterModel();

            parameter.ProcedureName = "GM_Check_Is_Holiday_Proc";

            parameter.Parameters.Add(new Field { Name = "check_date", Value = model.holiday_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });

            parameter.ResultModelNames.Add("RpHolidayResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(HolidayModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Holiday_830004_List_Proc";

            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });

            if (!string.IsNullOrEmpty(model.year))
            {
                parameter.Parameters.Add(new Field { Name = "year", Value = model.year });
            }

            if (model.holiday_date.HasValue)
            {
                parameter.Parameters.Add(new Field { Name = "holiday_date", Value = model.holiday_date.Value });
            }

            parameter.ResultModelNames.Add("HolidayResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 366;

            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(HolidayModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_Holiday_830004_Update_Proc";
                parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
                parameter.Parameters.Add(new Field { Name = "holiday_date", Value = model.holiday_date });
                parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
                parameter.ResultModelNames.Add("HolidayResultModel");
                return _uow.ExecNonQueryProc(parameter);
            }
            catch (Exception ex)
            {
                return new ResultWithModel
                {
                    Message = ex.Message,
                    RefCode = 500

                };
            }
        }

        public ResultWithModel Update(HolidayModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_Holiday_830004_Update_Proc";
                parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
                parameter.Parameters.Add(new Field { Name = "holiday_date", Value = model.holiday_date });
                parameter.Parameters.Add(new Field { Name = "holiday_desc", Value = model.holiday_desc });
                parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
                parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });
                parameter.ResultModelNames.Add("HolidayResultModel");
                return _uow.ExecNonQueryProc(parameter);
            }
            catch (Exception ex)
            {
                return new ResultWithModel
                {
                    Message = ex.Message,
                    RefCode = 500
                };
            }
        }

        public ResultWithModel UpdateList(List<HolidayModel> model)
        {
            throw new NotImplementedException();
        }
    }
}

