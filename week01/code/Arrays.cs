public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step plan:
        // 1. Create a new array of doubles with size equal to 'length'. This will hold our result.
        // 2. Loop through the array from index 0 to length - 1.
        // 3. For each index i, the value we want is 'number' multiplied by (i + 1).
        //    - When i = 0, we want the 1st multiple: number * 1
        //    - When i = 1, we want the 2nd multiple: number * 2
        //    - ...and so on, so the multiplier is always (i + 1)
        // 4. Store that computed value at index i in the result array.
        // 5. After the loop finishes, return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Create a temporary list to store the last 'amount' elements.
        // Step 2: Copy the last 'amount' elements into the temporary list.
        // Step 3: Remove those elements from the original list.
        // Step 4: Insert the temporary elements at the beginning of the original list.

        List<int> lastElements = data.GetRange(data.Count - amount, amount);

        data.RemoveRange(data.Count - amount, amount);

        data.InsertRange(0, lastElements);
    }
}
