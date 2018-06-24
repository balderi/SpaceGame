using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Entities
{
    abstract class SpaceShip : Entity
    {
        protected float _tanV;
        protected Texture2D _weaponTex;

        public int MaxVelocity { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public int MaxHP { get; protected set; }
        public int CurrentHP { get; protected set; }

        public SpaceShip(int maxVelocity, int maxHP, Rectangle container, Texture2D texture, Vector2 position, Texture2D weaponTexture) : base(container, texture, position)
        {
            _weaponTex = weaponTexture;
            MaxVelocity = maxVelocity;
            _tanV = MaxVelocity / 10f;
            MaxHP = maxHP;
            Velocity = new Vector2(0f);
        }
    }
}
