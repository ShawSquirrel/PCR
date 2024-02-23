using UnityEngine;

namespace GameLogic
{
    public class CharacterManager : MonoBehaviour
    {
        private void Awake()
        {
            InitName();

        }

        private void InitName()
        {
            name = "CharacterManager";
        }
    }
}