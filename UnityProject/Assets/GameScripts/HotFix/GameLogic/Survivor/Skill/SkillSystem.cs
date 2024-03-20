using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SkillSystem : GameBase.System
    {
        private float _angle;
        public float Angle => _angle;

        public override void Awake()
        {
            base.Awake();
            Utility.Unity.AddUpdateListener(Update);
        }

        private void Update()
        {
            Vector2 mouse = Input.mousePosition;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 vectorToConvert = (mouse - center).normalized;
            // 计算向量的极坐标角度（以弧度为单位）
            float angleRadians = Mathf.Atan2(vectorToConvert.y, vectorToConvert.x);

            // 将弧度转换为角度
            _angle = angleRadians * Mathf.Rad2Deg;

            Log.Debug($"方向向量：{vectorToConvert}, 角度 ：{_angle}");
        }

        public void CreateSkill(string skillName)
        {
            SwordSkill swordSkill = new SwordSkill();
            swordSkill._Atk = 100;
        }
    }
}