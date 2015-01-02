#include "TCPClosed.h"
#include "TCPEstablished.h"
#include "TCPListen.h"
#include "TCPConnection.h"

TCPState *TCPClosed::Instance()
{
	static TCPClosed *instance;
	return instance;
}

void TCPClosed::ActiveOpen(TCPConnection *t)
{
	// Send SYN, receive SYN, ACk, etc

	ChangeState(t, TCPEstablished::Instance());
}

void TCPClosed::PassiveOpen(TCPConnection *t)
{ 
	ChangeState(t, TCPListen::Instance());
}