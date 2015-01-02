#include "TCPEstablished.h"
#include "TCPListen.h"
#include "TCPClosed.h"
#include "TCPConnection.h"

TCPState *TCPEstablished::Instance()
{
	static TCPEstablished *instance;
	return instance;
}

void TCPEstablished::Close(TCPConnection *t)
{
	// send FIN, receive ACK of FIN

	ChangeState(t, TCPListen::Instance());
}

void TCPEstablished::Transmit(TCPConnection *t, TCPOctetStream *o)
{
	t->ProccessOctet(o);
}