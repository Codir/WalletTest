using ECS.Entities;
using ECS.Systems.Jobs;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace ECS.Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(PhysicsSystemGroup))]
    public partial struct PhysicsTriggerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CurrencyComponent>();
            state.RequireForUpdate<CurrencyCollectComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Dependency = new PhysicsTriggerCollectJob
            {
                CurrencyComponentGroup = SystemAPI.GetComponentLookup<CurrencyComponent>(),
                CurrencyCollectComponentGroup = SystemAPI.GetComponentLookup<CurrencyCollectComponent>(),
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);

            state.Dependency = new PhysicsTriggerCleanJob
            {
                CurrencyCleanComponentGroup = SystemAPI.GetComponentLookup<CurrencyCleanComponent>(),
                CurrencyCollectComponentGroup = SystemAPI.GetComponentLookup<CurrencyCollectComponent>(),
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);
        }
    }
}