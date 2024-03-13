using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Entities
{
    public struct MoveComponent : IComponentData
    {
        public float2 MoveSpeed;
    }
}