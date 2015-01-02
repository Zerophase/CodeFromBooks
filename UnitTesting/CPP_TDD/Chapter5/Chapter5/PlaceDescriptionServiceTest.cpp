#include "stdafx.h"

#include "gmock\gmock.h"
#include "Http.h"
#include "PlaceDescriptionService.h"
#include "PlaceDescriptionService2.h"
#include "PlaceDescriptionService3.h"
#include "PlaceDesciptionService4.h"
#include "PlaceDescriptionServiceTemplate.h"
#include "HttpFactory.h"
#include <string>

using namespace testing;
using namespace std;

class APlaceDescriptionService : public Test
{
public:
	static const string ValidLatitude;
	static const string ValidLongitude;
};

const string APlaceDescriptionService::ValidLatitude("38.005");
const string APlaceDescriptionService::ValidLongitude("-104.44");

// How to make a stub / mock in c++
// currently does so much that it is a mock. 
// Stub just stands in, while mock replaces object actions.
class HttpStub : public Http
{
public:
	string returnResponse;
	string expectedUrl;
	void initialize() override {};
	std::string get(const std::string &url) const override
	{
		verify(url);
		return returnResponse;
	}

	void verify(const string &url) const
	{
		string urlStart(
			"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&");
		string expected(urlStart +
			"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
			"lon=" + APlaceDescriptionService::ValidLongitude);
		ASSERT_THAT(url, Eq(expectedUrl));
	}
};

// Using Mock Tool
class HttpStubWithMockTool : public Http
{
public:
	MOCK_METHOD0(initialize, void());
	MOCK_CONST_METHOD1(get, string(const string &));
};

// using custom made mock
TEST_F(APlaceDescriptionService, ReturnsDescriptionForValidLocation)
{
	HttpStub httpStub;
	httpStub.returnResponse = R"({ "address": {
									 "road":"Drury Ln",
									 "city":"Fountain",
									 "state":"CO",
									 "country":"US" }})";
	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };
	httpStub.expectedUrl = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;
	PlaceDescriptionService service(&httpStub);

	auto description = service.summaryDescription(ValidLatitude, ValidLongitude);

	ASSERT_THAT(description, Eq("Drury Ln, Fountain, CO, US"));
}

// using mock tool
TEST_F(APlaceDescriptionService, MakesHttpRequestToObtainAddress)
{
	// Makes sure the order of method calls with mocks matter
	// Read Google Mock Docs code.google.com/p/googlemock/wiki/CheatSheet#Expectation_Order
	// for more on on expectations on method call orders.  After() says a call is supposed to come after
	// another call. An ordered list of expected method calls may also be defined.
	InSequence forceExpectationOrder;
	HttpStubWithMockTool httpStubWithMockTool;
	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };
	auto expectedUrl = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;

	// Configures GoogleMock to verify that message get() method gets sent to
	// the httpStubWithMockTool object with an argument that matches expectedUrl.
	// Mock::VerifyAndClearExpectation(&httpStubWithMockTool) would insure the verification
	// gets run before the object goes out of scope.
	EXPECT_CALL(httpStubWithMockTool, initialize());
	EXPECT_CALL(httpStubWithMockTool, get(expectedUrl));
	PlaceDescriptionService service(&httpStubWithMockTool);

	service.summaryDescription(ValidLatitude, ValidLongitude);
}

TEST_F(APlaceDescriptionService, FormatsRetrieveAddressIntoSUmmaryDescription)
{
	// wrapping Framework created mock in NiceMock removes warnings for additional method calls.
	// wrapping in StrictMock turns Warning call into an error.
	// prefer fixing design and use of StrictMock to not cover up potential errors from refactoring.
	NiceMock<HttpStubWithMockTool> httpStubWithMockTool;
										// _ is the wild card matcher in Google Mocks
	EXPECT_CALL(httpStubWithMockTool, get(_))
		.WillOnce(Return(
					R"({ "address": {
						  "road":"Drury Ln",
						  "city":"Fountain",
						  "state":"CO",
						  "country":"US" }})"));
	PlaceDescriptionService service(&httpStubWithMockTool);

	auto description = service.summaryDescription(ValidLatitude, ValidLongitude);

	ASSERT_THAT(description, Eq("Drury Ln, Fountain, CO, US"));
}

// With Factory method constructor injection
class PlaceDescriptionService_StubHttpService : public PlaceDescriptionService2
{
public:
	PlaceDescriptionService_StubHttpService(shared_ptr<HttpStubWithMockTool> httpStubWithMockTool) 
		: httpStubWithMockTool_(httpStubWithMockTool)
	{
	}
	shared_ptr<Http> httpService() const override { return httpStubWithMockTool_; }
	shared_ptr<Http> httpStubWithMockTool_;
};

TEST_F(APlaceDescriptionService, MakesHttpRequestToObtatainAddressWithFactoryMethod)
{
	InSequence forceExpectationOrder;
	shared_ptr<HttpStubWithMockTool> httpStubWithMockTool(new HttpStubWithMockTool);

	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };

	auto expectedURL = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;

	EXPECT_CALL(*httpStubWithMockTool, initialize());
	EXPECT_CALL(*httpStubWithMockTool, get(expectedURL));
	PlaceDescriptionService_StubHttpService service(httpStubWithMockTool);

	service.summaryDescription(ValidLatitude, ValidLongitude);
}

// With overridable getter

class PlaceDescriptionService_StubHttpServiceGetter : public PlaceDescriptionService3
{
public:
	PlaceDescriptionService_StubHttpServiceGetter(shared_ptr<HttpStubWithMockTool> httpStub)
		: httpStub_{ httpStub }
	{
	}
	shared_ptr<Http> httpService() const override { return httpStub_; }
	shared_ptr<Http> httpStub_;
};

TEST_F(APlaceDescriptionService, MakesHttpRequestToObtationAddressWithOverridenGetter)
{
	InSequence forceExpectationOrder;
	shared_ptr<HttpStubWithMockTool> httpStubWithMockTool(new HttpStubWithMockTool);

	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };

	auto expectedURL = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;

	EXPECT_CALL(*httpStubWithMockTool, initialize());
	EXPECT_CALL(*httpStubWithMockTool, get(expectedURL));
	PlaceDescriptionService_StubHttpServiceGetter service(httpStubWithMockTool);

	service.summaryDescription(ValidLatitude, ValidLongitude);
}


// using factory method for injector construction
// Only use if there is a legitimate use for a factory class.
class AplaceDescriptionServiceWithFactoryClass : public Test
{
public:
	static const string ValidLatitude;
	static const string ValidLongitude;

	shared_ptr<HttpStubWithMockTool> httpStub;
	shared_ptr<HttpFactory> factory;
	shared_ptr<PlaceDescriptionService4> service;

	virtual void SetUp() override
	{
		factory = make_shared<HttpFactory>();
		service = make_shared<PlaceDescriptionService4>(factory);
	}

	void TearDown() override
	{
		factory.reset();
		httpStub.reset();
	}
};

const string AplaceDescriptionServiceWithFactoryClass::ValidLatitude("38.005");
const string AplaceDescriptionServiceWithFactoryClass::ValidLongitude("-104.44");

class APlaceDescriptionServiceWithFactory_WithHttpMock : public AplaceDescriptionServiceWithFactoryClass
{
	void SetUp() override
	{
		AplaceDescriptionServiceWithFactoryClass::SetUp();
		httpStub = make_shared<HttpStubWithMockTool>();
		factory->setInstance(httpStub);
	}
};

TEST_F(APlaceDescriptionServiceWithFactory_WithHttpMock, MakesHttpRequestToObtainAddress)
{
	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };
	auto expectedURL = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;
	EXPECT_CALL(*httpStub, initialize());
	EXPECT_CALL(*httpStub, get(expectedURL));

	service->summaryDescription(ValidLatitude, ValidLongitude);
}

// Testing with template class design
// Best constrained to legacy situations when a template already exists.
class APlaceDescriptionServiceTemplate_WithHttpMock : public APlaceDescriptionService
{
public:
	PlaceDescriptionServiceTemplate<HttpStubWithMockTool> service;
};

TEST_F(APlaceDescriptionServiceTemplate_WithHttpMock, MakesHttpRequestToObtationAddress)
{
	string urlStart{
		"http://open.mapquestapi.com/nominatim/v1/reverse?format=json&" };
	auto expectedURL = urlStart +
		"lat=" + APlaceDescriptionService::ValidLatitude + "&" +
		"lon=" + APlaceDescriptionService::ValidLongitude;
	EXPECT_CALL(service.http(), initialize());
	EXPECT_CALL(service.http(), get(expectedURL));

	service.summaryDescription(ValidLatitude, ValidLongitude);
}