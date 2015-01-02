#include "Window.h"

Window::Window(View *contents)
{

}

void Window::DrawContents()
{

}

void Window::Open()
{

}

void Window::Close()
{

}

void Window::Iconify()
{

}

void Window::Deiconify()
{

}

void Window::SetOrigin(const Point &at)
{

}

void Window::SetExtent(const Point &extent)
{

}

void Window::Raise()
{

}

void Window::Lower()
{

}

void Window::DrawLine(const Point &origin, const Point &end)
{

}

void Window::DrawRect(const Point &origin, const Point &end)
{
	WindowImp *imp = GetWindowImp();
	imp->DeviceRect(origin.X(), origin.Y(), end.X(), end.Y());
}

void Window::DrawPolygon(const Point points [], int pointCount)
{

}

void Window::DrawText(const char *character, const Point &origin)
{

}

WindowImp *Window::GetWindowImp()
{
	//if (imp == 0)
		//Assign imp an abstract factory pattern here.
	return imp;
}

View *Window::GetView()
{
	//return new View
	return contents;
}
