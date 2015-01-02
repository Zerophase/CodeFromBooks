#include "TextShapeObjectAdapter.h"

TextShapeObjectAdapter::TextShapeObjectAdapter(TextView *textView)
{
	text = textView;
}

void TextShapeObjectAdapter::BoundingBox(
	Point &bottomLeft, Point &topRight) const
{
	Coord bottom, left, width, height;

	text->GetOrigin(bottom, left);
	text->GetExtent(width, height);

	bottomLeft = Point(bottom, left);
	topRight = Point(bottom + height, left + width);
}

bool TextShapeObjectAdapter::IsEmpty() const
{
	return text->IsEmpty();
}

Manipulator *TextShapeObjectAdapter::CreateManipulator() const
{
	//See if this will work without *.
	return new TextManipulator(*this);
}