using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.CExtended
{
    //TODO : Document
    public class NineSliceSprite
    {
        public Sprite Sprite;
        public SpriteBorders SpriteBorders;
        public Rectangle[] SubSpriteSourceBounds;
        
        public Vector2[] SubSpriteDestinationOffsets;
        public Vector2[] SubSpriteDestinationSize;

        public Vector2 NewSize;
        /// <summary>
        /// TODO: implement border scaling
        /// </summary>
        public float BorderScale = 1.0f;

        public NineSliceSprite(Sprite s, SpriteBorders b, Vector2 NewSize)
        {
            this.Sprite = s;
            this.NewSize = NewSize;
            this.SpriteBorders = b;

            int midHeight = (int)s.Height - b.Top - b.Bottom;
            int midWidth = (int)s.Width - b.Right - b.Left;

            SubSpriteSourceBounds = new Rectangle[9];
            SubSpriteDestinationOffsets = new Vector2[9];
            SubSpriteDestinationSize = new Vector2[9];

            //Absolute bounds in the texture of the sprite, accounting for the source rectangle of the original sprite
            SubSpriteSourceBounds[0] = new Rectangle(s.SourceRectangle.X, s.SourceRectangle.Y, b.Left, b.Top);
            SubSpriteSourceBounds[1] = new Rectangle(s.SourceRectangle.X + b.Left, s.SourceRectangle.Y, midWidth, b.Top);
            SubSpriteSourceBounds[2] = new Rectangle(s.SourceRectangle.X + s.SourceRectangle.Width - b.Right, s.SourceRectangle.Y, b.Right, b.Top);
            SubSpriteSourceBounds[3] = new Rectangle(s.SourceRectangle.X, s.SourceRectangle.Y + b.Top, b.Left, midHeight);
            SubSpriteSourceBounds[4] = new Rectangle(s.SourceRectangle.X + b.Left, s.SourceRectangle.Y + b.Top, midWidth, midHeight);
            SubSpriteSourceBounds[5] = new Rectangle(s.SourceRectangle.X + s.SourceRectangle.Width - b.Right, s.SourceRectangle.Y + b.Top, b.Right, midHeight);
            SubSpriteSourceBounds[6] = new Rectangle(s.SourceRectangle.X, s.SourceRectangle.Y + b.Top + midHeight, b.Left, b.Bottom);
            SubSpriteSourceBounds[7] = new Rectangle(s.SourceRectangle.X + b.Left, s.SourceRectangle.Y + b.Top + midHeight, midWidth, b.Bottom);
            SubSpriteSourceBounds[8] = new Rectangle(s.SourceRectangle.X + s.SourceRectangle.Width - b.Right, s.SourceRectangle.Y + b.Top + midHeight, b.Right, b.Bottom);

            //Find Offsets of the each subsprite relative to the top left of its destination rect, and the destination sizes
            RecalculateSize();
        }

        public void RecalculateSize()
        {
            SubSpriteDestinationOffsets[0] = new Vector2(0, 0);
            SubSpriteDestinationOffsets[1] = new Vector2(SpriteBorders.Left, 0);
            SubSpriteDestinationOffsets[2] = new Vector2(NewSize.X - SpriteBorders.Right, 0);
            SubSpriteDestinationOffsets[3] = new Vector2(0, SpriteBorders.Top);
            SubSpriteDestinationOffsets[4] = new Vector2(SpriteBorders.Left, SpriteBorders.Top);
            SubSpriteDestinationOffsets[5] = new Vector2(NewSize.X - SpriteBorders.Right, SpriteBorders.Top);
            SubSpriteDestinationOffsets[6] = new Vector2(0, NewSize.Y - SpriteBorders.Bottom);
            SubSpriteDestinationOffsets[7] = new Vector2(SpriteBorders.Left, NewSize.Y - SpriteBorders.Bottom);
            SubSpriteDestinationOffsets[8] = new Vector2(NewSize.X - SpriteBorders.Right, NewSize.Y - SpriteBorders.Bottom);

            SubSpriteDestinationSize[0] = new Vector2(SpriteBorders.Left, SpriteBorders.Top);
            SubSpriteDestinationSize[1] = new Vector2(NewSize.X - SpriteBorders.Left - SpriteBorders.Right, SpriteBorders.Top);
            SubSpriteDestinationSize[2] = new Vector2(SpriteBorders.Right, SpriteBorders.Top);

            SubSpriteDestinationSize[3] = new Vector2(SpriteBorders.Left, NewSize.Y - SpriteBorders.Bottom - SpriteBorders.Top);
            SubSpriteDestinationSize[4] = new Vector2(NewSize.X - SpriteBorders.Left - SpriteBorders.Right, NewSize.Y - SpriteBorders.Bottom - SpriteBorders.Top);
            SubSpriteDestinationSize[5] = new Vector2(SpriteBorders.Right, NewSize.Y - SpriteBorders.Bottom - SpriteBorders.Top);

            SubSpriteDestinationSize[6] = new Vector2(SpriteBorders.Left, SpriteBorders.Bottom);
            SubSpriteDestinationSize[7] = new Vector2(NewSize.X - SpriteBorders.Left - SpriteBorders.Right, SpriteBorders.Bottom);
            SubSpriteDestinationSize[8] = new Vector2(SpriteBorders.Right, SpriteBorders.Bottom);
        }

        public void Draw(SpriteBatch sb, Vector2 position)
        {
            for(int i = 0; i < 9; i++)
            {
                Rectangle destRect = new Rectangle(
                    (position + SubSpriteDestinationOffsets[i]).ToPoint(), 
                    SubSpriteDestinationSize[i].ToPoint()
                );

                sb.Draw(Sprite.TextureAtlas, destRect, SubSpriteSourceBounds[i], Color.White);
            }
        }
    }

    public struct SpriteBorders
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
        public int Width => Right - Left;
        public int Height => Bottom - Top;
        public Vector2 Size => new Vector2(Width, Height);

        public SpriteBorders(int Top, int Right, int Bottom, int Left)
        {
            this.Left = Left;
            this.Right = Right;
            this.Top = Top;
            this.Bottom = Bottom;
        }
    }

}
