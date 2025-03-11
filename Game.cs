using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pikachu_matrix;
using Pikachu_random;

namespace Pikachu_game
{
    class Game
    {
            private PokemonRandom PokeRandom;
            private PokemonMatrix firstSelectedCell;
            private PokemonMatrix secondSelectedCell;
            private Panel gamePanel;

        public Game(PokemonRandom PokeRandom, Form form, Panel panel)
            {
                this.PokeRandom = PokeRandom;
                this.gamePanel = panel;
                SetupBoard();
            }

            private void SetupBoard()
            {
                for (int i = 0; i < PokeRandom.GetX; i++)
                {
                    for (int j = 0; j < PokeRandom.GetY; j++)
                    {
                        PokeRandom.GetPokemonMatrix[i, j].PictureBox.Click += PictureBox_Click;
                        gamePanel.Controls.Add(PokeRandom.GetPokemonMatrix[i, j].PictureBox);
                        PokeRandom.GetPokemonMatrix[i, j].PictureBox.Left = j * 30;
                        PokeRandom.GetPokemonMatrix[i, j].PictureBox.Top = i * 30;
                    }
                }
            }

            private void PictureBox_Click(object sender, EventArgs e)
            {
                if (firstSelectedCell == null)
                {
                    firstSelectedCell = PokeRandom.GetPokemonMatrix.Cast<PokemonMatrix>().FirstOrDefault(c => c.PictureBox == sender);
                    firstSelectedCell.PictureBox.BorderStyle = BorderStyle.Fixed3D;
                }
                else if (secondSelectedCell == null)
                {
                    secondSelectedCell = PokeRandom.GetPokemonMatrix.Cast<PokemonMatrix>().FirstOrDefault(c => c.PictureBox == sender);
                    secondSelectedCell.PictureBox.BorderStyle = BorderStyle.Fixed3D;

                    if (CheckConnection(firstSelectedCell, secondSelectedCell))
                    {
                        firstSelectedCell.IsMatched = true;
                        secondSelectedCell.IsMatched = true;
                        firstSelectedCell.PictureBox.Visible = false;
                        secondSelectedCell.PictureBox.Visible = false;
                    }

                    firstSelectedCell.PictureBox.BorderStyle = BorderStyle.FixedSingle;
                    secondSelectedCell.PictureBox.BorderStyle = BorderStyle.FixedSingle;

                    firstSelectedCell = null;
                    secondSelectedCell = null;
                }
            }

            private bool CheckConnection(PokemonMatrix cell1, PokemonMatrix cell2)
            {
                if (cell1 == null || cell2 == null || cell1 == cell2 || cell1.Image1 != cell2.Image1)
                    return false;

                // Logic kiểm tra kết nối giữa hai ô (có thể thay đổi theo yêu cầu trò chơi)
                return true;
            }
        }

    }
