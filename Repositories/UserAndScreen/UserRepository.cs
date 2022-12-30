using System;
using System.Collections.Generic;
using GM.CommonLibs.Common;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly IUnitOfWork _uow;

        public UserRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(UserModel model)
        {
            Cryptography cryptography = new Cryptography();
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_User_910001_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "User_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "password", Value = model.password == null ? model.password : cryptography.Encrypt(model.password.Trim(), true) });
            parameter.Parameters.Add(new Field { Name = "ldap_user_flag", Value = model.ldap_user_flag });
            parameter.Parameters.Add(new Field { Name = "title_master_id", Value = model.title_master_id });
            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "user_eng_name", Value = model.user_eng_name });
            parameter.Parameters.Add(new Field { Name = "user_thai_name", Value = model.user_thai_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "costcenter_code", Value = model.costcenter_code });
            parameter.Parameters.Add(new Field { Name = "login_dt", Value = model.logout_dt });
            parameter.Parameters.Add(new Field { Name = "last_active_dt", Value = model.last_active_dt });
            parameter.Parameters.Add(new Field { Name = "logout_dt", Value = model.logout_dt });
            parameter.Parameters.Add(new Field { Name = "ip_address", Value = model.ip_address });
            parameter.Parameters.Add(new Field { Name = "desk_sub_group", Value = model.desk_sub_group });

            parameter.ResultModelNames.Add("UserResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<UserModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(UserModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_User_910001_List_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "user_thai_name", Value = model.user_thai_name });
            parameter.Parameters.Add(new Field { Name = "user_eng_name", Value = model.user_eng_name });
            parameter.Parameters.Add(new Field { Name = "ldap_user_flag", Value = model.ldap_user_flag });
            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_name", Value = model.desk_group_name });
            parameter.Parameters.Add(new Field { Name = "title_master_id", Value = model.title_master_id });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "costcenter_code", Value = model.costcenter_code });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });

            parameter.ResultModelNames.Add("UserResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(UserModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_User_910001_List_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "user_thai_name", Value = model.user_thai_name });
            parameter.Parameters.Add(new Field { Name = "user_eng_name", Value = model.user_eng_name });
            parameter.Parameters.Add(new Field { Name = "ldap_user_flag", Value = model.ldap_user_flag });
            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_name", Value = model.desk_group_name });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "title_master_id", Value = model.title_master_id });
            parameter.Parameters.Add(new Field { Name = "costcenter_code", Value = model.costcenter_code });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });

            parameter.ResultModelNames.Add("UserResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(UserModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_User_910001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("UserModels");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(UserModel model)
        {
            Cryptography cryptography = new Cryptography();
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_User_910001_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "User_id", Value = model.user_id });

            if (model.ldap_user_flag.HasValue && model.ldap_user_flag.Value)
            {
                parameter.Parameters.Add(new Field { Name = "password", Value = null });
            }
            else
            {
                parameter.Parameters.Add(new Field { Name = "password", Value = cryptography.Encrypt(model.password, true) });
            }

            parameter.Parameters.Add(new Field { Name = "ldap_user_flag", Value = model.ldap_user_flag });
            parameter.Parameters.Add(new Field { Name = "title_master_id", Value = model.title_master_id });
            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "user_eng_name", Value = model.user_eng_name });
            parameter.Parameters.Add(new Field { Name = "user_thai_name", Value = model.user_thai_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "costcenter_code", Value = model.costcenter_code });
            parameter.Parameters.Add(new Field { Name = "ip_address", Value = model.ip_address });
            parameter.Parameters.Add(new Field { Name = "desk_sub_group", Value = model.desk_sub_group });

            parameter.ResultModelNames.Add("UserResultModels");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<UserModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
