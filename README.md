# Учебный SAT solver

Библиотека для решения клоз в КНФ форме, основанная на алгоритме DPLL.

## Формат входных данных

Данные подаются в формате [DIMACS](https://logic.pdmi.ras.ru/~basolver/dimacs.html) через путь к файлу.

## Как использовать

```c#
var path = @"example.cnf";
SatAnswer ans = SATSolver.Solve(path);
// Ответ, если true, то "SAT", иначе -- "UNSAT"
bool sat = ans.SatOrNot;
// Список литералов, которые решают данную формулу. Пустой, если sat == false
List<int> solution = ans.Solution;
```
