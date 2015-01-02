#ifndef HTTP_FACTORY_H
#define HTTP_FACTORY_H

#include <memory>
#include "Http.h"

class HttpFactory
{
public:
	HttpFactory();
	std::shared_ptr<Http> get();
	void setInstance(std::shared_ptr<Http>);
	void reset();
	
private:
	std::shared_ptr<Http> instance;
};

#endif // !HTTP_FACTOR_H



