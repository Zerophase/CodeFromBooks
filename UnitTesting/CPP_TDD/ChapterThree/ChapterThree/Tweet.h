#ifndef TWEET_H
#define TWEET_H

#include <string>
#include <stdexcept>

class InvalidUserException : public std::invalid_argument
{
public:
	InvalidUserException(const std::string &user) : 
		invalid_argument(user) {}
};

class Tweet
{
public:
	Tweet(const std::string &message = "", const std::string &user = "")
		:message_(message), user_(user)
	{
		if (!isValid(user_))
			throw InvalidUserException(user_);
	}

	bool isValid(const std::string&user) const
	{
		return '@' == user[0];
	}

	bool operator==(const Tweet &rhs) const
	{
		return message_ == rhs.message_ &&
			user_ == rhs.user_;
	}

	bool operator!=(const Tweet &rhs) const
	{
		return !(*this == rhs);
	}

	bool operator <(const Tweet &rhs) const
	{
		if (user_ == rhs.user_)
			return message_ < rhs.message_;
		return user_ < rhs.user_;
	}

private:
	std::string message_;
	std::string user_;
};
#endif // !TWEET_H
