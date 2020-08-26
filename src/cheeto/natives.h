#include "pch.h"

QWORD MainModule = (QWORD)GetModuleHandle(NULL);

QWORD StepSquarePtr = MainModule + 0x31854;

typedef long(__fastcall* tStepSquare)(QWORD ClickManager, int* InfoStructPtr);
tStepSquare StepSquareBase = (tStepSquare)StepSquarePtr;

BYTE GetFieldState(int x, int y)
{
    QWORD GameManager = *(QWORD*)(*(QWORD*)(MainModule + 0xAAA38) + 0x18);
    QWORD Columns = *(QWORD*)(*(QWORD*)(GameManager + 0x50) + 0x10);
    QWORD Column = *(QWORD*)(*(QWORD*)(Columns + ((QWORD)x * 0x8)) + 0x10);
    QWORD Row = Column + (QWORD)y * 0x4;
    BYTE state = *(QWORD*)Row;

    return state;
}

void StepSquare(int x, int y)
{
    BYTE state = GetFieldState(x, y);
    if (state != 9 && state != 11) return;

    QWORD ClickManager = *((QWORD*)(*(QWORD*)(*(QWORD*)(MainModule + 0xAAC18) + 0x88)));
    int* addr = new int[14];
    addr[12] = x;
    addr[13] = y;
    StepSquareBase(ClickManager, addr);
}

