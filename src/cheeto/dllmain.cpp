// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include "natives.h"
#include "helper.h"

void StartPipe()
{
    HANDLE hPipe;
    char buffer[1024];
    DWORD dwRead;

    hPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\minecheeto"),
        PIPE_ACCESS_DUPLEX,
        PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT,   // FILE_FLAG_FIRST_PIPE_INSTANCE is not needed but forces CreateNamedPipe(..) to fail if the pipe already exists...
        1,
        1024 * 16,
        1024 * 16,
        NMPWAIT_USE_DEFAULT_WAIT,
        NULL);
    bool exit = false;
    
    while (!exit)
    {
        if (ConnectNamedPipe(hPipe, NULL) != FALSE)   // wait for someone to connect to the pipe
        {
            
            while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
            {

                buffer[dwRead] = '\0';

                std::string msg = std::string(buffer);
                if (StringStartsWith(msg, "step"))
                {
                    std::string* output = new std::string[2];
                    SplitString(msg.substr(4, std::string::npos), ',', &output);
                    int x = stoi(output[0]);
                    int y = stoi(output[1]);
                    StepSquare(x, y);
                }
                else if (StringStartsWith(msg, "exit"))
                {
                    exit = true;
                    break;
                }
            }
            DisconnectNamedPipe(hPipe);
            if (exit) break;
        }
    }
    CloseHandle(hPipe);
    return;
}

DWORD WINAPI MainThread(LPVOID param)
{
    StartPipe();
    FreeLibraryAndExitThread((HMODULE)param, 0);
    return 0;
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        CreateThread(0, 0, MainThread, hModule, 0, 0);
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

