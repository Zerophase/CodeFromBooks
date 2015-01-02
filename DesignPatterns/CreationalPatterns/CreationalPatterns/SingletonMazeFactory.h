#ifndef SINGLETONMAZEFACTORY_H
#define SINGLETONMAZEFACTORY_H

class SingletonMazeFactory
{
	public:
		static SingletonMazeFactory *Instance();

		//existing interface goes here
	protected:
		SingletonMazeFactory();
	private:
		static SingletonMazeFactory *instance;
};
#endif // !SINGLETONMAZEFACTORY_H
