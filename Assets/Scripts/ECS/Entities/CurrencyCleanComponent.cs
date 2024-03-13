using Unity.Entities;

namespace ECS.Entities
{
    public struct CurrencyCleanComponent : IComponentData
    {
        public CurrencyType Type;
    }
}