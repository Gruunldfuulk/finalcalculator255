namespace TheFinalCalculator.Models
{
    using System;
    using System.ComponentModel;

    public class Calculations : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Private members

        private string result;

        #endregion


        #region Constructors

        public Calculations(string firstOperand, string secondOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperand(secondOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
            result = string.Empty;
        }
        public Calculations(string firstOperand, string operation)
        {
            ValidateOperand(firstOperand);
            ValidateOperation(operation);

            FirstOperand = firstOperand;
            SecondOperand = string.Empty;
            Operation = operation;
            result = string.Empty;
        }

        public Calculations()
        {
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            result = string.Empty;
        }
        #endregion


        #region Public properties and methods

        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }
        public string Operation { get; set; }
        public string Result { get { return result; } }

        public void CalculateResult()
        {
            ValidateData();

            try
            {
                switch (Operation)
                {
                    case ("+"):
                        result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("-"):
                        result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("*"):
                        result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("/"):
                        result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;

                    case ("sin"):
                        result = Math.Sin(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;

                    case ("cos"):
                        result = Math.Cos(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;

                    case ("tan"):
                        result = Math.Tan(DegreeToRadian(Convert.ToDouble(FirstOperand))).ToString();
                        break;

                    case ("sqrt"):
                        result = Math.Sqrt(Convert.ToDouble(FirstOperand)).ToString();
                        break;

                    case ("sqr"):
                        result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(FirstOperand)).ToString();
                        break;

                    case ("%"):
                        result = (Convert.ToDouble(FirstOperand) * NumberToPrecent(Convert.ToDouble(SecondOperand))).ToString();
                        break;  
                }
            }
            catch (Exception)
            {
                result = "Error whilst calculating";
                throw;
            }
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double NumberToPrecent(double operand)
        {
            return Convert.ToDouble(SecondOperand) / 100;
        }

        private void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch (Exception)
            {
                result = "Invalid number: " + operand;
                throw;
            }
        }

        private void ValidateOperation(string operation)
        {
            switch (operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case "tan":
                case "cos":
                case "sin":
                case "sqrt":
                case "sqr":
                case "%":

                    break;
                default:
                    result = "Unknown operation: " + operation;
                    throw new ArgumentException("Unknown Operation: " + operation, "operation");
            }
        }

        private void ValidateData()
        {
            switch (Operation)
            {
                case "/":
                case "*":
                case "-":
                case "+":
                case "%":
                    ValidateOperand(FirstOperand);
                    ValidateOperand(SecondOperand);
                    break;
                case "tan":
                case "cos":
                case "sin":
                case "sqrt":
                case "sqr":
                    ValidateOperand(FirstOperand);
                    break;
                default:
                    result = "Unknown operation: " + Operation;
                    throw new ArgumentException("Unknown Operation: " + Operation, "operation");
            }
        }

        #endregion

    }
}
