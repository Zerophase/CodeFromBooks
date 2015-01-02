#ifndef TCP_CONNECTION_H
#define TCP_CONNECTION_H

class TCPOctetStream;
class TCPState;

class TCPConnection
{
public:
	TCPConnection();

	void ActiveOpen();
	void PassiveOpen();
	void Close();

	void Send();
	void Acknowledge();
	void Synchronize();

	void ProccessOctet(TCPOctetStream*);

private:
	friend class TCPState;
	void ChangeState(TCPState*);

private:
	TCPState *_state;
};
#endif // !TCP_CONNECTION_H
