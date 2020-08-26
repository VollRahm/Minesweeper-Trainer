#include "pch.h"

void SplitString(const std::string& str, char delim, std::string** output)
{
    std::stringstream ss(str);
    std::string token;
    int count = 0;
    while (std::getline(ss, token, delim))
    {
        (*output)[count] = token;
        count++;
        if (count > 2) return;
    }
}

bool StringStartsWith(std::string input, std::string param)
{
    if (input.rfind(param, 0) == 0)
    {
        return 1;
    }
    else return 0;
}