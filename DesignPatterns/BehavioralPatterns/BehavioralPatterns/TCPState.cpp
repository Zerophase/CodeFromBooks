#include "TCPState.h"
#include "TCPConnection.h"

void TCPState::Transmit(TCPConnection *c, TCPOctetStream *o)
{

}

void TCPState::ActiveOpen(TCPConnection *c)
{
	c->ActiveOpen();
}

void TCPState::PassiveOpen(TCPConnection *c)
{
	c->PassiveOpen();
}

void TCPState::Close(TCPConnection *c)
{
	c->Close();
}

void TCPState::Synchronize(TCPConnection *c)
{
	c->Synchronize();
}

void TCPState::Acknowledge(TCPConnection *c)
{
	c->Acknowledge();
}

void TCPState::Send(TCPConnection *c)
{
	c->Send();
}

void TCPState::ChangeState(TCPConnection *c, TCPState *s)
{
	c->ChangeState(s);
}