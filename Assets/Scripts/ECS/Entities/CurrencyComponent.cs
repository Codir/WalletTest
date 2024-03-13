using Unity.Entities;

namespace ECS.Entities
{
    public enum CurrencyType
    {
        Coins,
        Crystals
    }

    public struct CurrencyComponent : IComponentData
    {
        public CurrencyType Type;
        public int Value;
    }
}