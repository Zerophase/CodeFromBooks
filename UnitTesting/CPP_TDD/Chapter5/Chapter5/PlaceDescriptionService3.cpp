#include "stdafx.h"
#include "PlaceDescriptionService3.h"
#include "Http.h"
#include "AddressExtractor.h"
#include "Address.h"
#include "CurrlHttp.h"
#include <string>

using namespace std;

// good for legacy code testing if used sparingly.
// initializes overridable getter
PlaceDescriptionService3::PlaceDescriptionService3()
	: http_{ make_shared<CurlHttp>() }
{
}
// ...

string PlaceDescriptionService3::summaryDescription(
	const string& latitude, const string& longitude) const
{
	auto request = createGetRequestUrl(latitude, longitude);
	auto response = get(request);
	return summaryDescription(response);
}

string PlaceDescriptionService3::summaryDescription(
	const string& response) const
{
	AddressExtractor extractor;
	auto address = extractor.addressFrom(response);
	return address.summaryDescription();
}

string PlaceDescriptionService3::get(const string& url) const
{
	auto http = httpService();
	http->initialize();
	return http->get(url);
}

shared_ptr<Http> PlaceDescriptionService3::httpService() const
{
	// returns overrideable getter
	return http_;
}

string PlaceDescriptionService3::createGetRequestUrl(
	const string& latitude, const string& longitude) const
{
	string server{ "http://open.mapquestapi.com/" };
	string document{ "nominatim/v1/reverse" };
	return server + document + "?" +
		keyValue("format", "json") + "&" +
		keyValue("lat", latitude) + "&" +
		keyValue("lon", longitude);
}

string PlaceDescriptionService3::keyValue(
	const string& key, const string& value) const
{
	return key + "=" + value;
}
