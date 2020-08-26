using InternalPipeComm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinesweeperCheeto.Vars;

namespace MinesweeperCheeto.Minesweeper
{
    public class InternalModule
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern long GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
        IntPtr lpThreadAttributes, uint dwStackSize, long lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        private static PipeClient pc;

        public static async Task Inject(Process proc)
        {
            var dllPath = Path.GetFullPath("cheeto.dll");
            if (!File.Exists(dllPath))
            {
                MessageBox.Show("cheeto.dll not found, exiting...");
                Application.Exit();
            }

            long loadLibraryPtr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            long allocAddr = mem.AllocateExecutableMemory((uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))));
            mem.WriteBytes(allocAddr, Encoding.Default.GetBytes(dllPath));
            CreateRemoteThread(mem.process.Handle, IntPtr.Zero, 0, loadLibraryPtr, (IntPtr)allocAddr, 0, IntPtr.Zero);
            await Task.Delay(1500);
            ConnectPipe();
        }

        private static void ConnectPipe()
        {
            try
            {
                pc = new PipeClient("minecheeto");
            }
            catch { pc = null; return; }
        }

        public static async Task StepSquare(int x, int y)
        {
            string cmd = $"step{x},{y}";
            await pc.Send(cmd);
        }

        public static async Task Exit()
        {
            await pc.Send("exit");
        }

    }
}
