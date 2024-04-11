using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public interface IUnit
    {
         T AddComponent<T>() where T : Component;
         T GetComponent<T>() where T : Component;

         IUnit SetName(string name);
         IUnit SetPos(Vector3 pos);
         IUnit SetLocalPos(Vector3 pos);

         void Destroy();
         IUnit Enable();
         IUnit Disable();
         IUnit SetLocalRotation(Quaternion quaternion);
         IUnit SetRotation(Quaternion quaternion);
         IUnit SetParent(Transform parent);
         IUnit SetParent(Unit parent);
         string GetName();

         IUnit SetLayer(LayerMask layerMask);
    }
}