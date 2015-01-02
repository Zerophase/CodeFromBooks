#ifndef SCANNER_H
#define SCANNER_H

using namespace std;
#include <istream>

class Token;

class Scanner
{
public:
	Scanner(istream &input);
	virtual ~Scanner();

	virtual Token &Scan();
private:
	istream &inputStream;
};
#endif // !SCANNER_H
