#ifndef TEXTMANIPULATOR_H
#define TEXTMANIPULATOR_H

#include "Manipulator.h"
#include "Shape.h"

class TextManipulator : public Manipulator
{
	public:
		TextManipulator(const Shape &textShape);
};

#endif // !TEXTMANIPULATOR_H
