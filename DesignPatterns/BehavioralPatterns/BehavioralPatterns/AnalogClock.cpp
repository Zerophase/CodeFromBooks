#include "AnalogClock.h"
#include "ClockTimer.h"

AnalogClock::AnalogClock(ClockTimer *s)
	:Widget(this)
{ 
	_Subject = s;
	_Subject->Attach(this);
}

AnalogClock::~AnalogClock()
{
	_Subject->Detach(this);
}

void AnalogClock::Update(Subject *theChangedSubject)
{
	if (theChangedSubject == _Subject)
		Draw();
}

void AnalogClock::Draw()
{
	int hour = _Subject->GetHour();
	int minute = _Subject->GetMinute();
	int second = _Subject->GetSecond();

	// Draw the Analog clock
}