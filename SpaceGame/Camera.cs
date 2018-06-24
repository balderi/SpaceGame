﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Entity target)
        {
            var position = Matrix.CreateTranslation(
                -target.Position.X - target.Container.Width / 2,
                -target.Position.Y - target.Container.Height / 2,
                0);

            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}
