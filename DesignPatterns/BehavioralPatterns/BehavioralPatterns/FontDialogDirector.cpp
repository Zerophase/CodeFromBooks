#include "FontDialogDirector.h"
#include "ButtonMediator.h"
#include "ListBox.h"
#include "EntryField.h"

void FontDialogDirector::CreateWidgets()
{
	_ok = new ButtonMediator(this);
	_cancel = new ButtonMediator(this);
	_fontList = new ListBox(this);
	_fontName = new EntryField(this);

	//fills the listBox with the available font names
	
	//assemble the widgets in the dialog
}

void FontDialogDirector::WidgetChanged(WidgetMediator *changedWidget)
{
	if (changedWidget == _fontList)
		_fontName->SetText(_fontList->GetSelection());
	else if (changedWidget == _ok)
	{
		//apply font change and dismiss dialog
	}
	else if (changedWidget == _cancel)
	{
		//dismiss dialog
	}
}