using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Entities
{
    class Projectile : Entity
    {
        protected float _tanV;
        
        public int FireTime { get; protected set; }
        public SpaceShip ParentShip { get; protected set; }
        public int MaxVelocity { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public int Damage { get; protected set; }

        public Projectile(Vector2 offset, int fireTime, SpaceShip parentShip, int maxVelocity, int damage, Rectangle container, Texture2D texture, Vector2 position) : base(container, texture, position)
        {
            ParentShip = parentShip;
            MaxVelocity = maxVelocity;
            Damage = damage;
            _tanV = 10f;
            Velocity = ParentShip.Velocity;
            Rotation = ParentShip.Rotation;
            Origin = ParentShip.Origin + offset;
            Vector2 v = Velocity;
            v.X += (float)Math.Cos(Rotation) * _tanV;
            v.Y += (float)Math.Sin(Rotation) * _tanV;
            Velocity = v;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, Rotation, Origin, 0.5f, SpriteEffects.None, 1f);
        }

        public override void Update(GameTime gameTime)
        {
            Container = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            Position = Velocity + Position;
            //Origin = new Vector2(Container.Width / 2, Container.Height / 2);
        }
    }
}
