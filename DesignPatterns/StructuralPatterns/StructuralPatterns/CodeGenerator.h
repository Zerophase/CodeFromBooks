#ifndef CODEGENERATOR_H
#define CODEGENERATOR_H

class StatementNode;
class ExpressionNode;
class BytecodeStream;

class CodeGenerator
{
public:
	virtual void Vistit(StatementNode *statementNode);
	virtual void Visit(ExpressionNode *expressionNode);
	//...

protected:
	CodeGenerator(BytecodeStream &bytecodeStream);

	BytecodeStream &output;
};
#endif // !CODEGENERATOR_H
