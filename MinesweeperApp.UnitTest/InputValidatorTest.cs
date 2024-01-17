using MinesweeperApp.Models;
using MinesweeperApp.Utilities;
namespace MinesweeperApp.UnitTest;

[TestClass]
public class InputValidatorTest
{
    private InputValidator _inputValidator;

    public InputValidatorTest()
    {
        _inputValidator = new InputValidator();
    }

    [DataTestMethod]
    [DataRow("3")]
    [DataRow("26")]
    [DataRow("5")]
    [DataRow("20")]
    public void Validate_Correct_Positive_Number(string input)
    {
        int num;
        bool result = _inputValidator.ValidatePositiveNumber(input, out num);
        Assert.AreEqual(result, true);
    }

    [DataTestMethod]
    [DataRow("-1")]
    [DataRow("0")]
    [DataRow(" ")]
    [DataRow("A")]
    public void Validate_Error_Positive_Number(string input)
    {
        int num;
        bool result = _inputValidator.ValidatePositiveNumber(input, out num);
        Assert.AreEqual(result, false);
    }

    [DataTestMethod]
    [DataRow(8)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(26)]
    public void Validate_Correct_Size(int size)
    {
        bool result = _inputValidator.ValidateSize(size);
        Assert.AreEqual(result, true);
    }

    [DataTestMethod]
    [DataRow(2)]
    [DataRow(0)]
    [DataRow(100)]
    [DataRow(27)]
    public void Validate_Error_Size(int size)
    {
        bool result = _inputValidator.ValidateSize(size);
        Assert.AreEqual(result, false);
    }

    [DataTestMethod]
    [DataRow(2, 8)]
    [DataRow(1, 3)]
    [DataRow(3, 4)]
    [DataRow(10, 26)]
    public void Validate_Correct_Mine_Count(int count, int size)
    {
        bool result = _inputValidator.ValidateMineCount(count, size);
        Assert.AreEqual(result, true);
    }

    [DataTestMethod]
    [DataRow(100, 8)]
    [DataRow(5, 3)]
    [DataRow(16, 4)]
    [DataRow(240, 26)]
    public void Validate_Error_Mine_Count(int count, int size)
    {
        bool result = _inputValidator.ValidateMineCount(count, size);
        Assert.AreEqual(result, false);
    }

    [DataTestMethod]
    [DataRow("A1", 8)]
    [DataRow("C3", 3)]
    [DataRow("B2", 4)]
    [DataRow("S24", 26)]
    public void Validate_Correct_Cell(string input, int size)
    {
        Location loc;
        bool result = _inputValidator.ValidateCell(input, size, out loc);
        Assert.AreEqual(result, true);
    }

    [DataTestMethod]
    [DataRow("0", 8)]
    [DataRow("A7", 3)]
    [DataRow("", 4)]
    [DataRow("ABC", 26)]
    public void Validate_Error_Cell(string input, int size)
    {
        Location loc;
        bool result = _inputValidator.ValidateCell(input, size, out loc);
        Assert.AreEqual(result, false);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(9)]
    public void Validate_Hidden_Cell(int cellValue)
    {
        bool result = _inputValidator.ValidateHiddenCellValue(cellValue);
        Assert.AreEqual(result, true);
    }

    [DataTestMethod]
    [DataRow(-10)]
    [DataRow(-1)]
    [DataRow(-2)]
    [DataRow(-3)]
    public void Validate_Shown_Cell(int cellValue)
    {
        bool result = _inputValidator.ValidateHiddenCellValue(cellValue);
        Assert.AreEqual(result, false);
    }
}