#ifndef PORTFOLIO_H
#define PORTFOLIO_H

#include <string>
#include <exception>
#include <unordered_map>
#include <vector>
#include "boost\date_time\gregorian\gregorian_types.hpp"
#include "Holding.h"
#include "PurchaseRecord.h"

class InvalidPurchaseException : std::exception
{

};

class InsufficentSharesException : std::exception
{

};

class ShareCountCannotBeZeroException : std::exception
{

};



class Portfolio
{
public:
	bool IsEmpty() const;

	void Purchase(const std::string &symbol, int shareCount, 
		const boost::gregorian::date &transactionDate);
	void Sell(const std::string &symbol, int shareCount, 
		const boost::gregorian::date &transactionDate);
	
	int ShareCount(const std::string &symbol) const;
	std::vector<PurchaseRecord> Purchases(const std::string &symbol) const;
private:
	void transact(const std::string &symbol, int shareChange,
		const boost::gregorian::date &date);
	void throwIfShareCountIsZero(int shareChange) const;
	void addPurchaseRecord(const std::string &symbol, int shareCount, const boost::gregorian::date &date);

	bool containsSymbol(const std::string &symbol) const;
	void initializePurchaseRecords(const std::string &symbol);
	void add(const std::string &symbol, PurchaseRecord &&record);

	template<typename T>
	T Find(std::unordered_map<std::string, T> map, const std::string &key) const
	{
		auto it = map.find(key);
		return it == map.end() ? T{} : it->second;
	}

	std::unordered_map<std::string, Holding> holdings_;
};

#endif // !PORTFOLIO_H



