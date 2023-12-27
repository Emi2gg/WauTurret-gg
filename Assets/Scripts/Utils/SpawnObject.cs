using System;
using UnityEngine;

namespace Magas.Utilities
{
    public record SpawnObject(GameObject Object, GameObject Parent, Vector3 Position, Quaternion Rotation,
        Action<GameObject> OnSpawned) : ISignal
    {
        internal object DestroyAfterDelay(float v)
        {
            throw new NotImplementedException();
        }
    }
}
