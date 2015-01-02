#include "stdafx.h"

#include "gmock\gmock.h"
#include "RetweetCollection.h"
#include "Tweet.h"

#include <memory>

using namespace ::testing;
using namespace std;

class ARetweetCollection : public Test
{
public:
	RetweetCollection collection;
};

class ARetweetCollectionWithOneTweet : public Test
{
public:
	RetweetCollection collection;
	//Tweet *tweet;

	// With a Smart pointer
	shared_ptr<Tweet> tweet;

	void SetUp() override
	{
		// shared pointer initialization
		tweet = shared_ptr<Tweet>(new Tweet("msg", "@user"));
		//tweet = new Tweet("msg", "@user");
		collection.add(*tweet);
	}

	// no need for tear down method with shared pointer.
	/*void TearDown() override
	{
		delete tweet;
		tweet = nullptr;
	}*/
};

// look up in docs. Explained in book and works as a custom equality check
MATCHER_P(HasSize, expected, "")
{
	return arg.size() == expected &&
		arg.isEmpty() == (0 == expected);
}

TEST_F(ARetweetCollection, IsEmptyWhenCreated)
{
	ASSERT_TRUE(collection.isEmpty());
}

TEST_F(ARetweetCollection, HasSizeZeroWhenCreated)
{
	ASSERT_THAT(collection.size(), Eq(0u));
}

TEST_F(ARetweetCollectionWithOneTweet, IsNoLongerEmpty)
{
	ASSERT_FALSE(collection.isEmpty());
}

TEST_F(ARetweetCollectionWithOneTweet, HasSizeOfOne)
{
	ASSERT_THAT(collection.size(), Eq(1u));
}

TEST_F(ARetweetCollection, DecreasesSizeAfterRemovingTweet)
{
	collection.add(Tweet("msg", "@user"));
	collection.remove(Tweet("msg", "@user"));

	ASSERT_THAT(collection, HasSize(0u));
}

TEST_F(ARetweetCollection, IsEmptyWhenItsSizeIsZero)
{
									// Eq = equvalent
	ASSERT_THAT(collection.size(), Eq(0u));
}

TEST_F(ARetweetCollection, IsNotEmptyWhenItsSizeIsNonZero)
{
	collection.add(Tweet("msg", "@user"));
									// Gt = greater than
	ASSERT_THAT(collection.size(), Gt(0u));
	ASSERT_FALSE(collection.isEmpty());
}

TEST_F(ARetweetCollectionWithOneTweet, IgnoresDuplicateTweetAdded)
{
	Tweet duplicate(*tweet);

	collection.add(duplicate);

	ASSERT_THAT(collection.size(), Eq(1u));
}