#ifndef TEXTSHAPEOBJECTADAPTER_H
#define TEXTSHAPEOBJECTADAPTER_H

#include "Shape.h"
#include "TextView.h"
#include "TextManipulator.h"

class TextShapeObjectAdapter : public Shape
{
	public:
		TextShapeObjectAdapter(TextView *textView);

		virtual void BoundingBox(
			Point &bottomLeft, Point &topRight) const;
		virtual bool IsEmpty() const;
		virtual Manipulator *CreateManipulator() const;

	private:
		TextView *text;
};
#endif // !TEXTSHAPEOBJECTADAPTER_H
