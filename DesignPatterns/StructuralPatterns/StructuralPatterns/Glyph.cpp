#include "Glyph.h"
#include "Window.h"
#include "GlyphContext.h"
#include "Font.h"

Glyph::Glyph()
{

}

Glyph::~Glyph()
{

}

void Glyph::Draw(Window *window, GlyphContext &glyphContext)
{

}

void Glyph::SetFont(Font *font, GlyphContext &glyphContext)
{

}

void Glyph::Next(GlyphContext &glyphContext)
{

}

void Glyph::IsDone(GlyphContext &glyphContext)
{

}

Glyph *Glyph::Current(GlyphContext &glyphContext)
{
	return new Glyph;
}

void Glyph::Insert(Glyph *glyph, GlyphContext &glyphContext)
{

}

void Glyph::Remove(GlyphContext &glyphContext)
{

}