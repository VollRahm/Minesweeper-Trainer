using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinesweeperCheeto.Vars;

namespace MinesweeperCheeto.Minesweeper
{
    public class Cheat
    {
        public GameManager GameManager = new GameManager();
        public Minefield Minefield = new Minefield();

        public Cheat()
        {
            _ = InternalModule.Inject(mem.process);
        }

        private long AlwaysLooseInstruction = mem.MainModuleBaseAddress + 0x2787C;
        
        public void ToggleAlwaysLoose(bool enable)
        {
            if (enable)
                mem.WriteBytes(AlwaysLooseInstruction,new byte[] { 0x74, 0xA});
            else
                mem.WriteBytes(AlwaysLooseInstruction, new byte[] { 0x75, 0xA });
        }

        public long GetClickManager()
        {
            return mem.ReadInt64(mem.ReadInt64(mem.ReadInt64(mem.MainModuleBaseAddress + 0xAAC18) + 0x88));
        }

        public async Task StepSquare(int x, int y)
        {
            await InternalModule.StepSquare(x, y);
        }
    }
}
