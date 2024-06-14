using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_of_life
{
    public class GameOfLifeEditor : GameOfLifeBase
    {
        private int cursorX = 0;
        private int cursorY = 0;
        
        private int cellPos_X = 0;
        private int cellPos_Y = 0;

        public GameOfLifeEditor(int x, int y) : base(x, y)
        {

        }

        public override void DrawMenuPanel(int windowWidth)
        {
            base.DrawMenuPanel(windowWidth);

            stringBuilder.AppendLine("[Arrow keys] to move       [Enter] Clear the board");
            stringBuilder.AppendLine("[Spacebar] Toggle cell     [Escape] Start menu");
            stringBuilder.AppendLine("[Backspace] Start/stop the life");
        }

        public string PlayerMove(ConsoleKeyInfo key, int boardSize, int windowWidth)
        {
            string generationReturn = "";

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(cursorX - 2 > 0)
                    {
                        Console.SetCursorPosition(cursorX -= 2, cursorY);
                        //cellPositionY--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if(cursorX + 2 < CurrentCellGeneration.GetLength(1) - 1)
                    {
                        Console.SetCursorPosition(cursorX += 2, cursorY);
                        //cellPositionY++;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if(cursorY - 1 > 0)
                    {
                        Console.SetCursorPosition(cursorX, cursorY -= 1);
                        //cellPositionY--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (cursorX + 2 < CurrentCellGeneration.GetLength(1) - 1)
                    {
                        Console.SetCursorPosition(cursorX, cursorY += 1);
                        //cellPositionY++;
                    }
                    break;

                case ConsoleKey.Spacebar:
                    ToggleCurrentCellState();
                    generationReturn = Draw(boardSize, windowWidth);
                    break;

                case ConsoleKey.Enter:
                    ClearBoard();
                    generationReturn = Draw(boardSize, windowWidth);
                    break;

                default:
                    generationReturn = Draw(boardSize, windowWidth);
                    break;
            }


            cellPos_Y = cursorX / 2;
            cellPos_X = cursorY;

            return generationReturn;
        }

        private void ToggleCurrentCellState()
        {
            if (CurrentCellGeneration[cellPos_X, cellPos_Y] == 1)
            {
                CurrentCellGeneration[cellPos_X, cellPos_Y] = 0;
            }
            else
            {
                CurrentCellGeneration[cellPos_X, cellPos_Y] = 1;
            }

            Console.SetCursorPosition(cursorX, cursorY);
        }

        private void ClearBoard()
        {
            for(int row = 0; row < CurrentCellGeneration.GetLength(0); row++)
            {
                for(int col = 0; col < CurrentCellGeneration.GetLength(1); col++)
                {
                    CurrentCellGeneration[row, col] = 0;
                }
            }
        }

        public void UpdateCursorPosition()
        {
            Console.SetCursorPosition(cursorX, cursorY);
        }
    }
}
