#ifndef GLYPHFACTORY_H
#define GLYPHFACTORY_H

class Character;
class Row;
class Column;

const int NCHARCODES = 128;

class GlyphFactory
{
public:
	GlyphFactory();
	virtual ~GlyphFactory();

	virtual Character *CreateCharacter(char character);
	virtual Row *CreateRow();
	virtual Column *CreateColumn();
	//...
private:
	Character *character[NCHARCODES];
};
#endif // !GLYPHFACTORY_H
