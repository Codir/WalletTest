using ECS.Entities;
using Unity.Entities;
using UnityEngine;

namespace ECS.EntityAuthoring
{
    public class CurrencyCollectAuthoring : MonoBehaviour
    {
    }

    public class CurrencyCollectBaker : Baker<CurrencyCollectAuthoring>
    {
        public override void Bake(CurrencyCollectAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<CurrencyCollectComponent>(entity);
        }
    }
}