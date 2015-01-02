#include "stdafx.h"
#include "PlaceDescriptionService2.h"
#include "Http.h"
#include "AddressExtractor.h"
#include "Address.h"
#include "CurrlHttp.h"
#include <string>

using namespace std;

string PlaceDescriptionService2::summaryDescription(
	const string& latitude, const string& longitude) const
{
	auto request = createGetRequestUrl(latitude, longitude);
	auto response = get(request);
	return summaryDescription(response);
}

string PlaceDescriptionService2::summaryDescription(
	const string& response) const
{
	AddressExtractor extractor;
	auto address = extractor.addressFrom(response);
	return address.summaryDescription();
}

string PlaceDescriptionService2::get(const string& url) const
{
	auto http = httpService();
	http->initialize();
	return http->get(url);
}

// good for legacy code testing if used sparingly.
shared_ptr<Http> PlaceDescriptionService2::httpService() const
{
	// Make sure to not have any logic in factory method, or else
	// untested code will exist.
	return make_shared<CurlHttp>();
}

string PlaceDescriptionService2::createGetRequestUrl(
	const string& latitude, const string& longitude) const
{
	string server{ "http://open.mapquestapi.com/" };
	string document{ "nominatim/v1/reverse" };
	return server + document + "?" +
		keyValue("format", "json") + "&" +
		keyValue("lat", latitude) + "&" +
		keyValue("lon", longitude);
}

string PlaceDescriptionService2::keyValue(
	const string& key, const string& value) const
{
	return key + "=" + value;
}
