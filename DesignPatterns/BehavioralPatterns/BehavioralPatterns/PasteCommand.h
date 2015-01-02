#ifndef PASTECOMMAND_H
#define PASTECOMMAND_H

#include "Command.h"

class Document;

class PasteCommand : public Command
{
public:
	PasteCommand(Document *document);

	virtual void Execute();
private:
	Document *_document;
};

#endif // !PASTECOMMAND_H
