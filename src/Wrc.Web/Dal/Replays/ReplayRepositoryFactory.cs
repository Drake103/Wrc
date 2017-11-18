using System;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayRepositoryFactory : IReplayRepositoryFactory
    {
        private readonly LightReplayProjectionToLightReplayTransformer _lightReplayProjectionToLightReplayTransformer;
        private readonly ReplayRecordToReplayTransformer _replayRecordToReplayTransformer;

        public ReplayRepositoryFactory(
            LightReplayProjectionToLightReplayTransformer lightReplayProjectionToLightReplayTransformer,
            ReplayRecordToReplayTransformer replayRecordToReplayTransformer)
        {
            _lightReplayProjectionToLightReplayTransformer = lightReplayProjectionToLightReplayTransformer;
            _replayRecordToReplayTransformer = replayRecordToReplayTransformer;
        }

        public IReplayRepository Create(IUnitOfWork unitOfWork)
        {
            if (unitOfWork is WrcContext wrcContext)
                return new ReplayRepository(
                    wrcContext,
                    _lightReplayProjectionToLightReplayTransformer,
                    _replayRecordToReplayTransformer);

            throw new ArgumentException(nameof(unitOfWork));
        }
    }
}