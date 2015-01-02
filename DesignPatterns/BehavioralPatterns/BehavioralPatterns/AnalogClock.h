#ifndef ANALOG_CLOCK_H
#define ANALOG_CLOCK_H

#include "Widget.h"
#include "Observer.h"

class ClockTimer;
class Subject;

class AnalogClock : public Widget, public Observer
{
public:
	AnalogClock(ClockTimer*);
	virtual ~AnalogClock();

	virtual void Update(Subject*);
	virtual void Draw();

private:
	ClockTimer *_Subject;
};
#endif // !ANALOG_CLOCK_H
