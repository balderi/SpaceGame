using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame.Entities
{
    abstract class Entity
    {
        protected Texture2D _texture;

        public float Rotation { get; protected set; }
        public Vector2 Origin { get; protected set; }
        public Vector2 Position { get; protected set; }
        public Rectangle Container { get; protected set; }

        public Entity(Rectangle container, Texture2D texture, Vector2 position)
        {
            Position = position;
            Container = container;
            _texture = texture;
            Rotation = 0f;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
