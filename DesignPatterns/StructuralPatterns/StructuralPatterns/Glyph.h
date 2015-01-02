#ifndef GLYPH_H
#define GLYPH_H

class Window;
class GlyphContext;
class Font;

class Glyph
{
public:
	virtual ~Glyph();

	virtual void Draw(Window *window, GlyphContext &glyphContext);

	virtual void SetFont(Font *font, GlyphContext &glyphContext);
	virtual void Next(GlyphContext &glyphContext);
	virtual void IsDone(GlyphContext &glyphContext);
	virtual Glyph *Current(GlyphContext &glyphContext);

	virtual void Insert(Glyph *glyph, GlyphContext &glyphContext);
	virtual void Remove(GlyphContext &glyphContext);
protected:
	Glyph();
};
#endif // !GLYPH_H
