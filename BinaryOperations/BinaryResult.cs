namespace BinaryOperations;

public struct BinaryResult
{
    // The Value of the result
    public int Value {get; init;}

    // If the operation resulted in an overflow
    public int OverUnderflow {get; init;}

}