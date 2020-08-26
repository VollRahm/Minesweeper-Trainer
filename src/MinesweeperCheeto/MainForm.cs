using MinesweeperCheeto.Memory;
using MinesweeperCheeto.Minesweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinesweeperCheeto.Vars;

namespace MinesweeperCheeto
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var proc = Process.GetProcessesByName("Minesweeper").FirstOrDefault();
            if(proc == null)
            {
                MessageBox.Show("Minesweeper not found! Closing...");
                Application.Exit();
            }

            Vars.mem = new Mem(proc);
            cheat = new Cheat();
            updateUITimer.Start();
        }

        private void stopTmrBtn_Click(object sender, EventArgs e)
        {
            cheat.GameManager.StopTimer();
        }

        private void resumeTmrBtn_Click(object sender, EventArgs e)
        {
            cheat.GameManager.ResumeTimer();
        }

        private void updateUITimer_Tick(object sender, EventArgs e)
        {
            timerValue.Text = "Timer: " + Math.Round(cheat.GameManager.TimerValue, 1).ToString();
            gameStateLbl.Text = "Game State: " + cheat.GameManager.GameState.ToString();
        }

        private void reverseTmrBtn_Click(object sender, EventArgs e)
        {
            cheat.GameManager.ReverseTimer();
        }

        private void winBtn_Click(object sender, EventArgs e)
        {
            cheat.GameManager.GameState = 3;
        }

        private void looseBtn_Click(object sender, EventArgs e)
        {
            cheat.GameManager.GameState = 4;
        }

        private void alwaysLooseCb_CheckedChanged(object sender, EventArgs e)
        {
            cheat.ToggleAlwaysLoose(alwaysLooseCb.Checked);
        }

        private async void solveBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if(cheat.GameManager.IsTimerRunning == 0 && cheat.GameManager.TimesClicked == 0)
            {
                await cheat.StepSquare(0, 0);
            }
            if(cheat.GameManager.GameState != 1)
            {
                MessageBox.Show("No running game detected");
                this.Enabled = true;
                return;
            }
            await Task.Delay(5);
            var mines = cheat.Minefield.Mines;
            int fieldX = cheat.GameManager.FieldSizeX;
            int fieldY = cheat.GameManager.FieldSizeY;
            for (int x = 0; x < fieldX; x++)
            {
                for (int y = 0; y < fieldY; y++)
                {
                    if (mines[x][y] != 1)
                    {
                        var state = cheat.Minefield.GetFieldStatus(x, y);
                        if(state == 9 || state == 11)
                        {
                            await cheat.StepSquare(x, y);
                            await Task.Delay((int)solveDelayNUP.Value);
                        }
                       
                    }
                }
            }  
            this.Enabled = true;
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await InternalModule.Exit();
        }
    }
}
