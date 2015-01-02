#ifndef CHARACTER_H
#define CHARACTER_H

#include "Glyph.h"
#include "Window.h"

class Character : public Glyph
{
public:
	Character(char character);

	virtual void Draw(Window *window, GlyphContext &glyphContext);
private:
	char charCode;
};
#endif // !CHARACTER_H
