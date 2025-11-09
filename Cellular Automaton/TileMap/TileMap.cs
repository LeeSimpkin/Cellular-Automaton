using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Cellular_Automaton
{
    public class TileMap
    {
        // Make grid visible to other classes (Tile.CountAliveNeighbors uses it)
        public static Tile[,] Tiles;

        private int Columns => Tiles.GetLength(0);
        private int Rows => Tiles.GetLength(1);

        // Expose Size as static so state code can reference it
        public static int Size { get; set; } = 12;

        private Texture2D _whitePixelTexture;
        public TileMap(int columns, int rows, Texture2D texture)
        {
            Tiles = new Tile[columns, rows];
            _whitePixelTexture = texture;

            // expose to Tile
            Tile.AllTiles = Tiles;
            Tile.Columns = columns;
            Tile.Rows = rows;

            int tileSize = 10;
            int tileBorder = 1;

            int currentX = 0, currentY = 0;
            for (int i = 0; i < Columns; i++, currentX += tileSize + tileBorder * 2)
            {
                for (int j = 0; j < Rows; j++, currentY += tileSize + tileBorder * 2)
                {
                    Tiles[i, j] = new Tile();
                    Tiles[i, j].Column = i;
                    Tiles[i, j].Row = j;

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

        // Advance one generation (Conway-like rules you described):
        // - Alive tile survives if 2 or 3 neighbors.
        // - Dead tile becomes alive if exactly 3 neighbors.
        // Uses a temporary buffer to avoid in-place counting issues.
        public void StepSimulation()
        {
            int cols = Columns;
            int rows = Rows;
            var nextAlive = new bool[cols, rows];

            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    Tile t = Tiles[c, r];
                    int aliveNeighbors = t.CountAliveNeighbors();

                    if (t.Type == Tile.TileType.ALIVE)
                    {
                        // survive with 2 or 3 neighbors
                        nextAlive[c, r] = aliveNeighbors == 2 || aliveNeighbors == 3;
                    }
                    else
                    {
                        // birth with exactly 3
                        nextAlive[c, r] = aliveNeighbors == 3;
                    }
                }
            }

            // apply next state
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    Tiles[c, r].Type = nextAlive[c, r] ? Tile.TileType.ALIVE : Tile.TileType.DEAD;
                }
            }
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
