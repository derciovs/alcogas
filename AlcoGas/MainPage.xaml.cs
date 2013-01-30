using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace AlcoGas
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const string dot = ".";
        private const string comma = ",";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            setControls();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double valorAlcool = maskNumericInput(textBoxAlcool);
            double valorGas = maskNumericInput(textBoxGasolina);
            double result = valorAlcool / valorGas;
            if (result > 0.7)
            {
                //gasolina
                textBlockResult.Text = "Gasolina";
            }
            else
            {
                //alcool
                textBlockResult.Text = "Álcool";
            }

        }

        private void setInputScope(TextBox textBoxControl)
        {
            InputScopeNameValue digitsInputNameValue = InputScopeNameValue.TelephoneNumber;
            textBoxControl.InputScope = new InputScope()
            {
                Names = 
                { 
                    new InputScopeName() 
                    { 
                        NameValue = digitsInputNameValue 
                    } 
                }
            };
        }

        private void setControls()
        {
            setInputScope(textBoxAlcool);
            setInputScope(textBoxGasolina);
        }

        private double maskNumericInput(TextBox textBoxControl)
        {
            string[] invalidCharacters = { "*", "#", "(", ")", "x","-","+"," ","@"};
            string content = textBoxControl.Text;

            for (int i = 0; i < invalidCharacters.Length;  i++)
            {
                content = content.Replace(invalidCharacters[i], "");
            }
            content.Replace(comma,dot);

            return Double.Parse(content);
        }

        private void textBoxAlcool_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxAlcool.Text = "";
        }

        private void textBoxGasolina_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxGasolina.Text = "";
        }
    }
}