#ifndef PROGRAMNODEBUILDER_H
#define PRAOGRAMNODEBUILDER_H

class ProgramNode;

class ProgramNodeBuilder
{
public:
	ProgramNodeBuilder();

	virtual ProgramNode *newVariable(
		const char *variableName
		) const;

	virtual ProgramNode *NewAssignment(
		ProgramNode *variable, ProgramNode *expression
		) const;
	
	virtual ProgramNode *NewReturnStatement(
		ProgramNode *value
		) const;

	virtual ProgramNode *NewCondition(
		ProgramNode *condition,
		ProgramNode *truePart, ProgramNode *falsePart
		) const;

	//...

	ProgramNode *GetRootNode();
private:
	ProgramNode *node;
};
#endif // !PROGRAMNODEBUILDER_H
