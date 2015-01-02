#ifndef RETWEET_COLLECTION_H
#define RETWEET_COLLECTION_H

#include "Tweet.h"
#include <set>

class RetweetCollection
{
public:
	RetweetCollection()
		: size_(0)
	{

	}
	unsigned int size() const
	{
		return tweets.size();
	}

	bool isEmpty() const
	{
		return 0 == size();
	}

	void add(const Tweet &tweet)
	{
		tweets.insert(tweet);
		size_++;
	}

	void remove(const Tweet &tweet)
	{
		tweets.erase(tweet);
		size_--;
	}

private:
	unsigned int size_;
	std::set<Tweet> tweets;
};
#endif // !RETWEET_COLLECTION_H
