#ifndef PLACE_DESCRIPTION_SERVICE_2_H
#define PLACE_DESCRIPTION_SERVICE_2_H
#include <string>
#include <memory>

#include "Address.h"

class Http;

// good for legacy code testing if used sparingly.
class PlaceDescriptionService2
{
public:
	virtual ~PlaceDescriptionService2() {}
	// ...
	std::string summaryDescription(
		const std::string& latitude, const std::string& longitude) const;

private:
	std::string createGetRequestUrl(
		const std::string& latitude, const std::string& longitude) const;
	std::string summaryDescription(const Address& address) const;
	std::string keyValue(
		const std::string& key, const std::string& value) const;
	std::string get(const std::string& requestUrl) const;
	std::string summaryDescription(const std::string& response) const;

protected:
	// factory method
	virtual std::shared_ptr<Http> httpService() const;
};

#endif // !PLACE_DESCRIPTION_SERVICE_2_H



