
# Order Management System

## Overview
The Order Management System is a console-based application that allows users to create and manage product orders. The system includes functionality to add products, remove products, view the current cart, and save the order details to a file. Discounts are applied based on business rules to provide dynamic pricing adjustments.

## Features
1. **Add Products**: Add products to the order with specified quantities.
2. **Remove Products**: Remove selected products from the order.
3. **View Cart**: Display the current items in the cart, including their quantities and total cost.
4. **Dynamic Discounts**:
   - **10% Discount**: Applies to the cheapest product in the cart (when applicable).
   - **20% Discount**: Applies to the second cheapest product in the cart (when applicable).
   - **5% Discount**: Additional discount applied to the total order value if it exceeds 5000 PLN.
5. **Save Order**: Export order details, including applied discounts, to a text file.
6. **Error Handling**: Validates user input to prevent invalid data, such as negative quantities or invalid product choices.

## Products
The system includes the following products:
- **Laptop**: 2500 PLN
- **Keyboard**: 120 PLN
- **Mouse**: 90 PLN
- **Monitor**: 1000 PLN
- **Debugging Duck**: 66 PLN

## Usage
1. **Run the application**:
   Execute the application from the command line or terminal.

2. **Follow the menu options**:
   - Add products by selecting their corresponding numbers and entering the desired quantities.
   - Remove products by selecting their corresponding numbers.
   - Save the order to a file, which includes all details of the current cart, the applied discounts, and the final total.

3. **Exit the application**:
   Select the "Exit" option to close the program.

## Business Rules
1. **Discount Rules**:
   - If there are only two products in the cart, a **10% discount** is applied to the cheaper product.
   - If there are three or more products, the system compares the benefits of:
     - A **20% discount** on the second cheapest product.
     - A **10% discount** on the cheapest product.
     The higher discount is applied.
   - An additional **5% discount** is applied to the total order value if it exceeds 5000 PLN.

2. **Input Validation**:
   - Ensures that quantities are positive integers.
   - Validates product selection to match available options.

## File Output
The order details, including the following information, are saved to a file:
- Order ID
- List of products with quantities and prices
- Total value of the order
- Applied discounts
- Final total after discounts

The file is saved in the current working directory with a name format: `Order_<OrderID>.txt`.

## Installation and Setup
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Build the solution using Visual Studio or .NET CLI:
   ```bash
   dotnet build
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Testing
Unit tests are included for the `DiscountCalculator` and other business logic components. To run tests:
```bash
dotnet test
```

## License
This project is licensed under the MIT License. See the LICENSE file for details.
