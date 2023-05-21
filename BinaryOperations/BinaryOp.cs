namespace BinaryOperations;

/// <summary>
/// Contains methods for operations on binary data.
/// </summary>
public static class BinaryOp
{
        /// <summary>
        /// The max number of bit positions to iterate over.
        /// </summary>
        private const int MaxBits = 32;

        /// <summary>
        /// Lookup table for what the sum of 3 binary digits should be
        /// </summary>
        private const int SumLtb = 0b10010110;

        /// <summary>
        /// Lookup table for what the carry of 3 binary digits should be
        /// </summary>
        private const int CarryOutLtb = 0b11101000;
        
        /// <summary>
        /// Add two 32-bit numbers.
        /// Supports both positive and negative numbers (and any combination of the two).
        /// </summary>
        /// <param name="a">The first operand to add</param>
        /// <param name="b">The second operand to add</param>
        /// <returns>A result indicating the value and whether there was an over/underflow</returns>
        public static BinaryResult Add(int a, int b) {

            // Carry in. Used in the calculation.
            int cin = 0;

            // Carry out. Tracks if the calculation resulted in a carry.
            int cout = 0;

            // Accumulator. Holds the value of the addition.
            int acc = 0;

            // Tracks the number of bits we've added
            int targetBit = 0;

            while (targetBit < MaxBits)
            {
                cin = cout;

                // Build the values in the README.md lookup tables
                // Shift each component right based on the target bit.
                // Mask off all bits other than the 0th bit.
                // Move the bits into the right position.
                // lookupIndex ends up being `00000000000000000000000000000CAB`
                int lookupIndex = (cin << 2) | (a >> targetBit & 1) << 1 | (b >> targetBit & 1) << 0;

                // Look up the correct sum value and throw away anything but the 0th digit.
                // Make sure to place the sum digit at the correct location in the accumulator.
                acc |= ((SumLtb >> lookupIndex) & 1) << targetBit;

                // Look up the correct carry value and throw away anything but the 0th digit.
                cout = (CarryOutLtb >> lookupIndex) & 1;

                // Increment to move to the next bit position in the binary number.
                targetBit++;

            }

            // We know we've over/underflowed if the previous cin doesn't match the cout when we've finished.
            var of = cin ^ cout;

            return new BinaryResult {
                Value = acc,
                OverUnderflow = of
            };
        }
}
