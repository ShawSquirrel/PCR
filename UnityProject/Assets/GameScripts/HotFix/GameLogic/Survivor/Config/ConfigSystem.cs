using System.Collections.Generic;
using GameConfig;
using TEngine;

namespace GameLogic.Survivor.Config
{
    public class ConfigSystem : GameBase.System
    {
        private Dictionary<string, ActorAttribute> _dict_ActorAttribute;

        public override void Awake()
        {
            base.Awake();
            LoadConfig();
        }

        public void LoadConfig()
        {
            var config = global::ConfigSystem.Instance.Tables.SActorAttribute.DataList;

            _dict_ActorAttribute = new Dictionary<string, ActorAttribute>();
            foreach (SActor2Attribute attribute in config)
            {
                ActorAttribute actorAttribute = new ActorAttribute
                                                {
                                                    _HP    = attribute.Hp,
                                                    _Atk   = attribute.Atk,
                                                    _Def   = attribute.Def,
                                                    _Speed = attribute.Speed
                                                };

                _dict_ActorAttribute.TryAdd(attribute.Name, actorAttribute);
            }
        }

        public ActorAttribute GetAttributeByName(string name)
        {
            ActorAttribute actorAttribute;
            if (_dict_ActorAttribute.TryGetValue(name, out actorAttribute))
            {
                return actorAttribute;
            }

            Log.Error($"没有这个类型的数据：{name}");
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _dict_ActorAttribute = null;
        }
    }
}