#include "IconWindow.h"

void IconWindow::DrawContents()
{
	WindowImp *imp = GetWindowImp();
	if (imp != 0)
		imp->DeviceBitmap(bitmpName, 0.0, 0.0);
}