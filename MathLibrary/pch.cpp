#include "pch.h"
#include <Windows.h>

extern "C" __declspec(dllexport) int Add(int a, int b)
{
	return a + b;
}