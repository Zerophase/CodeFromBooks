#include "PrintNEmployees.h"

bool PrintNEmployees::ProcessItem(Employee *const&e)
{
	_count++;
	e->Print();
	return _count < _total;
}