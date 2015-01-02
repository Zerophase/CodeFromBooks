#ifndef TCPLISTEN_H
#define TCPLISTEN_H

#include "TCPState.h"

class TCPListen : public TCPState
{
public:
	static TCPState *Instance();

	virtual void Send(TCPConnection*);
	// ...
};
#endif // !TCPLISTEN_H
