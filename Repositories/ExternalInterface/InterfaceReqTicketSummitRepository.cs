using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.ExchRateSummit;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceReqTicketSummitRepository : IRepository<InterfaceReqHeaderTicketSummitModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceReqTicketSummitRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(InterfaceReqHeaderTicketSummitModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<InterfaceReqHeaderTicketSummitModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceReqHeaderTicketSummitModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceReqHeaderTicketSummitModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceReqHeaderTicketSummitModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceReqHeaderTicketSummitModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceReqHeaderTicketSummitModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
