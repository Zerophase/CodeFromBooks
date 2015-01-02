#ifndef PRINTNEMPLOYEES_H
#define PRINTNEMPLOYEES_H

#include "ListTraverser.h"
#include "List.h"
#include "Employee.h"

class PrintNEmployees : public ListTraverser<Employee*>
{
public:
	PrintNEmployees(List<Employee*> *aList, int n) :
		ListTraverser<Employee*>(aList), _total(n), _count(0) {}
protected:
	bool ProcessItem(Employee *const&);
private:
	int _total;
	int _count;
};
#endif // !PRINTNEMPLOYEES_H
