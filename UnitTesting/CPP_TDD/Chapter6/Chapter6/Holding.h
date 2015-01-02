#ifndef HOLDING_H
#define HOLDING_H

#include "PurchaseRecord.h"
#include <vector>
#include <numeric>

class Holding
{
public:

	void Add(PurchaseRecord &record);
	std::vector<PurchaseRecord> Purchases() const;
	int ShareCount() const;

private:
	std::vector<PurchaseRecord> purchaseRecords;
};

#endif // !HOLDING_H