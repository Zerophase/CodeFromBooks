#include "stdafx.h"
#include "Portfolio.h"

using namespace std;
using namespace boost::gregorian;

bool Portfolio::IsEmpty() const
{
	return 0 == holdings_.size();
}

void Portfolio::Purchase(const string &symbol, int shareCount,
	const date &transactionDate)
{
	transact(symbol, shareCount, transactionDate);
}

vector<PurchaseRecord> Portfolio::Purchases(const string &symbol) const
{
	return Find<Holding>(holdings_, symbol).Purchases();
}

void Portfolio::Sell(const string &symbol, int shareCount,
	const date &transactionDate)
{
	if (shareCount > ShareCount(symbol))
		throw InsufficentSharesException();

	transact(symbol, -shareCount, transactionDate);
}

void Portfolio::transact(const string &symbol, int shareChange,
	const date &date)
{
	throwIfShareCountIsZero(shareChange);
	addPurchaseRecord(symbol, shareChange, date);
}

void Portfolio::throwIfShareCountIsZero(int shareChange) const
{
	if (0 == shareChange)
		throw ShareCountCannotBeZeroException();
}

void Portfolio::addPurchaseRecord(const string &symbol, int shareCount, const date &date)
{
	if (!containsSymbol(symbol))
		initializePurchaseRecords(symbol);
	add(symbol, { shareCount, date });
}

bool Portfolio::containsSymbol(const std::string &symbol) const
{
	return holdings_.find(symbol) != holdings_.end();
}

void Portfolio::initializePurchaseRecords(const string &symbol)
{
	holdings_[symbol] = Holding();
}

void Portfolio::add(const string &symbol, PurchaseRecord &&record)
{
	holdings_[symbol].Add(record);
}

// this can be negative
int Portfolio::ShareCount(const string &symbol) const
{
	return Find<Holding>(holdings_, symbol).ShareCount();
}
