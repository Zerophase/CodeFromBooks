#include "stdafx.h"
#include "gmock\gmock.h"

int main(int argc, char** argv)
{
	testing::InitGoogleMock(&argc, argv);
	RUN_ALL_TESTS();
	std::getchar(); // keep console window open until Return keystroke
}