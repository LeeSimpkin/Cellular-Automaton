using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class TileMap
    {
        public static Tile[,] Tiles;
        private int Columns => Tiles.GetLength(0);
        private int Rows => Tiles.GetLength(1);
        public static int Size => 12;

        private Texture2D _whitePixelTexture;
        public TileMap(int columns, int rows, Texture2D texture, Game game)
        {
            Tiles = new Tile[columns, rows];
            _whitePixelTexture = texture;
            int tileSize = 10;
            int tileBorder = 1;

            int currentX = 0, currentY = 0;
            for (int i = 0; i < Columns; i++, currentX += tileSize + tileBorder * 2)
            {
                for (int j = 0; j < Rows; j++, currentY += tileSize + tileBorder * 2)
                {
                    Tiles[i, j] = new Tile(game);
                    Tiles[i, j].OutLineColour = Color.Black;
                    Tiles[i, j].Type = Tile.TileType.DEAD;
                    Tiles[i, j].OutLineRectangle = new Rectangle(currentX, currentY, tileSize + tileBorder * 2, tileSize + tileBorder * 2);
                    Tiles[i, j].InFillRectangle = new Rectangle(currentX + tileBorder, currentY + tileBorder, tileSize, tileSize);
                }
                currentY = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    spriteBatch.Draw(_whitePixelTexture, Tiles[i, j].OutLineRectangle, Tiles[i, j].OutLineColour);
                }
            }

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    spriteBatch.Draw(_whitePixelTexture, Tiles[i, j].InFillRectangle, Tiles[i, j].InFillColour);
                }
            }
        }
        public void ChangeType(Point point, Tile.TileType type)
        {
            int column = point.X / Size;
            int row = point.Y / Size;

            if (InvalidTile(column, row))
                return;
    
            Tile tile = Tiles[column, row];
            tile.Type = type;
        }
        private bool InvalidTile(int col, int row)
        {
            return col < 0 || col >= Columns || row < 0 || row >= Rows;
        }
        private bool ValidTile(int col, int row)
        {
            return !InvalidTile(col, row);
        }
    }
}
