using Unity.Entities;
using Unity.Physics;

// ReSharper disable once CheckNamespace
public static class PhysicsTriggerExtensions
{
    public static bool GetEntitiesFromTriggerEvent<T, T2>(TriggerEvent triggerEvent,
        ComponentLookup<T> componentData, ComponentLookup<T2> componentData2,
        out T entity, out T2 entity2, out Entity entityA, out Entity entityB)
        where T : unmanaged, IComponentData
        where T2 : unmanaged, IComponentData
    {
        entity = new T();
        entity2 = new T2();
        entityA = entityB = new Entity();

        if (componentData.HasComponent(triggerEvent.EntityA) && componentData2.HasComponent(triggerEvent.EntityB))
        {
            entityB = triggerEvent.EntityB;
            entityA = triggerEvent.EntityA;
        }
        else if (componentData.HasComponent(triggerEvent.EntityB) &&
                 componentData2.HasComponent(triggerEvent.EntityA))
        {
            entityB = triggerEvent.EntityA;
            entityA = triggerEvent.EntityB;
        }
        else
            return false;

        entity = componentData[entityA];
        entity2 = componentData2[entityB];

        return true;
    }
}