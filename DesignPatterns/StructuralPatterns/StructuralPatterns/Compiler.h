#ifndef COMPILER_H
#define COMPILER_H

class istream;
class BytecodeStream;

class Compiler
{
public:
	Compiler();

	virtual void Compile(istream &input, BytecodeStream &bytecodeStream);
};
#endif // !COMPILER_H
