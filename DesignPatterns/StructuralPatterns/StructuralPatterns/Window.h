#ifndef WINDOW_H
#define WINDOW_H

#include "View.h"
#include "Point.h"
#include "WindowImp.h"

class Window
{
	public:
		Window(View *contents);

		//requests handled by window
		virtual void DrawContents();

		virtual void Open();
		virtual void Close();
		virtual void Iconify();
		virtual void Deiconify();

		//requests forwarded to implementation
		virtual void SetOrigin(const Point &at);
		virtual void SetExtent(const Point &extent);
		virtual void Raise();
		virtual void Lower();

		virtual void DrawLine(const Point &origin, const Point &end);
		virtual void DrawRect(const Point &origin, const Point &end);
		virtual void DrawPolygon(const Point points[], int pointCount);
		virtual void DrawText(const char *character, const Point &origin);

	protected:
		WindowImp *GetWindowImp();
		View *GetView();

	private:
		WindowImp *imp;
		View *contents;
};
#endif // !WINDOW_H
