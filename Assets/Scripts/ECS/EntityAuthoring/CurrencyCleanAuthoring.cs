using ECS.Entities;
using Unity.Entities;
using UnityEngine;

namespace ECS.EntityAuthoring
{
    public class CurrencyCleanAuthoring : MonoBehaviour
    {
        public CurrencyType Type;
    }

    public class CurrencyCleanBaker : Baker<CurrencyCleanAuthoring>
    {
        public override void Bake(CurrencyCleanAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None);
            var component = new CurrencyCleanComponent
            {
                Type = authoring.Type
            };
            AddComponent(entity, component);
        }
    }
}