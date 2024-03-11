using System;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyController : MonoBehaviour
    {
        public Enum_EnemyType _Type;
        public GameObject _Pos;
        public EnemyData _Data;

        private Rigidbody2D _rigid;

        public Vector3 PlayerPos => Game._SurvivorGameRoot._Character.Pos;

        private void Awake()
        {
            _rigid = gameObject.AddComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 direct = (PlayerPos - transform.position).normalized;
            _rigid.velocity = direct * 1;
        }
    }
}