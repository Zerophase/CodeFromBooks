#ifndef PLACE_DESCRIPTION_SERVICE_3_H
#define PLACE_DESCRIPTION_SERVICE_3_H

#include <string>
#include <memory>
#include "Address.h"

class Http;

// good for legacy code testing if used sparingly.
class PlaceDescriptionService3
{
public:
	// allows ovverrideable getter
	PlaceDescriptionService3();
	virtual ~PlaceDescriptionService3() {}
	std::string summaryDescription(
		const std::string& latitude, const std::string& longitude) const;

private:
	// ...
	std::string createGetRequestUrl(
		const std::string& latitude, const std::string& longitude) const;
	std::string summaryDescription(const Address& address) const;
	std::string keyValue(
		const std::string& key, const std::string& value) const;
	std::string get(const std::string& requestUrl) const;
	std::string summaryDescription(const std::string& response) const;

	// for overrideable getter;
	std::shared_ptr<Http> http_;

protected:
	virtual std::shared_ptr<Http> httpService() const;
};

#endif // !PLACE_DESCRIPTION_SERVICE_3_H



