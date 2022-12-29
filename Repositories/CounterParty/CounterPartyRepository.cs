using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{

   public class CounterPartyRepository : IRepository<CounterPartyModel>  
   {
      private readonly IUnitOfWork _uow;
      public CounterPartyRepository(IUnitOfWork uow)   
      {
            _uow = uow;   
      }  

      public ResultWithModel Add(CounterPartyModel model)  
      {
            BaseParameterModel parameter = new BaseParameterModel();    
            parameter.ProcedureName = "GM_Counter_Party_82001-Insert_Proc";   
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });   
            parameter.Parameters.Add(new Field { Name = "counter_party_shortname", Value = model.counter_party_shortname });     
            parameter.Parameters.Add(new Field { Name = "counter_party_name", Value = model.counter_party_name });  
            parameter.Parameters.Add(new Field { Name = "counter_party_thainame", Value = model.counter_party_thainame });
            parameter.Parameters.Add(new Field { Name = "title_name", Value = model.title_name });
            parameter.Parameters.Add(new Field { Name = "counter_party_type_code", Value = model.counter_party_type_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_group_id", Value = model.counter_party_group_id });
            parameter.Parameters.Add(new Field { Name = "cif_no", Value = model.cif_no });
            parameter.Parameters.Add(new Field { Name = "contact_person", Value = model.contact_person });
            parameter.Parameters.Add(new Field { Name = "contact_email", Value = model.contact_email });
            parameter.Parameters.Add(new Field { Name = "tax_identity_no", Value = model.tax_identity_no });
            parameter.Parameters.Add(new Field { Name = "address_line1", Value = model.address_line1 });
            parameter.Parameters.Add(new Field { Name = "address_line2", Value = model.address_line2 });
            parameter.Parameters.Add(new Field { Name = "address_line3", Value = model.address_line3 });
            parameter.Parameters.Add(new Field { Name = "address_line4", Value = model.address_line4 });
            parameter.Parameters.Add(new Field { Name = "province_id", Value = model.province_id });
            parameter.Parameters.Add(new Field { Name = "district_id", Value = model.district_id });
            parameter.Parameters.Add(new Field { Name = "sub_district_id", Value = model.sub_district_id });
            parameter.Parameters.Add(new Field { Name = "zipcode", Value = model.zipcode });
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no });
            parameter.Parameters.Add(new Field { Name = "fax_no", Value = model.fax_no });
            parameter.Parameters.Add(new Field { Name = "wht_tax_pay", Value = model.wht_tax_pay });
            parameter.Parameters.Add(new Field { Name = "wht_tax_rec", Value = model.wht_tax_rec });
            parameter.Parameters.Add(new Field { Name = "tbma_code", Value = model.tbma_code });
            parameter.Parameters.Add(new Field { Name = "bb_firm_acc_no", Value = model.bb_firm_acc_no });
            parameter.Parameters.Add(new Field { Name = "ao_id", Value = model.ao_id });
            parameter.Parameters.Add(new Field { Name = "bot_def_code", Value = model.bot_def_code });
            parameter.Parameters.Add(new Field { Name = "ktbisic_code", Value = model.ktbisic_code });
            parameter.Parameters.Add(new Field { Name = "open_date", Value = model.open_date });
            parameter.Parameters.Add(new Field { Name = "close_date", Value = model.close_date });
            parameter.Parameters.Add(new Field { Name = "signed_date", Value = model.signed_date });
            parameter.Parameters.Add(new Field { Name = "custodian_flag", Value = model.custodian_flag });
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "netting_flag", Value = model.netting_flag });
            parameter.Parameters.Add(new Field { Name = "verify_flag_fo", Value = model.verify_flag_fo });
            parameter.Parameters.Add(new Field { Name = "verify_flag_bo", Value = model.verify_flag_bo });
            parameter.Parameters.Add(new Field { Name = "default_flag", Value = model.default_flag });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "tax_examtion_flag", Value = model.tax_examtion_flag });
            parameter.Parameters.Add(new Field { Name = "tax_examtion_amt", Value = model.tax_examtion_amt });
            parameter.Parameters.Add(new Field { Name = "int_compound", Value = model.int_compound });
            parameter.Parameters.Add(new Field { Name = "fundtypeid", Value = model.fundtypeid });  

            ResultWithModel rwm = _uow.ExecNonQueryProc(parameter, "CounterPartyID", out var id);      
            if (rwm.Success)
            {
                  model.counter_party_id = Convert.ToInt32(id);   
                  rwm.Data = model;   
            }
            return rwm;   
      }  

      public ResultWithModel AddList(list<CounterPartyModel> models)   
      {
            throw new NotImplementedException();   
      }   

      public ResultWithModel Find(CounterPartyModel model)     
      {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_820001_List_Proc";   
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value  = model.counter_party_id });   
            parameter.ResultModelNames.Add("CounterPartyResultModel");  
            parameter.Paging.PageNumber = 1;  
            parameter.paging.RecordPerPage = 1;   
            return _uow.ExecDataProc(parameter);      
      }   

      public ResultWithModel Get(CounterPartyModel model)    
      {
            BaseParameterModel parameter = new BaseParameterModel();       
            parameter.ProcedureName = "GM_Counter_Party_82001_List_Proc";       
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });      
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });   
            parameter.Parameters.Add(new Field { Name = "counter_party_shortname", Value = model.counter_party_shortname });    
            parameter.Parameters.Add(new Field { Name = "counter_party_name", Value = model.counter_party_name });   
            parameter.Parameters.Add(new Field { Name = "counter_party_thainame", Value = model.counter_party_thainame });   
            parameter.Parameters.Add(new Field { Name = "counter_party_type_code", Value = model.counter_party_type_code });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no });
            parameter.ResultModelNames.Add("CounterPartyResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_820001_Update_Proc";
            #region Parameter
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_shortname", Value = model.counter_party_shortname });
            parameter.Parameters.Add(new Field { Name = "counter_party_name", Value = model.counter_party_name });
            parameter.Parameters.Add(new Field { Name = "counter_party_thainame", Value = model.counter_party_thainame });
            parameter.Parameters.Add(new Field { Name = "title_name", Value = model.title_name });
            parameter.Parameters.Add(new Field { Name = "counter_party_type_code", Value = model.counter_party_type_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_group_id", Value = model.counter_party_group_id });
            parameter.Parameters.Add(new Field { Name = "cif_no", Value = model.cif_no });
            parameter.Parameters.Add(new Field { Name = "contact_person", Value = model.contact_person });
            parameter.Parameters.Add(new Field { Name = "contact_email", Value = model.contact_email });
            parameter.Parameters.Add(new Field { Name = "tax_identity_no", Value = model.tax_identity_no });
            parameter.Parameters.Add(new Field { Name = "address_line1", Value = model.address_line1 });
            parameter.Parameters.Add(new Field { Name = "address_line2", Value = model.address_line2 });
            parameter.Parameters.Add(new Field { Name = "address_line3", Value = model.address_line3 });
            parameter.Parameters.Add(new Field { Name = "address_line4", Value = model.address_line4 });
            parameter.Parameters.Add(new Field { Name = "province_id", Value = model.province_id });
            parameter.Parameters.Add(new Field { Name = "district_id", Value = model.district_id });
            parameter.Parameters.Add(new Field { Name = "sub_district_id", Value = model.sub_district_id });
            parameter.Parameters.Add(new Field { Name = "zipcode", Value = model.zipcode });
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no });
            parameter.Parameters.Add(new Field { Name = "fax_no", Value = model.fax_no });
            parameter.Parameters.Add(new Field { Name = "wht_tax_pay", Value = model.wht_tax_pay });
            parameter.Parameters.Add(new Field { Name = "wht_tax_rec", Value = model.wht_tax_rec });
            parameter.Parameters.Add(new Field { Name = "tbma_code", Value = model.tbma_code });
            parameter.Parameters.Add(new Field { Name = "bb_firm_acc_no", Value = model.bb_firm_acc_no });
            parameter.Parameters.Add(new Field { Name = "ao_id", Value = model.ao_id });
            parameter.Parameters.Add(new Field { Name = "bot_def_code", Value = model.bot_def_code });
            parameter.Parameters.Add(new Field { Name = "ktbisic_code", Value = model.ktbisic_code });
            parameter.Parameters.Add(new Field { Name = "open_date", Value = model.open_date });
            parameter.Parameters.Add(new Field { Name = "close_date", Value = model.close_date });
            parameter.Parameters.Add(new Field { Name = "signed_date", Value = model.signed_date });
            parameter.Parameters.Add(new Field { Name = "custodian_flag", Value = model.custodian_flag });
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "netting_flag", Value = model.netting_flag });
            parameter.Parameters.Add(new Field { Name = "verify_flag_fo", Value = model.verify_flag_fo });
            parameter.Parameters.Add(new Field { Name = "verify_flag_bo", Value = model.verify_flag_bo });
            parameter.Parameters.Add(new Field { Name = "default_flag", Value = model.default_flag });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "tax_examtion_flag", Value = model.tax_examtion_flag });
            parameter.Parameters.Add(new Field { Name = "tax_examtion_amt", Value = model.tax_examtion_amt });
            parameter.Parameters.Add(new Field { Name = "int_compound", Value = model.int_compound });
            parameter.Parameters.Add(new Field { Name = "fundtypeid", Value = model.fundtypeid });
            #endregion

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyModel> models)
        {
            throw new NotImplementedException();
        }
    }
}