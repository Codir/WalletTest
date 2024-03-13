using ECS.Entities;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems.Jobs
{
    [BurstCompile]
    public partial struct MoveJob : IJobEntity
    {
        public float HorizontalAxis;
        public float VerticalAxis;
        public float DeltaTime;

        private void Execute(in MoveComponent componentData, ref LocalTransform transform)
        {
            var move = new float3
            {
                x = HorizontalAxis * componentData.MoveSpeed.x,
                z = VerticalAxis * componentData.MoveSpeed.y
            };

            transform.Position += move * DeltaTime;
        }
    }
}