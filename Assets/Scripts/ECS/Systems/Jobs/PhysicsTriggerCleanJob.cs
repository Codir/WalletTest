using ECS.Entities;
using MVC;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;

namespace ECS.Systems.Jobs
{
    public struct PhysicsTriggerCleanJob : ITriggerEventsJob
    {
        [ReadOnly] public ComponentLookup<CurrencyCleanComponent> CurrencyCleanComponentGroup;
        public ComponentLookup<CurrencyCollectComponent> CurrencyCollectComponentGroup;

        public void Execute(TriggerEvent triggerEvent)
        {
            if (!PhysicsTriggerExtensions.GetEntitiesFromTriggerEvent(triggerEvent, CurrencyCleanComponentGroup,
                    CurrencyCollectComponentGroup,
                    out var trigger,
                    out var observer,
                    out var currencyData,
                    out var currencyWallet)) return;

            if (!CurrencyCollectComponentGroup.HasComponent(currencyWallet)) return;

            CurrencyWalletStorage.Instance.Clear(@trigger.Type);
        }
    }
}