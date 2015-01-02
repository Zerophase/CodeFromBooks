#ifndef EMPLOYEEAGGREGATE_H
#define EMPLOYEEAGGREGATE_H

#include "ListIterator.h"
#include "ReverseListIterator.h"
#include "Employee.h"
#include "List.h"
#include "AbstractList.h"
#include "IteratorPtr.h"
#include "PrintNEmployees.h"

class EmployeeAggregate
{
public:
	EmployeeAggregate() {}

	void Traversals()
	{
		//For external iterator
		//AbstractList<Employee*> *employees;
		/*List<Employee*> *employees;
		ListIterator<Employee*> forward(employees);
		ReverListIterator<Employee*> backward(employees);*/
		//Iterator<Employee*> *iterator = employees->CreateIterator();
		/*IteratorPtr<Employee*> iterator(employees->CreateIterator());
		PrintEmployees(*iterator);*/

		//Internal iterator
		//TODO ADD MEANS OF ADDING TO THE LIST
		List<Employee*> *employees;
		
		PrintNEmployees pa(employees, 10);
		pa.Traverse();
	}
	void PrintEmployees(Iterator<Employee*> &i)
	{
		for (i.First(); !i.IsDone(); i.Next())
		{
			i.CurrentItem()->Print();
		}
	}
};
#endif // !EMPLOYEEAGGREGATE_H
