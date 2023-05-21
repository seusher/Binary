# Binary Addition

[![.NET](https://github.com/seusher/Binary/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/seusher/Binary/actions/workflows/dotnet.yml)

## Truth Table

`Cin` = carry in  
`A` = binary digit of 1st number  
`B` = binary digit of 2nd number  
`Sum` = sum of `Cin` + `A` + `B`  
`Cout` = carry out

| Cin | A | B | Sum | Cout |
|-----|---|---|-----|------|
| 0   | 0 | 0 | 0   | 0    |
| 0   | 0 | 1 | 1   | 0    |
| 0   | 1 | 0 | 1   | 0    |
| 0   | 1 | 1 | 0   | 1    |
| 1   | 0 | 0 | 1   | 0    |
| 1   | 0 | 1 | 0   | 1    |
| 1   | 1 | 0 | 0   | 1    |
| 1   | 1 | 1 | 1   | 1    |

## Lookup Tables

### Sum

The output of sum in the table shows that the lookup table is equivalent to: `0b10010110`

### Carry (out)

The output of carr (out) in the table shows that the lookup table is equivalent to: `0b11101000`
