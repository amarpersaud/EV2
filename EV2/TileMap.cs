using System;
using System.Collections.Generic;
using System.Text;

namespace EV2
{
    public class TileMap
    {
        public int[,] Map;
        public List<Tile> Tiles;

        public int Width { get; }
        public int Height { get; }
        public TileMap(int Width, int Height, List<Tile> Tiles)
        {
            this.Width = Width;
            this.Height = Height;
            Map = new int[Width, Height];
            this.Tiles = Tiles; 
        }
    }
}
