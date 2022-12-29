using System;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceEodReconcile;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceEodReconcileRepository : IInterfaceEodReconcileRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceEodReconcileRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel AddPTI(DateTime asofDate, ReqEodReconcilePti model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_pti_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "filename", Value = model.filename });
            parameter.Parameters.Add(new Field { Name = "trans_date", Value = model.trans_date });
            parameter.Parameters.Add(new Field { Name = "matched_id", Value = model.matched_id });
            parameter.Parameters.Add(new Field { Name = "mt", Value = model.mt });
            parameter.Parameters.Add(new Field { Name = "status", Value = model.status });
            parameter.Parameters.Add(new Field { Name = "counter_party_bic", Value = model.counter_party_bic });
            parameter.Parameters.Add(new Field { Name = "delv_acct", Value = model.delv_acct });
            parameter.Parameters.Add(new Field { Name = "security_symbol", Value = model.security_symbol });
            parameter.Parameters.Add(new Field { Name = "isin_code", Value = model.isin_code });
            parameter.Parameters.Add(new Field { Name = "face_amt", Value = model.face_amt });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "volume", Value = model.volume });
            parameter.Parameters.Add(new Field { Name = "create_time", Value = model.create_time });
            parameter.Parameters.Add(new Field { Name = "settle_date", Value = model.settle_date });
            parameter.Parameters.Add(new Field { Name = "sender_ref", Value = model.sender_ref });
            parameter.Parameters.Add(new Field { Name = "bt", Value = model.bt });
            parameter.Parameters.Add(new Field { Name = "error", Value = model.error });
            parameter.Parameters.Add(new Field { Name = "count_sender_ref", Value = model.count_sender_ref });
            parameter.Parameters.Add(new Field { Name = "recv_acct", Value = model.recv_acct });
            parameter.Parameters.Add(new Field { Name = "cash_acct", Value = model.cash_acct });
            parameter.Parameters.Add(new Field { Name = "settle_amt", Value = model.settle_amt });
            parameter.Parameters.Add(new Field { Name = "currency2", Value = model.currency2 });
            parameter.Parameters.Add(new Field { Name = "channel", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "time", Value = model.time });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel RemovePTI(DateTime asofDate, string recordedBy)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_pti_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = recordedBy });

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddBahtnet(DateTime asofDate, ReqEodReconcileBahtnet model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_bahtnet_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "filename", Value = model.filename });
            parameter.Parameters.Add(new Field { Name = "bn_trans_id", Value = model.bn_trans_id });
            parameter.Parameters.Add(new Field { Name = "sender_ref", Value = model.sender_ref });
            parameter.Parameters.Add(new Field { Name = "mt", Value = model.mt });
            parameter.Parameters.Add(new Field { Name = "bt", Value = model.bt });
            parameter.Parameters.Add(new Field { Name = "dr_bic", Value = model.dr_bic });
            parameter.Parameters.Add(new Field { Name = "dr_acc", Value = model.dr_acc });
            parameter.Parameters.Add(new Field { Name = "cr_bic", Value = model.cr_bic });
            parameter.Parameters.Add(new Field { Name = "cr_acc", Value = model.cr_acc });
            parameter.Parameters.Add(new Field { Name = "dr_amt", Value = model.dr_amt });
            parameter.Parameters.Add(new Field { Name = "cr_amt", Value = model.cr_amt });
            parameter.Parameters.Add(new Field { Name = "status", Value = model.status });
            parameter.Parameters.Add(new Field { Name = "error", Value = model.error });
            parameter.Parameters.Add(new Field { Name = "time", Value = model.time });
            parameter.Parameters.Add(new Field { Name = "ch", Value = model.ch });
            parameter.Parameters.Add(new Field { Name = "transmission_type", Value = model.transmission_type });
            parameter.Parameters.Add(new Field { Name = "value_date", Value = model.value_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel RemoveBahtnet(DateTime asofDate, string recordedBy)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_bahtnet_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = recordedBy });

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Get(DateTime asofDate)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.ResultModelNames.Add("RPEodReconcileResultModel");
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Add(RPEodReconcileModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_EOD_Reconcile_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "TRANS_EOD_NO", Value = model.TRANS_EOD_NO });
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = model.ASOF_DATE });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_TRADE_TOTAL", Value = model.BILATERAL_TRADE_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_TRADE_VERIFY", Value = model.BILATERAL_TRADE_VERIFY });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_TRADE_PENDING", Value = model.BILATERAL_TRADE_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_TRADE_REMARK", Value = model.BILATERAL_TRADE_REMARK });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_DVP_TOTAL", Value = model.BILATERAL_SATTLEMENT_DVP_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_DVP_PTI", Value = model.BILATERAL_SATTLEMENT_DVP_PTI });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_DVP_PENDING", Value = model.BILATERAL_SATTLEMENT_DVP_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_DVP_REMARK", Value = model.BILATERAL_SATTLEMENT_DVP_REMARK });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_RVP_TOTAL", Value = model.BILATERAL_SATTLEMENT_RVP_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_RVP_PTI", Value = model.BILATERAL_SATTLEMENT_RVP_PTI });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_RVP_PENDING", Value = model.BILATERAL_SATTLEMENT_RVP_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_RVP_REMARK", Value = model.BILATERAL_SATTLEMENT_RVP_REMARK });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_MT202_TOTAL", Value = model.BILATERAL_SATTLEMENT_MT202_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_MT202_BAHTNET", Value = model.BILATERAL_SATTLEMENT_MT202_BAHTNET });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_MT202_PENDING", Value = model.BILATERAL_SATTLEMENT_MT202_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_MT202_REMARK", Value = model.BILATERAL_SATTLEMENT_MT202_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_TRADE_TOTAL", Value = model.PRIVATE_TRADE_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_TRADE_VERIFY", Value = model.PRIVATE_TRADE_VERIFY });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_TRADE_PENDING", Value = model.PRIVATE_TRADE_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_TRADE_REMARK", Value = model.PRIVATE_TRADE_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DVP_TOTAL", Value = model.PRIVATE_SATTLEMENT_DVP_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DVP_PTI", Value = model.PRIVATE_SATTLEMENT_DVP_PTI });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DVP_PENDING", Value = model.PRIVATE_SATTLEMENT_DVP_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DVP_REMARK", Value = model.PRIVATE_SATTLEMENT_DVP_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RVP_TOTAL", Value = model.PRIVATE_SATTLEMENT_RVP_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RVP_PTI", Value = model.PRIVATE_SATTLEMENT_RVP_PTI });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RVP_PENDING", Value = model.PRIVATE_SATTLEMENT_RVP_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RVP_REMARK", Value = model.PRIVATE_SATTLEMENT_RVP_REMARK });

            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DF_TOTAL", Value = model.PRIVATE_SATTLEMENT_DF_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DF_PTI", Value = model.PRIVATE_SATTLEMENT_DF_PTI });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DF_PENDING", Value = model.PRIVATE_SATTLEMENT_DF_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DF_REMARK", Value = model.PRIVATE_SATTLEMENT_DF_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RF_TOTAL", Value = model.PRIVATE_SATTLEMENT_RF_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RF_PTI", Value = model.PRIVATE_SATTLEMENT_RF_PTI });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RF_PENDING", Value = model.PRIVATE_SATTLEMENT_RF_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RF_REMARK", Value = model.PRIVATE_SATTLEMENT_RF_REMARK });

            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_MT103_TOTAL", Value = model.PRIVATE_SATTLEMENT_MT103_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_MT103_BAHTNET", Value = model.PRIVATE_SATTLEMENT_MT103_BAHTNET });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_MT103_PENDING", Value = model.PRIVATE_SATTLEMENT_MT103_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_MT103_REMARK", Value = model.PRIVATE_SATTLEMENT_MT103_REMARK });

            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_PAY_TOTAL", Value = model.BILATERAL_MARGIN_PAY_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_PAY_BAHTNET", Value = model.BILATERAL_MARGIN_PAY_BAHTNET });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_PAY_PENDING", Value = model.BILATERAL_MARGIN_PAY_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_PAY_REMARK", Value = model.BILATERAL_MARGIN_PAY_REMARK });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_RECEIVE_TOTAL", Value = model.BILATERAL_MARGIN_RECEIVE_TOTAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_RECEIVE_MANUAL", Value = model.BILATERAL_MARGIN_RECEIVE_MANUAL });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_RECEIVE_PENDING", Value = model.BILATERAL_MARGIN_RECEIVE_PENDING });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_RECEIVE_REMARK", Value = model.BILATERAL_MARGIN_RECEIVE_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_PAY_TOTAL", Value = model.PRIVATE_MARGIN_PAY_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_PAY_BAHTNET", Value = model.PRIVATE_MARGIN_PAY_BAHTNET });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_PAY_PENDING", Value = model.PRIVATE_MARGIN_PAY_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_PAY_REMARK", Value = model.PRIVATE_MARGIN_PAY_REMARK });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_RECEIVE_TOTAL", Value = model.PRIVATE_MARGIN_RECEIVE_TOTAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_RECEIVE_MANUAL", Value = model.PRIVATE_MARGIN_RECEIVE_MANUAL });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_RECEIVE_PENDING", Value = model.PRIVATE_MARGIN_RECEIVE_PENDING });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_RECEIVE_REMARK", Value = model.PRIVATE_MARGIN_RECEIVE_REMARK });
            parameter.Parameters.Add(new Field { Name = "RECORDED_BY", Value = model.CREATE_BY });
            parameter.ResultModelNames.Add("RPEodReconcileResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
