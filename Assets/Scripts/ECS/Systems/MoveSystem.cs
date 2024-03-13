using ECS.Entities;
using ECS.Systems.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ECS.Systems
{
    public partial class MoveSystem : SystemBase
    {
        [BurstCompile]
        protected override void OnUpdate()
        {
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");

            var query = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<MoveComponent>()
                .WithAllRW<LocalTransform>()
                .Build(this);

            new MoveJob
            {
                HorizontalAxis = horizontalAxis,
                VerticalAxis = verticalAxis,
                DeltaTime = SystemAPI.Time.DeltaTime
            }.Schedule(query);
        }
    }
}