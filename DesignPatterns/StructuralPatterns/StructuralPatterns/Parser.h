#ifndef PARSER_H
#define PARSER_H

#include "Scanner.h"

class ProgramNodeBuilder;

class Parser
{
public:
	Parser();
	virtual ~Parser();

	virtual void Parse(Scanner &scanner, ProgramNodeBuilder &programNodeBuilder);
};
#endif // !PARSER_H
