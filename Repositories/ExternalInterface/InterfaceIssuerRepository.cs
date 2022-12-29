using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceIssuer;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceIssuerRepository : IRepository<reqIssuerList>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceIssuerRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(reqIssuerList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Temp_820002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.Ref_code });
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "issuer_code", Value = model.issuer_code });
            parameter.Parameters.Add(new Field { Name = "issuer_name", Value = model.issuer_name });
            parameter.Parameters.Add(new Field { Name = "issuer_type_code", Value = model.issuer_type_code });
            parameter.Parameters.Add(new Field { Name = "currency_id", Value = model.currency_id });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "issuer_tname", Value = model.issuer_tname });
            parameter.Parameters.Add(new Field { Name = "listed_flg", Value = model.listed_flg });
            parameter.Parameters.Add(new Field { Name = "cntr_grp_code", Value = model.cntr_grp_code });
            parameter.Parameters.Add(new Field { Name = "country_code", Value = model.country_code });
            parameter.Parameters.Add(new Field { Name = "corp_type", Value = model.corp_type });
            parameter.Parameters.Add(new Field { Name = "open_date", Value = model.open_date });
            parameter.Parameters.Add(new Field { Name = "close_date", Value = model.close_date });
            parameter.Parameters.Add(new Field { Name = "reg_bus_tname", Value = model.reg_bus_tname });
            parameter.Parameters.Add(new Field { Name = "reg_bus_ename", Value = model.reg_bus_ename });
            parameter.Parameters.Add(new Field { Name = "juris_reg_date", Value = model.juris_reg_date });
            parameter.Parameters.Add(new Field { Name = "ktb_isic_code", Value = model.ktb_isic_code });
            parameter.Parameters.Add(new Field { Name = "title_id", Value = model.title_id });
            parameter.Parameters.Add(new Field { Name = "cif", Value = model.cif });
            parameter.Parameters.Add(new Field { Name = "cntr_id_linking", Value = model.cntr_id_linking });
            parameter.Parameters.Add(new Field { Name = "district_id", Value = model.district_id });
            parameter.Parameters.Add(new Field { Name = "province_id", Value = model.province_id });
            parameter.Parameters.Add(new Field { Name = "country_rating_flg", Value = model.country_rating_flg });
            parameter.ResultModelNames.Add("IssuerResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<reqIssuerList> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(reqIssuerList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(reqIssuerList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(reqIssuerList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(reqIssuerList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<reqIssuerList> models)
        {
            throw new NotImplementedException();
        }
    }
}
