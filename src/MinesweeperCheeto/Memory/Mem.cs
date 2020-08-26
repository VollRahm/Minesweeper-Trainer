using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperCheeto.Memory
{
    public class Mem
    {
        
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint dwSize, uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, uint lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        

        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RESERVE = 0x2000;
        public const int PAGE_EXECUTE_READWRITE = 0x40;


        private IntPtr processHandle;
        public Process process;
        public long MainModuleBaseAddress
        {
            get => (long)process.MainModule.BaseAddress;
        }

        public Mem(Process proc)
        {
            process = proc;
            processHandle = proc.Handle;
        }

        public byte[] ReadBytes(long address, uint size)
        {
            byte[] lpBuffer = new byte[size];
            ReadProcessMemory(processHandle, address, lpBuffer, size, 0);
            return lpBuffer;
        }

        public void WriteBytes(long address, byte[] bytes)
        {
            WriteProcessMemory(processHandle, address, bytes, (uint)bytes.Length, 0);
        }

        public long ReadInt64(long address)
        {
            var bytes = ReadBytes(address, 8);
            return BitConverter.ToInt64(bytes, 0);
        }

        public void WriteInt64(long address, long value)
        {
            WriteBytes(address, BitConverter.GetBytes(value));
        }

        public int ReadInt32(long address)
        {
            var bytes = ReadBytes(address, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public void WriteInt32(long address, int value)
        {
            WriteBytes(address, BitConverter.GetBytes(value));
        }

        public byte ReadByte(long address)
        {
            return ReadBytes(address, 1)[0];
        }

        public void WriteByte(long address, byte value)
        {
            WriteBytes(address, BitConverter.GetBytes(value));
        }

        public float ReadFloat(long address)
        {
            var bytes = ReadBytes(address, 4);
            return BitConverter.ToSingle(bytes, 0);
        }

        public void WriteFloat(long address, float value)
        {
            WriteBytes(address, BitConverter.GetBytes(value));
        }


        public long AllocateExecutableMemory(uint size)
        {
            return (long)VirtualAllocEx(processHandle, IntPtr.Zero, size, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
        }


    }
}
