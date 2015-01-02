#include "stdafx.h"
#include "PlaceDesciptionService4.h"
#include "Http.h"
#include "AddressExtractor.h"
#include "Address.h"
#include "HttpFactory.h"
#include <string>

using namespace std;

PlaceDescriptionService4::PlaceDescriptionService4(shared_ptr<HttpFactory> httpFactory)
	: httpFactory_{ httpFactory }
{
}

string PlaceDescriptionService4::summaryDescription(
	const string& latitude, const string& longitude) const
{
	auto request = createGetRequestUrl(latitude, longitude);
	auto response = get(request);
	return summaryDescription(response);
}

string PlaceDescriptionService4::summaryDescription(
	const string& response) const
{
	AddressExtractor extractor;
	auto address = extractor.addressFrom(response);
	return address.summaryDescription();
}

string PlaceDescriptionService4::get(const string& url) const
{
	// gets http instance from injected factory
	auto http = httpFactory_->get();
	http->initialize();
	return http->get(url);
}

string PlaceDescriptionService4::createGetRequestUrl(
	const string& latitude, const string& longitude) const
{
	string server{ "http://open.mapquestapi.com/" };
	string document{ "nominatim/v1/reverse" };
	return server + document + "?" +
		keyValue("format", "json") + "&" +
		keyValue("lat", latitude) + "&" +
		keyValue("lon", longitude);
}

string PlaceDescriptionService4::keyValue(
	const string& key, const string& value) const
{
	return key + "=" + value;
}
