using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.FloatingIndexSummit;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceFloatingIndexSummitRepository : IRepository<InterfaceFloatingIndexSummitReqModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceFloatingIndexSummitRepository(IUnitOfWork uow) => _uow = uow;

        public ResultWithModel Add(InterfaceFloatingIndexSummitReqModel model)
        {
            ResultWithModel rwm = new ResultWithModel();
            BaseParameterModel parameter = new BaseParameterModel();
            try
            {
                FloatingIndexEntity floatModel = model.FloatModel;

                try
                {
                    parameter.ProcedureName = "GM_Interface_Floating_Index_Summit_Insert_Temp_Proc";
                    parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
                    parameter.Parameters.Add(new Field { Name = "as_of_date", Value = floatModel.as_of_date });
                    parameter.Parameters.Add(new Field { Name = "curve_id", Value = floatModel.curve_id });
                    parameter.Parameters.Add(new Field { Name = "ccy", Value = floatModel.ccy });
                    parameter.Parameters.Add(new Field { Name = "index", Value = floatModel.index });

                    for (int i = 0; i < floatModel.money_market.Count; i++)
                    {
                        if (floatModel.money_market[i].tenor == "1D")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_1D", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_1D", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "2D")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_2D", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_2D", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "1W")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_1W", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_1W", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "1M")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_1M", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_1M", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "2M")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_2M", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_2M", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "3M")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_3M", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_3M", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "6M")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_6M", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_6M", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }

                        if (floatModel.money_market[i].tenor == "9M")
                        {
                            parameter.Parameters.Add(new Field { Name = "tenor_rate_9M", Value = floatModel.money_market[i].rate.ToString() });
                            parameter.Parameters.Add(new Field { Name = "spread_9M", Value = floatModel.money_market[i].spread.ToString() });
                            continue;
                        }
                    }
                    rwm = _uow.ExecNonQueryProc(parameter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Insert FloatingIndex() : " + ex.Message);
                }

                try
                {
                    for (int i = 0; i < floatModel.swap_spread.Count; i++)
                    {
                        parameter = new BaseParameterModel();
                        parameter.ProcedureName = "GM_Interface_Floating_Index_SwapSpread_Summit_Insert_Temp_Proc";
                        parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
                        parameter.Parameters.Add(new Field { Name = "as_of_date", Value = floatModel.as_of_date });
                        parameter.Parameters.Add(new Field { Name = "curve_id", Value = floatModel.curve_id });
                        parameter.Parameters.Add(new Field { Name = "ccy", Value = floatModel.ccy });
                        parameter.Parameters.Add(new Field { Name = "index", Value = floatModel.index });
                        parameter.Parameters.Add(new Field { Name = "tenor", Value = floatModel.swap_spread[i].tenor });
                        parameter.Parameters.Add(new Field { Name = "spread", Value = floatModel.swap_spread[i].spread.ToString() });
                        rwm = _uow.ExecNonQueryProc(parameter);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Insert FloatingIndex SwapSpread() : " + ex.Message);
                }

                try
                {
                    for (int i = 0; i < model.FloatModel.zero_rate.Count; i++)
                    {
                        parameter = new BaseParameterModel();
                        parameter.ProcedureName = "GM_Interface_Floating_Index_ZeroRate_Summit_Insert_Temp_Proc";
                        parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
                        parameter.Parameters.Add(new Field { Name = "as_of_date", Value = floatModel.as_of_date });
                        parameter.Parameters.Add(new Field { Name = "curve_id", Value = floatModel.curve_id });
                        parameter.Parameters.Add(new Field { Name = "ccy", Value = floatModel.ccy });
                        parameter.Parameters.Add(new Field { Name = "index", Value = floatModel.index });
                        parameter.Parameters.Add(new Field { Name = "date", Value = floatModel.zero_rate[i].date });
                        parameter.Parameters.Add(new Field { Name = "days", Value = floatModel.zero_rate[i].days.ToString() });
                        parameter.Parameters.Add(new Field { Name = "rate", Value = floatModel.zero_rate[i].rate });
                        parameter.Parameters.Add(new Field { Name = "discount", Value = floatModel.zero_rate[i].discount.ToString() });
                        parameter.ResultModelNames.Add("FloatingIndexZeroRrateSSMDModel");
                        rwm = _uow.ExecNonQueryProc(parameter);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Insert FloatingIndex ZeroRrate() : " + ex.Message);
                }

                return rwm;
            }
            catch (Exception ex)
            {
                rwm.Success = false;
                rwm.RefCode = 500;
                rwm.Message = ex.Message;
                return rwm;
            }
        }

        public ResultWithModel AddList(List<InterfaceFloatingIndexSummitReqModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceFloatingIndexSummitReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceFloatingIndexSummitReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceFloatingIndexSummitReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Interface_Floating_Index_Summit_Update_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.as_of_date });
            parameter.Parameters.Add(new Field { Name = "curve_id", Value = model.curve_id });
            parameter.Parameters.Add(new Field { Name = "ccy", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(InterfaceFloatingIndexSummitReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceFloatingIndexSummitReqModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
