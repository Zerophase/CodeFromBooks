#ifndef VIEW_H
#define VIEW_H

class View
{
public:
	View();
	void Display();

	void SetFocus();
	virtual void DoDisplay() = 0;
	void ResetFocus();
};
#endif // !VIEW_H
