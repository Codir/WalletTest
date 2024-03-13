using ECS.Entities;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.EntityAuthoring
{
    public class MoveAuthoring : MonoBehaviour
    {
        public float2 MoveSpeed;
    }

    public class MoveBaker : Baker<MoveAuthoring>
    {
        public override void Bake(MoveAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            var component = new MoveComponent
            {
                MoveSpeed = authoring.MoveSpeed
            };
            AddComponent(entity, component);
        }
    }
}