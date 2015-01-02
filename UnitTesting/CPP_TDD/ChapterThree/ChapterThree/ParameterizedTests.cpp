#include "stdafx.h"

#include "gmock\gmock.h"
#include "Adder.h"

using namespace ::testing;

struct SumCase
{
	int a, b, expected;

	SumCase(int anA, int aB, int anExpected)
		: a(anA), b(aB), expected(anExpected) { }
};

class AnAdder : public TestWithParam < SumCase >
{
	
};

TEST_P(AnAdder, GeneratesLotsOfSumsFromTwoNumbers)
{
	SumCase input = GetParam();

	ASSERT_THAT(Adder::sum(input.a, input.b), Eq(input.expected));
}

SumCase sums [] =
{
	SumCase(1, 1, 2),
	SumCase(1, 2, 3),
	SumCase(2, 2, 4)
};
INSTANTIATE_TEST_CASE_P(BulkTest, AnAdder, ValuesIn(sums));
