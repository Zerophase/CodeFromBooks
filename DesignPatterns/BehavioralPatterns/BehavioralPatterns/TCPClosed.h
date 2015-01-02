#ifndef TCPCLOSED_H
#define TCPCLOSED_H

#include "TCPState.h"

class TCPClosed : public TCPState
{
public:
	static TCPState *Instance();

	virtual void ActiveOpen(TCPConnection*);
	virtual void PassiveOpen(TCPConnection*);
	// ...
};
#endif // !TCPCLOSED_H
