#include "PasteCommand.h"
#include "Document.h"

PasteCommand::PasteCommand(Document *document)
{
	_document = document;
}

void PasteCommand::Execute()
{
	_document->Paste();
}