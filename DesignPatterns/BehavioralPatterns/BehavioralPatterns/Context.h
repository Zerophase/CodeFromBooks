#ifndef CONTEXT_H
#define CONTEXT_H

#include <list>
#include <vector>

using namespace std;

class VariableExp;

class Context
{
public:
	bool LookUp(const char *) const;
	void Assign(VariableExp*, bool);
private:
	vector<pair<VariableExp*, bool>> variableExps;
};
#endif // !CONTEXT_H
