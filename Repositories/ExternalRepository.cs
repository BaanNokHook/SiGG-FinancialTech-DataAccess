using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.ExternalInterface;
using GM.DataAccess.UnitOfWork;
using GM.Model.ExternalInterface;
using GM.Model.ExternalInterface.ExchRateSummit;
using GM.Model.ExternalInterface.FloatingIndexSummit;
using GM.Model.ExternalInterface.InterfaceThorIndex;
using GM.Model.ExternalInterface.InterfaceThorRate;
using GM.Model.InterfaceIssuer;
using GM.Model.InterfaceSecurity;

namespace GM.DataAccess.Repositories
{
    public class ExternalRepository
    {
        #region InterfaceIssuer
        public IRepository<reqIssuerHeader> InterfaceIssuerHeaderReq { get; }
        public IRepository<resIssuerHeader> InterfaceIssuerHeaderRes { get; }
        public IRepository<reqIssuerList> InterfaceIssuer { get; }
        public IRepository<reqIssuer> InterfaceIssuerImport { get; }
        #endregion

        #region InterfaceSecurity
        public IRepository<ReqSecurityHeader> InterfaceSecurityReq { get; }
        public IRepository<ReqSecurityList> InterfaceSecurity { get; }
        public IRepository<ReqSecurityRatingList> InterfaceSecurityRating { get; }
        public IRepository<ReqCashFlowList> InterfaceSecurityCashFlow { get; }
        public IRepository<ReqSecurity> InterfaceSecurityImport { get; }
        public IRepository<resSecurityHeader> InterfaceSecurityRes { get; }
        #endregion

        public IInterfaceRpReferenceRepository InterfaceRpReference { get; }
        public IRepository<InterfaceDmsSftpModel> InterfaceDMSsftp { get; }
        public IInterfaceDWHRepository InterfaceDWHsftp { get; }

        public IRepository<InterfaceBondPledgeFitsModel> InterfaceBondPledgeFits { get; }
        public IRepository<ServiceInOutReqModel> ServiceInOutReq { get; }
        public IRepository<InterfaceCounterRateExRateReqModel> InterfaceCounterRateExRate { get; }
        public IRepository<InterfaceTrpFitsSftpModel> InterfaceTrpFitsSftp { get; }
        public IInterfaceMarketPriceRepository InterfaceMarketPrice { get; }
        public IInterfaceMarketPriceTbmaRepository InterfaceMarketPriceTbma { get; }
        public IInterfaceConfirmationRepository InterfaceConfirmation { get; }
        public IRepository<InterfaceReqExchRateHeaderSummitModel> InterfaceReqExchRateSummit { get; }
        public IRepository<InterfaceResExchRateFXSpotDetailModel> InterfaceResExchRateFXSpot { get; }
        //public IRepository<InterfaceReqHeaderTicketSummitModel> InterfaceReqHeaderTicketSummit { get; }
        public IRepository<InterfaceFloatingIndexSummitReqModel> InterfaceFloatingIndexSummit { get; }
        public IExportAmendCancelRepository ExportAmendCancel { get; }
        public IInterfaceFxRepository InterfaceFx { get; }
        public IInterfaceCheckingEodRepository InterfaceCheckingEod { get; }
        public IExportUserProfileRepository ExportUserProfile { get; }
        public IInterfaceEodReconcileRepository InterfaceEodReconcile { get; }
        public IRepository<InterfaceMidValuationRateExRateReqModel> InterfaceMidValuationRateExRate { get; }
        public IRepository<InterfaceNesSftpModel> InterfaceNes { get; }
        public IInterfaceNavPriceRepository InterfaceNavPrice { get; }
        public IInterfaceNavPriceEquityRepository InterfaceNavPriceEquity { get; }
        public IInterfaceEquitySymbolRepository InterfaceEquitySymbol { get; }
        public IRepository<InterfaceEquityPledgeModel> InterfaceEquityPledge { get; }

        public IRepository<InterfaceResRateHeaderThorRateModel> InterfaceThorRate { get; }
        public IRepository<ThorRateModel> ThorRate { get; }

        public IRepository<ThorIndexModel> InterfaceThorIndex { get; }

        public ExternalRepository(IUnitOfWork uow)
        {
            #region InterfaceIssuer
            InterfaceIssuerHeaderReq = new InterfaceIssuerReqRepository(uow);
            InterfaceIssuerHeaderRes = new InterfaceIssuerResRepository(uow);
            InterfaceIssuer = new InterfaceIssuerRepository(uow);
            InterfaceIssuerImport = new InterfaceIssuerImportRepository(uow);
            #endregion

            #region InterfaceSecurity
            InterfaceSecurityReq = new InterfaceSecurityReqRepository(uow);
            InterfaceSecurity = new InterfaceSecurityRepository(uow);
            InterfaceSecurityRating = new InterfaceSecurityRatingRepository(uow);
            InterfaceSecurityCashFlow = new InterfaceSecurityCashFlowRepository(uow);
            InterfaceSecurityImport = new InterfaceSecurityImportRepository(uow);
            InterfaceSecurityRes = new InterfaceSecurityResRepository(uow);
            #endregion

            InterfaceRpReference = new InterfaceRpReferenceRepository(uow);
            InterfaceDMSsftp = new InterfaceDMSRepository(uow);
            InterfaceDWHsftp = new InterfaceDWHRepository(uow);

            InterfaceBondPledgeFits = new InterfaceBondPledgeFitsRepository(uow);
            ServiceInOutReq = new ServiceInOutReqRepository(uow);
            InterfaceMarketPrice = new InterfaceMarketPriceRepository(uow);
            InterfaceMarketPriceTbma = new InterfaceMarketPriceTbmaRepository(uow);
            InterfaceCounterRateExRate = new InterfaceCounterRateExRateRepository(uow);
            InterfaceTrpFitsSftp = new InterfaceTrpFITSRepository(uow);
            InterfaceConfirmation = new InterfaceConfirmationRepository(uow);
            InterfaceFx = new InterfaceFxRepository(uow);

            InterfaceReqExchRateSummit = new InterfaceReqExchRateSummitRepository(uow);
            InterfaceResExchRateFXSpot = new InterfaceResExchRateFXSpotRepository(uow);
            //InterfaceReqHeaderTicketSummit = new InterfaceReqTicketSummitRepository(uow);
            InterfaceFloatingIndexSummit = new InterfaceFloatingIndexSummitRepository(uow);

            ExportAmendCancel = new ExportAmendCancelRepository(uow);
            InterfaceCheckingEod = new InterfaceCheckingEodRepository(uow);
            ExportUserProfile = new ExportUserProfileRepository(uow);
            InterfaceEodReconcile = new InterfaceEodReconcileRepository(uow);
            InterfaceMidValuationRateExRate = new InterfaceMidValuationRateExRateRepository(uow);
            InterfaceNes = new InterfaceNesRepository(uow);
            InterfaceNavPrice = new InterfaceNavPriceRepository(uow);
            InterfaceNavPriceEquity = new InterfaceNavPriceEquityRepository(uow);
            InterfaceEquitySymbol = new InterfaceEquitySymbolRepository(uow);
            InterfaceEquityPledge = new InterfaceEquityPledgeRepository(uow);

            InterfaceThorRate = new InterfaceThorRateRepository(uow);
            ThorRate = new ThorRateRepository(uow);

            InterfaceThorIndex = new ThorIndexRepository(uow);
        }
    }
}
