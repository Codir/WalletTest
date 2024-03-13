using ECS.Entities;
using Unity.Entities;
using UnityEngine;

namespace ECS.EntityAuthoring
{
    public class CurrencyAuthoring : MonoBehaviour
    {
        public CurrencyType Type;
        public int Value;
    }

    public class CurrencyBaker : Baker<CurrencyAuthoring>
    {
        public override void Bake(CurrencyAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None);
            var component = new CurrencyComponent
            {
                Type = authoring.Type,
                Value = authoring.Value
            };
            AddComponent(entity, component);
        }
    }
}