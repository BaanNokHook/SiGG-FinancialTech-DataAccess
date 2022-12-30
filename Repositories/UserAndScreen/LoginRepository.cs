using System;
using GM.CommonLibs.Common;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class LoginRepository : ILoginRepository<LoginModel>
    {
        private readonly IUnitOfWork _uow;

        public LoginRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Authenticate(LoginModel model)
        {
            try
            {
                Cryptography cryptography = new Cryptography();
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_User_910001_Login_Proc";
                parameter.Parameters.Add(new Field() { Name = "userID", Value = model.Username });
                parameter.Parameters.Add(new Field() { Name = "pass", Value = cryptography.Encrypt(model.Password.Trim(), true) });
                parameter.ResultModelNames.Add("LoginViewModels");
                return _uow.ExecDataProc(parameter);
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

        public ResultWithModel Online(LoginModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_User_910001_Online_Proc";
                parameter.Parameters.Add(new Field { Name = "userID", Value = model.Username });
                parameter.Parameters.Add(new Field { Name = "IPaddress", Value = model.IPaddress });
                parameter.Parameters.Add(new Field { Name = "sessionID", Value = model.sessionID });
                parameter.Parameters.Add(new Field { Name = "isKick", Value = model.isKick });
                parameter.ResultModelNames.Add("LoginModel");
                return _uow.ExecDataProc(parameter);
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

        public ResultWithModel Offline(LoginModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_User_910001_Offline_Proc";
                parameter.Parameters.Add(new Field { Name = "userID", Value = model.Username });
                parameter.Parameters.Add(new Field { Name = "IPaddress", Value = model.IPaddress });
                parameter.Parameters.Add(new Field { Name = "sessionID", Value = model.sessionID });
                parameter.ResultModelNames.Add("LoginModel");
                return _uow.ExecDataProc(parameter);
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

        public ResultWithModel IsStillOnline(LoginModel model)
        {
            try
            {
                ResultWithModel rwm = new ResultWithModel();
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.Parameters.Add(new Field { Name = "userID", Value = model.Username });
                parameter.Parameters.Add(new Field { Name = "IPaddress", Value = model.IPaddress });
                parameter.Parameters.Add(new Field { Name = "sessionID", Value = model.sessionID });
                rwm.Message = _uow.ExecScalar("SELECT DBO.IsStillOnline(@userID,@IPaddress,@sessionID)", parameter).ToString();
                return rwm;
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
    }
}
