#include "stdafx.h"

#include "CppUTest\TestHarness.h"
#include "WavReader.h"
#include <iostream>
#include <string>
#include <sstream>

using namespace std;

TEST_GROUP(WavReader_WriteSamples)
{
	WavReader reader{ "", "" };
	ostringstream out;
};

TEST(WavReader_WriteSamples, WritesSingleSample)
{
	char data [] {"abcd"};
	uint32_t bytesPerSample{ 1 };
	uint32_t startingSample{ 0 };
	uint32_t samplesToWrite{ 1 };
	reader.writeSamples(&out, data, startingSample, samplesToWrite, bytesPerSample);
	CHECK_EQUAL("a", out.str());
}

TEST(WavReader_WriteSamples, WritesMultibyteSampleFromMiddle)
{
	char data[] {"0123456789ABCDEFG"};
	uint32_t bytestPerSample{ 2 };
	uint32_t startingSample{ 4 };
	uint32_t samplesToWrite{ 3 };

	reader.writeSamples(&out, data, startingSample, samplesToWrite, bytestPerSample);
	CHECK_EQUAL("89ABCD", out.str());
}