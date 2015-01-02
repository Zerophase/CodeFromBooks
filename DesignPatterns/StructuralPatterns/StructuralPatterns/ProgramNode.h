#ifndef PROGRAMNODE_H
#define PROGRAMNODE_H

class CodeGenerator;

class ProgramNode
{
public:
	//program node manipulation
	virtual void GetSourcePosition(int &line, int &index);
	//...

	//child manipulation
	virtual void Add(ProgramNode *programNode);
	virtual void Remove(ProgramNode *programNode);
	//...

	virtual void Traverse(CodeGenerator &codeGenerator);
protected:
	ProgramNode();
};
#endif // !PROGRAMNODE_H
