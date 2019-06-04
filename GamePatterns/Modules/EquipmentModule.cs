using GamePatterns.Messages;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GamePatterns.Modules
{
    public interface IEquipmentModule : IGameObjectModule
    {
        Action<ItemChangedMessage> OnEquip { get; set; }
        Action<ItemChangedMessage> OnUnequip { get; set; }
        List<IGameObject> GameObjects { get; set; }
        void Equip(IGameObject obj);
        void Unequip(IGameObject obj);
    }

    public class EquipmentModule : IEquipmentModule
    {
        public List<IGameObject> GameObjects { get; set; }
        public Action<ItemChangedMessage> OnEquip { get; set; }
        public Action<ItemChangedMessage> OnUnequip { get; set; }

        public EquipmentModule()
        {
            GameObjects = new List<IGameObject>();
        }

        public void Equip(IGameObject obj)
        {
            if (!GameObjects.Contains(obj))
            {
                GameObjects.Add(obj);
                if (OnEquip != null) OnEquip.Invoke(new ItemChangedMessage(obj));
            }
        }

        public void Unequip(IGameObject obj)
        {
            if (GameObjects.Contains(obj))
            {
                GameObjects.Remove(obj);
                if (OnUnequip != null) OnUnequip.Invoke(new ItemChangedMessage(obj));
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
