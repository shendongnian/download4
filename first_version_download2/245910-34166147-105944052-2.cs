    [TestCase(1, 1)]
    [TestCase(10, 5, 1, 4)]
    [TestCase(25, 3, 5, 5, 12)]
    public void Linq_Add_ShouldSumAllTheNumbers(int expected, params int[] numbers)
    {
        var result = numbers.Sum();
        Assert.AreEqual(expected, result);
    }
