# Cython

Cython is a simple Python-like interpreter implemented in C#.

# Features
- All data types are implemented from scratch 
 - Works as a single command line interpreter
 ```
 >>>x="hello world"
 >>>x
 >>>'hello world'
  ```
  - Works as an interpreter of a whole Cython file with multi-line commands
  ```
  C:\Users\User>cython.exe program.cy
  C:\Users\User>hello world
  ```

## Data Types
### Primitive Types
- int
- float
- bool
### Collections
- CArray (dynamic array)
- CList
- CSet
- CDictionary
- CStack
- CQueue

## Special Types
- complex (complex numbers)
- DateTime

## UnitTests
- There are unit-tests for every datatype


