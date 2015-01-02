#ifndef COMPOSITION_H
#define COMPOSITION_H

class Compositor;
class Component;

class Composition
{
public:
	Composition(Compositor*);
	void Repair();

private:
	Compositor *_compositor;
	Component *_components; // the list of components
	int _componentCount; // the number of components
	int _lineWidth; // the composition's line width
	int *_linBreaks; // the position of linebreaks in components

	int _lineCount; // the number of lines
};
#endif // !COMPOSITION_H
