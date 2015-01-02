#include "TextDocument.h"
#include "ImageProxy.h"

void Test();

void Test()
{
	TextDocument *text = new TextDocument;
	//...
	text->Insert(new ImageProxy("anImageFileName"));
}