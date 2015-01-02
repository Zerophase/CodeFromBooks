#ifndef ICONWINDOW_H
#define ICONWINDOW_H

#include "Window.h"

class IconWindow : public Window
{
	public:
		virtual void DrawContents();
	
	private:
		const char *bitmpName;
};
#endif // !ICONWINDOW_H
