//#include "Compiler.h"

//Facade gathers all associated classes together into one class for other parts of the application
//to send input to a generic interface that passes the work onto the appropriate class.
//void Compiler::Compile(
//	istream &input, BytecodeStream &output);
//{
//	Scanner scanner(input);
//	ProgramNodeBuilder builder;
//	Parser parser;
//
//	parser.parse(scanner, builder);
//
//	RISCCodeGenerator generator(output);
//	ProgramNode *parseTree = builder.GetRootNode();
//	parseTree->Traverse(generator);
//}