#ifndef CONSTRAINT_SOLVER_H
#define CONSTRAINT_SOLVER_H

class Graphic;
class ConstraintSolverMemento;

class ConstraintSolver
{
public:
	static ConstraintSolver *Instance();

	void Solve();
	void AddConstraint(Graphic *startConnection, Graphic *endConnection);
	void RemoveConstraint(Graphic *startConnection, Graphic *endConnection);

	ConstraintSolverMemento *CreateMemento();
	void SetMemento(ConstraintSolverMemento*);

private:
	// Nontrivial state and operation for enforcing connectivity semantics
};
#endif // !CONSTRAINT_SOLVER_H
