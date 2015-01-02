#include "SingletonMazeFactory.h"
#include "EnchantedMazeFactory.h"
#include <stdlib.h>
#include <string.h>

SingletonMazeFactory *SingletonMazeFactory::Instance()
{
	if (instance == 0)
	{
		const char *mazeStyle = getenv("MAZESTYLE");

		if (strcmp(mazeStyle, "bombed") == 0)
		{
			//TODO write BombedMazeFactory
		}
		else if (strcmp(mazeStyle, "enchanted") == 0)
		{
			//TODO rewwrite as MazeFactory
			//Broken because SingletonMazeFactory and not a MazeFactory
			//instance = new EnchantedMazeFactory;
		}
		//And many more subclasses.
		else
			instance = new SingletonMazeFactory;
	}
	return instance;
}

SingletonMazeFactory::SingletonMazeFactory()
{

}

SingletonMazeFactory *SingletonMazeFactory::instance = 0;