using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalPipeComm
{

    public class PipeClient
    {
        private NamedPipeClientStream pipeStream;

        public PipeClient(string PipeName)
        {
            pipeStream = new NamedPipeClientStream(".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);
            pipeStream.Connect(10000);
        }

        public async Task<bool> Send(string Message)
        {
            try
            {
                if (pipeStream.IsConnected)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(Message);
                    await pipeStream.WriteAsync(buffer, 0, buffer.Length);
                    await pipeStream.FlushAsync();
                    pipeStream.WaitForPipeDrain();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
