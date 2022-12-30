using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class CustodianRepository : IRepository<CustodianModel>
    {
        private readonly IUnitOfWork _uow;

        public CustodianRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CustodianModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Custodian_830005_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "custodian_code", Value = model.custodian_code != null ? model.custodian_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "custodian_shortname", Value = model.custodian_shortname != null ? model.custodian_shortname.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "custodian_name", Value = model.custodian_name != null ? model.custodian_name.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "contact", Value = model.contact != null ? model.contact.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address1", Value = model.address1 != null ? model.address1.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address2", Value = model.address2 != null ? model.address2.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address3", Value = model.address3 != null ? model.address3.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address4", Value = model.address4 != null ? model.address4.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no != null ? model.tel_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "fax_no", Value = model.fax_no != null ? model.fax_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "sa_acc_no", Value = model.sa_acc_no != null ? model.sa_acc_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "ca_acc_no", Value = model.ca_acc_no != null ? model.ca_acc_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "swift_code", Value = model.swift_code != null ? model.swift_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "province_id", Value = model.province_id != null ? model.province_id : null });
            parameter.Parameters.Add(new Field { Name = "district_id", Value = model.district_id != null ? model.district_id : null });
            parameter.Parameters.Add(new Field { Name = "sub_district_id", Value = model.sub_district_id != null ? model.sub_district_id : null });
            parameter.Parameters.Add(new Field { Name = "post_code", Value = model.post_code != null ? model.post_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("CustodianResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<CustodianModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CustodianModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Custodian_830005_List_Proc";
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.ResultModelNames.Add("CustodianResultModel");
            parameter.Paging = model.paging;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(CustodianModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Custodian_830005_List_Proc";
            parameter.Parameters.Add(new Field { Name = "custodian_code", Value = model.custodian_code });
            parameter.Parameters.Add(new Field { Name = "custodian_shortname", Value = model.custodian_shortname });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("CustodianResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CustodianModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Custodian_830005_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("CustodianResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CustodianModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Custodian_830005_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "custodian_code", Value = model.custodian_code != null ? model.custodian_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "custodian_shortname", Value = model.custodian_shortname != null ? model.custodian_shortname.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "custodian_name", Value = model.custodian_name != null ? model.custodian_name.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "contact", Value = model.contact != null ? model.contact.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address1", Value = model.address1 != null ? model.address1.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address2", Value = model.address2 != null ? model.address2.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address3", Value = model.address3 != null ? model.address3.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "address4", Value = model.address4 != null ? model.address4.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no != null ? model.tel_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "fax_no", Value = model.fax_no != null ? model.fax_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "sa_acc_no", Value = model.sa_acc_no != null ? model.sa_acc_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "ca_acc_no", Value = model.ca_acc_no != null ? model.ca_acc_no.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "swift_code", Value = model.swift_code != null ? model.swift_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "province_id", Value = model.province_id != null ? model.province_id : null });
            parameter.Parameters.Add(new Field { Name = "district_id", Value = model.district_id != null ? model.district_id : null });
            parameter.Parameters.Add(new Field { Name = "sub_district_id", Value = model.sub_district_id != null ? model.sub_district_id : null });
            parameter.Parameters.Add(new Field { Name = "post_code", Value = model.post_code != null ? model.post_code.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("CustodianResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CustodianModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
