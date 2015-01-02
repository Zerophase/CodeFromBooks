#include "stdafx.h"
#include "Holding.h"

using namespace std;
void Holding::Add(PurchaseRecord &record)
{
	purchaseRecords.push_back(record);
}

vector<PurchaseRecord> Holding::Purchases() const
{
	return purchaseRecords;
}

int Holding::ShareCount() const
{
	return std::accumulate(purchaseRecords.begin(), purchaseRecords.end(), 0,
		[](int total, PurchaseRecord record) { return total + record.ShareCount; });
}
