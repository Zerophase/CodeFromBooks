#include "Composition.h"
#include "Coord.h"
#include "Compositor.h"

Composition::Composition(Compositor *c)
{
	_compositor = c;
}

void Composition::Repair()
{
	Coord *natural;
	Coord *stretchability;
	Coord *shrinkability;
	int componentCount;
	int *breaks;

	// prepare the array with desired component sizes
	natural = new Coord[2] {Coord(), Coord()};
	stretchability = new Coord[2] {Coord(), Coord()};
	shrinkability = new Coord[2] {Coord(), Coord()};
	componentCount = 1;
	breaks = new int[2]{1, 2};

	int breakCount;
	breakCount = _compositor->Compose(natural, stretchability, shrinkability,
		componentCount, _lineWidth, breaks);

	// layout components according to breaks
}