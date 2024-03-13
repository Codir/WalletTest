using ECS.Entities;
using Unity.Entities;
using UnityEngine;

namespace ECS.EntityAuthoring
{
    public class CurrencyIncrementAuthoring : MonoBehaviour
    {
        public CurrencyType Type;
        public int Value;
    }

    public class CurrencyIncrementBaker : Baker<CurrencyIncrementAuthoring>
    {
        public override void Bake(CurrencyIncrementAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None);
            var component = new CurrencyIncrementComponent
            {
                Type = authoring.Type,
                Value = authoring.Value
            };
            AddComponent(entity, component);
        }
    }
}