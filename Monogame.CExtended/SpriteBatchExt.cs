using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGame.CExtended
{
    public static class SpriteBatchExt
    {
        /// <summary>
        /// Draw a sprite at a position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        public static void Draw(this SpriteBatch sb, Sprite sprite, Vector2 position)
        {
            sb.Draw(sprite.TextureAtlas, position + sprite.Offset, sprite.SourceRectangle, sprite.Color, sprite.Angle, sprite.Origin, sprite.Scale, sprite.Effect, 0);
        }

        /// <summary>
        /// Draw a sprite at position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        /// <param name="col">Color of the sprite</param>
        public static void Draw(this SpriteBatch sb, Sprite sprite, Vector2 position, float Angle)
        {
            sb.Draw(sprite.TextureAtlas, position + sprite.Offset, sprite.SourceRectangle, sprite.Color, Angle, sprite.Origin, sprite.Scale, sprite.Effect, 0);
        }

        /// <summary>
        /// Draw a sprite at position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        /// <param name="col">Color of the sprite</param>
        /// <param name="Angle">Rotation angle to draw the sprite</param>
        /// <param name="Scale">Scale of the sprite</param>
        public static void Draw(this SpriteBatch sb, Sprite sprite, Vector2 position, float Angle, Color col, Vector2 Scale)
        {
            sb.Draw(sprite.TextureAtlas, position, sprite.SourceRectangle, col, Angle, sprite.Origin, sprite.Scale, sprite.Effect, 0);
        }

        /// <summary>
        /// Draw a stacked sprite at a position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        public static void Draw(this SpriteBatch sb, StackedSprite sprite, Vector2 position)
        {
            for(int i = 0; i < sprite.SourceRectangles.Length; i++)
            {
                sb.Draw(sprite.TextureAtlas, position + sprite.Offset, sprite.SourceRectangles[i], sprite.Color, sprite.Angle, sprite.Origin, sprite.Scale, sprite.Effect, 0);
                position -= new Vector2(0, sprite.VerticalSeparation);
            }
        }

        /// <summary>
        /// Draw a stacked sprite at a position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        public static void Draw(this SpriteBatch sb, StackedSprite sprite, Vector2 position, float angle)
        {
            for (int i = 0; i < sprite.SourceRectangles.Length; i++)
            {
                sb.Draw(sprite.TextureAtlas, position + sprite.Offset, sprite.SourceRectangles[i], sprite.Color, angle, sprite.Origin, sprite.Scale, sprite.Effect, 0);
                position -= new Vector2(0, sprite.VerticalSeparation);
            }
        }

        /// <summary>
        /// Draw a stacked sprite at a position
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="sprite">Sprite</param>
        /// <param name="position">Position to draw sprite at</param>
        public static void Draw(this SpriteBatch sb, StackedSprite sprite, Vector2 position, float angle, Color col, Vector2 scale)
        {
            for (int i = 0; i < sprite.SourceRectangles.Length; i++)
            {
                sb.Draw(sprite.TextureAtlas, position + sprite.Offset, sprite.SourceRectangles[i], col, angle, sprite.Origin, scale, sprite.Effect, 0);
                position -= new Vector2(0, sprite.VerticalSeparation);
            }
        }
    }
}
