#include "stdafx.h"

#include "gmock\gmock.h"
#include "Tweet.h"

using namespace ::testing;
using namespace std;

TEST(ATweet, RequiresUserToStartWithAtSign)
{
	string invalidUser("notStartingWith@");
	
	// If exception type is unknown
	//ASSERT_ANY_THROW(Tweet tweet("msg", invalidUser));

	// If exception type is known.
	//ASSERT_THROW(Tweet tweet("msg", invalidUser), InvalidUserException);

	// if Framework doesn't support a single line declaritive structure
	/*try
	{
		Tweet tweet("msg", invalidUser);
		FAIL();
	}
	catch (const InvalidUserException &expected)
	{

	}*/
	// To verify any conditions after catch block
	try
	{
		Tweet tweet("msg", invalidUser);
		FAIL();
	}
	catch (const InvalidUserException &expected)
	{
		ASSERT_STREQ("notStartingWith@", expected.what());
	}
}