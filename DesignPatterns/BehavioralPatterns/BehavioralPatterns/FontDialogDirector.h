#ifndef FONTDIALOGDIRECTOR_H
#define FONTDIALOGDIRECTOR_H

#include "DialogDirector.h"

class WidgetMediator;
class ButtonMediator;
class ListBox;
class EntryField;

class FontDialogDirector : public DialogDirector
{
public:
	FontDialogDirector();
	virtual ~FontDialogDirector();
	virtual void WidgetChanged(WidgetMediator*);

protected:
	virtual void CreateWidgets();

private:
	ButtonMediator *_ok;
	ButtonMediator *_cancel;
	ListBox *_fontList;
	EntryField *_fontName;
};
#endif // !FONTDIALOGDIRECTOR_H
