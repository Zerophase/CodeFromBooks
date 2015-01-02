#ifndef COORD_H
#define COORD_H

class Coord
{
	public:
		Coord(float x = 0.0f, float y = 0.0f);
		float GetX();
		float GetY();
		void SetX(float x);
		void SetY(float y);

		friend Coord operator+(const Coord &c1, const Coord &c2);
	private:
		float x;
		float y;
};

#endif // !COORD_H
