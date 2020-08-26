using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinesweeperCheeto.Vars;

namespace MinesweeperCheeto.Minesweeper
{
    public class GameManager
    {
        public long Base
        {
            get => mem.ReadInt64(mem.ReadInt64(mem.MainModuleBaseAddress + 0xAAA38) + 0x18);
        }

        public int BombCount
        {
            get => mem.ReadInt32(Base + 0x8);
            set => mem.WriteInt32(Base + 0x8, value);
        }

        public int FieldSizeX
        {
            get => mem.ReadInt32(Base + 0x10);
        }
        public int FieldSizeY
        {
            get => mem.ReadInt32(Base + 0xC);
        }

        public int TimesClicked
        {
            get => mem.ReadInt32(Base + 0x1C);
        }

        public int GameState
        {
            get => mem.ReadInt32(mem.ReadInt64(mem.MainModuleBaseAddress + 0xAAA38) + 0x38);
            set => mem.WriteInt32(mem.ReadInt64(mem.MainModuleBaseAddress + 0xAAA38) + 0x38, value);
        }

        public int IsTimerRunning
        {
            get => mem.ReadByte(Base + 0x126);
        }

        public float TimerValue
        {
            get => mem.ReadFloat(Base + 0x20);
            set => mem.WriteFloat(Base + 0x20, value);
        }


        private long TimerInstruction = mem.MainModuleBaseAddress + 0x2B753;
        private byte[] RunningTimer = { 0xF3, 0x0F, 0x58, 0x05, 0xF9, 0x8C, 0xFE, 0xFF };
        private byte[] StoppedTimer = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        private byte[] ReversedTimer = { 0xF3, 0x0F, 0x5C, 0x05, 0xF9, 0x8C, 0xFE, 0xFF };

        public void StopTimer()
        {
            mem.WriteBytes(TimerInstruction, StoppedTimer);
        }

        public void ResumeTimer()
        {
            mem.WriteBytes(TimerInstruction, RunningTimer);
        }

        public void ReverseTimer()
        {
            mem.WriteBytes(TimerInstruction, ReversedTimer);
        }
    }
}
