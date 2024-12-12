using LogicLibrary.Implementations;

namespace LogicLibrary.Interfaces
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(Order order);

    }
}
