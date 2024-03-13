using Unity.Entities;

namespace ECS.Entities
{
    public struct CurrencyIncrementComponent : IComponentData
    {
        public CurrencyType Type;
        public int Value;
    }
}