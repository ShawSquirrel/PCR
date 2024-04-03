using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public interface IUnit
    {
         T AddComponent<T>() where T : Component;
         T GetComponent<T>() where T : Component;

         Transform SetName(string name);
         Transform SetPos(Vector3 pos);
         Transform SetLocalPos(Vector3 pos);

         void Destroy();
         void Enable();
         void Disable();
    }
}