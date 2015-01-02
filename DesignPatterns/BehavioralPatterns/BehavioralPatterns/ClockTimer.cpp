#include "ClockTimer.h"

ClockTimer::ClockTimer()
{

}

int ClockTimer::GetHour()
{
	return 1;
}

int ClockTimer::GetMinute()
{
	return 1;
}

int ClockTimer::GetSecond()
{
	return 1;
}

void ClockTimer::Tick()
{
	// Update internal time keeping state

	Notify();
}