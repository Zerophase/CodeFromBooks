#include "GlyphFactory.h"
#include "Row.h"
#include "Column.h"
#include "Character.h"

GlyphFactory::GlyphFactory()
{
	for (int i = 0; i < NCHARCODES; ++i)
	{
		character[i] = 0;
	}
}

GlyphFactory::~GlyphFactory()
{

}

Character *GlyphFactory::CreateCharacter(char character)
{
	if (!this->character[character])
		this->character[character] = new Character(character);

	return this->character[character];
}

Row *GlyphFactory::CreateRow()
{
	return new Row;
}

Column *GlyphFactory::CreateColumn()
{
	return new Column;
}