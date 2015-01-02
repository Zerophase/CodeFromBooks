#include "OpenCommand.h"
#include "ApplicationForCommand.h"
#include "Document.h"

OpenCommand::OpenCommand(Application *application)
{
	_application = application;
}

void OpenCommand::Execute()
{
	const char *name = AskUser();

	if (name != 0)
	{
		Document *document = new Document(name);
		_application->Add(document);
		document->Open();
	}
}

const char *OpenCommand::AskUser()
{
	const char *things = "Name";
	return things;
}