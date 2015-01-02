#ifndef TCPESTABLISHED_H
#define TCPESTABLISHED_H

#include "TCPState.h"

class TCPEstablished : public TCPState
{
public:
	static TCPState *Instance();

	virtual void Transmit(TCPConnection*, TCPOctetStream*);
	virtual void Close(TCPConnection*);
};
#endif // !TCPESTABLISHED_H
