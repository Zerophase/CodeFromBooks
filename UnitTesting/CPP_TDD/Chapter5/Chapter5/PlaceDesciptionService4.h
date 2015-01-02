#ifndef PLACE_DESCRIPTION_SERVICE_4_H
#define PLACE_DESCIPTION_SERVICE_4_H

#include <string>
#include <memory>
#include "Address.h"
#include "HttpFactory.h"

class Http;

class PlaceDescriptionService4
{
public:
public:
	PlaceDescriptionService4(std::shared_ptr<HttpFactory> factory);
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

	std::shared_ptr<HttpFactory> httpFactory_;
};

#endif // !PLACE_DESCRIPTION_SERVICE_4_H



