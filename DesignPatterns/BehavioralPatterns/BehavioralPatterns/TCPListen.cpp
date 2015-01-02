#include "TCPListen.h"
#include "TCPClosed.h"
#include "TCPEstablished.h"
#include "TCPConnection.h"

TCPState *TCPListen::Instance()
{
	static TCPListen *instance;
	return instance;
}

void TCPListen::Send(TCPConnection *t)
{
	// send SYN, receive SYN, ACK, etc

	ChangeState(t, TCPEstablished::Instance());
}