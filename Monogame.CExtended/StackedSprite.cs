using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonoGame.CExtended
{
    public class StackedSprite
    {
        /// <summary>
        /// Scale of the sprite.
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        /// Offset the sprite when drawn
        /// </summary>
        public Vector2 Offset;

        /// <summary>
        /// Angle of the sprite
        /// </summary>
        public float Angle;

        /// <summary>
        /// Separation between vertical slices
        /// </summary>
        public float VerticalSeparation;
        
        /// <summary>
        /// Origin of the sprites
        /// </summary>
        public Vector2 Origin;

        /// <summary>
        /// Sprite color
        /// </summary>
        public Color Color;

        /// <summary>
        /// Texture atlas from which the texture is drawn
        /// </summary>
        public Texture2D TextureAtlas;

        /// <summary>
        /// Source rectangles for each sprite slice
        /// </summary>
        public Rectangle[] SourceRectangles;

        /// <summary>
        /// Sprite effects for drawing this sprite
        /// </summary>
        public SpriteEffects Effect = SpriteEffects.None;


        /// <summary>
        /// Create a sprite
        /// </summary>
        /// <param name="TextureAtlas">Atlas of sprites</param>
        /// <param name="Scale">Scale of the sprite. Usually Vector2.One</param>
        /// <param name="Color">Color of the sprite. Color.White for no change</param>
        /// <param name="SourceRects">Source rectangles within the </param>
        public StackedSprite(Texture2D TextureAtlas, Vector2 Scale, Color Color, Rectangle[] SourceRects)
        {
            this.TextureAtlas = TextureAtlas;
            this.Scale = Scale;
            this.Color = Color;
            this.SourceRectangles = SourceRects;
            this.Offset = Vector2.Zero;

            //Center of the sprites
            this.Origin = (SourceRects[0].Size).ToVector2() * 0.5f;
            
        }

    }
}
