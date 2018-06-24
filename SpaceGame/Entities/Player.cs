using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame.Entities
{
    class Player : SpaceShip
    {
        Viewport _view;
        GameWindow _window;
        List<Projectile> _firedProjectiles;
        float rTrigState, lTrigState;

        public Player(int maxVelocity, int maxHP, Rectangle container, Texture2D texture, Vector2 position, Viewport view, GameWindow window, Texture2D weaponTexture) : base(maxVelocity, maxHP, container, texture, position, weaponTexture)
        {
            _view = view;
            _window = window;
            _firedProjectiles = new List<Projectile>();
        }

        public void FireLeft(int fireTime)
        {
            Projectile p = new Projectile(new Vector2(0,0), fireTime, this, 10, 0, new Rectangle(), _weaponTex, Position);
            _firedProjectiles.Add(p);
        }
        public void FireRight(int fireTime)
        {
            Projectile p = new Projectile(new Vector2(0, -Container.Height), fireTime, this, 10, 0, new Rectangle(), _weaponTex, Position);
            _firedProjectiles.Add(p);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile p in _firedProjectiles)
                p.Draw(spriteBatch);
            spriteBatch.Draw(_texture, Position, null, Color.White, Rotation, Origin, 0.5f, SpriteEffects.None, 1f);
        }

        public override void Update(GameTime gameTime)
        {
            Container = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            Position = Velocity + Position;
            Origin = new Vector2(Container.Width / 2, Container.Height / 2);

            GamePadState padState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular);
            Vector2 leftStick = padState.ThumbSticks.Left;
            Vector2 rightStick = padState.ThumbSticks.Right;


            Vector2 v = Velocity;
            if(v.X < MaxVelocity && v.X > -MaxVelocity)
                v.X += leftStick.X;
            if (v.Y < MaxVelocity && v.Y > -MaxVelocity)
                v.Y += -leftStick.Y;

            Velocity = v;

            if (rightStick.LengthSquared() > 0.1f)
                Rotation = (float)Math.Atan2(-rightStick.Y, rightStick.X);

            if (padState.Triggers.Right > 0.1f && rTrigState < 0.1f)
                FireRight(gameTime.TotalGameTime.Milliseconds);

            if (padState.Triggers.Left > 0.1f && lTrigState < 0.1f)
                FireLeft(gameTime.TotalGameTime.Milliseconds);

            else if(Velocity != Vector2.Zero)
            {
                v.X = v.X -= 0.01f * v.X;
                v.Y = v.Y -= 0.01f * v.Y;

                Velocity = v;
            }

            var ProjList = _firedProjectiles.ToList();

            foreach (Projectile p in ProjList)
            {
                if (gameTime.TotalGameTime.Milliseconds - p.FireTime > 1000)
                    _firedProjectiles.Remove(p);
                p.Update(gameTime);
            }

            rTrigState = padState.Triggers.Right;
            lTrigState = padState.Triggers.Left;
        }
    }
}
