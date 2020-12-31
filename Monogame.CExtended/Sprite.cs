using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.CExtended
{
    public class Sprite
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
        /// Sprite color
        /// </summary>
        public Color Color;

        /// <summary>
        /// Source rectangle in atlas
        /// </summary>
        public Rectangle SourceRectangle;

        /// <summary>
        /// Height of the Sprite in pixels, accounting for scale
        /// </summary>
        public float Height { get { return SourceRectangle.Height * Scale.Y; } }

        /// <summary>
        /// Height of the Sprite in pixels, accounting for scale
        /// </summary>
        public float Width  { get { return SourceRectangle.Width * Scale.X; } }

        /// <summary>
        /// Vector2 size of the sprite accounting for scale
        /// </summary>
        public Vector2 Size { get { return SourceRectangle.Size.ToVector2() * Scale; } }

        /// <summary>
        /// Origin point of the sprite, around which it is rotated, scaled, and positioned.
        /// </summary>
        public Vector2 Origin { get; private set; }

        /// <summary>
        /// Texture atlas from which the texture is drawn
        /// </summary>
        public Texture2D TextureAtlas;

        /// <summary>
        /// Sprite effects for drawing this sprite
        /// </summary>
        public SpriteEffects Effect = SpriteEffects.None;

        /// <summary>
        /// Alignment of the sprite image
        /// </summary>
        public SpriteAlignment Alignment = SpriteAlignment.TopLeft;


        /// <summary>
        /// Create a sprite
        /// </summary>
        /// <param name="TextureAtlas">Atlas of sprites</param>
        /// <param name="Scale">Scale of the sprite. Usually Vector2.One</param>
        /// <param name="Color">Color of the sprite. Color.White for no change</param>
        /// <param name="SourceRect">Source rectangle within the </param>
        /// <param name="Alignment">If the sprite's center is the top left or center</param>
        public Sprite(Texture2D TextureAtlas, Vector2 Scale, Color Color, Rectangle SourceRect, SpriteAlignment Alignment = SpriteAlignment.TopLeft)
        {
            this.TextureAtlas = TextureAtlas;
            this.Scale = Scale;
            this.Color = Color;
            this.SourceRectangle = SourceRect;
            this.Alignment = Alignment;

            this.Offset = Vector2.Zero;

            //If the sprite is top left aligned zero the origin and offset
            if (Alignment == SpriteAlignment.TopLeft) {
                this.Origin = Vector2.Zero;
            }
            else if(Alignment == SpriteAlignment.Center)    //check if center for future extensibility
            {
                //If the sprite is center then move the origin to the center
                this.Origin = Size * 0.5f;
            }
        }

    }

    public enum SpriteAlignment
    {
        TopLeft,
        Center
    }
}
