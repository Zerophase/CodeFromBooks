#ifndef EMPLOYEE_H
#define EMPLOYEE_H

#include <iostream>
#include <string>

class Employee
{
public:
	Employee() : name("Robert") {}

	void Print()
	{
		std::cout << name <<  std::endl;
	}

private:
	std::string name;
};
#endif // !EMPLOYEE_H
